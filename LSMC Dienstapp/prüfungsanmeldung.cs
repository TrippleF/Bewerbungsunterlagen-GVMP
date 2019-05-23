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
    public partial class prüfungsanmeldung : Form
    {
        public prüfungsanmeldung()
        {
            InitializeComponent();
        }

        private void prüfungsanmeldung_Load(object sender, EventArgs e)
        {
            Insert_Pruefungen();
            dateTimePicker1.MouseWheel += new MouseEventHandler(dateTimePicker1_MouseWheel);
            dateTimePicker2.MouseWheel += new MouseEventHandler(dateTimePicker2_MouseWheel);

        }
        List<List<string>> pruefungenlist;

        private void Insert_Pruefungen()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM Pruefungsliste");
            pruefungenlist = new List<List<string>>();

            while (res.Read())
            {
                if (res[3].ToString() != "0")
                {
                    List<string> temp = new List<string>();
                    
                    if(res[1].ToString().Contains("Einweisung") || res[1].ToString().Contains("RTWSolo"))
                    {
                        continue;
                    }

                    comboBox1.Items.Add(res[1]);
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



        private void dateTimePicker1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                System.Windows.Forms.SendKeys.Send("{UP}");
            }
            else
            {
                System.Windows.Forms.SendKeys.Send("{DOWN}");
            }        }
        private void dateTimePicker2_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                System.Windows.Forms.SendKeys.Send("{UP}");
            }
            else
            {
                System.Windows.Forms.SendKeys.Send("{DOWN}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prüfung = comboBox1.Text;
            string name = Form1.username;
            string uhrzeit = dateTimePicker1.Value.ToShortTimeString() + " - " + dateTimePicker2.Value.ToShortTimeString();
            string datum = "";
            if (checkBox1.Checked)
            {
                datum += checkBox1.Text + ",";
            }
            if (checkBox2.Checked)
            {
                datum += checkBox2.Text + ",";
            }
            if (checkBox3.Checked)
            {
                datum += checkBox3.Text + ",";
            }
            if (checkBox4.Checked)
            {
                datum += checkBox4.Text + ",";
            }
            if (checkBox5.Checked)
            {
                datum += checkBox5.Text + ",";
            }
            if (checkBox6.Checked)
            {
                datum += checkBox6.Text + ",";
            }
            if (!checkBox6.Checked && !checkBox5.Checked && !checkBox4.Checked && !checkBox3.Checked && !checkBox2.Checked && !checkBox1.Checked)
            {
                MessageBox.Show("Du musst mindestens 1 Wochentag angeben!");
                return;
            }
               
            {
                datum += checkBox6.Text + ",";
            }
            //MessageBox.Show("Wochentage: " + datum + "\n" + "Uhrzeit: " + uhrzeit);
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("INSERT INTO AusbildungsTermine (prüfling,prüfung,uhrzeit,wochentage) VALUES ('" + name + "','" + prüfung + "','" + uhrzeit + "','" + datum + "')");
            x.closeConnection();
            this.Close();
        }
    }
}
