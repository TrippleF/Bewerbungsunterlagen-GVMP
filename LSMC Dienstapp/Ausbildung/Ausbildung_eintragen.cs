using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSMC_Dienstapp
{
    public partial class Ausbildung_eintragen : Form
    {
        public Ausbildung_eintragen()
        {
            InitializeComponent();
            Insert_Pruefungen();
            Insert_Mitarbeiter();
        }
        public static string name;
        public static string id;
        private List<List<string>> pruefungenlist;
        private List<List<string>> mitarbeiter;
        int anzahlprüfer;

   
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM User ORDER BY rang DESC");

            mitarbeiter = new List<List<string>>();

            while (res.Read())
            {
                List<string> temp = new List<string>();
                comboBox2.Items.Add(res[2]);
                comboBox3.Items.Add(res[2]);
                comboBox4.Items.Add(res[2]);
                comboBox5.Items.Add(res[2]);
                temp.Add(res[2].ToString()); // 0 = Username
                temp.Add(res[1].ToString()); // 1 = ID
                temp.Add(res[6].ToString()); // 2 = rang

                mitarbeiter.Add(temp);
            }
            abfragemitarbeiter.closeConnection();

        }
        private int Suche_Mitarbeiter(ComboBox box)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                if (mitarbeiter[i][0] == box.Text)
                {
                    return i;
                }
            }
            return -1;
        }
        private void Ausbildung_eintragen_Load(object sender, EventArgs e)
        {
            label4.Text = name;
            label5.Text = "(" + id + ")";



        }
        
        private void Insert_Pruefungen()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM Pruefungsliste");
            pruefungenlist = new List<List<string>>();

            while (res.Read())
            {
                if(res[3].ToString() != "0")
                {
                    List<string> temp = new List<string>();
                    pruefungen.Items.Add(res[1]);
                    temp.Add(res[1].ToString()); // 0 = Name
                    temp.Add(res[2].ToString()); // 1 = Anzahlpersonen
                    temp.Add(res[3].ToString()); // Aktiv
                    temp.Add(res[4].ToString()); // Sonderbemerkgung
                    pruefungenlist.Add(temp);
                }
                
            }
            res.Close();
            abfragemitarbeiter.closeConnection();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            dbConnection addPruefung = new dbConnection();
            addPruefung.openConnection();
            string prüfer;
            if (anzahlprüfer == 1)
            {
                string id1 = mitarbeiter[Suche_Mitarbeiter(comboBox2)][1];
                prüfer = id1;
            }
            else if(anzahlprüfer == 2)
            {
                string id1 = mitarbeiter[Suche_Mitarbeiter(comboBox2)][1];
                string id2 = mitarbeiter[Suche_Mitarbeiter(comboBox3)][1];
                prüfer = id1 + " & " + id2;
            }
            else if (anzahlprüfer == 3)
            {
                string id1 = mitarbeiter[Suche_Mitarbeiter(comboBox2)][1];
                string id2 = mitarbeiter[Suche_Mitarbeiter(comboBox3)][1];
                string id3 = mitarbeiter[Suche_Mitarbeiter(comboBox4)][1];
                prüfer = id1 + " & " + id2 + " & " + id3;
            }
            else if (anzahlprüfer == 4)
            {
                string id1 = mitarbeiter[Suche_Mitarbeiter(comboBox2)][1];
                string id2 = mitarbeiter[Suche_Mitarbeiter(comboBox3)][1];
                string id3 = mitarbeiter[Suche_Mitarbeiter(comboBox4)][1];
                string id4 = mitarbeiter[Suche_Mitarbeiter(comboBox5)][1];
                prüfer = id1 + " & " + id2 + " & " + id3 + " & " + id4;
            }
            else
            {
                notification.Show("Fehler!", AlertType.error);
                return;
            }

            int bestanden = 0;

            if (comboBox1.Text == "Ja")
                bestanden = 1;
            int prüfung = Suche_Pruefung();
            MessageBox.Show("id " + pruefungen.Text + "', " + bestanden + ", '" + pruefungenlist[prüfung][3] + "', '" + prüfer + "'");
            string sonder = null;
            if(pruefungenlist[prüfung][3] != "")
            {
                sonder = textBox1.Text;
            }
            addPruefung.ExecuteSQL("INSERT INTO Pruefungen (userid,pruefung,bestanden,bemerkung,pruefer) VALUES ('" + id + "','" + pruefungen.Text + "','" + bestanden + "','" + sonder + "','" + prüfer + "')");
            addPruefung.closeConnection();
            
                

        }

        private void pruefungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prüfung = Suche_Pruefung();
            if (pruefungenlist[prüfung][3] != "")
            {
                panel1.Enabled = true;
                panel1.Visible = true;
                label3.Text = pruefungenlist[prüfung][3];
            }
            else
            {
                panel1.Enabled = false;
                panel1.Visible = false;
            }
           
            if (pruefungenlist[prüfung][1] == "1")
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                anzahlprüfer = 1;
            }
            if (pruefungenlist[prüfung][1] == "2")
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                anzahlprüfer = 2;
            }
            if (pruefungenlist[prüfung][1] == "3")
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = false;
                anzahlprüfer = 3;
            }
            if (pruefungenlist[prüfung][1] == "3")
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Visible = true;
                comboBox5.Enabled = true;
                anzahlprüfer = 4;
            }
        }
        private int Suche_Pruefung()
        {
            for (int i = 0; i < pruefungen.Items.Count; i++)
            {
                if (pruefungenlist[i][0] == pruefungen.Text)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
