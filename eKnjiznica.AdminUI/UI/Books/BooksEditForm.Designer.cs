using System.Windows.Forms;

namespace eKnjiznica.AdminUI.UI.Books
{
    partial class BooksEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnAction;
        private TextBox inputDescription;
        private Label label3;
        private TextBox inputAuthor;
        private Label label2;
        private TextBox inputBookName;
        private Label label1;
        private ErrorProvider errorProvider;
        private CheckedListBox cbCategories;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAction = new System.Windows.Forms.Button();
            this.inputDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputBookName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbCategories = new System.Windows.Forms.CheckedListBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(196, 288);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(98, 30);
            this.btnAction.TabIndex = 70;
            this.btnAction.Text = "Dodaj";
            this.btnAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // inputDescription
            // 
            this.inputDescription.Location = new System.Drawing.Point(99, 69);
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.Size = new System.Drawing.Size(195, 20);
            this.inputDescription.TabIndex = 64;
            this.inputDescription.Validating += new System.ComponentModel.CancelEventHandler(this.inputDescription_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Opis:";
            // 
            // inputAuthor
            // 
            this.inputAuthor.Location = new System.Drawing.Point(99, 43);
            this.inputAuthor.Name = "inputAuthor";
            this.inputAuthor.Size = new System.Drawing.Size(195, 20);
            this.inputAuthor.TabIndex = 62;
            this.inputAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.inputAuthor_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Ime autora:";
            // 
            // inputBookName
            // 
            this.inputBookName.Location = new System.Drawing.Point(99, 17);
            this.inputBookName.Name = "inputBookName";
            this.inputBookName.Size = new System.Drawing.Size(195, 20);
            this.inputBookName.TabIndex = 61;
            this.inputBookName.Validating += new System.ComponentModel.CancelEventHandler(this.inputBookName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Naslov knjige:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(99, 150);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(195, 109);
            this.cbCategories.TabIndex = 71;
            this.cbCategories.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategories_Validating);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(230, 265);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(64, 17);
            this.cbIsActive.TabIndex = 72;
            this.cbIsActive.Text = "IsActive";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(99, 97);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpReleaseDate.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Datum izdavanja";
            // 
            // BooksEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 332);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.inputDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputBookName);
            this.Controls.Add(this.label1);
            this.Name = "BooksEditForm";
            this.Text = "BooksAddForm";
            this.Load += new System.EventHandler(this.BooksEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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


        #endregion

        private CheckBox cbIsActive;
        private Label label4;
        private DateTimePicker dtpReleaseDate;
    }
}