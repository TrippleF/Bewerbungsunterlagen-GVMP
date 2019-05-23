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
    public partial class Ausbildung_SchulungEintragen : Form
    {
        public static int typ = 0;
        public Ausbildung_SchulungEintragen()
        {
            InitializeComponent();
            
        }
        private List<List<string>> pruefungenlist;
        private List<List<string>> mitarbeiter;
        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM User WHERE abteilung=2 ORDER BY rang DESC ");

            mitarbeiter = new List<List<string>>();

            while (res.Read())
            {
                List<string> temp = new List<string>();
                comboBox1.Items.Add(res[2]);
               
                temp.Add(res[2].ToString()); // 0 = Username
                temp.Add(res[1].ToString()); // 1 = ID
                temp.Add(res[6].ToString()); // 2 = rang

                mitarbeiter.Add(temp);
            }
            abfragemitarbeiter.closeConnection();

        }
        private void Insert_Pruefungen()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM Schulungsliste");
            pruefungenlist = new List<List<string>>();

            while (res.Read())
            {
                if (res[2].ToString() != "0")
                {
                    List<string> temp = new List<string>();
                    pruefungen.Items.Add(res[1]);
                    temp.Add(res[1].ToString()); // 0 = Name
                    temp.Add(res[2].ToString()); // 1 = Aktiv
                    pruefungenlist.Add(temp);
                }

            }
            res.Close();
            abfragemitarbeiter.closeConnection();
        }
        public void Insert_FST()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM FSTListe");
            pruefungenlist = new List<List<string>>();

            while (res.Read())
            {
                if (res[2].ToString() != "0")
                {
                    List<string> temp = new List<string>();
                    pruefungen.Items.Add(res[1]);
                    temp.Add(res[1].ToString()); // 0 = Name
                    temp.Add(res[2].ToString()); // 1 = Aktiv
                    pruefungenlist.Add(temp);
                }

            }
            res.Close();
            abfragemitarbeiter.closeConnection();
        }
        private int Suche_Mitarbeiter()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (mitarbeiter[i][0] == comboBox1.Text)
                {
                    return i;
                }
            }
            return -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(typ == 0)
            {
                dbConnection addPruefung = new dbConnection();
                addPruefung.openConnection();
                int prüfung = Suche_Pruefung();
                string pruefer = mitarbeiter[Suche_Mitarbeiter()][1];
                addPruefung.ExecuteSQL("INSERT INTO Schulungen (userid,schulung,pruefer) VALUES ('" + Ausbildung_User_Manage.id + "','" + pruefungen.Text + "','" + pruefer + "')");
                addPruefung.closeConnection();
            }
            else
            {
                dbConnection addPruefung = new dbConnection();
                addPruefung.openConnection();
                int prüfung = Suche_Pruefung();
                string pruefer = mitarbeiter[Suche_Mitarbeiter()][1];
                addPruefung.ExecuteSQL("INSERT INTO FST (userid,fst,pruefer) VALUES ('" + Ausbildung_User_Manage.id + "','" + pruefungen.Text + "','" + pruefer + "')");
                addPruefung.closeConnection();
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

        private void Ausbildung_SchulungEintragen_Load(object sender, EventArgs e)
        {
            if(typ == 1)
            {
                groupBox1.Text = "FST";
                label2.Text = "Ausbilder";
                Insert_FST();
                Insert_Mitarbeiter();
            }
            else
            {
                Insert_Pruefungen();
                Insert_Mitarbeiter();
            }
        }
    }
}
