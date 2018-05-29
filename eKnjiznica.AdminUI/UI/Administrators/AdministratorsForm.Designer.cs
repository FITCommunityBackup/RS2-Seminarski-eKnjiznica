namespace eKnjiznica.AdminUI.UI.Administrators  
{
    partial class AdministratorsForm
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
            this.txtUserNameFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.gvAdministrators = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAdministrators)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisničko ime";
            // 
            // txtUserNameFilter
            // 
            this.txtUserNameFilter.Location = new System.Drawing.Point(129, 27);
            this.txtUserNameFilter.Name = "txtUserNameFilter";
            this.txtUserNameFilter.Size = new System.Drawing.Size(151, 20);
            this.txtUserNameFilter.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(286, 26);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // gvAdministrators
            // 
            this.gvAdministrators.AllowUserToAddRows = false;
            this.gvAdministrators.AllowUserToDeleteRows = false;
            this.gvAdministrators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAdministrators.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.gvFirstName,
            this.gvLastName,
            this.gvEmail,
            this.gvPhoneNumber,
            this.gvUsername,
            this.gvIsActive});
            this.gvAdministrators.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvAdministrators.Location = new System.Drawing.Point(27, 72);
            this.gvAdministrators.MultiSelect = false;
            this.gvAdministrators.Name = "gvAdministrators";
            this.gvAdministrators.ReadOnly = true;
            this.gvAdministrators.RowTemplate.Height = 24;
            this.gvAdministrators.Size = new System.Drawing.Size(643, 330);
            this.gvAdministrators.TabIndex = 3;
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
            // gvEmail
            // 
            this.gvEmail.DataPropertyName = "Email";
            this.gvEmail.HeaderText = "Email";
            this.gvEmail.Name = "gvEmail";
            this.gvEmail.ReadOnly = true;
            // 
            // gvPhoneNumber
            // 
            this.gvPhoneNumber.DataPropertyName = "PhoneNumber";
            this.gvPhoneNumber.HeaderText = "Broj telefona";
            this.gvPhoneNumber.Name = "gvPhoneNumber";
            this.gvPhoneNumber.ReadOnly = true;
            // 
            // gvUsername
            // 
            this.gvUsername.DataPropertyName = "Username";
            this.gvUsername.HeaderText = "Korisničko ime";
            this.gvUsername.Name = "gvUsername";
            this.gvUsername.ReadOnly = true;
            // 
            // gvIsActive
            // 
            this.gvIsActive.DataPropertyName = "IsActive";
            this.gvIsActive.HeaderText = "Aktivan";
            this.gvIsActive.Name = "gvIsActive";
            this.gvIsActive.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(504, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(595, 408);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 5;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.button3_Click);
            // 
            // AdministratorsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(708, 453);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gvAdministrators);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtUserNameFilter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdministratorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administratori";
            this.Load += new System.EventHandler(this.AdministratorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAdministrators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserNameFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView gvAdministrators;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvUsername;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvIsActive;
    }
}