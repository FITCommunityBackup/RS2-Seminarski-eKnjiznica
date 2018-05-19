namespace eKnjiznica.AdminUI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administratoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjaviSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administratoriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administratoriToolStripMenuItem,
            this.odjaviSeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administratoriToolStripMenuItem
            // 
            this.administratoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administratoriToolStripMenuItem1,
            this.logoviToolStripMenuItem});
            this.administratoriToolStripMenuItem.Name = "administratoriToolStripMenuItem";
            this.administratoriToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.administratoriToolStripMenuItem.Text = "Administracija";
            this.administratoriToolStripMenuItem.Click += new System.EventHandler(this.administratoriToolStripMenuItem_Click);
            // 
            // odjaviSeToolStripMenuItem
            // 
            this.odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            this.odjaviSeToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.odjaviSeToolStripMenuItem.Text = "Odjavi se";
            this.odjaviSeToolStripMenuItem.Click += new System.EventHandler(this.odjaviSeToolStripMenuItem_Click);
            // 
            // administratoriToolStripMenuItem1
            // 
            this.administratoriToolStripMenuItem1.Name = "administratoriToolStripMenuItem1";
            this.administratoriToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.administratoriToolStripMenuItem1.Text = "Administratori";
            this.administratoriToolStripMenuItem1.Click += new System.EventHandler(this.administratoriToolStripMenuItem1_Click);
            // 
            // logoviToolStripMenuItem
            // 
            this.logoviToolStripMenuItem.Name = "logoviToolStripMenuItem";
            this.logoviToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.logoviToolStripMenuItem.Text = "Logovi";
            this.logoviToolStripMenuItem.Click += new System.EventHandler(this.logoviToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1176, 770);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administratoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjaviSeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administratoriToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoviToolStripMenuItem;
    }
}