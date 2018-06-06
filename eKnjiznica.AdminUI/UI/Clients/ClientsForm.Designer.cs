namespace eKnjiznica.AdminUI.UI.Clients
{
    partial class ClientsForm
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
            this.gvClients = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtUserNameFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBirthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbIncludeInactive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // gvClients
            // 
            this.gvClients.AllowUserToAddRows = false;
            this.gvClients.AllowUserToDeleteRows = false;
            this.gvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.gvFirstName,
            this.gvLastName,
            this.gvUsername,
            this.gbBirthdate,
            this.gvIsActive});
            this.gvClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvClients.Location = new System.Drawing.Point(12, 62);
            this.gvClients.MultiSelect = false;
            this.gvClients.Name = "gvClients";
            this.gvClients.ReadOnly = true;
            this.gvClients.RowTemplate.Height = 24;
            this.gvClients.Size = new System.Drawing.Size(552, 330);
            this.gvClients.TabIndex = 9;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(385, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtUserNameFilter
            // 
            this.txtUserNameFilter.Location = new System.Drawing.Point(114, 17);
            this.txtUserNameFilter.Name = "txtUserNameFilter";
            this.txtUserNameFilter.Size = new System.Drawing.Size(151, 20);
            this.txtUserNameFilter.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Korisničko ime";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(489, 398);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 11;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // gvFirstName
            // 
            this.gvFirstName.DataPropertyName = "FirstName";
            this.gvFirstName.HeaderText = "Ime";
            this.gvFirstName.Name = "gvFirstName";
            this.gvFirstName.ReadOnly = true;
            // 
            // gvLastName
            // 
            this.gvLastName.DataPropertyName = "LastName";
            this.gvLastName.HeaderText = "Prezime";
            this.gvLastName.Name = "gvLastName";
            this.gvLastName.ReadOnly = true;
            // 
            // gvUsername
            // 
            this.gvUsername.DataPropertyName = "Username";
            this.gvUsername.HeaderText = "Korisničko ime";
            this.gvUsername.Name = "gvUsername";
            this.gvUsername.ReadOnly = true;
            // 
            // gbBirthdate
            // 
            this.gbBirthdate.DataPropertyName = "BirthDate";
            this.gbBirthdate.HeaderText = "Datum rođenja";
            this.gbBirthdate.Name = "gbBirthdate";
            this.gbBirthdate.ReadOnly = true;
            // 
            // gvIsActive
            // 
            this.gvIsActive.DataPropertyName = "IsActive";
            this.gvIsActive.HeaderText = "Aktivan";
            this.gvIsActive.Name = "gvIsActive";
            this.gvIsActive.ReadOnly = true;
            // 
            // cbIncludeInactive
            // 
            this.cbIncludeInactive.AutoSize = true;
            this.cbIncludeInactive.Location = new System.Drawing.Point(271, 19);
            this.cbIncludeInactive.Name = "cbIncludeInactive";
            this.cbIncludeInactive.Size = new System.Drawing.Size(108, 17);
            this.cbIncludeInactive.TabIndex = 12;
            this.cbIncludeInactive.Text = "Uključi neaktivne";
            this.cbIncludeInactive.UseVisualStyleBackColor = true;
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 459);
            this.Controls.Add(this.cbIncludeInactive);
            this.Controls.Add(this.gvClients);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtUserNameFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.button2);
            this.Name = "ClientsForm";
            this.Text = "ClientsForm";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn gbBirthdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvIsActive;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtUserNameFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbIncludeInactive;
    }
}