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
    public partial class Termine_manage : Form
    {
        public Termine_manage()
        {
            InitializeComponent();
        }
        public static string name;
        private void button1_Click(object sender, EventArgs e)
        {
            Bewerbung x = new Bewerbung();
            
            Bewerbung.name = name;
            x.ShowDialog();
            if(x.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Termine_manage_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            DialogResult res = MessageBox.Show("Bist du sicher, dass du den Termin löschen willst?","", MessageBoxButtons.YesNo);
           if (res == DialogResult.Yes)
            {
                x.ExecuteSQL("UPDATE Bewerbungstermine SET aktiv=0,status=4 WHERE name='" + name + "'");
                
            }
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
