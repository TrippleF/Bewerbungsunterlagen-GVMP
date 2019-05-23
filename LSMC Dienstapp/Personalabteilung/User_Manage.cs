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
    public partial class User_Manage : Form
    {
        public User_Manage()
        {
            InitializeComponent();
        }
        public static int id;
        public static string name;
        private void User_Manage1_Load(object sender, EventArgs e)
        {
            label1.Text = name + " ("+id.ToString() + ")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bemerkung_eintragen x = new Bemerkung_eintragen();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
