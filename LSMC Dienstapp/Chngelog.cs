using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LSMC_Dienstapp
{
    public partial class Changelog : Form
    {
        RichTextBox Changelogbox;
        Button Neuerchangelog;
        RichTextBox Neuerchangelogbox;
        TextBox Neuerchangelogtitel;
        MysqlClass db;

        public Changelog()
        {
            InitializeComponent();
            db = new MysqlClass();
            Generate_Richtextbox();
            Generate_Changelogwriting();
            Fill_Changelog();
            if(Form1.admin == 1)
            {
                menuStrip1.Visible = true;
            }
        }

        private void Changelog_FormClosing(object sender, FormClosingEventArgs e)
        {
            formposition.WritePosition(this, "Changelog");
        }

        private void Changelog_Load(object sender, EventArgs e)
        {
            formposition.ReadPosition(this, "Changelog");
        }

        private void Generate_Richtextbox()
        {

            Changelogbox = new RichTextBox();
            Changelogbox.Dock = DockStyle.Fill;
            Changelogbox.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            Changelogbox.Enabled = false;

            this.Controls.Add(Changelogbox);
        }

        private void Generate_Changelogwriting()
        {
            Neuerchangelogtitel = new TextBox();
            Neuerchangelogtitel.Width = this.ClientSize.Width - 40;
            Neuerchangelogtitel.Left = 20;
            Neuerchangelogtitel.Text = "Titel";
            Neuerchangelogtitel.Top = 30;
            Neuerchangelogtitel.Enter += new EventHandler(Neuerchangelogtitel_Enter);
            Neuerchangelogtitel.Visible = false;
            this.Controls.Add(Neuerchangelogtitel);
            Neuerchangelogbox = new RichTextBox();
            Neuerchangelogbox.Width = this.ClientSize.Width - 40;
            Neuerchangelogbox.Height = this.ClientSize.Height - 30 - 80;
            Neuerchangelogbox.Top = 60;
            Neuerchangelogbox.Left = 20;
            Neuerchangelogbox.Visible = false;
            this.Controls.Add(Neuerchangelogbox);
            Neuerchangelog = new Button();
            Neuerchangelog.Width = this.ClientSize.Width - 40;
            Neuerchangelog.Top = 30 + Neuerchangelogbox.Height + 20 + 20;
            Neuerchangelog.Height = 30;
            Neuerchangelog.Left = 20;
            Neuerchangelog.Visible = false;
            Neuerchangelog.Text = "Changelog erstellen";
            Neuerchangelog.Click += new EventHandler(Neuerchangelog_Click);
            this.Controls.Add(Neuerchangelog);
        }

        private void Fill_Changelog()
        {
            Changelogbox.Visible = true;
            var cl = db.Select("SELECT * FROM Changelog ORDER BY id DESC", "Changelog");
            var cl_zaehler = db.zaehler;
            db.Update("UPDATE User SET cl = '" + cl[0][0] + "' WHERE id = '" + Form1.userid + "' AND cl != '" + cl[0][0] + "'");
            var temp_text = "";
            if (Form1.admin == 1) temp_text += "\r";
            for (int i = 0; i < cl_zaehler; i++)
            {
                if (i > 0) temp_text += "\r\r\r";
                temp_text += cl[1][i] + " --- " + cl[3][i];
                temp_text += "\r\r";
                temp_text += cl[2][i];
            }
            Changelogbox.Text = temp_text;
        }

        private void changelogHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changelogbox.Visible = false;
            Neuerchangelogtitel.Visible = true;
            Neuerchangelogbox.Visible = true;
            Neuerchangelog.Visible = true;
        }
        

        private void Neuerchangelogtitel_Enter(object sender, EventArgs e)
        {
            if(Neuerchangelogtitel.Text == "Titel")
            {
                Neuerchangelogtitel.Text = "";
            }
        }

        private void Neuerchangelog_Click(object sender, EventArgs e)
        {
            if(Neuerchangelogtitel.Text != "Titel" && Neuerchangelogtitel.Text != "")
            {
                if (Neuerchangelogbox.Text != "")
                {
                    Neuerchangelog.Visible = false;
                    Neuerchangelogbox.Visible = false;
                    Neuerchangelogtitel.Visible = false;
                    db.Insert("INSERT INTO Changelog (`titel`, `text`, `datum`) VALUES ('" + Neuerchangelogtitel.Text + "','" + Neuerchangelogbox.Text + "',NOW())");
                    Fill_Changelog();
                    notification.Show("Neuer Changelog eingetragen!", AlertType.success);
                } else
                {
                    notification.Show("Kein Changelogtext eingegeben!", AlertType.info);
                }
            } else
            {
                notification.Show("Kein Titel eingetragen!", AlertType.info);
            }
        }

        private void Changelog_ClientSizeChanged(object sender, EventArgs e)
        {
            Neuerchangelogtitel.Width = this.ClientSize.Width - 40;
            Neuerchangelogbox.Width = this.ClientSize.Width - 40;
            Neuerchangelogbox.Height = this.ClientSize.Height - 30 - 80;
            Neuerchangelog.Width = this.ClientSize.Width - 40;
            Neuerchangelog.Top = 30 + Neuerchangelogbox.Height + 20 + 20;
        }
    }
}
