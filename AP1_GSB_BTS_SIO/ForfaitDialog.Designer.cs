namespace AP1_GSB_BTS_SIO
{
    partial class ForfaitDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbTypeFrais;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTypeFrais;
        private System.Windows.Forms.Label lblQuantite;

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
            this.cmbTypeFrais = new System.Windows.Forms.ComboBox();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTypeFrais = new System.Windows.Forms.Label();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTypeFrais
            // 
            this.cmbTypeFrais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFrais.FormattingEnabled = true;
            this.cmbTypeFrais.Location = new System.Drawing.Point(12, 49);
            this.cmbTypeFrais.Name = "cmbTypeFrais";
            this.cmbTypeFrais.Size = new System.Drawing.Size(260, 28);
            this.cmbTypeFrais.TabIndex = 0;
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(12, 103);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(260, 26);
            this.txtQuantite.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(114, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTypeFrais
            // 
            this.lblTypeFrais.AutoSize = true;
            this.lblTypeFrais.Location = new System.Drawing.Point(8, 26);
            this.lblTypeFrais.Name = "lblTypeFrais";
            this.lblTypeFrais.Size = new System.Drawing.Size(104, 20);
            this.lblTypeFrais.TabIndex = 4;
            this.lblTypeFrais.Text = "Type de Frais";
            // 
            // lblQuantite
            // 
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(8, 80);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(70, 20);
            this.lblQuantite.TabIndex = 5;
            this.lblQuantite.Text = "Quantité";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 159);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(258, 26);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Date";
            // 
            // ForfaitDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.lblTypeFrais);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.cmbTypeFrais);
            this.Name = "ForfaitDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ForfaitDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
    }
}
