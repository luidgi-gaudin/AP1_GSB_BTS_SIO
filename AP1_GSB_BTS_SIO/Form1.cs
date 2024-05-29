using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace AP1_GSB_BTS_SIO
{
    public partial class Form1 : Form
    {
        string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_utilisateur, id_role FROM utilisateur WHERE email=@Email AND motdepasse=@Password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("id_utilisateur");
                        int roleId = reader.GetInt32("id_role");

                        if (roleId == 1) // Administrateur
                        {
                            AdminForm adminForm = new AdminForm();
                            this.Hide();
                            adminForm.ShowDialog();
                            this.Close();
                        }
                        else if (roleId == 2) // Visiteur
                        {
                            VisitorForm visitorForm = new VisitorForm(userId); // Passer userId comme visitorId
                            this.Hide();
                            visitorForm.ShowDialog();
                            this.Close();
                        }
                        else if (roleId == 3) // Comptable
                        {
                            AccountantForm accountantForm = new AccountantForm();
                            this.Hide();
                            accountantForm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Rôle utilisateur inconnu.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email ou mot de passe incorrect.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur: " + ex.Message);
                }
            }
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
