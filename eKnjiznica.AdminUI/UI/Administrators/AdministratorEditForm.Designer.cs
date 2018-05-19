namespace eKnjiznica.AdminUI.UI.Administrators
{
    partial class AdministratorEditForm
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
            this.inputPhone = new System.Windows.Forms.MaskedTextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inputUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPhone
            // 
            this.inputPhone.Location = new System.Drawing.Point(136, 121);
            this.inputPhone.Margin = new System.Windows.Forms.Padding(4);
            this.inputPhone.Mask = "(999) 000-000";
            this.inputPhone.Name = "inputPhone";
            this.inputPhone.Size = new System.Drawing.Size(259, 22);
            this.inputPhone.TabIndex = 65;
            this.inputPhone.Validating += new System.ComponentModel.CancelEventHandler(this.inputPhone_Validating);
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(136, 206);
            this.inputPassword.Margin = new System.Windows.Forms.Padding(4);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '*';
            this.inputPassword.Size = new System.Drawing.Size(259, 22);
            this.inputPassword.TabIndex = 68;
            this.inputPassword.Validating += new System.ComponentModel.CancelEventHandler(this.inputPassword_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 72;
            this.label6.Text = "Lozinka:";
            // 
            // inputUserName
            // 
            this.inputUserName.Location = new System.Drawing.Point(136, 174);
            this.inputUserName.Margin = new System.Windows.Forms.Padding(4);
            this.inputUserName.Name = "inputUserName";
            this.inputUserName.ReadOnly = true;
            this.inputUserName.Size = new System.Drawing.Size(259, 22);
            this.inputUserName.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 71;
            this.label5.Text = "Korisničko ime:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 69;
            this.label4.Text = "Telefon:";
            // 
            // btnAdd
            // 
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(264, 273);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 37);
            this.btnAdd.TabIndex = 70;
            this.btnAdd.Text = "Izmjeni";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(136, 86);
            this.inputEmail.Margin = new System.Windows.Forms.Padding(4);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(259, 22);
            this.inputEmail.TabIndex = 64;
            this.inputEmail.Validating += new System.ComponentModel.CancelEventHandler(this.inputEmail_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "E-mail:";
            // 
            // inputLastName
            // 
            this.inputLastName.Location = new System.Drawing.Point(136, 54);
            this.inputLastName.Margin = new System.Windows.Forms.Padding(4);
            this.inputLastName.Name = "inputLastName";
            this.inputLastName.Size = new System.Drawing.Size(259, 22);
            this.inputLastName.TabIndex = 62;
            this.inputLastName.Validating += new System.ComponentModel.CancelEventHandler(this.inputLastName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Prezime:";
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(136, 22);
            this.inputName.Margin = new System.Windows.Forms.Padding(4);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(259, 22);
            this.inputName.TabIndex = 61;
            this.inputName.Validating += new System.ComponentModel.CancelEventHandler(this.inputName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Ime:";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(297, 245);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(76, 21);
            this.cbActive.TabIndex = 73;
            this.cbActive.Text = "Aktivan";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AdministratorEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 347);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.inputPhone);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inputUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.label1);
            this.Name = "AdministratorEditForm";
            this.Text = "AdministratorEditForm";
            this.Load += new System.EventHandler(this.AdministratorEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox inputPhone;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox inputUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}