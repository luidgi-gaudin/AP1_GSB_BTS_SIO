namespace AP1_GSB_BTS_SIO
{
    partial class DetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewForfait;
        private System.Windows.Forms.ListView listViewHorsForfait;
        private System.Windows.Forms.ColumnHeader columnHeaderTypeFrais;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantite;
        private System.Windows.Forms.ColumnHeader columnHeaderMontant;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ColumnHeader columnHeaderMontantHors;
        private System.Windows.Forms.ColumnHeader columnHeaderDateHors;
        private System.Windows.Forms.Button btnExportPDF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewForfait = new System.Windows.Forms.ListView();
            this.columnHeaderTypeFrais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMontant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewHorsForfait = new System.Windows.Forms.ListView();
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMontantHors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDateHors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewForfait
            // 
            this.listViewForfait.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTypeFrais,
            this.columnHeaderQuantite,
            this.columnHeaderMontant,
            this.columnHeaderDate});
            this.listViewForfait.FullRowSelect = true;
            this.listViewForfait.GridLines = true;
            this.listViewForfait.HideSelection = false;
            this.listViewForfait.Location = new System.Drawing.Point(12, 12);
            this.listViewForfait.MultiSelect = false;
            this.listViewForfait.Name = "listViewForfait";
            this.listViewForfait.Size = new System.Drawing.Size(360, 150);
            this.listViewForfait.TabIndex = 0;
            this.listViewForfait.UseCompatibleStateImageBehavior = false;
            this.listViewForfait.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTypeFrais
            // 
            this.columnHeaderTypeFrais.Text = "Type de frais";
            this.columnHeaderTypeFrais.Width = 90;
            // 
            // columnHeaderQuantite
            // 
            this.columnHeaderQuantite.Text = "Quantité";
            this.columnHeaderQuantite.Width = 70;
            // 
            // columnHeaderMontant
            // 
            this.columnHeaderMontant.Text = "Montant";
            this.columnHeaderMontant.Width = 90;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 110;
            // 
            // listViewHorsForfait
            // 
            this.listViewHorsForfait.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDescription,
            this.columnHeaderMontantHors,
            this.columnHeaderDateHors});
            this.listViewHorsForfait.FullRowSelect = true;
            this.listViewHorsForfait.GridLines = true;
            this.listViewHorsForfait.HideSelection = false;
            this.listViewHorsForfait.Location = new System.Drawing.Point(12, 168);
            this.listViewHorsForfait.MultiSelect = false;
            this.listViewHorsForfait.Name = "listViewHorsForfait";
            this.listViewHorsForfait.Size = new System.Drawing.Size(360, 150);
            this.listViewHorsForfait.TabIndex = 1;
            this.listViewHorsForfait.UseCompatibleStateImageBehavior = false;
            this.listViewHorsForfait.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 160;
            // 
            // columnHeaderMontantHors
            // 
            this.columnHeaderMontantHors.Text = "Montant";
            this.columnHeaderMontantHors.Width = 90;
            // 
            // columnHeaderDateHors
            // 
            this.columnHeaderDateHors.Text = "Date";
            this.columnHeaderDateHors.Width = 110;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(12, 324);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(360, 23);
            this.btnExportPDF.TabIndex = 2;
            this.btnExportPDF.Text = "Exporter en PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // DetailForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.listViewHorsForfait);
            this.Controls.Add(this.listViewForfait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Détails des frais";
            this.Load += new System.EventHandler(this.DetailForm_Load);
            this.ResumeLayout(false);

        }
    }
}
