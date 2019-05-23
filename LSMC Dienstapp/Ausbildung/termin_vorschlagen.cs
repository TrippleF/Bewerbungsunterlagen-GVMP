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
    public partial class termin_vorschlagen : Form
    {
        public static string prüfung;
        public static string name;
        public static string id;
        public termin_vorschlagen()
        {
            InitializeComponent();
        }

        private void termin_vorschlagen_Load(object sender, EventArgs e)
        {
            label1.Text = name + ": " + prüfung ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datum = monthCalendar1.SelectionStart.ToShortDateString();
            string time = dateTimePicker1.Value.ToShortTimeString();
            string termin = datum + "  -  " + time;
            string prüfer = Form1.username;
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("UPDATE AusbildungsTermine SET status=1,prüfer='"+Form1.username+"',termin='"+termin+"' WHERE id='"+id+"'");
            x.closeConnection();
            notification.Show("Terminvorschlag abgeschickt! (" + termin + ")", AlertType.success);
            this.DialogResult = DialogResult.OK;
        }
    }
}
