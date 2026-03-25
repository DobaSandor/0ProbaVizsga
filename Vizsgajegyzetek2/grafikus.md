# Grafikus alkalmazás – C# WinForms + MySQL

---

## 1. Adatbázis kapcsolat (`MySqlConnection`)

```csharp
using MySql.Data.MySqlClient;
using System.Data;

string connString = "server=localhost;user=root;database=szuperhosok;password=;";
```

---

## 2. Adatok betöltése `DataGridView`-ba

```csharp
private void LoadHeroes()
{
    using (var conn = new MySqlConnection(connString))
    {
        conn.Open();
        string query = "SELECT * FROM szuperhosok;";
        var adapter = new MySqlDataAdapter(query, conn);
        var table = new DataTable();
        adapter.Fill(table);
        dataGridView1.DataSource = table;
    }
}
```

---

## 3. Új rekord felvétele (`INSERT`)

```csharp
private void btnAdd_Click(object sender, EventArgs e)
{
    using (var conn = new MySqlConnection(connString))
    {
        conn.Open();
        string query = "INSERT INTO szuperhosok (szuperhos_nev, valodi_nev) VALUES (@nev, @vnev);";
        var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@nev", textBoxNev.Text);
        cmd.Parameters.AddWithValue("@vnev", textBoxValodiNev.Text);
        cmd.ExecuteNonQuery();
    }
    LoadHeroes();
}
```

---

## 4. Törlés (`DELETE`)

```csharp
if (dataGridView1.SelectedRows.Count > 0)
{
    string nev = dataGridView1.SelectedRows[0].Cells["Szuperhősnév"].Value.ToString();
    // ... DELETE FROM szuperhosok WHERE szuperhos_nev = @nev;
}
```

---

## 5. Módosítás (`UPDATE`) cellaszerkesztés után

```csharp
dataGridView1.CellEndEdit += (s, e) => {
    // UPDATE szuperhosok SET ... WHERE id = ...
};
```

---

## 6. Komponensek és események

| Komponens | Használat |
|---|---|
| `DataGridView` | `DataSource` beállítása a DataTable-el |
| `ComboBox` | `DataSource`, `DisplayMember`, `ValueMember` |
| `Button` | Dupla kattintás -> Click eseménykezelő |
| `Form` | Properties -> Events -> **Load** esemény |

---

## 7. MySQL CRUD gyorslista

```csharp
// SELECT (DataGridView-hoz)
var adapter = new MySqlDataAdapter(query, conn);
var table = new DataTable();
adapter.Fill(table);
dataGridView1.DataSource = table;

// INSERT / UPDATE / DELETE
var cmd = new MySqlCommand(query, conn);
cmd.Parameters.AddWithValue("@param", ertek);
cmd.ExecuteNonQuery();
```

---

## 8. Teljes projekt felállítás (Checklist)

1. Visual Studio -> New Project -> **Windows Forms App**
2. Project -> **Manage NuGet Packages** -> `MySql.Data` telepítése
3. Add -> Class -> `Role.cs` (vagy segédosztály a ComboBox-hoz)
4. Designer: DataGridView, ComboBox, Gombok elhelyezése
5. DataGridView -> **SelectionMode: FullRowSelect**
6. Form Load + Gomb Click események bekötése
7. `connString` beállítása (adatbázis neve!)
8. CRUD metódusok megírása
