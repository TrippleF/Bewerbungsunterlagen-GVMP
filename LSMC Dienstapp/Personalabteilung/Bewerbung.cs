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
    public partial class Bewerbung : Form
    {
        public Bewerbung()
        {
            InitializeComponent();
        }
        public static string name;
        
        List<List<string>> beispiele = new List<List<string>>();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult diag = MessageBox.Show("Hat der Bewerber noch fragen?", "", MessageBoxButtons.YesNo);
            if (diag == DialogResult.No)
            {


                dbConnection x = new dbConnection();
                x.openConnection();


                var reader = x.readerSQL("SELECT * FROM BewerbungFallbeispiele");
                while (reader.Read())
                {
                    List<string> tmp = new List<string>();
                    tmp.Add(reader.GetString("beispiel"));
                    tmp.Add(reader.GetString("richtig"));
                    tmp.Add(reader.GetString("aktiv"));
                    if (reader.GetString("aktiv") == "1")
                    {
                        beispiele.Add(tmp);
                    }
                }
                reader.Close();

                Random rnd = new Random();
                int index = rnd.Next(0, beispiele.Count);
                // MessageBox.Show(index.ToString() + "\n " + beispiele.Count);
                textBox1.Text = beispiele[index][0];
                textBox2.Text = beispiele[index][1];
                reader.Close();
                this.groupBox2.Visible = false;
                this.groupBox1.Visible = false;
                this.groupBox3.Visible = true;
                this.button1.Visible = false;
                this.button2.Visible = true;
                this.button3.Visible = true;
                this.button4.Visible = true;
                x.closeConnection();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();

            x.ExecuteSQL("UPDATE Bewerbungstermine SET status=2,aktiv=0 WHERE name='" + name + "'");
            
            x.closeConnection();

            //User_add f = new User_add();
            //f.Show();,


            var api_key = Generate_api();
            dbConnection insertquery = new dbConnection();
            insertquery.openConnection();
            insertquery.ExecuteSQL("INSERT INTO User (apikey, id, username, forumname, beitritt, telefon, rang, email, abteilung) VALUES ('" + api_key + "', '" + userid + "', '" + name + "', '" + forumsname + "', NOW(), '" + telnummer + "', '0', NULL, NULL)");
            insertquery.closeConnection();
            MessageBox.Show("Generierter API Key: " + api_key);
            Clipboard.SetText(api_key);







            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();

            x.ExecuteSQL("UPDATE Bewerbungstermine SET status=3,aktiv=0 WHERE name='" + name + "'");
            x.closeConnection();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        string forumsname = "", userid = "", telnummer = "";
        private void Bewerbung_Load(object sender, EventArgs e)
        {

            dbConnection x = new dbConnection();
            x.openConnection();

            label1.Text = name;
            var reader = x.readerSQL("SELECT * FROM Bewerbungstermine WHERE name='"+name+"'");
            while (reader.Read())
            {

                forumsname = reader.GetString("forumsname");
                userid = reader.GetString("userid");
                telnummer = reader.GetString("telnummer");
                
            }
            reader.Close();
            x.closeConnection();
        }

        private string Generate_api()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var api_key = new char[32];
            var random = new Random();

            for (int i = 0; i < api_key.Length; i++)
            {
                api_key[i] = chars[random.Next(chars.Length)];
            }

            var final_api = new String(api_key);
            return final_api;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, beispiele.Count);
            // MessageBox.Show(index.ToString() + "\n " + beispiele.Count);
            textBox1.Text = beispiele[index][0];
            textBox2.Text = beispiele[index][1];
           
            this.groupBox2.Visible = false;
            this.groupBox1.Visible = false;
            this.groupBox3.Visible = true;
            this.button1.Visible = false;
            this.button2.Visible = true;
            this.button3.Visible = true;
            this.button4.Visible = true;
        }
    }
}
