using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LSMC_Dienstapp
{
    public partial class Verwaltung_Manage : Form
    {
        private Custominputbox y;
        private int id;
        private int dbid;
        private DateTime beitritt;
        private int rang;
        private string formular;

        private int brang;    // Bearbeiter Rang
        public DateTime jetzt;

        dbConnection db1 = new dbConnection();

        private Verwaltung verwaltung;
        private Archiv archivierung;

        public Verwaltung_Manage()
        {
            InitializeComponent();
            jetzt = DateTime.Now;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LSMC-DienstApp");
            db1.openConnection();
            var result = db1.readerSQL("SELECT rang FROM User WHERE apikey = '" + key.GetValue("API") + "'");
            result.Read();
            Brang = Convert.ToInt32(result[0]);
            db1.closeConnection();
        }

        public void PruefeUser()
        {
            db1.openConnection();
            MySqlDataReader result;
            switch (Formular)
            {
                case "Archiv":
                    button1.Text = "Kommentar bearbeiten";
                    this.Text = "Archivverwaltung";
                    result = db1.readerSQL("SELECT uninvite, username FROM User WHERE id = '" + Id + "'");
                    result.Read();
                    label1.Text = result[1].ToString() + " (" + Id + ") - Datenbankid (" + DBId + ")";
                    break;
                case "Verwaltung":
                result = db1.readerSQL("SELECT uninvite, username FROM User WHERE id = '" + Id + "'");
                result.Read();
                label1.Text = result[1].ToString() + " (" + Id + ")";
                if (Convert.ToInt32(result[0]) == 0)
                {
                    button1.Text = "Uninvite vorschlagen";
                }
                else if (Convert.ToInt32(result[0]) == 1)
                {
                    button1.Text = "Uninvite zurückziehen";
                    if (Brang >= 11)
                    {
                        button1.Text = "Uninvite bestätigen?";
                    }
                }
                    break;
                default:
                    MessageBox.Show("Unerreichbares Formular!");
                    break;
            }
            db1.closeConnection();
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                // MessageBox.Show("Benutzer wurde gesetzt auf " + this.id.ToString());
            }
        }

        public int Brang
        {
            get
            {
                return this.brang;
            }
            set
            {
                this.brang = value;
            }
        }

        public Verwaltung Verwaltung
        {
            get
            {
                return this.verwaltung;
            }
            set
            {
                this.verwaltung = value;
            }
        }

        public Archiv Archivierung
        {
            get
            {
                return this.archivierung;
            }
            set
            {
                this.archivierung = value;
            }
        }

        public string Formular
        {
            get
            {
                return this.formular;
            }
            set
            {
                this.formular = value;
            }
        }

        public int DBId
        {
            get
            {
                return this.dbid;
            }
            set
            {
                this.dbid = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (button1.Text)
            {
                case "Uninvite zurückziehen":
                    db1.openConnection();
                    db1.ExecuteSQL("UPDATE User SET uninvite = '0' WHERE id = '" + Id + "'");
                    db1.closeConnection();
                    MessageBox.Show("Uninvite zurückgezogen!");
                    break;
                case "Uninvite vorschlagen":
                    db1.openConnection();
                    db1.ExecuteSQL("UPDATE User SET uninvite = '1' WHERE id = '" + Id + "'");
                    db1.closeConnection();
                    MessageBox.Show("Uninvite vorgeschlagen!");
                    break;
                case "Uninvite bestätigen?":
                    CustomMessageBox cm = new CustomMessageBox();
                    cm.Text = "Bestätigung";
                    cm.Uebergabetext = "Uninvite durchführen?";
                    cm.Button1 = "Entlassen";
                    cm.Button2 = "Zurückziehen";
                    cm.ShowDialog();
                    if (cm.Ausgabe)
                    {
                        db1.openConnection();
                        db1.ExecuteSQL("UPDATE User SET uninvite = '2' WHERE id = '" + Id + "'");
                        db1.closeConnection();
                        MessageBox.Show("Mitarbeiter entlassen!");
                        TimeSpan sp = jetzt - Beitritt;
                        if (Rang == 0 && Convert.ToInt32(sp.Days) >= 15 && Convert.ToInt32(sp.Days) <= 30)
                        {
                            MessageBox.Show("Mitarbeiter muss auch gemeldet werden bei Frakverwaltung");
                        }
                        if(Rang != 0 && Convert.ToInt32(sp.Days) <= 30)
                        {
                            MessageBox.Show("Mitarbeiter muss auch gemeldet werden bei Frakverwaltung");
                        }
                        db1.openConnection();
                        db1.ExecuteSQL("INSERT INTO Archiv (userid, austritt, beitritt, rang) VALUES ('"+Id+"','"+jetzt.Date.ToString("yyyy-MM-dd").ToString()+"','"+Beitritt.Date.ToString("yyyy-MM-dd") + "', '" + Rang + "')");
                        db1.closeConnection();
                    } else
                    {
                        db1.openConnection();
                        db1.ExecuteSQL("UPDATE User SET uninvite = '0' WHERE id = '" + Id + "'");
                        db1.closeConnection();
                        MessageBox.Show("Uninvite zurückgezogen!");
                    }
                    break;
                case "Kommentar bearbeiten":
                    switch (Formular)
                    {
                        case "Archiv":
                            y = new Custominputbox(this);
                            y.DBId = DBId;
                            y.Formular = "Archiv";
                            y.Aktion = "Kommentar";
                            y.Lade_Daten();
                            y.ShowDialog();
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Da ging was schief!");
                    break;
            }
            this.Close();
        }

        public void Close_Verwaltung()
        {
            switch (Formular)
            {
                case "Archiv":
                    Archivierung.Uebersicht();
                    break;
            }
        }

        private void Verwaltung_Manage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Verwaltung != null)
            {
                Verwaltung.Uebersicht();
            }
        }

        public DateTime Beitritt
        {
            get
            {
                return this.beitritt;
            }
            set
            {
                this.beitritt = value;
            }
        }

        public int Rang
        {
            get
            {
                return this.rang;
            }
            set
            {
                this.rang = value;
            }
        }
    }
}
