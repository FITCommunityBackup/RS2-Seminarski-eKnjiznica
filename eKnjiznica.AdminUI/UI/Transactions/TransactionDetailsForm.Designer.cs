namespace eKnjiznica.AdminUI.UI.Transactions
{
    partial class TransactionDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBuyer = new System.Windows.Forms.TextBox();
            this.textAdmin = new System.Windows.Forms.TextBox();
            this.textAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.textAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kupac";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Administrator";
            // 
            // textBuyer
            // 
            this.textBuyer.Enabled = false;
            this.textBuyer.Location = new System.Drawing.Point(113, 20);
            this.textBuyer.Name = "textBuyer";
            this.textBuyer.Size = new System.Drawing.Size(212, 20);
            this.textBuyer.TabIndex = 3;
            // 
            // textAdmin
            // 
            this.textAdmin.Enabled = false;
            this.textAdmin.Location = new System.Drawing.Point(113, 48);
            this.textAdmin.Name = "textAdmin";
            this.textAdmin.Size = new System.Drawing.Size(212, 20);
            this.textAdmin.TabIndex = 4;
            // 
            // textAmount
            // 
            this.textAmount.Enabled = false;
            this.textAmount.Location = new System.Drawing.Point(113, 76);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(212, 20);
            this.textAmount.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Uplata";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Datum";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Location = new System.Drawing.Point(113, 106);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(212, 20);
            this.dtpDate.TabIndex = 9;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(203, 136);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(122, 23);
            this.btnGenerateReport.TabIndex = 10;
            this.btnGenerateReport.Text = "Generiraj izvještaj";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // TransactionDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 171);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textAmount);
            this.Controls.Add(this.textAdmin);
            this.Controls.Add(this.textBuyer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "TransactionDetailsForm";
            this.Text = "Detalji transakcije";
            this.Load += new System.EventHandler(this.TransactionDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBuyer;
        private System.Windows.Forms.TextBox textAdmin;
        private System.Windows.Forms.NumericUpDown textAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}