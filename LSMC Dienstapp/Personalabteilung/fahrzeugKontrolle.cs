using Microsoft.Win32;
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
    public partial class fahrzeugKontrolle : Form
    {
        public static int nummer;
        public fahrzeugKontrolle()
        {
            InitializeComponent();
        }
        List<List<string>> items = new List<List<string>>();
        private void fahrzeugKontrolle_Load(object sender, EventArgs e)
        {
            label1.Text = "Fahrzeug: " + nummer;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Beladung";
            dataGridView1.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Beladung");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                
                string name = reader.GetString("itemname");
                string id = reader.GetString("id");
                string anzahl = reader.GetString("anzahl");
                tmp.Add(id);
                tmp.Add(name);
                tmp.Add(anzahl);
                items.Add(tmp);
                dataGridView1.Rows.Add(id,name + " (" + anzahl + ")","");
            }
            reader.Close();

            reader = x.readerSQL("SELECT beladung FROM Fahrzeuge WHERE nummer = " + nummer);
            while (reader.Read())
            {
                string beladung = "";
                string[] temp = reader[0].ToString().Split(';');
                foreach(string s in temp)
                {
                    string[] tmp = s.Split(':');
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        //MessageBox.Show(row.Cells[0].Value.ToString());
                        if(row.Cells[0].Value.ToString() == tmp[0])
                        {
                            row.Cells[2].Value = tmp[1];
                        }
                    }
                }
            }
            reader.Close();
            x.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LSMC-DienstApp");
            string username = key.GetValue("Name").ToString();
            string neuebeladung = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells[2].Value.ToString() == "")
                {
                    row.Cells[2].Value = "0";
                }
                neuebeladung += row.Cells[0].Value + ":" + row.Cells[2].Value +";";
            }
            MessageBox.Show(neuebeladung);
            string kontroliert = username + ";" + DateTime.Now.ToString("d/M/yyyy");
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("UPDATE Fahrzeuge SET beladung='"+ neuebeladung + "', kontroliert='"+kontroliert+"' WHERE nummer=" + nummer);
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    
}
