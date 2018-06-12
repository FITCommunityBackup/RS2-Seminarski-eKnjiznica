namespace eKnjiznica.AdminUI.UI.Books
{
    partial class BooksOfferEditForm
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
            this.components = new System.ComponentModel.Container();
            this.inputAuthorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvBooks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFilter = new System.Windows.Forms.Button();
            this.inputBookTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputPrice = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputAuthorName
            // 
            this.inputAuthorName.Location = new System.Drawing.Point(124, 39);
            this.inputAuthorName.Name = "inputAuthorName";
            this.inputAuthorName.Size = new System.Drawing.Size(151, 20);
            this.inputAuthorName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Autor";
            // 
            // gvBooks
            // 
            this.gvBooks.AllowUserToAddRows = false;
            this.gvBooks.AllowUserToDeleteRows = false;
            this.gvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.gvBookTitle,
            this.gvAuthorName});
            this.gvBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvBooks.Location = new System.Drawing.Point(12, 183);
            this.gvBooks.MultiSelect = false;
            this.gvBooks.Name = "gvBooks";
            this.gvBooks.ReadOnly = true;
            this.gvBooks.RowTemplate.Height = 24;
            this.gvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBooks.Size = new System.Drawing.Size(263, 146);
            this.gvBooks.TabIndex = 17;
            this.gvBooks.Validating += new System.ComponentModel.CancelEventHandler(this.gvBooks_Validating);
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
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(200, 65);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // inputBookTitle
            // 
            this.inputBookTitle.Location = new System.Drawing.Point(124, 8);
            this.inputBookTitle.Name = "inputBookTitle";
            this.inputBookTitle.Size = new System.Drawing.Size(151, 20);
            this.inputBookTitle.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Naslov";
            // 
            // inputPrice
            // 
            this.inputPrice.DecimalPlaces = 2;
            this.inputPrice.Location = new System.Drawing.Point(124, 103);
            this.inputPrice.Name = "inputPrice";
            this.inputPrice.Size = new System.Drawing.Size(151, 20);
            this.inputPrice.TabIndex = 20;
            this.inputPrice.Validating += new System.ComponentModel.CancelEventHandler(this.inputPrice_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Odaberite knjigu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Cijena(KM)";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(200, 345);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 23;
            this.btnAction.Text = "Dodaj";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(213, 129);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(62, 17);
            this.cbIsActive.TabIndex = 24;
            this.cbIsActive.Text = "Aktivan";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BooksOfferEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 373);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputPrice);
            this.Controls.Add(this.inputAuthorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvBooks);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.inputBookTitle);
            this.Controls.Add(this.label1);
            this.Name = "BooksOfferEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Evidencija knjiga";
            this.Load += new System.EventHandler(this.BooksOfferEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputAuthorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvBookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAuthorName;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox inputBookTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inputPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}