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
    public partial class Ausbildung_Prüfungsverwaltung : Form
    {
        public Ausbildung_Prüfungsverwaltung()
        {
            InitializeComponent();
        }
        List<List<string>> prüfungen = new List<List<string>>();
        List<List<string>> schulungen = new List<List<string>>();
        List<List<string>> fsts = new List<List<string>>();
        private void Ausbildung_Prüfungsverwaltung_Load(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Pruefungsliste");
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1].ToString());
                List<string> tmp = new List<string>();
                tmp.Add(reader[0].ToString()); //ID
                tmp.Add(reader[1].ToString());// Name
                tmp.Add(reader[2].ToString());// Personenanzahl
                tmp.Add(reader[3].ToString());// Aktiv
                tmp.Add(reader[4].ToString());// sonderbemerkung
                prüfungen.Add(tmp);
            }
            reader.Close();
            reader = x.readerSQL("SELECT * FROM Schulungsliste");
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[1].ToString());
                List<string> tmp = new List<string>();
                tmp.Add(reader[0].ToString()); //ID
                tmp.Add(reader[1].ToString());// Name
                tmp.Add(reader[2].ToString());// Aktiv

                schulungen.Add(tmp);
            }
            reader.Close();
            reader = x.readerSQL("SELECT * FROM FSTListe");
            while (reader.Read())
            {
              
                List<string> tmp = new List<string>();
                tmp.Add(reader[0].ToString()); //ID
                tmp.Add(reader[1].ToString());// Name
                tmp.Add(reader[2].ToString());// Aktiv

                fsts.Add(tmp);
            }
            reader.Close();
            x.closeConnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int index = Suche_Pruefung();
            textBox4.Text = prüfungen[index][1];
            numericUpDown2.Value = int.Parse(prüfungen[index][2]);
            if(prüfungen[index][3] == "1")
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if (prüfungen[index][4] != "")
            {
                textBox3.Enabled = true;
                checkBox3.Checked = true;
                textBox3.Text = prüfungen[index][4];

            }
            else
            {
                checkBox3.Checked = false;
                textBox3.Enabled = false;
            }
        }
        private int Suche_Pruefung()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (prüfungen[i][1] == comboBox1.Text)
                {
                    return i;
                }
            }
            return -1;
        }
        private int Suche_Schulung()
        {
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (schulungen[i][1] == comboBox2.Text)
                {
                    return i;
                }

            }
            return -1;
        }
        private int Suche_FST()
        {
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {

                if (fsts[i][1] == comboBox2.Text)
                {
                    return i;
                }
            }
            return -1;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = Suche_Pruefung();
            int id = int.Parse(prüfungen[index][0]);
            string name = textBox4.Text;
            int anzpers = int.Parse(numericUpDown2.Value.ToString());
            int aktiv = 0;
            string bemerkung = "";
            if (checkBox4.Checked)
            {
                aktiv = 1;
            }
            if (checkBox3.Checked)
            {
                bemerkung = textBox3.Text;
            }
            dbConnection con = new dbConnection();
            con.openConnection();
            con.ExecuteSQL("UPDATE Pruefungsliste SET name='" + name + "',anzpers=" + anzpers + ",aktiv=" + aktiv + ",sonderbemerkung='" + bemerkung + "' WHERE id="+id);
            con.closeConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int anzpers = int.Parse(numericUpDown1.Value.ToString());
            int aktiv = 0;
            string bemerkung = "";
            if (checkBox1.Checked)
            {
                aktiv = 1;
            }
            if (checkBox2.Checked)
            {
                bemerkung = textBox3.Text;
            }
            dbConnection con = new dbConnection();
            con.openConnection();
            con.ExecuteSQL("INSERT INTO Pruefungsliste (name,anzpers,aktiv,sonderbemerkung) VALUES ('"+name+"',"+anzpers+","+aktiv+",'"+bemerkung+"')");
            con.closeConnection();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

            }
            else
            {

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                comboBox2.Items.Clear();
                foreach (List<string> x in schulungen)
                {
                    comboBox2.Items.Add(x[1]);
                }
            }
            else
            {

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox2.Items.Clear();
                foreach (List<string> x in fsts)
                {
                    comboBox2.Items.Add(x[1]);
                }
            }
            else
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int index;
            if (radioButton3.Checked)
                index = Suche_FST();
            else
                index = Suche_Schulung();

            
            if (radioButton3.Checked)
            {
                textBox5.Text = fsts[index][1];
            }
            else
            {
                
                textBox5.Text = schulungen[index][1];
            }
            
           
            if (fsts[index][2] == "1" || schulungen[index][2] == "1")
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            int aktiv = 0;
            if (checkBox6.Checked)
            {
                aktiv = 1;
            }
            if (radioButton1.Checked)
            {
                dbConnection con = new dbConnection();
                con.openConnection();
                con.ExecuteSQL("INSERT INTO Schulungsliste (name,aktiv) VALUES ('" + name + "'," + aktiv+")");
                con.closeConnection();
            }
            else
            {

                dbConnection con = new dbConnection();
                con.openConnection();
                con.ExecuteSQL("INSERT INTO FSTListe (name,aktiv) VALUES ('" + name + "'," + aktiv + ")");
                con.closeConnection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            int aktiv = 0;
            if (checkBox5.Checked)
            {
                aktiv = 1;
            }
            if (radioButton4.Checked)
            {
                int index = Suche_Schulung();
                int id = int.Parse(schulungen[index][0]);
                dbConnection con = new dbConnection();
                con.openConnection();
                con.ExecuteSQL("UPDATE Schulungsliste SET name='"+name+"',aktiv="+aktiv + " WHERE id="+id);
                con.closeConnection();
            }
            else
            {
                int index = Suche_FST();
                int id = int.Parse(fsts[index][0]);
                dbConnection con = new dbConnection();
                con.openConnection();
                con.ExecuteSQL("UPDATE FSTListe SET name='" + name + "',aktiv=" + aktiv + " WHERE id=" + id);
                con.closeConnection();
            }
        }
    }
}
