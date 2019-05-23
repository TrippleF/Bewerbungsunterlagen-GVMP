namespace LSMC_Dienstapp { 
    partial class Verwaltungsuebersicht
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verwaltungsuebersicht));
            this.dGVerwaltung = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitarbeiterHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitarbeiterUpDownrankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountZurücksetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rang12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankUpBedinungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dGVerwaltung)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGVerwaltung
            // 
            this.dGVerwaltung.AllowUserToAddRows = false;
            this.dGVerwaltung.AllowUserToDeleteRows = false;
            this.dGVerwaltung.AllowUserToResizeColumns = false;
            this.dGVerwaltung.AllowUserToResizeRows = false;
            this.dGVerwaltung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGVerwaltung.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dGVerwaltung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVerwaltung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVerwaltung.Location = new System.Drawing.Point(0, 24);
            this.dGVerwaltung.Name = "dGVerwaltung";
            this.dGVerwaltung.Size = new System.Drawing.Size(984, 577);
            this.dGVerwaltung.TabIndex = 0;
            this.dGVerwaltung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVerwaltung_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalToolStripMenuItem,
            this.rang12ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitarbeiterHinzufügenToolStripMenuItem,
            this.mitarbeiterUpDownrankToolStripMenuItem,
            this.accountZurücksetzenToolStripMenuItem});
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.personalToolStripMenuItem.Text = "Personal";
            // 
            // mitarbeiterHinzufügenToolStripMenuItem
            // 
            this.mitarbeiterHinzufügenToolStripMenuItem.Name = "mitarbeiterHinzufügenToolStripMenuItem";
            this.mitarbeiterHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.mitarbeiterHinzufügenToolStripMenuItem.Text = "Mitarbeiter hinzufügen";
            this.mitarbeiterHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.mitarbeiterHinzufügenToolStripMenuItem_Click);
            // 
            // mitarbeiterUpDownrankToolStripMenuItem
            // 
            this.mitarbeiterUpDownrankToolStripMenuItem.Name = "mitarbeiterUpDownrankToolStripMenuItem";
            this.mitarbeiterUpDownrankToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.mitarbeiterUpDownrankToolStripMenuItem.Text = "Mitarbeiter Up-/Downrank";
            this.mitarbeiterUpDownrankToolStripMenuItem.Click += new System.EventHandler(this.mitarbeiterUpDownrankToolStripMenuItem_Click);
            // 
            // accountZurücksetzenToolStripMenuItem
            // 
            this.accountZurücksetzenToolStripMenuItem.Name = "accountZurücksetzenToolStripMenuItem";
            this.accountZurücksetzenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.accountZurücksetzenToolStripMenuItem.Text = "Account zurücksetzen";
            this.accountZurücksetzenToolStripMenuItem.Click += new System.EventHandler(this.accountZurücksetzenToolStripMenuItem_Click);
            // 
            // Verwaltungsuebersicht
            // rang12ToolStripMenuItem
            // 
            this.rang12ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rankUpBedinungenToolStripMenuItem});
            this.rang12ToolStripMenuItem.Name = "rang12ToolStripMenuItem";
            this.rang12ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.rang12ToolStripMenuItem.Text = "Rang 12";
            // 
            // rankUpBedinungenToolStripMenuItem
            // 
            this.rankUpBedinungenToolStripMenuItem.Name = "rankUpBedinungenToolStripMenuItem";
            this.rankUpBedinungenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.rankUpBedinungenToolStripMenuItem.Text = "RankUp-Bedinungen";
            this.rankUpBedinungenToolStripMenuItem.Click += new System.EventHandler(this.rankUpBedinungenToolStripMenuItem_Click);
            // 
            // Verwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Controls.Add(this.dGVerwaltung);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Verwaltungsuebersicht";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verwaltung";
            ((System.ComponentModel.ISupportInitialize)(this.dGVerwaltung)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVerwaltung;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitarbeiterHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitarbeiterUpDownrankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountZurücksetzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rang12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankUpBedinungenToolStripMenuItem;
    }
}