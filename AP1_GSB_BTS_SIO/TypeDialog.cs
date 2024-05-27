using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class TypeDialog : Form
    {
        public string TypeName { get; set; }
        public decimal TypeAmount { get; set; }

        public TypeDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TypeName = txtTypeName.Text;
            if (decimal.TryParse(txtTypeAmount.Text, out decimal amount))
            {
                TypeAmount = amount;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un montant valide.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void LoadType(string name, decimal amount)
        {
            txtTypeName.Text = name;
            txtTypeAmount.Text = amount.ToString();
        }
    }
}
