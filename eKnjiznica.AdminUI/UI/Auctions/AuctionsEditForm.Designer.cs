namespace eKnjiznica.AdminUI.UI.Auctions
{
    partial class AuctionsEditForm
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
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputStartPrice = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.inputCurrentPrice = new System.Windows.Forms.NumericUpDown();
            this.gvBooks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputAuthorName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.inputBookTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inputStartPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCurrentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(225, 138);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(62, 17);
            this.cbIsActive.TabIndex = 13;
            this.cbIsActive.Text = "Aktivna";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(87, 48);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 12;
            this.dtpTo.Validating += new System.ComponentModel.CancelEventHandler(this.dtpTo_Validating);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(87, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 11;
            this.dtpFrom.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFrom_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Datum do";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datum od";
            // 
            // inputStartPrice
            // 
            this.inputStartPrice.Location = new System.Drawing.Point(167, 79);
            this.inputStartPrice.Name = "inputStartPrice";
            this.inputStartPrice.Size = new System.Drawing.Size(120, 20);
            this.inputStartPrice.TabIndex = 14;
            this.inputStartPrice.Validating += new System.ComponentModel.CancelEventHandler(this.inputStartPrice_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Početna cijena";
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Location = new System.Drawing.Point(13, 107);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(81, 13);
            this.lblCurrentPrice.TabIndex = 17;
            this.lblCurrentPrice.Text = "Trenutna cijena";
            // 
            // inputCurrentPrice
            // 
            this.inputCurrentPrice.Enabled = false;
            this.inputCurrentPrice.Location = new System.Drawing.Point(167, 105);
            this.inputCurrentPrice.Name = "inputCurrentPrice";
            this.inputCurrentPrice.Size = new System.Drawing.Size(120, 20);
            this.inputCurrentPrice.TabIndex = 16;
            // 
            // gvBooks
            // 
            this.gvBooks.AllowUserToAddRows = false;
            this.gvBooks.AllowUserToDeleteRows = false;
            this.gvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.gvBookTitle,
            this.gvAuthorName});
            this.gvBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvBooks.Location = new System.Drawing.Point(24, 252);
            this.gvBooks.MultiSelect = false;
            this.gvBooks.Name = "gvBooks";
            this.gvBooks.ReadOnly = true;
            this.gvBooks.RowTemplate.Height = 24;
            this.gvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBooks.Size = new System.Drawing.Size(263, 146);
            this.gvBooks.TabIndex = 18;
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
            // inputAuthorName
            // 
            this.inputAuthorName.Location = new System.Drawing.Point(136, 196);
            this.inputAuthorName.Name = "inputAuthorName";
            this.inputAuthorName.Size = new System.Drawing.Size(151, 20);
            this.inputAuthorName.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Autor";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(212, 222);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 22;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // inputBookTitle
            // 
            this.inputBookTitle.Location = new System.Drawing.Point(136, 165);
            this.inputBookTitle.Name = "inputBookTitle";
            this.inputBookTitle.Size = new System.Drawing.Size(151, 20);
            this.inputBookTitle.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Naslov";
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(212, 404);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 25;
            this.btnAction.Text = "Akcija";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AuctionsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 441);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.inputAuthorName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.inputBookTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gvBooks);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.inputCurrentPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputStartPrice);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AuctionsEditForm";
            this.Text = "Evidencija aukcija";
            this.Load += new System.EventHandler(this.AuctionsEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputStartPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCurrentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inputStartPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.NumericUpDown inputCurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvBookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAuthorName;
        private System.Windows.Forms.TextBox inputAuthorName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox inputBookTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAction;
        public System.Windows.Forms.DataGridView gvBooks;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}