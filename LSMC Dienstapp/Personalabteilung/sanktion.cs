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
    public partial class sanktion : Form
    {
        public sanktion()
        {
            InitializeComponent();
        }
        List<List<string>> sanktionen = new List<List<string>>();
        List<List<string>>  mitarbeiter = new List<List<string>>();
        private void sanktion_Load(object sender, EventArgs e)
        {
            Insert_Mitarbeiter();
            leichteVergehen();
        }

        private void leichteVergehen()
        {
            sanktionen.Clear();
            comboBox1.Items.Clear();
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=1");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("id"));
                tmp.Add(reader.GetString("Vergehen"));
                tmp.Add(reader.GetString("Punkte"));
                string[] money = reader.GetString("Geld").Split(';');

                tmp.Add(money[0]);
                tmp.Add(money[1]);
                tmp.Add(money[2]);
                tmp.Add(money[3]);
                sanktionen.Add(tmp);
                comboBox1.Items.Add(reader.GetString("Vergehen"));
            }
            reader.Close();
            x.closeConnection();
        }
        private void minimalschwerVergehen()
        {
            sanktionen.Clear();
            comboBox1.Items.Clear();
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=2");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("id"));
                tmp.Add(reader.GetString("Vergehen"));
                tmp.Add(reader.GetString("Punkte"));
                string[] money = reader.GetString("Geld").Split(';');

                tmp.Add(money[0]);
                tmp.Add(money[1]);
                tmp.Add(money[2]);
                tmp.Add(money[3]);
                sanktionen.Add(tmp);
                comboBox1.Items.Add(reader.GetString("Vergehen"));
            }
            reader.Close();
            x.closeConnection();
        }
        private void mittelschwerVergehen()
        {
            sanktionen.Clear();
            comboBox1.Items.Clear();
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=3");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("id"));
                tmp.Add(reader.GetString("Vergehen"));
                tmp.Add(reader.GetString("Punkte"));
                string[] money = reader.GetString("Geld").Split(';');

                tmp.Add(money[0]);
                tmp.Add(money[1]);
                tmp.Add(money[2]);
                tmp.Add(money[3]);
                sanktionen.Add(tmp);
                comboBox1.Items.Add(reader.GetString("Vergehen"));
            }
            reader.Close();
            x.closeConnection();
        }
        private void schwereVergehen()
        {
            sanktionen.Clear();
            comboBox1.Items.Clear();
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=4");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("id"));
                tmp.Add(reader.GetString("Vergehen"));
                tmp.Add(reader.GetString("Punkte"));
                string[] money = reader.GetString("Geld").Split(';');

                tmp.Add(money[0]);
                tmp.Add(money[1]);
                tmp.Add(money[2]);
                tmp.Add(money[3]);
                sanktionen.Add(tmp);
                comboBox1.Items.Add(reader.GetString("Vergehen"));
            }
            reader.Close();
            x.closeConnection();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                leichteVergehen();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                minimalschwerVergehen();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                mittelschwerVergehen();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                schwereVergehen();
        }
        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM User ORDER BY rang DESC");

            

            while (res.Read())
            {
                List<string> temp = new List<string>();
                comboBox2.Items.Add(res[2]);
                
                temp.Add(res[2].ToString()); // 0 = Username
                temp.Add(res[1].ToString()); // 1 = ID
                temp.Add(res[6].ToString()); // 2 = rang
                temp.Add(res.GetString("sanktionspunkte")); // 2 = rang

                mitarbeiter.Add(temp);
            }
            abfragemitarbeiter.closeConnection();
        }

        private int Suche_Mitarbeiter()
        {
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (mitarbeiter[i][0] == comboBox2.Text)
                {
                    return i;
                }
            }
            return -1;
        }
        private int Suche_Vergehen()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (sanktionen[i][1] == comboBox1.Text)
                {
                    return i;
                }
            }
            return -1;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;


            int index = Suche_Mitarbeiter();
            int sanktionIndex = Suche_Vergehen();

            int rang = int.Parse(mitarbeiter[index][2]);
            string strafe="";
            if(rang>=0 && rang <= 2)
            {
                strafe = sanktionen[sanktionIndex][3];
            }
            if (rang >= 3 && rang <= 5)
            {
                strafe = sanktionen[sanktionIndex][4];
            }
            if (rang >= 6 && rang <= 9)
            {
                strafe = sanktionen[sanktionIndex][5];
            }
            if (rang >= 10 && rang <= 12)
            {
                strafe = sanktionen[sanktionIndex][6];
            }
            string punkte = sanktionen[sanktionIndex][2];
            label1.Text = "Punkte: " + punkte;
            label2.Text = "Geld: " + strafe + "$";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
                return;


            int index = Suche_Mitarbeiter();
            int sanktionIndex = Suche_Vergehen();

            int rang = int.Parse(mitarbeiter[index][2]);
            string strafe = "";
            if (rang >= 0 && rang <= 2)
            {
                strafe = sanktionen[sanktionIndex][3];
            }
            if (rang >= 3 && rang <= 5)
            {
                strafe = sanktionen[sanktionIndex][4];
            }
            if (rang >= 6 && rang <= 9)
            {
                strafe = sanktionen[sanktionIndex][5];
            }
            if (rang >= 10 && rang <= 12)
            {
                strafe = sanktionen[sanktionIndex][6];
            }
            string punkte = sanktionen[sanktionIndex][2];
            label1.Text = "Punkte: " + punkte;
            label2.Text = "Geld: " + strafe + "$";
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int index = Suche_Vergehen();
            int mbindex = Suche_Mitarbeiter();
            int sanktionsID = int.Parse(sanktionen[index][0]);
            string name = comboBox2.Text;
            int gesammt = int.Parse(mitarbeiter[mbindex][3]);
            int punkte = int.Parse(sanktionen[index][2]);

            int rang = int.Parse(mitarbeiter[index][2]);
            string strafe = "";
            if (rang >= 0 && rang <= 2)
            {
                strafe = sanktionen[index][3];
            }
            if (rang >= 3 && rang <= 5)
            {
                strafe = sanktionen[index][4];
            }
            if (rang >= 6 && rang <= 9)
            {
                strafe = sanktionen[index][5];
            }
            if (rang >= 10 && rang <= 12)
            {
                strafe = sanktionen[index][6];
            }
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("INSERT INTO Sanktionen (username,sanktion,datum,strafe) VALUES ('" + name + "'," + sanktionsID + ",NOW(),"+strafe+")");
           
            x.closeConnection();
            x.openConnection();
            gesammt = gesammt + punkte;
            //MessageBox.Show("PUNKTE: " + gesammt + "Name:" + name); 
            x.ExecuteSQL("UPDATE User SET sanktionspunkte=" + gesammt + " WHERE username='" + name + "'");
            x.closeConnection();
            notification.Show("Erfolgreich eingetragen! \n "+punkte + "Punkte",AlertType.success);
            this.Close();
        }
    }
}
