namespace LSMC_Dienstapp
{
    partial class Uninvite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uninvite));
            this.GBMitarbeiter = new System.Windows.Forms.GroupBox();
            this.CBMitarbeiter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBbemerkung = new System.Windows.Forms.TextBox();
            this.CBuninvite = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBDocuments = new System.Windows.Forms.CheckBox();
            this.CBMeldung = new System.Windows.Forms.CheckBox();
            this.BtnQuest = new System.Windows.Forms.Button();
            this.BtnBestaetigen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CBVorschlag = new System.Windows.Forms.CheckBox();
            this.GBMitarbeiter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBMitarbeiter
            // 
            this.GBMitarbeiter.Controls.Add(this.CBMitarbeiter);
            this.GBMitarbeiter.Location = new System.Drawing.Point(16, 88);
            this.GBMitarbeiter.Name = "GBMitarbeiter";
            this.GBMitarbeiter.Size = new System.Drawing.Size(150, 45);
            this.GBMitarbeiter.TabIndex = 4;
            this.GBMitarbeiter.TabStop = false;
            this.GBMitarbeiter.Text = "Mitarbeiter";
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBbemerkung);
            this.groupBox1.Location = new System.Drawing.Point(16, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 45);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bemerkung";
            // 
            // TBbemerkung
            // 
            this.TBbemerkung.Location = new System.Drawing.Point(6, 17);
            this.TBbemerkung.Name = "TBbemerkung";
            this.TBbemerkung.Size = new System.Drawing.Size(138, 20);
            this.TBbemerkung.TabIndex = 5;
            // 
            // CBuninvite
            // 
            this.CBuninvite.AutoSize = true;
            this.CBuninvite.Location = new System.Drawing.Point(30, 29);
            this.CBuninvite.Name = "CBuninvite";
            this.CBuninvite.Size = new System.Drawing.Size(78, 17);
            this.CBuninvite.TabIndex = 5;
            this.CBuninvite.Text = "Entlassen?";
            this.CBuninvite.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBDocuments);
            this.groupBox2.Controls.Add(this.CBMeldung);
            this.groupBox2.Controls.Add(this.CBuninvite);
            this.groupBox2.Location = new System.Drawing.Point(16, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 111);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Erledigungen";
            // 
            // CBDocuments
            // 
            this.CBDocuments.AutoSize = true;
            this.CBDocuments.Location = new System.Drawing.Point(30, 77);
            this.CBDocuments.Name = "CBDocuments";
            this.CBDocuments.Size = new System.Drawing.Size(92, 17);
            this.CBDocuments.TabIndex = 7;
            this.CBDocuments.Text = "Ausgetragen?";
            this.CBDocuments.UseVisualStyleBackColor = true;
            // 
            // CBMeldung
            // 
            this.CBMeldung.AutoSize = true;
            this.CBMeldung.Location = new System.Drawing.Point(30, 53);
            this.CBMeldung.Name = "CBMeldung";
            this.CBMeldung.Size = new System.Drawing.Size(77, 17);
            this.CBMeldung.TabIndex = 6;
            this.CBMeldung.Text = "Gemeldet?";
            this.CBMeldung.UseVisualStyleBackColor = true;
            // 
            // BtnQuest
            // 
            this.BtnQuest.Location = new System.Drawing.Point(160, -1);
            this.BtnQuest.Name = "BtnQuest";
            this.BtnQuest.Size = new System.Drawing.Size(18, 23);
            this.BtnQuest.TabIndex = 1;
            this.BtnQuest.Text = "?";
            this.BtnQuest.UseVisualStyleBackColor = true;
            this.BtnQuest.Click += new System.EventHandler(this.BtnQuest_Click);
            // 
            // BtnBestaetigen
            // 
            this.BtnBestaetigen.Location = new System.Drawing.Point(49, 307);
            this.BtnBestaetigen.Name = "BtnBestaetigen";
            this.BtnBestaetigen.Size = new System.Drawing.Size(75, 23);
            this.BtnBestaetigen.TabIndex = 8;
            this.BtnBestaetigen.Text = "Speichern";
            this.BtnBestaetigen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CBVorschlag);
            this.groupBox3.Location = new System.Drawing.Point(16, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 54);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vorschlag";
            // 
            // CBVorschlag
            // 
            this.CBVorschlag.AutoSize = true;
            this.CBVorschlag.Location = new System.Drawing.Point(33, 20);
            this.CBVorschlag.Name = "CBVorschlag";
            this.CBVorschlag.Size = new System.Drawing.Size(37, 17);
            this.CBVorschlag.TabIndex = 0;
            this.CBVorschlag.Text = "Ja";
            this.CBVorschlag.UseVisualStyleBackColor = true;
            this.CBVorschlag.CheckedChanged += new System.EventHandler(this.CBVorschlag_CheckedChanged);
            // 
            // Uninvite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 342);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnBestaetigen);
            this.Controls.Add(this.BtnQuest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBMitarbeiter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Uninvite";
            this.Text = "Form2";
            this.GBMitarbeiter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBMitarbeiter;
        private System.Windows.Forms.ComboBox CBMitarbeiter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBbemerkung;
        private System.Windows.Forms.CheckBox CBuninvite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CBDocuments;
        private System.Windows.Forms.CheckBox CBMeldung;
        private System.Windows.Forms.Button BtnQuest;
        private System.Windows.Forms.Button BtnBestaetigen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CBVorschlag;
    }
}