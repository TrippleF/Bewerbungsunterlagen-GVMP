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
    public partial class Fahrzeugverwaltung : Form
    {
        public Fahrzeugverwaltung()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            if (textBox2.Text == "")
                return;

            dbConnection x = new dbConnection();
            x.openConnection();
            try
            {
                x.ExecuteSQL("INSERT INTO Fahrzeuge (nummer,typ) VALUES ('" + textBox2.Text + "','" + textBox1.Text + "')");
            }catch(Exception ex)
            {
                notification.Show("FEHLER \n Gibt es evtl. schon ein Fahrzeug mit dieser Fahrzeugnummer?",AlertType.error);
            }
            
            x.closeConnection();
            MessageBox.Show("Gepsiechert!");
        }
        List<List<string>> fahrzeuge = new List<List<string>>();
        private void Fahrzeugverwaltung_Load(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT nummer,typ,aktiv from Fahrzeuge");
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("typ") + " | " + reader.GetString("nummer"));
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("nummer"));
                tmp.Add(reader.GetString("typ"));
                tmp.Add(reader.GetString("aktiv"));
                fahrzeuge.Add(tmp);
            }
            reader.Close();


            x.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                return;
            if (textBox4.Text == "")
                return;

            dbConnection x = new dbConnection();
            x.openConnection();
            if(checkBox1.Checked)
                x.ExecuteSQL("UPDATE Fahrzeuge SET nummer='"+textBox4.Text+"',typ='"+textBox3.Text+ "',aktiv=1 WHERE nummer='" + textBox4.Text + "'");
            else
                x.ExecuteSQL("UPDATE Fahrzeuge SET nummer='" + textBox4.Text + "',typ='" + textBox3.Text + "',aktiv=0 WHERE nummer='"+textBox4.Text+"'");
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Gepsiechert!");
        }
        private int Suche_Fahrzeug()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Text.Contains(fahrzeuge[i][0]))
                {
                    return i;
                }
            }
            return -1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Suche_Fahrzeug();

            textBox3.Text = fahrzeuge[index][1];
            textBox4.Text = fahrzeuge[index][0];
            if (fahrzeuge[index][2] == "1")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;

        }
    }
}
