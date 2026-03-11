# Grafikus – C# WinForms + MySQL

---

## 1. Projekt létrehozása

Visual Studio → **Windows Forms App**   
Projekt neve: `heroes` (vagy amit a feladat kér)

---

## 2. MySQL csomag telepítése

> Project → **Manage NuGet Packages** → Browse → `MySql.Data` → Install

---

## 3. Segédosztály a ComboBox-hoz – `Role.cs`

> Jobb klikk projektre → **Add → Class** → `Role.cs`

```csharp
namespace Hosok
{
    internal class Role
    {
        public int id { get; set; }
        public string nev { get; set; }
    }
}
```

> Minden ComboBox-ba töltendő táblához ilyen egyszerű osztályt kell csinálni

---

## 4. `Form1.cs` – teljes sablon

```csharp
using MySql.Data.MySqlClient;
using System.Data;

namespace Hosok
{
    public partial class Form1 : Form
    {
        // database nevét megváltoztatni a feladatéra
        string connString = "server=localhost;user=root;database=heroes;password=;";

        public Form1()
        {
            InitializeComponent();
        }

        // Induláskor fut le
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHeroes();   // DataGridView feltöltése
            LoadRoles();    // ComboBox feltöltése
        }
    }
}
```

---

## 5. DataGridView feltöltése (JOIN-al)

```csharp
private void LoadHeroes()
{
    using (var conn = new MySqlConnection(connString))
    {
        // DataGridView feltöltése
        conn.Open();
        string query = @"SELECT h.id, h.nev, h.szarmazas, h.szint, k.nev AS kaszt
                         FROM hos h
                         JOIN kaszt k ON h.kasztId = k.id";

        var adapter = new MySqlDataAdapter(query, conn);
        var table = new DataTable();
        adapter.Fill(table);

        dataGridView1.DataSource = table;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }
}
```

> Egyszerű (JOIN nélkül, csak egy tábla):
> ```csharp
> string query = "SELECT * FROM hos";
> ```

---

## 6. ComboBox feltöltése

```csharp
private void LoadRoles()
{
    List<Role> roles = new List<Role>();
    try
    {
        using (var conn = new MySqlConnection(connString))
        {
            // ComboBox feltöltése
            conn.Open();
            var cmd = new MySqlCommand("SELECT id, nev FROM kaszt", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(new Role
                {
                    id  = reader.GetInt32("id"),
                    nev = reader.GetString("nev")
                });
            }

            comboBoxKasztok.DataSource     = roles;
            comboBoxKasztok.DisplayMember  = "nev";   // ez látszik a listában
            comboBoxKasztok.ValueMember    = "id";    // ez az érték (SelectedValue)
        }
    }
    catch (Exception)
    {
        MessageBox.Show("Hiba a kasztok betöltésekor!");
    }
}
```

---

## 7. Hozzáadás gomb (INSERT + validáció)

```csharp
private void buttonAdd_Click(object sender, EventArgs e)
{
    try
    {
        // szinte mindent meg kell változtatni feladat függően
        int szint = int.Parse(textBoxSzint.Text);   // ha nem szám → exception

        // Szint validáció
        if (szint < 1 || szint > 100)
        {
            MessageBox.Show("A szint értékének 1 és 100 között kell lennie!");
            return;
        }

        using (var conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "INSERT INTO hos (nev, szarmazas, szint, kasztId) " +
                           "VALUES (@nev, @szarmazas, @szint, @kasztId)";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nev",       textBoxNev.Text);
            cmd.Parameters.AddWithValue("@szarmazas", textBoxSzarmazas.Text);
            cmd.Parameters.AddWithValue("@szint",     szint);
            cmd.Parameters.AddWithValue("@kasztId",   comboBoxKasztok.SelectedValue);
            cmd.ExecuteNonQuery();
        }

        LoadHeroes();   // frissítés
    }
    catch (FormatException)
    {
        MessageBox.Show("A szint értékének 1 és 100 között kell lennie!");
    }
    catch (Exception)
    {
        MessageBox.Show("Hiba a hős hozzáadásakor!");
    }
}
```

---

## 8. Törlés gomb (DELETE)

