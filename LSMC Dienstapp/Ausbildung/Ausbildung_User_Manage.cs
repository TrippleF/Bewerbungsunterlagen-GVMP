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
    public partial class Ausbildung_User_Manage : Form
    {
        public Ausbildung_User_Manage()
        {
            InitializeComponent();
        }
        public static string name;
        public static string id;

        private void Ausbildung_User_Manage_Load(object sender, EventArgs e)
        {
            if(Form1.rang < 9)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            label1.Text = name + " (" + id +")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ausbildung_eintragen x = new Ausbildung_eintragen();
            Ausbildung_eintragen.name = name;
            Ausbildung_eintragen.id = id;
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modt x = new modt();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ausbildung_SchulungEintragen x = new Ausbildung_SchulungEintragen();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Yes;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ausbildung_SchulungEintragen x = new Ausbildung_SchulungEintragen();
            Ausbildung_SchulungEintragen.typ = 1;
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.No;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
