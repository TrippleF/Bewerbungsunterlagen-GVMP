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
    public partial class Ausbildung_Bemerkung_eintragen : Form
    {
        public Ausbildung_Bemerkung_eintragen()
        {
            InitializeComponent();
        }

        private void Ausbildung_Bemerkung_eintragen_Load(object sender, EventArgs e)
        {
            label1.Text = Ausbildung_User_Manage.name + " ("+Ausbildung_User_Manage.id+")";
            dbConnection con = new dbConnection();
            con.openConnection();
            var reader = con.readerSQL("SELECT ausbilderBemerkung from User WHERE id='" + Ausbildung_User_Manage.id + "'");
            while (reader.Read())
            {
                textBox1.Text = reader.GetString("ausbilderBemerkung");
            }
            reader.Close();
            con.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Ausbildung_User_Manage.id);
            dbConnection con = new dbConnection();
            con.openConnection();
            con.ExecuteSQL("UPDATE User SET ausbilderBemerkung='" + textBox1.Text + "' WHERE id='"+ Ausbildung_User_Manage.id + "'");
            con.closeConnection();
            this.DialogResult = DialogResult.OK;
        }


    }
}
