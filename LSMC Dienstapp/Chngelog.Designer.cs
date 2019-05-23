namespace LSMC_Dienstapp
{
    partial class Changelog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Changelog));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.changelogHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changelogHinzufügenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // changelogHinzufügenToolStripMenuItem
            // 
            this.changelogHinzufügenToolStripMenuItem.Name = "changelogHinzufügenToolStripMenuItem";
            this.changelogHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.changelogHinzufügenToolStripMenuItem.Text = "Changelog hinzufügen";
            this.changelogHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.changelogHinzufügenToolStripMenuItem_Click);
            // 
            // Changelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Changelog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Changelogs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Changelog_FormClosing);
            this.Load += new System.EventHandler(this.Changelog_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Changelog_ClientSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changelogHinzufügenToolStripMenuItem;
    }
}