using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class JustificatifDialog : Form
    {
        public string FilePath { get; set; }

        public JustificatifDialog()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
                FilePath = openFileDialog.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un fichier.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void JustificatifDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
