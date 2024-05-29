using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class UserDialog : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRole { get; set; }

        public UserDialog()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id_role, role FROM Role", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbRole.Items.Add(new ComboBoxItem(reader["role"].ToString(), int.Parse(reader["id_role"].ToString())));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserName = txtName.Text;
            UserSurname = txtSurname.Text;
            UserEmail = txtEmail.Text;
            UserPassword = txtPassword.Text;

            if (cmbRole.SelectedItem is ComboBoxItem selectedItem)
            {
                UserRole = selectedItem.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un rôle.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void LoadUser(string name, string surname, string email, string roleName)
        {
            txtName.Text = name;
            txtSurname.Text = surname;
            txtEmail.Text = email;
            foreach (ComboBoxItem item in cmbRole.Items)
            {
                if (item.Text == roleName)
                {
                    cmbRole.SelectedItem = item;
                    break;
                }
            }
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; }
        public int Value { get; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
