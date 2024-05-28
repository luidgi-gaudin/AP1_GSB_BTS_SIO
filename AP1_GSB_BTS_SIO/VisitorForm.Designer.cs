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
        private System.Windows.Forms.ListView listViewForfait;
        private System.Windows.Forms.ListView listViewHorsForfait;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitleForfait;
        private System.Windows.Forms.Label lblTitleHorsForfait;
        private System.Windows.Forms.GroupBox groupBoxForfait;
        private System.Windows.Forms.GroupBox groupBoxHorsForfait;

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
            this.listViewForfait = new System.Windows.Forms.ListView();
            this.listViewHorsForfait = new System.Windows.Forms.ListView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblTitleForfait = new System.Windows.Forms.Label();
            this.lblTitleHorsForfait = new System.Windows.Forms.Label();
            this.groupBoxForfait = new System.Windows.Forms.GroupBox();
            this.groupBoxHorsForfait = new System.Windows.Forms.GroupBox();
            this.groupBoxForfait.SuspendLayout();
            this.groupBoxHorsForfait.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddForfait
            // 
            this.btnAddForfait.Location = new System.Drawing.Point(486, 19);
            this.btnAddForfait.Name = "btnAddForfait";
            this.btnAddForfait.Size = new System.Drawing.Size(120, 23);
            this.btnAddForfait.TabIndex = 0;
            this.btnAddForfait.Text = "Ajouter un frais forfait";
            this.btnAddForfait.UseVisualStyleBackColor = true;
            this.btnAddForfait.Click += new System.EventHandler(this.btnAddForfait_Click);
            // 
            // btnAddHorsForfait
            // 
            this.btnAddHorsForfait.Location = new System.Drawing.Point(486, 19);
            this.btnAddHorsForfait.Name = "btnAddHorsForfait";
            this.btnAddHorsForfait.Size = new System.Drawing.Size(120, 23);
            this.btnAddHorsForfait.TabIndex = 1;
            this.btnAddHorsForfait.Text = "Ajouter un hors forfait";
            this.btnAddHorsForfait.UseVisualStyleBackColor = true;
            this.btnAddHorsForfait.Click += new System.EventHandler(this.btnAddHorsForfait_Click);
            // 
            // btnViewCurrent
            // 
            this.btnViewCurrent.Location = new System.Drawing.Point(12, 12);
            this.btnViewCurrent.Name = "btnViewCurrent";
            this.btnViewCurrent.Size = new System.Drawing.Size(100, 23);
            this.btnViewCurrent.TabIndex = 2;
            this.btnViewCurrent.Text = "Fiche en cours";
            this.btnViewCurrent.UseVisualStyleBackColor = true;
            this.btnViewCurrent.Click += new System.EventHandler(this.btnViewCurrent_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(118, 12);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(100, 23);
            this.btnViewHistory.TabIndex = 3;
            this.btnViewHistory.Text = "Historique";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnAddJustificatif
            // 
            this.btnAddJustificatif.Location = new System.Drawing.Point(224, 12);
            this.btnAddJustificatif.Name = "btnAddJustificatif";
            this.btnAddJustificatif.Size = new System.Drawing.Size(100, 23);
            this.btnAddJustificatif.TabIndex = 4;
            this.btnAddJustificatif.Text = "Ajouter Justificatif";
            this.btnAddJustificatif.UseVisualStyleBackColor = true;
            this.btnAddJustificatif.Click += new System.EventHandler(this.btnAddJustificatif_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(330, 12);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(100, 23);
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.Text = "Exporter en PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // listViewForfait
            // 
            this.listViewForfait.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        new System.Windows.Forms.ColumnHeader() { Text = "Type Frais", Width = 150 },
        new System.Windows.Forms.ColumnHeader() { Text = "Etat", Width = 100 },
        new System.Windows.Forms.ColumnHeader() { Text = "Montant Total", Width = 100 },
    });
            this.listViewForfait.HideSelection = false;
            this.listViewForfait.Location = new System.Drawing.Point(6, 48);
            this.listViewForfait.Name = "listViewForfait";
            this.listViewForfait.Size = new System.Drawing.Size(600, 150);
            this.listViewForfait.TabIndex = 6;
            this.listViewForfait.UseCompatibleStateImageBehavior = false;
            this.listViewForfait.View = System.Windows.Forms.View.Details;
            this.listViewForfait.SelectedIndexChanged += new System.EventHandler(this.listViewForfait_SelectedIndexChanged);

            // 
            // listViewHorsForfait
            // 
            this.listViewHorsForfait.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        new System.Windows.Forms.ColumnHeader() { Text = "Description", Width = 150 },
        new System.Windows.Forms.ColumnHeader() { Text = "Etat", Width = 100 },
        new System.Windows.Forms.ColumnHeader() { Text = "Montant", Width = 100 },
    });
            this.listViewHorsForfait.HideSelection = false;
            this.listViewHorsForfait.Location = new System.Drawing.Point(6, 48);
            this.listViewHorsForfait.Name = "listViewHorsForfait";
            this.listViewHorsForfait.Size = new System.Drawing.Size(600, 150);
            this.listViewHorsForfait.TabIndex = 7;
            this.listViewHorsForfait.UseCompatibleStateImageBehavior = false;
            this.listViewHorsForfait.View = System.Windows.Forms.View.Details;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 415);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblTitleForfait
            // 
            this.lblTitleForfait.AutoSize = true;
            this.lblTitleForfait.Location = new System.Drawing.Point(6, 32);
            this.lblTitleForfait.Name = "lblTitleForfait";
            this.lblTitleForfait.Size = new System.Drawing.Size(132, 20);
            this.lblTitleForfait.TabIndex = 9;
            this.lblTitleForfait.Text = "Vos frais forfaits :";
            // 
            // lblTitleHorsForfait
            // 
            this.lblTitleHorsForfait.AutoSize = true;
            this.lblTitleHorsForfait.Location = new System.Drawing.Point(6, 32);
            this.lblTitleHorsForfait.Name = "lblTitleHorsForfait";
            this.lblTitleHorsForfait.Size = new System.Drawing.Size(167, 20);
            this.lblTitleHorsForfait.TabIndex = 10;
            this.lblTitleHorsForfait.Text = "Vos frais hors forfaits :";
            // 
            // groupBoxForfait
            // 
            this.groupBoxForfait.Controls.Add(this.btnAddForfait);
            this.groupBoxForfait.Controls.Add(this.listViewForfait);
            this.groupBoxForfait.Controls.Add(this.lblTitleForfait);
            this.groupBoxForfait.Location = new System.Drawing.Point(12, 41);
            this.groupBoxForfait.Name = "groupBoxForfait";
            this.groupBoxForfait.Size = new System.Drawing.Size(612, 204);
            this.groupBoxForfait.TabIndex = 11;
            this.groupBoxForfait.TabStop = false;
            // 
            // groupBoxHorsForfait
            // 
            this.groupBoxHorsForfait.Controls.Add(this.btnAddHorsForfait);
            this.groupBoxHorsForfait.Controls.Add(this.listViewHorsForfait);
            this.groupBoxHorsForfait.Controls.Add(this.lblTitleHorsForfait);
            this.groupBoxHorsForfait.Location = new System.Drawing.Point(12, 251);
            this.groupBoxHorsForfait.Name = "groupBoxHorsForfait";
            this.groupBoxHorsForfait.Size = new System.Drawing.Size(612, 204);
            this.groupBoxHorsForfait.TabIndex = 12;
            this.groupBoxHorsForfait.TabStop = false;
            // 
            // VisitorForm
            // 
            this.ClientSize = new System.Drawing.Size(636, 450);
            this.Controls.Add(this.groupBoxHorsForfait);
            this.Controls.Add(this.groupBoxForfait);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnAddJustificatif);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnViewCurrent);
            this.Name = "VisitorForm";
            this.Text = "VisitorForm";
            this.Load += new System.EventHandler(this.VisitorForm_Load);
            this.groupBoxForfait.ResumeLayout(false);
            this.groupBoxForfait.PerformLayout();
            this.groupBoxHorsForfait.ResumeLayout(false);
            this.groupBoxHorsForfait.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
