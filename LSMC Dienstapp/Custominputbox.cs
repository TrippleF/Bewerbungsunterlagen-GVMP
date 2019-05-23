using System;
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
    public partial class Custominputbox : Form
    {
        private string formular;
        private string aktion;
        private int dbid;

        private Verwaltung_Manage x;
        private MysqlClass db;

        public Custominputbox(Verwaltung_Manage u)
        {
            InitializeComponent();
            db = new MysqlClass();
            x = u;
        }

        public void Lade_Daten()
        {
            switch (Formular)
            {
                case "Archiv":
                    if(Aktion == "Kommentar")
                    {
                        List<string>[] ausgabe = db.Select("SELECT * FROM Archiv WHERE id='" + DBId + "'","Archiv");
                        textBox1.Text = ausgabe[3][0].ToString();
                    }
                    break;
            }
        }

        public string Formular
        {
            set
            {
                this.formular = value;
            }
            get
            {
                return this.formular;
            }
        }

        public string Aktion
        {
            set
            {
                this.aktion = value;
            }
            get
            {
                return this.aktion;
            }
        }

        public int DBId
        {
            set
            {
                this.dbid = value;
            }
            get
            {
                return this.dbid;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Formular)
            {
                case "Archiv":
                    if(Aktion == "Kommentar")
                    {
                        db.Update("UPDATE Archiv SET bemerkung = '" + textBox1.Text + "' WHERE id = '" + DBId + "'");
                        MessageBox.Show("Bemerkung erfolgreich geändert");
                        this.Close();
                    }
                    break;
            }
        }

        private void Custominputbox_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (Formular)
            {
                case "Archiv":
                    x.Close_Verwaltung();
                    break;
            }
        }
    }
}
