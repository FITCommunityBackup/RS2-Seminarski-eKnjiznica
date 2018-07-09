namespace eKnjiznica.AdminUI.UI.UserBooks
{
    partial class UserBooksForm
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
            this.inputBookTitle = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.inputClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.inputAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvClientBooks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvClientBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBookTitle
            // 
            this.inputBookTitle.Location = new System.Drawing.Point(101, 42);
            this.inputBookTitle.Name = "inputBookTitle";
            this.inputBookTitle.Size = new System.Drawing.Size(151, 20);
            this.inputBookTitle.TabIndex = 27;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(24, 44);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(71, 13);
            this.lblAdmin.TabIndex = 26;
            this.lblAdmin.Text = "Naslov knjige";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(177, 94);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 23;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // inputClient
            // 
            this.inputClient.Location = new System.Drawing.Point(101, 12);
            this.inputClient.Name = "inputClient";
            this.inputClient.Size = new System.Drawing.Size(151, 20);
            this.inputClient.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Klijent";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(515, 401);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 25;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // inputAuthor
            // 
            this.inputAuthor.Location = new System.Drawing.Point(101, 68);
            this.inputAuthor.Name = "inputAuthor";
            this.inputAuthor.Size = new System.Drawing.Size(151, 20);
            this.inputAuthor.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Naziv autora";
            // 
            // gvClientBooks
            // 
            this.gvClientBooks.AllowUserToAddRows = false;
            this.gvClientBooks.AllowUserToDeleteRows = false;
            this.gvClientBooks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gvClientBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvClientBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClientBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BookTitle,
            this.AuthorName,
            this.Klijent,
            this.Price,
            this.Date});
            this.gvClientBooks.Location = new System.Drawing.Point(12, 123);
            this.gvClientBooks.Name = "gvClientBooks";
            this.gvClientBooks.ReadOnly = true;
            this.gvClientBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvClientBooks.Size = new System.Drawing.Size(578, 272);
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
            // Klijent
            // 
            this.Klijent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Klijent.DataPropertyName = "ClientName";
            this.Klijent.HeaderText = "Klijent";
            this.Klijent.Name = "Klijent";
            this.Klijent.ReadOnly = true;
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
            // UserBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 436);
            this.Controls.Add(this.gvClientBooks);
            this.Controls.Add(this.inputAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputBookTitle);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.inputClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetails);
            this.Name = "UserBooksForm";
            this.Text = "Korisničke knjige";
            this.Load += new System.EventHandler(this.UserBooksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvClientBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputBookTitle;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox inputClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.TextBox inputAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvClientBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}