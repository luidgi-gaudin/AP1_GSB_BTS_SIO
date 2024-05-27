namespace AP1_GSB_BTS_SIO
{
    partial class VisitorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddForfait;
        private System.Windows.Forms.Button btnAddHorsForfait;
        private System.Windows.Forms.Button btnViewCurrent;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnAddJustificatif;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.ListBox listBoxFrais;
        private System.Windows.Forms.DateTimePicker dateTimePicker;

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
            this.btnAddForfait = new System.Windows.Forms.Button();
            this.btnAddHorsForfait = new System.Windows.Forms.Button();
            this.btnViewCurrent = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnAddJustificatif = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.listBoxFrais = new System.Windows.Forms.ListBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnAddForfait
            // 
            this.btnAddForfait.Location = new System.Drawing.Point(12, 12);
            this.btnAddForfait.Name = "btnAddForfait";
            this.btnAddForfait.Size = new System.Drawing.Size(100, 23);
            this.btnAddForfait.TabIndex = 0;
            this.btnAddForfait.Text = "Ajouter Forfait";
            this.btnAddForfait.UseVisualStyleBackColor = true;
            this.btnAddForfait.Click += new System.EventHandler(this.btnAddForfait_Click);
            // 
            // btnAddHorsForfait
            // 
            this.btnAddHorsForfait.Location = new System.Drawing.Point(118, 12);
            this.btnAddHorsForfait.Name = "btnAddHorsForfait";
            this.btnAddHorsForfait.Size = new System.Drawing.Size(100, 23);
            this.btnAddHorsForfait.TabIndex = 1;
            this.btnAddHorsForfait.Text = "Ajouter Hors Forfait";
            this.btnAddHorsForfait.UseVisualStyleBackColor = true;
            this.btnAddHorsForfait.Click += new System.EventHandler(this.btnAddHorsForfait_Click);
            // 
            // btnViewCurrent
            // 
            this.btnViewCurrent.Location = new System.Drawing.Point(224, 12);
            this.btnViewCurrent.Name = "btnViewCurrent";
            this.btnViewCurrent.Size = new System.Drawing.Size(100, 23);
            this.btnViewCurrent.TabIndex = 2;
            this.btnViewCurrent.Text = "Fiche en cours";
            this.btnViewCurrent.UseVisualStyleBackColor = true;
            this.btnViewCurrent.Click += new System.EventHandler(this.btnViewCurrent_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(330, 12);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(100, 23);
            this.btnViewHistory.TabIndex = 3;
            this.btnViewHistory.Text = "Historique";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnAddJustificatif
            // 
            this.btnAddJustificatif.Location = new System.Drawing.Point(436, 12);
            this.btnAddJustificatif.Name = "btnAddJustificatif";
            this.btnAddJustificatif.Size = new System.Drawing.Size(100, 23);
            this.btnAddJustificatif.TabIndex = 4;
            this.btnAddJustificatif.Text = "Ajouter Justificatif";
            this.btnAddJustificatif.UseVisualStyleBackColor = true;
            this.btnAddJustificatif.Click += new System.EventHandler(this.btnAddJustificatif_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(542, 12);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(100, 23);
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.Text = "Exporter en PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // listBoxFrais
            // 
            this.listBoxFrais.FormattingEnabled = true;
            this.listBoxFrais.Location = new System.Drawing.Point(12, 41);
            this.listBoxFrais.Name = "listBoxFrais";
            this.listBoxFrais.Size = new System.Drawing.Size(630, 329);
            this.listBoxFrais.TabIndex = 6;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 376);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // VisitorForm
            // 
            this.ClientSize = new System.Drawing.Size(654, 411);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.listBoxFrais);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnAddJustificatif);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnViewCurrent);
            this.Controls.Add(this.btnAddHorsForfait);
            this.Controls.Add(this.btnAddForfait);
            this.Name = "VisitorForm";
            this.Text = "VisitorForm";
            this.Load += new System.EventHandler(this.VisitorForm_Load);
            this.ResumeLayout(false);

        }
    }
}
