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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitorForm));
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxForfait.SuspendLayout();
            this.groupBoxHorsForfait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddForfait
            // 
            this.btnAddForfait.Location = new System.Drawing.Point(451, 14);
            this.btnAddForfait.Name = "btnAddForfait";
            this.btnAddForfait.Size = new System.Drawing.Size(155, 28);
            this.btnAddForfait.TabIndex = 0;
            this.btnAddForfait.Text = "Ajouter un frais forfait";
            this.btnAddForfait.UseVisualStyleBackColor = true;
            this.btnAddForfait.Click += new System.EventHandler(this.btnAddForfait_Click);
            // 
            // btnAddHorsForfait
            // 
            this.btnAddHorsForfait.Location = new System.Drawing.Point(420, 13);
            this.btnAddHorsForfait.Name = "btnAddHorsForfait";
            this.btnAddHorsForfait.Size = new System.Drawing.Size(186, 29);
            this.btnAddHorsForfait.TabIndex = 1;
            this.btnAddHorsForfait.Text = "Ajouter un hors forfait";
            this.btnAddHorsForfait.UseVisualStyleBackColor = true;
            this.btnAddHorsForfait.Click += new System.EventHandler(this.btnAddHorsForfait_Click);
            // 
            // btnViewCurrent
            // 
            this.btnViewCurrent.Location = new System.Drawing.Point(700, 127);
            this.btnViewCurrent.Name = "btnViewCurrent";
            this.btnViewCurrent.Size = new System.Drawing.Size(164, 81);
            this.btnViewCurrent.TabIndex = 2;
            this.btnViewCurrent.Text = "Fiche en cours";
            this.btnViewCurrent.UseVisualStyleBackColor = true;
            this.btnViewCurrent.Click += new System.EventHandler(this.btnViewCurrent_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(700, 214);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(164, 68);
            this.btnViewHistory.TabIndex = 3;
            this.btnViewHistory.Text = "Historique";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnAddJustificatif
            // 
            this.btnAddJustificatif.Location = new System.Drawing.Point(700, 288);
            this.btnAddJustificatif.Name = "btnAddJustificatif";
            this.btnAddJustificatif.Size = new System.Drawing.Size(164, 77);
            this.btnAddJustificatif.TabIndex = 4;
            this.btnAddJustificatif.Text = "Ajouter Justificatif";
            this.btnAddJustificatif.UseVisualStyleBackColor = true;
            this.btnAddJustificatif.Click += new System.EventHandler(this.btnAddJustificatif_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.IndianRed;
            this.btnExportPDF.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnExportPDF.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExportPDF.Location = new System.Drawing.Point(700, 371);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(164, 67);
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.Text = "Exporter en PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            this.listViewForfait.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        new System.Windows.Forms.ColumnHeader() { Text = "Type Frais", Width = 150 },
        new System.Windows.Forms.ColumnHeader() { Text = "Etat", Width = 100 },
        new System.Windows.Forms.ColumnHeader() { Text = "Quantitée", Width = 100 },
        new System.Windows.Forms.ColumnHeader() { Text = "Montant Total", Width = 100 },
        new System.Windows.Forms.ColumnHeader() { Text = "Date", Width = 100 },
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
        new System.Windows.Forms.ColumnHeader() { Text = "Date", Width = 100 },
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
            this.lblTitleForfait.Location = new System.Drawing.Point(6, 22);
            this.lblTitleForfait.Name = "lblTitleForfait";
            this.lblTitleForfait.Size = new System.Drawing.Size(132, 20);
            this.lblTitleForfait.TabIndex = 9;
            this.lblTitleForfait.Text = "Vos frais forfaits :";
            // 
            // lblTitleHorsForfait
            // 
            this.lblTitleHorsForfait.AutoSize = true;
            this.lblTitleHorsForfait.Location = new System.Drawing.Point(6, 22);
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
            this.groupBoxForfait.Location = new System.Drawing.Point(12, 12);
            this.groupBoxForfait.Name = "groupBoxForfait";
            this.groupBoxForfait.Size = new System.Drawing.Size(612, 222);
            this.groupBoxForfait.TabIndex = 11;
            this.groupBoxForfait.TabStop = false;
            // 
            // groupBoxHorsForfait
            // 
            this.groupBoxHorsForfait.Controls.Add(this.btnAddHorsForfait);
            this.groupBoxHorsForfait.Controls.Add(this.listViewHorsForfait);
            this.groupBoxHorsForfait.Controls.Add(this.lblTitleHorsForfait);
            this.groupBoxHorsForfait.Location = new System.Drawing.Point(12, 240);
            this.groupBoxHorsForfait.Name = "groupBoxHorsForfait";
            this.groupBoxHorsForfait.Size = new System.Drawing.Size(612, 215);
            this.groupBoxHorsForfait.TabIndex = 12;
            this.groupBoxHorsForfait.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(674, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // VisitorForm
            // 
            this.ClientSize = new System.Drawing.Size(913, 462);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxHorsForfait);
            this.Controls.Add(this.groupBoxForfait);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnAddJustificatif);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnViewCurrent);
            this.MaximizeBox = false;
            this.Name = "VisitorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISITEUR";
            this.Load += new System.EventHandler(this.VisitorForm_Load);
            this.groupBoxForfait.ResumeLayout(false);
            this.groupBoxForfait.PerformLayout();
            this.groupBoxHorsForfait.ResumeLayout(false);
            this.groupBoxHorsForfait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
