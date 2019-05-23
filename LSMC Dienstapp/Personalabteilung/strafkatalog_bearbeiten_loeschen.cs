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
    public partial class strafkatalog_bearbeiten_loeschen : Form
    {
        public strafkatalog_bearbeiten_loeschen()
        {
            InitializeComponent();
        }
        public static int id;
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult diag = MessageBox.Show("Sicher, dass du dieses Vergehen entfernen willst?", "", MessageBoxButtons.YesNo);
            if(diag == DialogResult.Yes)
            {
                dbConnection x = new dbConnection();
                x.openConnection();
                x.ExecuteSQL("DELETE From Strafkatalog WHERE id="+id);
                x.closeConnection();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strafkatalog_add f = new strafkatalog_add();
            strafkatalog_add.add = false;
            strafkatalog_add.id = id;
            f.Show();
        }

        private void strafkatalog_bearbeiten_loeschen_Load(object sender, EventArgs e)
        {
            label1.Text = "Strafkatalogs-ID:" + id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
