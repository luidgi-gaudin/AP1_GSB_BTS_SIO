using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            listBoxUsers.Items.Clear();
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
                        string userInfo = $"{reader["id_utilisateur"]}, {reader["nom"]} {reader["prenom"]}, {reader["email"]}, {reader["role"]}";
                        listBoxUsers.Items.Add(userInfo);
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
            listBoxTypes.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id_typeFrais, TypeFrai, montant FROM TypeFrais", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string typeInfo = $"{reader["id_typeFrais"]}, {reader["TypeFrai"]}, {reader["montant"]}";
                        listBoxTypes.Items.Add(typeInfo);
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
            if (listBoxUsers.SelectedItem != null)
            {
                string selectedUser = listBoxUsers.SelectedItem.ToString();
                string[] userDetails = selectedUser.Split(',');

                if (userDetails.Length >= 4) // Vérifiez que tous les éléments nécessaires sont présents
                {
                    string[] nameParts = userDetails[1].Trim().Split(' ');
                    if (nameParts.Length >= 2)
                    {
                        string nom = nameParts[0];
                        string prenom = nameParts[1];
                        string email = userDetails[2].Trim();
                        string role = userDetails[3].Trim();

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
                                    cmd.Parameters.AddWithValue("@id_utilisateur", int.Parse(userDetails[0].Trim()));
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
                        MessageBox.Show("Erreur lors de la récupération des détails de l'utilisateur.");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la récupération des détails de l'utilisateur.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à modifier.");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string selectedUser = listBoxUsers.SelectedItem.ToString();
                    string[] userDetails = selectedUser.Split(',');

                    if (userDetails.Length > 0)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();
                                string query = "DELETE FROM Utilisateur WHERE id_utilisateur=@id_utilisateur";
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@id_utilisateur", int.Parse(userDetails[0]));
                                cmd.ExecuteNonQuery();
                                LoadUsers();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la récupération des détails de l'utilisateur.");
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
            if (listBoxTypes.SelectedItem != null)
            {
                string selectedType = listBoxTypes.SelectedItem.ToString();
                string[] typeDetails = selectedType.Split(',');

                if (typeDetails.Length >= 3) // Vérifiez que tous les éléments nécessaires sont présents
                {
                    TypeDialog typeDialog = new TypeDialog();
                    if (decimal.TryParse(typeDetails[2].Trim(), out decimal amount))
                    {
                        typeDialog.LoadType(typeDetails[1].Trim(), amount);

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
                                    cmd.Parameters.AddWithValue("@id_typeFrais", int.Parse(typeDetails[0]));
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
                    MessageBox.Show("Erreur lors de la récupération des détails du type de frais.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de frais à modifier.");
            }
        }

        private void listBoxUsers_DoubleClick(object sender, EventArgs e)
        {
            btnEditUser_Click(sender, e);
        }

        private void listBoxTypes_DoubleClick(object sender, EventArgs e)
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
