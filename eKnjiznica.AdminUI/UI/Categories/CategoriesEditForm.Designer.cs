namespace eKnjiznica.AdminUI.UI.Categories
{
    partial class CategoriesEditForm
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.inputCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(260, 70);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(199, 54);
            this.btnUpdate.TabIndex = 73;
            this.btnUpdate.Text = "Izmjeni";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // inputCategoryName
            // 
            this.inputCategoryName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputCategoryName.Location = new System.Drawing.Point(154, 13);
            this.inputCategoryName.Margin = new System.Windows.Forms.Padding(4);
            this.inputCategoryName.Name = "inputCategoryName";
            this.inputCategoryName.Size = new System.Drawing.Size(305, 22);
            this.inputCategoryName.TabIndex = 72;
            this.inputCategoryName.Validating += new System.ComponentModel.CancelEventHandler(this.inputCategoryName_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 71;
            this.label1.Text = "Naziv kategorije";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(383, 42);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(76, 21);
            this.cbActive.TabIndex = 74;
            this.cbActive.Text = "Aktivan";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // CategoriesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 137);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.inputCategoryName);
            this.Controls.Add(this.label1);
            this.Name = "CategoriesEditForm";
            this.Text = "CategoriesEditForm";
            this.Load += new System.EventHandler(this.CategoriesEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox inputCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox cbActive;
    }
}