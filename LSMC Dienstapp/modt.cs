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
    public partial class modt : Form
    {
        public modt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("TRUNCATE TABLE motd");
            x.closeConnection();
            x.openConnection();
            x.ExecuteSQL("INSERT INTO motd (nachricht) VALUES ('" + textBox1.Text + "')");
            x.closeConnection();
            notification.Show("Eingetragen!", AlertType.success);
            this.Close();
        }
    }
}
