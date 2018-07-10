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
            this.pbLoading = new MetroFramework.Controls.MetroProgressBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dodajSlikuButton = new System.Windows.Forms.Button();
            this.inputPicture = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(290, 365);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(104, 30);
            this.btnAction.TabIndex = 70;
            this.btnAction.Text = "Dodaj";
            this.btnAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // inputDescription
            // 
            this.inputDescription.Location = new System.Drawing.Point(131, 74);
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.Size = new System.Drawing.Size(259, 20);
            this.inputDescription.TabIndex = 64;
            this.inputDescription.Validating += new System.ComponentModel.CancelEventHandler(this.inputDescription_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Opis:";
            // 
            // inputAuthor
            // 
            this.inputAuthor.Location = new System.Drawing.Point(131, 48);
            this.inputAuthor.Name = "inputAuthor";
            this.inputAuthor.Size = new System.Drawing.Size(259, 20);
            this.inputAuthor.TabIndex = 62;
            this.inputAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.inputAuthor_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Ime autora:";
            // 
            // inputBookName
            // 
            this.inputBookName.Location = new System.Drawing.Point(131, 20);
            this.inputBookName.Name = "inputBookName";
            this.inputBookName.Size = new System.Drawing.Size(259, 20);
            this.inputBookName.TabIndex = 61;
            this.inputBookName.Validating += new System.ComponentModel.CancelEventHandler(this.inputBookName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 20);
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
            this.cbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(12, 226);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(274, 109);
            this.cbCategories.TabIndex = 71;
            this.cbCategories.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategories_Validating);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(320, 158);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(64, 17);
            this.cbIsActive.TabIndex = 72;
            this.cbIsActive.Text = "IsActive";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(131, 103);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(259, 20);
            this.dtpReleaseDate.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Datum izdavanja";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(302, 180);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(92, 41);
            this.btnUpload.TabIndex = 75;
            this.btnUpload.Text = "Upload PDF";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            this.btnUpload.Validating += new System.ComponentModel.CancelEventHandler(this.btnUpload_Validating);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(196, 180);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(92, 41);
            this.btnDownload.TabIndex = 76;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.Location = new System.Drawing.Point(33, 401);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoading.Size = new System.Drawing.Size(354, 23);
            this.pbLoading.TabIndex = 77;
            this.pbLoading.Visible = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(293, 226);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(95, 133);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 78;
            this.pictureBox.TabStop = false;
            // 
            // dodajSlikuButton
            // 
            this.dodajSlikuButton.Location = new System.Drawing.Point(333, 129);
            this.dodajSlikuButton.Name = "dodajSlikuButton";
            this.dodajSlikuButton.Size = new System.Drawing.Size(57, 23);
            this.dodajSlikuButton.TabIndex = 79;
            this.dodajSlikuButton.Text = "Dodaj";
            this.dodajSlikuButton.UseVisualStyleBackColor = true;
            this.dodajSlikuButton.Click += new System.EventHandler(this.dodajSlikuButton_Click);
            // 
            // inputPicture
            // 
            this.inputPicture.Location = new System.Drawing.Point(131, 129);
            this.inputPicture.Name = "inputPicture";
            this.inputPicture.Size = new System.Drawing.Size(200, 20);
            this.inputPicture.TabIndex = 80;
            this.inputPicture.TabStop = false;
            this.inputPicture.Validating += new System.ComponentModel.CancelEventHandler(this.inputPicture_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "Slika:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // BooksEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 448);
            this.Controls.Add(this.dodajSlikuButton);
            this.Controls.Add(this.inputPicture);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.pbLoading);
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
            this.Name = "BooksEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodaj knjigu";
            this.Load += new System.EventHandler(this.BooksEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
        private MetroFramework.Controls.MetroProgressBar pbLoading;
        private PictureBox pictureBox;
        private Button dodajSlikuButton;
        private TextBox inputPicture;
        private Label label6;
        private OpenFileDialog openFileDialog;
    }
}