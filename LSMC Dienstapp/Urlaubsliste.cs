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
    public partial class Urlaubsliste : Form
    {
        public Urlaubsliste()
        {
            InitializeComponent();
        }

        private void Urlaubsliste_Load(object sender, EventArgs e)
        {
            var urlaub = Form1.db.Select("SELECT * FROM Urlaub WHERE bis > NOW() - 86400", "Urlaub");
            var urlaub_zaehler = Form1.db.zaehler;
            formposition.ReadPosition(this, "Urlaubsliste");
            for(int i = 0; i < urlaub_zaehler; i++)
            { 
                if(urlaub[5][i] == "1")
                {
                    bunifuCustomDataGrid1.Rows.Add(urlaub[1][i], Convert_to_Date(urlaub[2][i]), Convert_to_Date(urlaub[3][i]), urlaub[4][i]);
                } else
                {
                    bunifuCustomDataGrid1.Rows.Add(urlaub[1][i], Convert_to_Date(urlaub[2][i]), Convert_to_Date(urlaub[3][i]));
                }
            }
        }

        private void Urlaubsliste_FormClosing(object sender, FormClosingEventArgs e)
        {
            formposition.WritePosition(this, "Urlaubsliste");
        }


        private string Convert_to_Date(string zeit)
        {
            return zeit.Substring(0,10);
        }
    }
}
