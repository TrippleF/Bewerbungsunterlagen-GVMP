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
    public partial class CustomMessageBox : Form
    {
        private bool ausgabe;

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ausgabe = true;
            this.Close();
        }

        public bool Ausgabe
        {
            get
            {
                return ausgabe;
            }
            set
            {
                this.ausgabe = value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ausgabe = false;
            this.Close();
        }
        
        public string Uebergabetext
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        public string Button1
        {
            get
            {
                return this.button1.Text;
            }
            set
            {
                this.button1.Text = value;
            }
        }

        public string Button2
        {
            get
            {
                return this.button2.Text;
            }
            set
            {
                this.button2.Text = value;
            }
        }
    }
}
