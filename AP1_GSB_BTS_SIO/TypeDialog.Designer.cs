namespace AP1_GSB_BTS_SIO
{
    partial class TypeDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.TextBox txtTypeAmount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label lblTypeAmount;

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
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.txtTypeAmount = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.lblTypeAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(12, 25);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(260, 26);
            this.txtTypeName.TabIndex = 0;
            // 
            // txtTypeAmount
            // 
            this.txtTypeAmount.Location = new System.Drawing.Point(12, 71);
            this.txtTypeAmount.Name = "txtTypeAmount";
            this.txtTypeAmount.Size = new System.Drawing.Size(260, 26);
            this.txtTypeAmount.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(12, 2);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(154, 20);
            this.lblTypeName.TabIndex = 6;
            this.lblTypeName.Text = "Nom du type de frais";
            // 
            // lblTypeAmount
            // 
            this.lblTypeAmount.AutoSize = true;
            this.lblTypeAmount.Location = new System.Drawing.Point(12, 54);
            this.lblTypeAmount.Name = "lblTypeAmount";
            this.lblTypeAmount.Size = new System.Drawing.Size(68, 20);
            this.lblTypeAmount.TabIndex = 7;
            this.lblTypeAmount.Text = "Montant";
            // 
            // TypeDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTypeAmount);
            this.Controls.Add(this.lblTypeAmount);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lblTypeName);
            this.Name = "TypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
