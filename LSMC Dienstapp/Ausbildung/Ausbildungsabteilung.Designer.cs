namespace LSMC_Dienstapp
{
    partial class Ausbildungsabteilung
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ausbildungsabteilung));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGAusbildung = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.übersichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schulungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fahrsicherheitstrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwaltungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meistertaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prüfungstermineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prüfungsverteilungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prüfungseinladungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einweisungChecklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.termineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGAusbildung)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dGAusbildung);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 578);
            this.panel1.TabIndex = 0;
            // 
            // dGAusbildung
            // 
            this.dGAusbildung.AllowUserToAddRows = false;
            this.dGAusbildung.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dGAusbildung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGAusbildung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGAusbildung.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dGAusbildung.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dGAusbildung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGAusbildung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGAusbildung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGAusbildung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGAusbildung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGAusbildung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGAusbildung.DoubleBuffered = true;
            this.dGAusbildung.EnableHeadersVisualStyles = false;
            this.dGAusbildung.HeaderBgColor = System.Drawing.Color.White;
            this.dGAusbildung.HeaderForeColor = System.Drawing.Color.Black;
            this.dGAusbildung.Location = new System.Drawing.Point(0, 0);
            this.dGAusbildung.Name = "dGAusbildung";
            this.dGAusbildung.ReadOnly = true;
            this.dGAusbildung.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGAusbildung.Size = new System.Drawing.Size(986, 578);
            this.dGAusbildung.TabIndex = 0;
            this.dGAusbildung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGAusbildung_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.übersichtToolStripMenuItem,
            this.schulungenToolStripMenuItem,
            this.fahrsicherheitstrainingToolStripMenuItem,
            this.verwaltungToolStripMenuItem,
            this.meistertaskToolStripMenuItem,
            this.einweisungChecklistToolStripMenuItem,
            this.termineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // übersichtToolStripMenuItem
            // 
            this.übersichtToolStripMenuItem.Name = "übersichtToolStripMenuItem";
            this.übersichtToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.übersichtToolStripMenuItem.Text = "Übersicht";
            this.übersichtToolStripMenuItem.Click += new System.EventHandler(this.übersichtToolStripMenuItem_Click);
            // 
            // schulungenToolStripMenuItem
            // 
            this.schulungenToolStripMenuItem.Name = "schulungenToolStripMenuItem";
            this.schulungenToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.schulungenToolStripMenuItem.Text = "Schulungen";
            this.schulungenToolStripMenuItem.Click += new System.EventHandler(this.schulungenToolStripMenuItem_Click);
            // 
            // fahrsicherheitstrainingToolStripMenuItem
            // 
            this.fahrsicherheitstrainingToolStripMenuItem.Name = "fahrsicherheitstrainingToolStripMenuItem";
            this.fahrsicherheitstrainingToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.fahrsicherheitstrainingToolStripMenuItem.Text = "Fahrsicherheitstraining";
            this.fahrsicherheitstrainingToolStripMenuItem.Click += new System.EventHandler(this.fahrsicherheitstrainingToolStripMenuItem_Click);
            // 
            // verwaltungToolStripMenuItem
            // 
            this.verwaltungToolStripMenuItem.Name = "verwaltungToolStripMenuItem";
            this.verwaltungToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.verwaltungToolStripMenuItem.Text = "Prüfungsverwaltung";
            this.verwaltungToolStripMenuItem.Click += new System.EventHandler(this.verwaltungToolStripMenuItem_Click);
            // 
            // meistertaskToolStripMenuItem
            // 
            this.meistertaskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prüfungstermineToolStripMenuItem,
            this.prüfungsverteilungToolStripMenuItem,
            this.prüfungseinladungToolStripMenuItem,
            this.websiteToolStripMenuItem});
            this.meistertaskToolStripMenuItem.Name = "meistertaskToolStripMenuItem";
            this.meistertaskToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.meistertaskToolStripMenuItem.Text = "Links";
            this.meistertaskToolStripMenuItem.Visible = false;
            // 
            // prüfungstermineToolStripMenuItem
            // 
            this.prüfungstermineToolStripMenuItem.Name = "prüfungstermineToolStripMenuItem";
            this.prüfungstermineToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.prüfungstermineToolStripMenuItem.Text = "Prüfungstermine";
            this.prüfungstermineToolStripMenuItem.Click += new System.EventHandler(this.prüfungstermineToolStripMenuItem_Click);
            // 
            // prüfungsverteilungToolStripMenuItem
            // 
            this.prüfungsverteilungToolStripMenuItem.Name = "prüfungsverteilungToolStripMenuItem";
            this.prüfungsverteilungToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.prüfungsverteilungToolStripMenuItem.Text = "Prüfungsverteilung";
            this.prüfungsverteilungToolStripMenuItem.Click += new System.EventHandler(this.prüfungsverteilungToolStripMenuItem_Click);
            // 
            // prüfungseinladungToolStripMenuItem
            // 
            this.prüfungseinladungToolStripMenuItem.Name = "prüfungseinladungToolStripMenuItem";
            this.prüfungseinladungToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.prüfungseinladungToolStripMenuItem.Text = "Prüfungseinladung";
            this.prüfungseinladungToolStripMenuItem.Click += new System.EventHandler(this.prüfungseinladungToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // einweisungChecklistToolStripMenuItem
            // 
            this.einweisungChecklistToolStripMenuItem.Name = "einweisungChecklistToolStripMenuItem";
            this.einweisungChecklistToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.einweisungChecklistToolStripMenuItem.Text = "EinweisungChecklist";
            this.einweisungChecklistToolStripMenuItem.Click += new System.EventHandler(this.einweisungChecklistToolStripMenuItem_Click);
            // 
            // termineToolStripMenuItem
            // 
            this.termineToolStripMenuItem.Name = "termineToolStripMenuItem";
            this.termineToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.termineToolStripMenuItem.Text = "Termine";
            this.termineToolStripMenuItem.Click += new System.EventHandler(this.termineToolStripMenuItem_Click);
            // 
            // Ausbildungsabteilung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ausbildungsabteilung";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Ausbildungsabteilung";
            this.Load += new System.EventHandler(this.Ausbildungsabteilung_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGAusbildung)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem übersichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schulungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fahrsicherheitstrainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verwaltungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meistertaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prüfungstermineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prüfungsverteilungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einweisungChecklistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prüfungseinladungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem termineToolStripMenuItem;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dGAusbildung;
    }
}