namespace eKnjiznica.AdminUI.UI.Logs
{
    partial class LogsForm
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
            this.gvLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // gvLogs
            // 
            this.gvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLogs.Location = new System.Drawing.Point(13, 12);
            this.gvLogs.Name = "gvLogs";
            this.gvLogs.RowTemplate.Height = 24;
            this.gvLogs.Size = new System.Drawing.Size(775, 426);
            this.gvLogs.TabIndex = 0;
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gvLogs);
            this.Name = "LogsForm";
            this.Text = "LogsForm";
            this.Load += new System.EventHandler(this.LogsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvLogs;
    }
}