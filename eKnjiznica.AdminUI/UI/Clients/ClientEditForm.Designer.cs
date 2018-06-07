namespace eKnjiznica.AdminUI.UI.Clients
{
    partial class ClientEditForm
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
            this.btnAction = new System.Windows.Forms.Button();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.inputPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.inputPayIn = new System.Windows.Forms.NumericUpDown();
            this.lblPayIn = new System.Windows.Forms.Label();
            this.btnPayIn = new System.Windows.Forms.Button();
            this.labelAccountBalance = new System.Windows.Forms.Label();
            this.inputAccountBalance = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPayIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAccountBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(281, 283);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(98, 30);
            this.btnAction.TabIndex = 84;
            this.btnAction.Text = "Dodaj";
            this.btnAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new System.Drawing.Point(179, 84);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.Size = new System.Drawing.Size(195, 20);
            this.inputUsername.TabIndex = 82;
            this.inputUsername.Validating += new System.ComponentModel.CancelEventHandler(this.inputUsername_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "Korisničko ime";
            // 
            // inputLastName
            // 
            this.inputLastName.Location = new System.Drawing.Point(179, 53);
            this.inputLastName.Name = "inputLastName";
            this.inputLastName.Size = new System.Drawing.Size(195, 20);
            this.inputLastName.TabIndex = 80;
            this.inputLastName.Validating += new System.ComponentModel.CancelEventHandler(this.inputLastName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Prezime";
            // 
            // inputFirstName
            // 
            this.inputFirstName.Location = new System.Drawing.Point(179, 21);
            this.inputFirstName.Name = "inputFirstName";
            this.inputFirstName.Size = new System.Drawing.Size(195, 20);
            this.inputFirstName.TabIndex = 79;
            this.inputFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.inputFirstName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Ime";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Email";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(179, 180);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(195, 20);
            this.dtpBirthday.TabIndex = 87;
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(315, 235);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(64, 17);
            this.cbIsActive.TabIndex = 86;
            this.cbIsActive.Text = "IsActive";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 92;
            this.label5.Text = "Broj telefona";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Datum rođenja";
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(179, 116);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(195, 20);
            this.inputEmail.TabIndex = 94;
            this.inputEmail.Validating += new System.ComponentModel.CancelEventHandler(this.inputEmail_Validating);
            // 
            // inputPhoneNumber
            // 
            this.inputPhoneNumber.Location = new System.Drawing.Point(179, 148);
            this.inputPhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.inputPhoneNumber.Mask = "(999) 000-0000";
            this.inputPhoneNumber.Name = "inputPhoneNumber";
            this.inputPhoneNumber.Size = new System.Drawing.Size(195, 20);
            this.inputPhoneNumber.TabIndex = 96;
            this.inputPhoneNumber.Validating += new System.ComponentModel.CancelEventHandler(this.inputPhoneNumber_Validating);
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(179, 211);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '*';
            this.inputPassword.Size = new System.Drawing.Size(195, 20);
            this.inputPassword.TabIndex = 98;
            this.inputPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.inputPassword.Validating += new System.ComponentModel.CancelEventHandler(this.inputPassword_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Lozinka";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(26, 256);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 99;
            // 
            // inputPayIn
            // 
            this.inputPayIn.Location = new System.Drawing.Point(474, 73);
            this.inputPayIn.Name = "inputPayIn";
            this.inputPayIn.Size = new System.Drawing.Size(120, 20);
            this.inputPayIn.TabIndex = 100;
            // 
            // lblPayIn
            // 
            this.lblPayIn.AutoSize = true;
            this.lblPayIn.Location = new System.Drawing.Point(471, 53);
            this.lblPayIn.Name = "lblPayIn";
            this.lblPayIn.Size = new System.Drawing.Size(56, 13);
            this.lblPayIn.TabIndex = 101;
            this.lblPayIn.Text = "Uplati(KM)";
            // 
            // btnPayIn
            // 
            this.btnPayIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayIn.Location = new System.Drawing.Point(496, 99);
            this.btnPayIn.Name = "btnPayIn";
            this.btnPayIn.Size = new System.Drawing.Size(98, 30);
            this.btnPayIn.TabIndex = 102;
            this.btnPayIn.Text = "Uplati";
            this.btnPayIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayIn.UseVisualStyleBackColor = true;
            this.btnPayIn.Click += new System.EventHandler(this.btnPayIn_Click);
            // 
            // labelAccountBalance
            // 
            this.labelAccountBalance.AutoSize = true;
            this.labelAccountBalance.Location = new System.Drawing.Point(31, 257);
            this.labelAccountBalance.Name = "labelAccountBalance";
            this.labelAccountBalance.Size = new System.Drawing.Size(110, 13);
            this.labelAccountBalance.TabIndex = 103;
            this.labelAccountBalance.Text = "Stanje na računu(KM)";
            // 
            // inputAccountBalance
            // 
            this.inputAccountBalance.Location = new System.Drawing.Point(254, 257);
            this.inputAccountBalance.Name = "inputAccountBalance";
            this.inputAccountBalance.Size = new System.Drawing.Size(120, 20);
            this.inputAccountBalance.TabIndex = 104;
            // 
            // ClientEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 334);
            this.Controls.Add(this.inputAccountBalance);
            this.Controls.Add(this.labelAccountBalance);
            this.Controls.Add(this.btnPayIn);
            this.Controls.Add(this.lblPayIn);
            this.Controls.Add(this.inputPayIn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.inputPhoneNumber);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.inputUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.cbIsActive);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientEditForm";
            this.Text = "ClientEditForm";
            this.Load += new System.EventHandler(this.ClientEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPayIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAccountBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox inputUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox inputPhoneNumber;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button btnPayIn;
        private System.Windows.Forms.Label lblPayIn;
        private System.Windows.Forms.NumericUpDown inputPayIn;
        private System.Windows.Forms.NumericUpDown inputAccountBalance;
        private System.Windows.Forms.Label labelAccountBalance;
    }
}