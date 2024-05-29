namespace AP1_GSB_BTS_SIO
{
    partial class VisitorForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnAddJustificatif = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.listViewForfait = new System.Windows.Forms.ListView();
            this.listViewHorsForfait = new System.Windows.Forms.ListView();
            this.lblTitleForfait = new System.Windows.Forms.Label();
            this.lblTitleHorsForfait = new System.Windows.Forms.Label();
            this.groupBoxForfait = new System.Windows.Forms.GroupBox();
            this.groupBoxHorsForfait = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogoutV = new System.Windows.Forms.Button();
            this.groupBoxForfait.SuspendLayout();
            this.groupBoxHorsForfait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddForfait
            // 
            this.btnAddForfait.Location = new System.Drawing.Point(587, 14);
            this.btnAddForfait.Name = "btnAddForfait";
            this.btnAddForfait.Size = new System.Drawing.Size(155, 28);
            this.btnAddForfait.TabIndex = 0;
            this.btnAddForfait.Text = "Ajouter un frais forfait";
            this.btnAddForfait.UseVisualStyleBackColor = true;
            this.btnAddForfait.Click += new System.EventHandler(this.btnAddForfait_Click);
            // 
            // btnAddHorsForfait
            // 
            this.btnAddHorsForfait.Location = new System.Drawing.Point(565, 13);
            this.btnAddHorsForfait.Name = "btnAddHorsForfait";
            this.btnAddHorsForfait.Size = new System.Drawing.Size(186, 29);
            this.btnAddHorsForfait.TabIndex = 1;
            this.btnAddHorsForfait.Text = "Ajouter un hors forfait";
            this.btnAddHorsForfait.UseVisualStyleBackColor = true;
            this.btnAddHorsForfait.Click += new System.EventHandler(this.btnAddHorsForfait_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(836, 199);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(164, 68);
            this.btnViewHistory.TabIndex = 3;
            this.btnViewHistory.Text = "Historique";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.BtnViewHistory_Click);
            // 
            // btnAddJustificatif
            // 
            this.btnAddJustificatif.Location = new System.Drawing.Point(836, 288);
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
            this.btnExportPDF.Location = new System.Drawing.Point(836, 393);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(164, 67);
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.Text = "Exporter en PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // listViewForfait
            // 
            this.listViewForfait.HideSelection = false;
            this.listViewForfait.Location = new System.Drawing.Point(6, 48);
            this.listViewForfait.Name = "listViewForfait";
            this.listViewForfait.Size = new System.Drawing.Size(745, 150);
            this.listViewForfait.TabIndex = 6;
            this.listViewForfait.UseCompatibleStateImageBehavior = false;
            this.listViewForfait.View = System.Windows.Forms.View.Details;
            this.listViewForfait.SelectedIndexChanged += new System.EventHandler(this.listViewForfait_SelectedIndexChanged);
            // 
            // listViewHorsForfait
            // 
            this.listViewHorsForfait.HideSelection = false;
            this.listViewHorsForfait.Location = new System.Drawing.Point(6, 48);
            this.listViewHorsForfait.Name = "listViewHorsForfait";
            this.listViewHorsForfait.Size = new System.Drawing.Size(747, 150);
            this.listViewHorsForfait.TabIndex = 7;
            this.listViewHorsForfait.UseCompatibleStateImageBehavior = false;
            this.listViewHorsForfait.View = System.Windows.Forms.View.Details;
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
            this.groupBoxForfait.Location = new System.Drawing.Point(12, 71);
            this.groupBoxForfait.Name = "groupBoxForfait";
            this.groupBoxForfait.Size = new System.Drawing.Size(757, 222);
            this.groupBoxForfait.TabIndex = 11;
            this.groupBoxForfait.TabStop = false;
            // 
            // groupBoxHorsForfait
            // 
            this.groupBoxHorsForfait.Controls.Add(this.btnAddHorsForfait);
            this.groupBoxHorsForfait.Controls.Add(this.listViewHorsForfait);
            this.groupBoxHorsForfait.Controls.Add(this.lblTitleHorsForfait);
            this.groupBoxHorsForfait.Location = new System.Drawing.Point(12, 299);
            this.groupBoxHorsForfait.Name = "groupBoxHorsForfait";
            this.groupBoxHorsForfait.Size = new System.Drawing.Size(757, 215);
            this.groupBoxHorsForfait.TabIndex = 12;
            this.groupBoxHorsForfait.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(798, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(420, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 69);
            this.label1.TabIndex = 14;
            this.label1.Text = "Visiteur";
            // 
            // btnLogoutV
            // 
            this.btnLogoutV.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogoutV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogoutV.Location = new System.Drawing.Point(12, 12);
            this.btnLogoutV.Name = "btnLogoutV";
            this.btnLogoutV.Size = new System.Drawing.Size(173, 33);
            this.btnLogoutV.TabIndex = 15;
            this.btnLogoutV.Text = "Déconnexion";
            this.btnLogoutV.UseVisualStyleBackColor = false;
            this.btnLogoutV.Click += new System.EventHandler(this.btnLogoutV_Click);
            // 
            // VisitorForm
            // 
            this.ClientSize = new System.Drawing.Size(1055, 526);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogoutV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxHorsForfait);
            this.Controls.Add(this.groupBoxForfait);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnAddJustificatif);
            this.Controls.Add(this.btnViewHistory);
            this.MaximizeBox = false;
            this.Name = "VisitorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.VisitorForm_Load);
            this.groupBoxForfait.ResumeLayout(false);
            this.groupBoxForfait.PerformLayout();
            this.groupBoxHorsForfait.ResumeLayout(false);
            this.groupBoxHorsForfait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnAddForfait;
        private System.Windows.Forms.Button btnAddHorsForfait;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnAddJustificatif;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.ListView listViewForfait;
        private System.Windows.Forms.ListView listViewHorsForfait;
        private System.Windows.Forms.Label lblTitleForfait;
        private System.Windows.Forms.Label lblTitleHorsForfait;
        private System.Windows.Forms.GroupBox groupBoxForfait;
        private System.Windows.Forms.GroupBox groupBoxHorsForfait;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogoutV;
    }
}
