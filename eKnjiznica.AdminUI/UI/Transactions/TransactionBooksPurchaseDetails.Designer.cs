namespace eKnjiznica.AdminUI.UI.Transactions
{
    partial class TransactionBooksPurchaseDetails
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textAmount = new System.Windows.Forms.NumericUpDown();
            this.textBuyer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvClientBooks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.textAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClientBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Location = new System.Drawing.Point(108, 96);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(212, 20);
            this.dtpDate.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Datum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ukupna cijena";
            // 
            // textAmount
            // 
            this.textAmount.Enabled = false;
            this.textAmount.Location = new System.Drawing.Point(108, 54);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(212, 20);
            this.textAmount.TabIndex = 14;
            // 
            // textBuyer
            // 
            this.textBuyer.Enabled = false;
            this.textBuyer.Location = new System.Drawing.Point(108, 14);
            this.textBuyer.Name = "textBuyer";
            this.textBuyer.Size = new System.Drawing.Size(212, 20);
            this.textBuyer.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kupac";
            // 
            // gvClientBooks
            // 
            this.gvClientBooks.AllowUserToAddRows = false;
            this.gvClientBooks.AllowUserToDeleteRows = false;
            this.gvClientBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvClientBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvClientBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClientBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BookTitle,
            this.AuthorName,
            this.Price,
            this.Date});
            this.gvClientBooks.Location = new System.Drawing.Point(18, 180);
            this.gvClientBooks.Name = "gvClientBooks";
            this.gvClientBooks.ReadOnly = true;
            this.gvClientBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvClientBooks.Size = new System.Drawing.Size(486, 195);
            this.gvClientBooks.TabIndex = 106;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // BookTitle
            // 
            this.BookTitle.DataPropertyName = "BookTitle";
            this.BookTitle.HeaderText = "Naslov knjige";
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            // 
            // AuthorName
            // 
            this.AuthorName.DataPropertyName = "AuthorName";
            this.AuthorName.HeaderText = "Autor";
            this.AuthorName.Name = "AuthorName";
            this.AuthorName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Cijena";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "BuyDate";
            this.Date.HeaderText = "Datum kupovine";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(198, 135);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(122, 23);
            this.btnGenerateReport.TabIndex = 107;
            this.btnGenerateReport.Text = "Generiraj izvještaj";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // TransactionBooksPurchaseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 387);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.gvClientBooks);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textAmount);
            this.Controls.Add(this.textBuyer);
            this.Controls.Add(this.label1);
            this.Name = "TransactionBooksPurchaseDetails";
            this.Text = "Detalji transakcije";
            this.Load += new System.EventHandler(this.TransactionBooksPurchaseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClientBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown textAmount;
        private System.Windows.Forms.TextBox textBuyer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvClientBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}