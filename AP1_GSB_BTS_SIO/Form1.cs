using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace AP1_GSB_BTS_SIO
{
    public partial class Form1 : Form
    {
        string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        public Form1()
        {
            InitializeComponent();
        }
        private void ConnectToDatabase()
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (IsLoginValid(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool IsLoginValid(string username, string password)
        {
            bool isValid = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM Utilisateur WHERE nom=@username AND motdepasse=@password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return isValid;
        }
    }

}
