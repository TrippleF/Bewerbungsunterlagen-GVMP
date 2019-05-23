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
    public partial class resetAccount : Form
    {
        public resetAccount()
        {
            InitializeComponent();
        }
        private List<List<string>> mitarbeiter;
        private void resetAccount_Load(object sender, EventArgs e)
        {
            Insert_Mitarbeiter();
        }
        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT username,id FROM User ORDER BY rang DESC");

            mitarbeiter = new List<List<string>>();

            while (res.Read())
            {
                List<string> temp = new List<string>();
                comboBox1.Items.Add(res[0]);
                temp.Add(res[0].ToString()); // 0 = Username
                temp.Add(res[1].ToString()); // 1 = ID
               
                mitarbeiter.Add(temp);
            }
            res.Close();
            abfragemitarbeiter.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = Suche_Mitarbeiter();

            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("UPDATE User SET hwid='~' WHERE id='" + mitarbeiter[index][1] + "'");
            x.closeConnection();
            this.Close();

        }
        private int Suche_Mitarbeiter()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (mitarbeiter[i][0] == comboBox1.Text)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
