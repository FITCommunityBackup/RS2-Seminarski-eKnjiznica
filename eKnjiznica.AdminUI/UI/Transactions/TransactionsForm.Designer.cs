namespace eKnjiznica.AdminUI.UI.Transactions
{
    partial class TransactionsForm
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
            this.gvTransactions = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvClientUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAdminUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvTransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvPreviousBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtUserNameFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.txtAdminUsername = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // gvTransactions
            // 
            this.gvTransactions.AllowUserToAddRows = false;
            this.gvTransactions.AllowUserToDeleteRows = false;
            this.gvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.gvClientUsername,
            this.gvAdminUsername,
            this.gvAmount,
            this.gvTransactionType,
            this.gvPreviousBalance,
            this.AccountBalance,
            this.Date});
            this.gvTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvTransactions.Location = new System.Drawing.Point(23, 70);
            this.gvTransactions.MultiSelect = false;
            this.gvTransactions.Name = "gvTransactions";
            this.gvTransactions.ReadOnly = true;
            this.gvTransactions.RowTemplate.Height = 24;
            this.gvTransactions.Size = new System.Drawing.Size(755, 330);
            this.gvTransactions.TabIndex = 16;
            this.gvTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvClients_CellContentClick);
            this.gvTransactions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvTransactions_CellFormatting);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // gvClientUsername
            // 
            this.gvClientUsername.DataPropertyName = "ClientUsername";
            this.gvClientUsername.HeaderText = "Korisničko ime";
            this.gvClientUsername.Name = "gvClientUsername";
            this.gvClientUsername.ReadOnly = true;
            // 
            // gvAdminUsername
            // 
            this.gvAdminUsername.DataPropertyName = "AdminUsername";
            this.gvAdminUsername.HeaderText = "Administrator";
            this.gvAdminUsername.Name = "gvAdminUsername";
            this.gvAdminUsername.ReadOnly = true;
            // 
            // gvAmount
            // 
            this.gvAmount.DataPropertyName = "Amount";
            this.gvAmount.HeaderText = "Količina(KM)";
            this.gvAmount.Name = "gvAmount";
            this.gvAmount.ReadOnly = true;
            // 
            // gvTransactionType
            // 
            this.gvTransactionType.DataPropertyName = "TransactionType";
            this.gvTransactionType.HeaderText = "Tip transakcije";
            this.gvTransactionType.Name = "gvTransactionType";
            this.gvTransactionType.ReadOnly = true;
            // 
            // gvPreviousBalance
            // 
            this.gvPreviousBalance.DataPropertyName = "PreviousBalance";
            this.gvPreviousBalance.HeaderText = "Prethodno stanje";
            this.gvPreviousBalance.Name = "gvPreviousBalance";
            this.gvPreviousBalance.ReadOnly = true;
            // 
            // AccountBalance
            // 
            this.AccountBalance.DataPropertyName = "NewBalance";
            this.AccountBalance.HeaderText = "Novo stanje";
            this.AccountBalance.Name = "AccountBalance";
            this.AccountBalance.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Datum";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(564, 21);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtUserNameFilter
            // 
            this.txtUserNameFilter.Location = new System.Drawing.Point(101, 21);
            this.txtUserNameFilter.Name = "txtUserNameFilter";
            this.txtUserNameFilter.Size = new System.Drawing.Size(151, 20);
            this.txtUserNameFilter.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Korisničko ime";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(703, 406);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 18;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // txtAdminUsername
            // 
            this.txtAdminUsername.Location = new System.Drawing.Point(350, 21);
            this.txtAdminUsername.Name = "txtAdminUsername";
            this.txtAdminUsername.Size = new System.Drawing.Size(151, 20);
            this.txtAdminUsername.TabIndex = 20;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(277, 24);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(67, 13);
            this.lblAdmin.TabIndex = 19;
            this.lblAdmin.Text = "Administrator";
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 476);
            this.Controls.Add(this.txtAdminUsername);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.gvTransactions);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtUserNameFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetails);
            this.Name = "TransactionsForm";
            this.Text = "TransactionsForm";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTransactions;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtUserNameFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvClientUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAdminUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvPreviousBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}