using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class HorsForfaitDialog : Form
    {
        public string Description { get; set; }
        public decimal Montant { get; set; }

        public HorsForfaitDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Description = txtDescription.Text;
            if (decimal.TryParse(txtMontant.Text, out decimal montant))
            {
                Montant = montant;
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
    }
}
