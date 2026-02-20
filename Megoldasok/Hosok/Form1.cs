using MySql.Data.MySqlClient;
using System.CodeDom.Compiler;
using System.Data;

namespace Hosok
{
    public partial class Form1 : Form
    {
        // Connection string to the database
        string connString = "server=localhost;user=root;database=heroes;password=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHeroes();
            LoadRoles();
        }

        private void LoadRoles()
        {
            /*
             - ComboBox feltöltése a kasztokkal az adatbázisból
             - A kasztok nevét jeleníti meg 
             - A kiválasztott elem értéke a kaszt id legyen 
            */

            // Store roles in a list
            List<Role> roles = new List<Role>();
            try
            {
                //conn create, conn open, command create, reader -> cmd execute
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT id, nev FROM kaszt", conn);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            id = reader.GetInt32("id"),
                            nev = reader.GetString("nev")
                        });
                    }
                    comboBoxKasztok.DataSource = roles;
                    comboBoxKasztok.DisplayMember = "nev";
                    comboBoxKasztok.ValueMember = "id";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a kasztok betöltésekor!");
            }

        }

        private void LoadHeroes()
        {
            using (var conn = new MySqlConnection(connString))
            {
                /*
                 Tábla: hos
                    id, nev, szarmazas, szint, kasztId         
                Tábla: kaszt
                    id, nev
                 */
                conn.Open();
                string query = @"SELECT h.id, h.nev, h.szarmazas, h.szint, k.nev AS kaszt
                                 FROM hos h
                                 JOIN kaszt k ON h.kasztId = k.id";
                var adapter = new MySqlDataAdapter(query, conn);

                var table = new System.Data.DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                // strecth to fill grid
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        private void comboBoxKasztok_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO hos (nev, szarmazas, szint, kasztId) VALUES (@nev, @szarmazas, @szint, @kasztId)";
                    var cmd = new MySqlCommand(query, conn);
                    int te = int.Parse(textBoxSzint.Text);
                    if (te > 1 && te < 100)
                    {
                        cmd.Parameters.AddWithValue("@nev", textBoxNev.Text);
                        cmd.Parameters.AddWithValue("@szarmazas", textBoxSzarmazas.Text);
                        cmd.Parameters.AddWithValue("@szint", te);
                        cmd.Parameters.AddWithValue("@kasztId", comboBoxKasztok.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // hiba
                        MessageBox.Show("A szintnek 1 és 100 között kell lennie!");
                    }


                }
                LoadHeroes();
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a hõs hozzáadásakor!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kiválasztott hõs törlése
            if (dataGridView1.SelectedRows.Count > 0)
            {
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
                    LoadHeroes();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hiba a hõs törlésekor!");
                }
            }
        }
    }
}
