namespace eKnjiznica.AdminUI.UI.Books
{
    partial class BooksSellForm
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
            this.gvBookOffers = new System.Windows.Forms.DataGridView();
            this.gvAuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvOfferCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.inputAuthorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.inputBookTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbInactive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvBookOffers)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBookOffers
            // 
            this.gvBookOffers.AllowUserToAddRows = false;
            this.gvBookOffers.AllowUserToDeleteRows = false;
            this.gvBookOffers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBookOffers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvAuthorName,
            this.Id,
            this.gvTitle,
            this.Price,
            this.gvOfferCreatedDate,
            this.gvIsActive});
            this.gvBookOffers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvBookOffers.Location = new System.Drawing.Point(12, 113);
            this.gvBookOffers.MultiSelect = false;
            this.gvBookOffers.Name = "gvBookOffers";
            this.gvBookOffers.ReadOnly = true;
            this.gvBookOffers.RowTemplate.Height = 24;
            this.gvBookOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBookOffers.Size = new System.Drawing.Size(544, 300);
            this.gvBookOffers.TabIndex = 10;
            // 
            // gvAuthorName
            // 
            this.gvAuthorName.DataPropertyName = "AuthorName";
            this.gvAuthorName.HeaderText = "Ime autora";
            this.gvAuthorName.Name = "gvAuthorName";
            this.gvAuthorName.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // gvTitle
            // 
            this.gvTitle.DataPropertyName = "Title";
            this.gvTitle.HeaderText = "Naslov";
            this.gvTitle.Name = "gvTitle";
            this.gvTitle.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Cijena(KM)";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // gvOfferCreatedDate
            // 
            this.gvOfferCreatedDate.DataPropertyName = "OfferCreatedDate";
            this.gvOfferCreatedDate.HeaderText = "Datum";
            this.gvOfferCreatedDate.Name = "gvOfferCreatedDate";
            this.gvOfferCreatedDate.ReadOnly = true;
            // 
            // gvIsActive
            // 
            this.gvIsActive.DataPropertyName = "IsActive";
            this.gvIsActive.HeaderText = "Aktivan";
            this.gvIsActive.Name = "gvIsActive";
            this.gvIsActive.ReadOnly = true;
            // 
            // inputAuthorName
            // 
            this.inputAuthorName.Location = new System.Drawing.Point(58, 46);
            this.inputAuthorName.Name = "inputAuthorName";
            this.inputAuthorName.Size = new System.Drawing.Size(151, 20);
            this.inputAuthorName.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Autor";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(481, 61);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // inputBookTitle
            // 
            this.inputBookTitle.Location = new System.Drawing.Point(58, 12);
            this.inputBookTitle.Name = "inputBookTitle";
            this.inputBookTitle.Size = new System.Drawing.Size(151, 20);
            this.inputBookTitle.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Naslov";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(481, 419);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 18;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbInactive
            // 
            this.cbInactive.AutoSize = true;
            this.cbInactive.Location = new System.Drawing.Point(101, 72);
            this.cbInactive.Name = "cbInactive";
            this.cbInactive.Size = new System.Drawing.Size(108, 17);
            this.cbInactive.TabIndex = 21;
            this.cbInactive.Text = "Uključi neaktivne";
            this.cbInactive.UseVisualStyleBackColor = true;
            // 
            // BooksSellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 468);
            this.Controls.Add(this.cbInactive);
            this.Controls.Add(this.inputAuthorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.inputBookTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gvBookOffers);
            this.Name = "BooksSellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ponude";
            this.Load += new System.EventHandler(this.BooksSellForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBookOffers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBookOffers;
        private System.Windows.Forms.TextBox inputAuthorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox inputBookTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAuthorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvOfferCreatedDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvIsActive;
        private System.Windows.Forms.CheckBox cbInactive;
    }
}