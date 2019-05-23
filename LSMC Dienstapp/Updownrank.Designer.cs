namespace LSMC_Dienstapp
{
    partial class Updownrank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updownrank));
            this.CBMitarbeiter = new System.Windows.Forms.ComboBox();
            this.GbAktRang = new System.Windows.Forms.GroupBox();
            this.Lblrang = new System.Windows.Forms.Label();
            this.GbWhorang = new System.Windows.Forms.GroupBox();
            this.CBnewrang = new System.Windows.Forms.ComboBox();
            this.GBMitarbeiter = new System.Windows.Forms.GroupBox();
            this.Gbaenderung = new System.Windows.Forms.GroupBox();
            this.CBchange = new System.Windows.Forms.ComboBox();
            this.TBbemerkung = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btnaccept = new System.Windows.Forms.Button();
            this.GbAktRang.SuspendLayout();
            this.GbWhorang.SuspendLayout();
            this.GBMitarbeiter.SuspendLayout();
            this.Gbaenderung.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBMitarbeiter
            // 
            this.CBMitarbeiter.Cursor = System.Windows.Forms.Cursors.Default;
            this.CBMitarbeiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBMitarbeiter.FormattingEnabled = true;
            this.CBMitarbeiter.Location = new System.Drawing.Point(6, 18);
            this.CBMitarbeiter.Name = "CBMitarbeiter";
            this.CBMitarbeiter.Size = new System.Drawing.Size(138, 21);
            this.CBMitarbeiter.TabIndex = 0;
            this.CBMitarbeiter.SelectedValueChanged += new System.EventHandler(this.CBMitarbeiter_SelectedValueChanged);
            // 
            // GbAktRang
            // 
            this.GbAktRang.Controls.Add(this.Lblrang);
            this.GbAktRang.Location = new System.Drawing.Point(19, 64);
            this.GbAktRang.Name = "GbAktRang";
            this.GbAktRang.Size = new System.Drawing.Size(144, 45);
            this.GbAktRang.TabIndex = 1;
            this.GbAktRang.TabStop = false;
            this.GbAktRang.Text = "Aktueller Rang";
            // 
            // Lblrang
            // 
            this.Lblrang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lblrang.AutoSize = true;
            this.Lblrang.Location = new System.Drawing.Point(58, 20);
            this.Lblrang.Name = "Lblrang";
            this.Lblrang.Size = new System.Drawing.Size(38, 13);
            this.Lblrang.TabIndex = 0;
            this.Lblrang.Text = "Center";
            // 
            // GbWhorang
            // 
            this.GbWhorang.Controls.Add(this.CBnewrang);
            this.GbWhorang.Location = new System.Drawing.Point(19, 115);
            this.GbWhorang.Name = "GbWhorang";
            this.GbWhorang.Size = new System.Drawing.Size(144, 45);
            this.GbWhorang.TabIndex = 2;
            this.GbWhorang.TabStop = false;
            this.GbWhorang.Text = "Welcher Rang?";
            // 
            // CBnewrang
            // 
            this.CBnewrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBnewrang.FormattingEnabled = true;
            this.CBnewrang.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.CBnewrang.Location = new System.Drawing.Point(56, 19);
            this.CBnewrang.Name = "CBnewrang";
            this.CBnewrang.Size = new System.Drawing.Size(40, 21);
            this.CBnewrang.TabIndex = 0;
            // 
            // GBMitarbeiter
            // 
            this.GBMitarbeiter.Controls.Add(this.CBMitarbeiter);
            this.GBMitarbeiter.Location = new System.Drawing.Point(13, 13);
            this.GBMitarbeiter.Name = "GBMitarbeiter";
            this.GBMitarbeiter.Size = new System.Drawing.Size(150, 45);
            this.GBMitarbeiter.TabIndex = 3;
            this.GBMitarbeiter.TabStop = false;
            this.GBMitarbeiter.Text = "Mitarbeiter";
            // 
            // Gbaenderung
            // 
            this.Gbaenderung.Controls.Add(this.CBchange);
            this.Gbaenderung.Location = new System.Drawing.Point(170, 13);
            this.Gbaenderung.Name = "Gbaenderung";
            this.Gbaenderung.Size = new System.Drawing.Size(150, 45);
            this.Gbaenderung.TabIndex = 4;
            this.Gbaenderung.TabStop = false;
            this.Gbaenderung.Text = "Art der Rangänderung";
            // 
            // CBchange
            // 
            this.CBchange.Cursor = System.Windows.Forms.Cursors.Default;
            this.CBchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBchange.FormattingEnabled = true;
            this.CBchange.Items.AddRange(new object[] {
            "Beförderung",
            "Degradierung",
            "Abteilung"});
            this.CBchange.Location = new System.Drawing.Point(6, 18);
            this.CBchange.Name = "CBchange";
            this.CBchange.Size = new System.Drawing.Size(138, 21);
            this.CBchange.TabIndex = 5;
            // 
            // TBbemerkung
            // 
            this.TBbemerkung.Location = new System.Drawing.Point(6, 17);
            this.TBbemerkung.Name = "TBbemerkung";
            this.TBbemerkung.Size = new System.Drawing.Size(138, 20);
            this.TBbemerkung.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBbemerkung);
            this.groupBox1.Location = new System.Drawing.Point(170, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bemerkung";
            // 
            // Btnaccept
            // 
            this.Btnaccept.Location = new System.Drawing.Point(176, 126);
            this.Btnaccept.Name = "Btnaccept";
            this.Btnaccept.Size = new System.Drawing.Size(138, 29);
            this.Btnaccept.TabIndex = 5;
            this.Btnaccept.Text = "Durchführen";
            this.Btnaccept.UseVisualStyleBackColor = true;
            this.Btnaccept.Click += new System.EventHandler(this.Btnaccept_Click);
            // 
            // Updownrank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 174);
            this.Controls.Add(this.Btnaccept);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Gbaenderung);
            this.Controls.Add(this.GBMitarbeiter);
            this.Controls.Add(this.GbWhorang);
            this.Controls.Add(this.GbAktRang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Updownrank";
            this.Text = "Updownrank";
            this.GbAktRang.ResumeLayout(false);
            this.GbAktRang.PerformLayout();
            this.GbWhorang.ResumeLayout(false);
            this.GBMitarbeiter.ResumeLayout(false);
            this.Gbaenderung.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBMitarbeiter;
        private System.Windows.Forms.GroupBox GbAktRang;
        private System.Windows.Forms.Label Lblrang;
        private System.Windows.Forms.GroupBox GbWhorang;
        private System.Windows.Forms.ComboBox CBnewrang;
        private System.Windows.Forms.GroupBox GBMitarbeiter;
        private System.Windows.Forms.GroupBox Gbaenderung;
        private System.Windows.Forms.ComboBox CBchange;
        private System.Windows.Forms.TextBox TBbemerkung;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btnaccept;
    }
}