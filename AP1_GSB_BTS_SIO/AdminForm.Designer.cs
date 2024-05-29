namespace AP1_GSB_BTS_SIO
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ListView listViewTypes;
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
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.listViewTypes = new System.Windows.Forms.ListView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.btnEditType = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        new System.Windows.Forms.ColumnHeader { Text = "ID" },
        new System.Windows.Forms.ColumnHeader { Text = "Nom" },
        new System.Windows.Forms.ColumnHeader { Text = "Prénom" },
        new System.Windows.Forms.ColumnHeader { Text = "Email" },
        new System.Windows.Forms.ColumnHeader { Text = "Role" }
    });
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(13, 53);
            this.listViewUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(388, 504);
            this.listViewUsers.TabIndex = 0;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.DoubleClick += new System.EventHandler(this.listViewUsers_DoubleClick);
            // 
            // listViewTypes
            // 
            this.listViewTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        new System.Windows.Forms.ColumnHeader { Text = "ID" },
        new System.Windows.Forms.ColumnHeader { Text = "Type" },
        new System.Windows.Forms.ColumnHeader { Text = "Montant" }
    });
            this.listViewTypes.FullRowSelect = true;
            this.listViewTypes.GridLines = true;
            this.listViewTypes.HideSelection = false;
            this.listViewTypes.Location = new System.Drawing.Point(417, 53);
            this.listViewTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewTypes.Name = "listViewTypes";
            this.listViewTypes.Size = new System.Drawing.Size(388, 504);
            this.listViewTypes.TabIndex = 1;
            this.listViewTypes.UseCompatibleStateImageBehavior = false;
            this.listViewTypes.View = System.Windows.Forms.View.Details;
            this.listViewTypes.DoubleClick += new System.EventHandler(this.listViewTypes_DoubleClick);
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
            this.Controls.Add(this.listViewTypes);
            this.Controls.Add(this.listViewUsers);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panneau d'administration";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
        }
    }
}
