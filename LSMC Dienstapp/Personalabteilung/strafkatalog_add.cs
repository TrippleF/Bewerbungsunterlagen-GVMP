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
    public partial class strafkatalog_add : Form
    {
        public strafkatalog_add()
        {
            InitializeComponent();
        }
        public static bool add;
        public static int id;
        private void button1_Click(object sender, EventArgs e)
        {
             
            if(textBox1.Text == "" || comboBox1.Text == "" || numericUpDown1.Value == 0 || numericUpDown2.Value == 0 || numericUpDown3.Value == 0 || numericUpDown4.Value == 0 || numericUpDown5.Value == 0)
            {
                MessageBox.Show("Du hast nicht alles ausgefüllt!");
                return;
            }

            string vergehen = textBox1.Text;
            string typString = comboBox1.Text;
            int typ = 0; 
            if(typString == "leichtes Vergehen")
            {
                typ = 1;
            }
            if (typString == "minimalschweres Vergehen")
            {
                typ = 2;
            }
            if (typString == "mittelschweres Vergehen")
            {
                typ = 3;
            }
            if (typString == "schweres Vergehen")
            {
                typ = 4;
            }

            string money = numericUpDown2.Value + ";" + numericUpDown3.Value + ";" + numericUpDown4.Value + ";" + numericUpDown5.Value;
            int punkte = (int)numericUpDown1.Value;
           // MessageBox.Show(add.ToString());
            if (add == false)
            {
                dbConnection x = new dbConnection();
                x.openConnection();
                x.ExecuteSQL("UPDATE Strafkatalog SET Vergehen='" + vergehen + "',Typ=" + typ + ",Punkte=" + punkte + ",Geld='" + money + "' WHERE id="+id);
                x.closeConnection();
                notification.Show("Bearbeitet!",AlertType.info);
            }
            else
            {
                dbConnection x = new dbConnection();
                x.openConnection();
                x.ExecuteSQL("INSERT INTO Strafkatalog (Vergehen,Typ,Punkte,Geld) VALUES ('" + vergehen + "'," + typ + "," + punkte + ",'" + money + "')");
                x.closeConnection();
                //MessageBox.Show("Hinzugefügt!");
                notification.Show("Hinzugefügt!", AlertType.info);
            }
            
        }

        private void strafkatalog_add_Load(object sender, EventArgs e)
        {
            
            if (add == false)
            {
                dbConnection x = new dbConnection();
                x.openConnection();
                var reader = x.readerSQL("SELECT * FROM Strafkatalog Where id=" + id);
                while (reader.Read())
                {
                    textBox1.Text = reader.GetString("Vergehen");
                    if(reader.GetString("typ") == "1"){
                        comboBox1.SelectedIndex = comboBox1.Items.IndexOf("leichtes Vergehen");
                    }
                    if (reader.GetString("typ") == "2"){
                        comboBox1.SelectedIndex = comboBox1.Items.IndexOf("minimalschweres Vergehen");
                    }
                    if (reader.GetString("typ") == "3")
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.IndexOf("mittelschweres Vergehen");
                    }
                    if (reader.GetString("typ") == "3")
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.IndexOf("schweres Vergehen");
                    }
                    string[] money = reader.GetString("Geld").Split(';');
                    numericUpDown2.Value = int.Parse(money[0]);
                    numericUpDown3.Value = int.Parse(money[1]);
                    numericUpDown4.Value = int.Parse(money[2]);
                    numericUpDown5.Value = int.Parse(money[3]);
                    numericUpDown1.Value = int.Parse(reader.GetString("Punkte"));
                }
                reader.Close();
                x.closeConnection();
            }
        }
    }
}
