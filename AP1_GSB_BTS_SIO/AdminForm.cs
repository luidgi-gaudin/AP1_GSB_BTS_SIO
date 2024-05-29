using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class AdminForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTypes();
        }

        private void LoadUsers()
        {
            listViewUsers.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT u.id_utilisateur, u.nom, u.prenom, u.email, r.role
                        FROM Utilisateur u
                        JOIN Role r ON u.id_role = r.id_role";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["id_utilisateur"].ToString());
                        item.SubItems.Add(reader["nom"].ToString());
                        item.SubItems.Add(reader["prenom"].ToString());
                        item.SubItems.Add(reader["email"].ToString());
                        item.SubItems.Add(reader["role"].ToString());
                        listViewUsers.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadTypes()
        {
            listViewTypes.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id_typeFrais, TypeFrai, montant FROM TypeFrais", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["id_typeFrais"].ToString());
                        item.SubItems.Add(reader["TypeFrai"].ToString());
                        item.SubItems.Add(reader["montant"].ToString());
                        listViewTypes.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserDialog userDialog = new UserDialog();
            if (userDialog.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Utilisateur (nom, prenom, email, motdepasse, id_role) VALUES (@nom, @prenom, @email, @motdepasse, @id_role)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nom", userDialog.UserName);
                        cmd.Parameters.AddWithValue("@prenom", userDialog.UserSurname);
                        cmd.Parameters.AddWithValue("@email", userDialog.UserEmail);
                        cmd.Parameters.AddWithValue("@motdepasse", userDialog.UserPassword);
                        cmd.Parameters.AddWithValue("@id_role", userDialog.UserRole);
                        cmd.ExecuteNonQuery();
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewUsers.SelectedItems[0];
                string id = selectedItem.SubItems[0].Text;
                string nom = selectedItem.SubItems[1].Text;
                string prenom = selectedItem.SubItems[2].Text;
                string email = selectedItem.SubItems[3].Text;
                string role = selectedItem.SubItems[4].Text;

                UserDialog userDialog = new UserDialog();
                userDialog.LoadUser(nom, prenom, email, role);

                if (userDialog.ShowDialog() == DialogResult.OK)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "UPDATE Utilisateur SET nom=@nom, prenom=@prenom, email=@email, id_role=@id_role";
                            if (!string.IsNullOrEmpty(userDialog.UserPassword))
                            {
                                query += ", motdepasse=@motdepasse";
                            }
                            query += " WHERE id_utilisateur=@id_utilisateur";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@nom", userDialog.UserName);
                            cmd.Parameters.AddWithValue("@prenom", userDialog.UserSurname);
                            cmd.Parameters.AddWithValue("@email", userDialog.UserEmail);
                            cmd.Parameters.AddWithValue("@id_role", userDialog.UserRole);
                            if (!string.IsNullOrEmpty(userDialog.UserPassword))
                            {
                                cmd.Parameters.AddWithValue("@motdepasse", userDialog.UserPassword);
                            }
                            cmd.Parameters.AddWithValue("@id_utilisateur", int.Parse(id));
                            cmd.ExecuteNonQuery();
                            LoadUsers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à modifier.");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ListViewItem selectedItem = listViewUsers.SelectedItems[0];
                    string id = selectedItem.SubItems[0].Text;

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM Utilisateur WHERE id_utilisateur=@id_utilisateur";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id_utilisateur", int.Parse(id));
                            cmd.ExecuteNonQuery();
                            LoadUsers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.");
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            TypeDialog typeDialog = new TypeDialog();
            if (typeDialog.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO TypeFrais (TypeFrai, montant) VALUES (@TypeFrai, @montant)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TypeFrai", typeDialog.TypeName);
                        cmd.Parameters.AddWithValue("@montant", typeDialog.TypeAmount);
                        cmd.ExecuteNonQuery();
                        LoadTypes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnEditType_Click(object sender, EventArgs e)
        {
            if (listViewTypes.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewTypes.SelectedItems[0];
                string id = selectedItem.SubItems[0].Text;
                string type = selectedItem.SubItems[1].Text;
                string montant = selectedItem.SubItems[2].Text;

                if (decimal.TryParse(montant, out decimal amount))
                {
                    TypeDialog typeDialog = new TypeDialog();
                    typeDialog.LoadType(type, amount);

                    if (typeDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();
                                string query = "UPDATE TypeFrais SET TypeFrai=@TypeFrai, montant=@montant WHERE id_typeFrais=@id_typeFrais";
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@TypeFrai", typeDialog.TypeName);
                                cmd.Parameters.AddWithValue("@montant", typeDialog.TypeAmount);
                                cmd.Parameters.AddWithValue("@id_typeFrais", int.Parse(id));
                                cmd.ExecuteNonQuery();
                                LoadTypes();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la conversion du montant.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de frais à modifier.");
            }
        }

        private void listViewUsers_DoubleClick(object sender, EventArgs e)
        {
            btnEditUser_Click(sender, e);
        }

        private void listViewTypes_DoubleClick(object sender, EventArgs e)
        {
            btnEditType_Click(sender, e);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
