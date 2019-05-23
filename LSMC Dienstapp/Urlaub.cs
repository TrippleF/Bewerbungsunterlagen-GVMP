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
    public partial class Urlaub : Form
    {
        public Urlaub()
        {
            InitializeComponent();
            monthCalendar1.MinDate = DateTime.Now;
            monthCalendar2.MinDate = monthCalendar1.SelectionRange.Start.Date.AddDays(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox1.Text == "Begründung")
            {
                notification.Show("Begründung fehlt!", AlertType.error);
                return;
            }
            int tmp = 0;
            if(bunifuiOSSwitch1.Value == true)
            {
                tmp = 1;
            }
            Form1.db.Insert("INSERT INTO Urlaub (name,von,bis,begründung,veröffentlichen) VALUES ('"+Form1.username+"','"+ monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd") + "','"+ monthCalendar2.SelectionRange.Start.ToString("yyyy-MM-dd") + "','"+bunifuMaterialTextbox1.Text+"','"+tmp+"')");
            notification.Show("Urlaub eingetragen", AlertType.success);
            //this.Close();
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "Begründung";
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.MinDate = monthCalendar1.SelectionRange.Start.Date.AddDays(2);
            monthCalendar2.SetDate(monthCalendar1.SelectionRange.Start.Date.AddDays(2));
        }

        private void Urlaub_FormClosing(object sender, FormClosingEventArgs e)
        {
            formposition.WritePosition(this, "Urlaub");
        }

        private void Urlaub_Load(object sender, EventArgs e)
        {
            formposition.ReadPosition(this, "Urlaub");
        }

    }
}
