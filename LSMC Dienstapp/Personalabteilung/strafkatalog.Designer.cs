namespace LSMC_Dienstapp
{
    partial class strafkatalog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(strafkatalog));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.leichteVergehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalschwereVergehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mittelschwereVergehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schwereVergehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entfernenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leichteVergehenToolStripMenuItem,
            this.minimalschwereVergehenToolStripMenuItem,
            this.mittelschwereVergehenToolStripMenuItem,
            this.schwereVergehenToolStripMenuItem,
            this.hinzufügenToolStripMenuItem,
            this.entfernenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // leichteVergehenToolStripMenuItem
            // 
            this.leichteVergehenToolStripMenuItem.Name = "leichteVergehenToolStripMenuItem";
            this.leichteVergehenToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.leichteVergehenToolStripMenuItem.Text = "leichte Vergehen";
            this.leichteVergehenToolStripMenuItem.Click += new System.EventHandler(this.leichteVergehenToolStripMenuItem_Click);
            // 
            // minimalschwereVergehenToolStripMenuItem
            // 
            this.minimalschwereVergehenToolStripMenuItem.Name = "minimalschwereVergehenToolStripMenuItem";
            this.minimalschwereVergehenToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.minimalschwereVergehenToolStripMenuItem.Text = "minimalschwere Vergehen";
            this.minimalschwereVergehenToolStripMenuItem.Click += new System.EventHandler(this.minimalschwereVergehenToolStripMenuItem_Click);
            // 
            // mittelschwereVergehenToolStripMenuItem
            // 
            this.mittelschwereVergehenToolStripMenuItem.Name = "mittelschwereVergehenToolStripMenuItem";
            this.mittelschwereVergehenToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.mittelschwereVergehenToolStripMenuItem.Text = "mittelschwere Vergehen";
            this.mittelschwereVergehenToolStripMenuItem.Click += new System.EventHandler(this.mittelschwereVergehenToolStripMenuItem_Click);
            // 
            // schwereVergehenToolStripMenuItem
            // 
            this.schwereVergehenToolStripMenuItem.Name = "schwereVergehenToolStripMenuItem";
            this.schwereVergehenToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.schwereVergehenToolStripMenuItem.Text = "schwere Vergehen";
            this.schwereVergehenToolStripMenuItem.Click += new System.EventHandler(this.schwereVergehenToolStripMenuItem_Click);
            // 
            // hinzufügenToolStripMenuItem
            // 
            this.hinzufügenToolStripMenuItem.Name = "hinzufügenToolStripMenuItem";
            this.hinzufügenToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.hinzufügenToolStripMenuItem.Text = "Hinzufügen";
            this.hinzufügenToolStripMenuItem.Click += new System.EventHandler(this.hinzufügenToolStripMenuItem_Click);
            // 
            // entfernenToolStripMenuItem
            // 
            this.entfernenToolStripMenuItem.Name = "entfernenToolStripMenuItem";
            this.entfernenToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.entfernenToolStripMenuItem.Text = "Entfernen";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // strafkatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "strafkatalog";
            this.Text = "strafkatalog";
            this.Load += new System.EventHandler(this.strafkatalog_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem leichteVergehenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalschwereVergehenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mittelschwereVergehenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schwereVergehenToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem hinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entfernenToolStripMenuItem;
    }
}