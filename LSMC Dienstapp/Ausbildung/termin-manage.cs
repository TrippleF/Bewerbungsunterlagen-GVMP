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
    public partial class termin_manage : Form
    {
        public termin_manage()
        {
            InitializeComponent();
        }
        public static string prüfung;
        public static string name;
        public static string id;
        private void button1_Click(object sender, EventArgs e)
        {
            termin_vorschlagen f = new termin_vorschlagen();
            
            termin_vorschlagen.prüfung = prüfung;
            termin_vorschlagen.name = name;
            termin_vorschlagen.id = id;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void termin_manage_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("UPDATE AusbildungsTermine SET status='5' WHERE id='" + id + "'");
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("UPDATE AusbildungsTermine SET status='5' WHERE id='" + id + "'");
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
        }
    }
}