```csharp
private void buttonDelete_Click(object sender, EventArgs e)
{
    if (dataGridView1.SelectedRows.Count > 0)
    {
        // Az "id" oszlopból olvassuk ki a kiválasztott sor id-ját
        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

        try
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM hos WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadHeroes();   // frissítés
        }
        catch (Exception)
        {
            MessageBox.Show("Hiba a hős törlésekor!");
        }
    }
}
```

> A DataGridView-ban a `SelectionMode` legyen **FullRowSelect** (Properties-ben)!

---

## 9. Form designer – komponensek összekötése

| Komponens | Name | Csatlakoztatás |
|---|---|---|
| `DataGridView` | `dataGridView1` | `LoadHeroes()` tölti fel |
| `ComboBox` | `comboBoxKasztok` | `LoadRoles()` tölti fel |
| `TextBox` (név) | `textBoxNev` | INSERT-nél `textBoxNev.Text` |
| `TextBox` (szárm.) | `textBoxSzarmazas` | INSERT-nél `textBoxSzarmazas.Text` |
| `TextBox` (szint) | `textBoxSzint` | INSERT-nél `int.Parse(textBoxSzint.Text)` |
| `Button` (add) | `buttonAdd` | dupla klikk → `buttonAdd_Click` |
| `Button` (delete) | `buttonDelete` | dupla klikk → `buttonDelete_Click` |
| `Form` | `Form1` | Properties → Events → `Load` → `Form1_Load` |

---

## 10. SQL – adatbázis létrehozása

```sql
CREATE DATABASE heroes CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE heroes;

CREATE TABLE kaszt (
    id  INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(255)
);

CREATE TABLE hos (
    id       INT AUTO_INCREMENT PRIMARY KEY,
    nev      VARCHAR(255),
    szarmazas VARCHAR(255),
    szint    INT,
    kasztId  INT,
    FOREIGN KEY (kasztId) REFERENCES kaszt(id)
);
```

---

## 11. MySQL CRUD – gyorslista

```csharp
// SELECT (olvasás) – DataAdapter + DataTable
var adapter = new MySqlDataAdapter("SELECT * FROM tabla", conn);
var table = new DataTable();
adapter.Fill(table);
dataGridView1.DataSource = table;

// SELECT (olvasás) – ExecuteReader (ComboBox-hoz)
var cmd = new MySqlCommand("SELECT id, nev FROM tabla", conn);
var reader = cmd.ExecuteReader();
while (reader.Read()) { /* reader.GetInt32("id"), reader.GetString("nev") */ }

// INSERT
string q = "INSERT INTO tabla (mezo1, mezo2) VALUES (@mezo1, @mezo2)";
var cmd = new MySqlCommand(q, conn);
cmd.Parameters.AddWithValue("@mezo1", ertek1);
cmd.Parameters.AddWithValue("@mezo2", ertek2);
cmd.ExecuteNonQuery();

// DELETE
string q = "DELETE FROM tabla WHERE id = @id";
var cmd = new MySqlCommand(q, conn);
cmd.Parameters.AddWithValue("@id", id);
cmd.ExecuteNonQuery();

// UPDATE
string q = "UPDATE tabla SET mezo1 = @mezo1 WHERE id = @id";
var cmd = new MySqlCommand(q, conn);
cmd.Parameters.AddWithValue("@mezo1", ujErtek);
cmd.Parameters.AddWithValue("@id", id);
cmd.ExecuteNonQuery();
```

---

## 12. Teljes projekt felállítás

```
1.  Visual Studio → New Project → Windows Forms App
2.  Projekt neve: pl. heroes / amit a feladat kér
3.  Project → Manage NuGet Packages → MySql.Data telepítése
4.  Add → Class → Role.cs (id, nev property-k)
5.  Form1 designer-ben: DataGridView, ComboBox, TextBox-ok, Button-ok elhelyezése
6.  DataGridView → SelectionMode: FullRowSelect (Properties)
7.  Form Load esemény bekötése (Form1_Load)
8.  Gombok dupla klikk → Click esemény
9.  Form1.cs → connString beállítása (database neve!)
10. LoadHeroes() + LoadRoles() megírása
11. buttonAdd_Click() + buttonDelete_Click() megírása
12. Ctrl+F5 → futtatás
```