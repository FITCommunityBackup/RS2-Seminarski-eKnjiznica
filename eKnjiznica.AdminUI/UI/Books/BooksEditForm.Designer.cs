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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(260, 426);
            this.btnAction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(131, 37);
            this.btnAction.TabIndex = 70;
            this.btnAction.Text = "Dodaj";
            this.btnAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // inputDescription
            // 
            this.inputDescription.Location = new System.Drawing.Point(132, 85);
            this.inputDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.Size = new System.Drawing.Size(259, 22);
            this.inputDescription.TabIndex = 64;
            this.inputDescription.Validating += new System.ComponentModel.CancelEventHandler(this.inputDescription_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "Opis:";
            // 
            // inputAuthor
            // 
            this.inputAuthor.Location = new System.Drawing.Point(132, 53);
            this.inputAuthor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputAuthor.Name = "inputAuthor";
            this.inputAuthor.Size = new System.Drawing.Size(259, 22);
            this.inputAuthor.TabIndex = 62;
            this.inputAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.inputAuthor_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Ime autora:";
            // 
            // inputBookName
            // 
            this.inputBookName.Location = new System.Drawing.Point(132, 21);
            this.inputBookName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputBookName.Name = "inputBookName";
            this.inputBookName.Size = new System.Drawing.Size(259, 22);
            this.inputBookName.TabIndex = 61;
            this.inputBookName.Validating += new System.ComponentModel.CancelEventHandler(this.inputBookName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
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
            this.cbCategories.Location = new System.Drawing.Point(132, 256);
            this.cbCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(259, 123);
            this.cbCategories.TabIndex = 71;
            this.cbCategories.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategories_Validating);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(307, 397);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(78, 21);
            this.cbIsActive.TabIndex = 72;
            this.cbIsActive.Text = "IsActive";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(132, 119);
            this.dtpReleaseDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(265, 22);
            this.dtpReleaseDate.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 74;
            this.label4.Text = "Datum izdavanja";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(277, 174);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(114, 51);
            this.btnUpload.TabIndex = 75;
            this.btnUpload.Text = "Upload PDF";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(156, 174);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(115, 51);
            this.btnDownload.TabIndex = 76;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // BooksEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 476);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private Button btnUpload;
        private Button btnDownload;
    }
}