using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSMC_Dienstapp
{
    public partial class mdw : Form
    {
        public mdw()
        {
            InitializeComponent();
        }

        private void mdw_Load(object sender, EventArgs e)
        {
            Insert_Mitarbeiter();
        }
        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT username,rang FROM User ORDER BY rang DESC");
            while (res.Read())
            {
                if (res[0].ToString() != Form1.username && int.Parse(res[1].ToString())<=9)
                {
                    comboBox1.Items.Add(res[0]);
                    comboBox2.Items.Add(res[0]);
                    comboBox3.Items.Add(res[0]);
                }
                
                
            }
            res.Close();
            abfragemitarbeiter.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                notification.Show("Du musst mindestens 1 Vorschlag abgeben", AlertType.error);
                return;
            }
            if(comboBox1.Text == comboBox2.Text || comboBox2.Text == comboBox3.Text || comboBox3.Text == comboBox1.Text)
            {
                notification.Show("Namen dürfen nur 1x gewählt werden!", AlertType.error);
                return;
            }
            dbConnection x = new dbConnection();
            x.openConnection();
            CultureInfo CUI = CultureInfo.CurrentCulture;
            int kw = CUI.Calendar.GetWeekOfYear(DateTime.Now, CUI.DateTimeFormat.CalendarWeekRule, CUI.DateTimeFormat.FirstDayOfWeek);
            x.ExecuteSQL("INSERT INTO mdw (username,vorschlag1,vorschlag2,vorschlag3,kw,jahr) VALUES('" + Form1.username + "','" + comboBox1.Text + "','" + comboBox2.Text + "','"+comboBox3.Text+"',"+kw+","+DateTime.Now.Year+")");

            x.closeConnection();
            notification.Show("Erfolgreich abgestimmt!", AlertType.success);
            this.Close();
        }
    }
}
