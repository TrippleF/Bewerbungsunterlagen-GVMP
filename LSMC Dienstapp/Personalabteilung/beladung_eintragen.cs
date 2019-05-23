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
    public partial class beladung_eintragen : Form
    {
        public beladung_eintragen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                return;

            string name = comboBox1.Text;
            string gefehlt = textBox1.Text;
            int kw = KW(DateTime.Now);
            string link = textBox2.Text;
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("INSERT INTO FahrzeugbeladungArchiv (name,link,gefehlt,woche) VALUES ('"+name+"','"+link+"','"+ gefehlt + "',"+kw+")");
            x.closeConnection();
            //MessageBox.Show("Eingetragen!");
            notification.Show("Erfolgreich eingetragen!",AlertType.success);
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public static int KW(DateTime Datum)
        {
            CultureInfo CUI = CultureInfo.CurrentCulture;
            return CUI.Calendar.GetWeekOfYear(Datum, CUI.DateTimeFormat.CalendarWeekRule, CUI.DateTimeFormat.FirstDayOfWeek);
        }
        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT username FROM User ORDER BY rang DESC");


            while (res.Read())
            {
               
                comboBox1.Items.Add(res[0].ToString());
               
            }
            abfragemitarbeiter.closeConnection();

        }

        private void beladung_eintragen_Load(object sender, EventArgs e)
        {
            Insert_Mitarbeiter();
        }


    }
}
