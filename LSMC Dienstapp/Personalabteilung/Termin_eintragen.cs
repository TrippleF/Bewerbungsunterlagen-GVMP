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
    public partial class Termin_eintragen : Form
    {
        public Termin_eintragen()
        {
            InitializeComponent();
        }

        private void Termin_eintragen_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (!textBox1.Text.Contains('_'))
            {
                MessageBox.Show("Bitte trage den Namen mit Unterstrich ein!");
                return;

            }
            string date = dateTimePicker1.Text;
            string time = textBox2.Text;
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("INSERT INTO Bewerbungstermine (name,Datum,Uhrzeit,forumsname,userid,telnummer) VALUES('" + name + "','" + date + "','" + time + "','"+ textBox3.Text + "','"+ textBox4.Text +"','"+textBox5.Text+ "')");
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
