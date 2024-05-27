namespace AP1_GSB_BTS_SIO
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.ListBox listBoxTypes;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnEditType;
        private System.Windows.Forms.Button btnLogout;

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
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.listBoxTypes = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.btnEditType = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 20;
            this.listBoxUsers.Location = new System.Drawing.Point(13, 53);
            this.listBoxUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(388, 504);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.DoubleClick += new System.EventHandler(this.listBoxUsers_DoubleClick);
            // 
            // listBoxTypes
            // 
            this.listBoxTypes.FormattingEnabled = true;
            this.listBoxTypes.ItemHeight = 20;
            this.listBoxTypes.Location = new System.Drawing.Point(417, 53);
            this.listBoxTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxTypes.Name = "listBoxTypes";
            this.listBoxTypes.Size = new System.Drawing.Size(388, 504);
            this.listBoxTypes.TabIndex = 1;
            this.listBoxTypes.DoubleClick += new System.EventHandler(this.listBoxTypes_DoubleClick);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(26, 567);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(112, 35);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Ajouter Utilisateur";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(146, 567);
            this.btnEditUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(112, 35);
            this.btnEditUser.TabIndex = 3;
            this.btnEditUser.Text = "Modifier Utilisateur";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(266, 567);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(112, 35);
            this.btnDeleteUser.TabIndex = 4;
            this.btnDeleteUser.Text = "Supprimer Utilisateur";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(417, 567);
            this.btnAddType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(112, 35);
            this.btnAddType.TabIndex = 5;
            this.btnAddType.Text = "Ajouter Type";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // btnEditType
            // 
            this.btnEditType.Location = new System.Drawing.Point(537, 567);
            this.btnEditType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditType.Name = "btnEditType";
            this.btnEditType.Size = new System.Drawing.Size(112, 35);
            this.btnEditType.TabIndex = 6;
            this.btnEditType.Text = "Modifier Type";
            this.btnEditType.UseVisualStyleBackColor = true;
            this.btnEditType.Click += new System.EventHandler(this.btnEditType_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogout.Location = new System.Drawing.Point(682, 8);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(123, 35);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 616);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnEditType);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.listBoxTypes);
            this.Controls.Add(this.listBoxUsers);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panneau d\'administration";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);

        }
    }
}
