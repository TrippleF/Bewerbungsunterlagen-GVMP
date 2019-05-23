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
    public partial class Bemerkung_eintragen : Form
    {
        public Bemerkung_eintragen()
        {
            InitializeComponent();
        }

        private void Bemerkung_eintragen_Load(object sender, EventArgs e)
        {
            label1.Text = User_Manage.name + " (" + User_Manage.id + ")";
            dbConnection con = new dbConnection();
            con.openConnection();
            var reader = con.readerSQL("SELECT personalBemerkung from User WHERE id='" + User_Manage.id + "'");
            while (reader.Read())
            {
                textBox1.Text = reader.GetString("personalBemerkung");
            }
            reader.Close();
            con.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConnection con = new dbConnection();
            con.openConnection();
            con.ExecuteSQL("UPDATE User SET personalBemerkung='" + textBox1.Text + "' WHERE id='" + User_Manage.id + "'");
            con.closeConnection();
            this.DialogResult = DialogResult.OK;
        }
    }
}
