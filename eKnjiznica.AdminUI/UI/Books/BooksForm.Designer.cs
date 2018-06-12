namespace eKnjiznica.AdminUI.UI.Books
{
    partial class BooksForm
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
            this.gvBooks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnFilter = new System.Windows.Forms.Button();
            this.inputBookTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.inputAuthorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBooks
            // 
            this.gvBooks.AllowUserToAddRows = false;
            this.gvBooks.AllowUserToDeleteRows = false;
            this.gvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.gvBookTitle,
            this.gvAuthorName,
            this.gvIsActive});
            this.gvBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvBooks.Location = new System.Drawing.Point(12, 72);
            this.gvBooks.MultiSelect = false;
            this.gvBooks.Name = "gvBooks";
            this.gvBooks.ReadOnly = true;
            this.gvBooks.RowTemplate.Height = 24;
            this.gvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBooks.Size = new System.Drawing.Size(346, 330);
            this.gvBooks.TabIndex = 9;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // gvBookTitle
            // 
            this.gvBookTitle.DataPropertyName = "BookTitle";
            this.gvBookTitle.HeaderText = "Naslov";
            this.gvBookTitle.Name = "gvBookTitle";
            this.gvBookTitle.ReadOnly = true;
            // 
            // gvAuthorName
            // 
            this.gvAuthorName.DataPropertyName = "AuthorName";
            this.gvAuthorName.HeaderText = "Ime autora";
            this.gvAuthorName.Name = "gvAuthorName";
            this.gvAuthorName.ReadOnly = true;
            // 
            // gvIsActive
            // 
            this.gvIsActive.DataPropertyName = "IsActive";
            this.gvIsActive.HeaderText = "Aktivan";
            this.gvIsActive.Name = "gvIsActive";
            this.gvIsActive.ReadOnly = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(215, 44);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // inputBookTitle
            // 
            this.inputBookTitle.Location = new System.Drawing.Point(58, 12);
            this.inputBookTitle.Name = "inputBookTitle";
            this.inputBookTitle.Size = new System.Drawing.Size(151, 20);
            this.inputBookTitle.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Naslov";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(283, 408);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 11;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // inputAuthorName
            // 
            this.inputAuthorName.Location = new System.Drawing.Point(58, 46);
            this.inputAuthorName.Name = "inputAuthorName";
            this.inputAuthorName.Size = new System.Drawing.Size(151, 20);
            this.inputAuthorName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Autor";
            // 
            // BooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 458);
            this.Controls.Add(this.inputAuthorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvBooks);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.inputBookTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.button2);
            this.Name = "BooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Knjige";
            this.Load += new System.EventHandler(this.BooksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBooks;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox inputBookTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox inputAuthorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvBookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAuthorName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvIsActive;
    }
}