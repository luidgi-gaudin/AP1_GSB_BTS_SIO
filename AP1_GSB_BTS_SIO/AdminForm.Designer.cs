namespace AP1_GSB_BTS_SIO
{
    partial class AdminForm
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
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.Id_User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prenom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTypes = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Montant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnEditType = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id_User,
            this.Nom,
            this.Prenom,
            this.Email,
            this.Role});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(13, 174);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(982, 226);
            this.listViewUsers.TabIndex = 0;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.DoubleClick += new System.EventHandler(this.listViewUsers_DoubleClick);
            // 
            // Id_User
            // 
            this.Id_User.Text = "Id";
            this.Id_User.Width = 50;
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            this.Nom.Width = 150;
            // 
            // Prenom
            // 
            this.Prenom.Text = "Prénom";
            this.Prenom.Width = 150;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 200;
            // 
            // Role
            // 
            this.Role.Text = "Role";
            this.Role.Width = 100;
            // 
            // listViewTypes
            // 
            this.listViewTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Type,
            this.Montant});
            this.listViewTypes.FullRowSelect = true;
            this.listViewTypes.GridLines = true;
            this.listViewTypes.HideSelection = false;
            this.listViewTypes.Location = new System.Drawing.Point(13, 438);
            this.listViewTypes.Name = "listViewTypes";
            this.listViewTypes.Size = new System.Drawing.Size(982, 225);
            this.listViewTypes.TabIndex = 1;
            this.listViewTypes.UseCompatibleStateImageBehavior = false;
            this.listViewTypes.View = System.Windows.Forms.View.Details;
            this.listViewTypes.DoubleClick += new System.EventHandler(this.listViewTypes_DoubleClick);
            // 
            // ID
            // 
            this.ID.Text = "Id";
            this.ID.Width = 50;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 300;
            // 
            // Montant
            // 
            this.Montant.Text = "Montant";
            this.Montant.Width = 200;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(1038, 174);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(165, 72);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Ajouter";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(1038, 328);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(165, 72);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Supprimer";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(1038, 250);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(165, 72);
            this.btnEditUser.TabIndex = 4;
            this.btnEditUser.Text = "Modifier";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnEditType
            // 
            this.btnEditType.Location = new System.Drawing.Point(1038, 547);
            this.btnEditType.Name = "btnEditType";
            this.btnEditType.Size = new System.Drawing.Size(165, 72);
            this.btnEditType.TabIndex = 5;
            this.btnEditType.Text = "Modifier";
            this.btnEditType.UseVisualStyleBackColor = true;
            this.btnEditType.Click += new System.EventHandler(this.btnEditType_Click);
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(1038, 469);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(165, 72);
            this.btnAddType.TabIndex = 6;
            this.btnAddType.Text = "Ajouter";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(17, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(202, 37);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Utilisateurs :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Types :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AP1_GSB_BTS_SIO.Properties.Resources.LOGO_GSB;
            this.pictureBox1.Location = new System.Drawing.Point(998, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(417, 69);
            this.label3.TabIndex = 11;
            this.label3.Text = "Administrateur";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 678);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.btnEditType);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.listViewTypes);
            this.Controls.Add(this.listViewUsers);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ListView listViewTypes;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Montant;
        private System.Windows.Forms.ColumnHeader Id_User;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ColumnHeader Prenom;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Role;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnEditType;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}
