namespace AP1_GSB_BTS_SIO
{
    partial class AccountantForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.listViewFiche = new System.Windows.Forms.ListView();
            this.anneeMois = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NomPrenom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.listViewDetails = new System.Windows.Forms.ListView();
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Montant_Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AP1_GSB_BTS_SIO.Properties.Resources.LOGO_GSB;
            this.pictureBox1.Location = new System.Drawing.Point(894, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(434, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compta";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(12, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(193, 34);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // listViewFiche
            // 
            this.listViewFiche.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.anneeMois,
            this.NomPrenom});
            this.listViewFiche.FullRowSelect = true;
            this.listViewFiche.GridLines = true;
            this.listViewFiche.HideSelection = false;
            this.listViewFiche.Location = new System.Drawing.Point(290, 143);
            this.listViewFiche.MultiSelect = false;
            this.listViewFiche.Name = "listViewFiche";
            this.listViewFiche.Size = new System.Drawing.Size(267, 380);
            this.listViewFiche.TabIndex = 3;
            this.listViewFiche.UseCompatibleStateImageBehavior = false;
            this.listViewFiche.View = System.Windows.Forms.View.Details;
            this.listViewFiche.ItemActivate += new System.EventHandler(this.listViewFiche_ItemActivate);
            // 
            // anneeMois
            // 
            this.anneeMois.Text = "Année - Mois";
            this.anneeMois.Width = 89;
            // 
            // NomPrenom
            // 
            this.NomPrenom.Text = "Nom Prenom";
            this.NomPrenom.Width = 100;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.YellowGreen;
            this.btnApprove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnApprove.Location = new System.Drawing.Point(41, 155);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(164, 43);
            this.btnApprove.TabIndex = 4;
            this.btnApprove.Text = "Approuver";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.IndianRed;
            this.btnReject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReject.Location = new System.Drawing.Point(41, 225);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(164, 43);
            this.btnReject.TabIndex = 5;
            this.btnReject.Text = "Refuser";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // listViewDetails
            // 
            this.listViewDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Description,
            this.Montant_Total,
            this.date});
            this.listViewDetails.FullRowSelect = true;
            this.listViewDetails.GridLines = true;
            this.listViewDetails.HideSelection = false;
            this.listViewDetails.Location = new System.Drawing.Point(604, 143);
            this.listViewDetails.Name = "listViewDetails";
            this.listViewDetails.Size = new System.Drawing.Size(348, 380);
            this.listViewDetails.TabIndex = 6;
            this.listViewDetails.UseCompatibleStateImageBehavior = false;
            this.listViewDetails.View = System.Windows.Forms.View.Details;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            // 
            // Montant_Total
            // 
            this.Montant_Total.Text = "Montant total";
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(574, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "double clickez sur une fiche de frais pour voir les details";
            // 
            // AccountantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 576);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewDetails);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.listViewFiche);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AccountantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AccountantForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListView listViewFiche;
        private System.Windows.Forms.ColumnHeader anneeMois;
        private System.Windows.Forms.ColumnHeader NomPrenom;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.ListView listViewDetails;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Montant_Total;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.Label label2;
    }
}