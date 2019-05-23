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
    public partial class mdwListe : Form
    {
        public mdwListe()
        {
            InitializeComponent();
        }
        
        private void mdwListe_Load(object sender, EventArgs e)
        {
            CultureInfo CUI = CultureInfo.CurrentCulture;
            int kw = CUI.Calendar.GetWeekOfYear(DateTime.Now, CUI.DateTimeFormat.CalendarWeekRule, CUI.DateTimeFormat.FirstDayOfWeek);
            dbConnection x = new dbConnection();
            x.openConnection();
            var dict = new Dictionary<string, int>();
            var reader = x.readerSQL("SELECT username,rang FROM User");
            while (reader.Read())
            {
                if(int.Parse(reader[1].ToString())<10)
                    dict.Add(reader[0].ToString(), 0);
            }
            reader.Close();
            reader = x.readerSQL("SELECT * FROM mdw WHERE kw=" + kw);
            while (reader.Read())
            {
                int v1, v2, v3;
                dict.TryGetValue(reader.GetString("vorschlag1"), out v1);
                dict[reader.GetString("vorschlag1")] = v1 + 1;

                dict.TryGetValue(reader.GetString("vorschlag2"), out v2);
                dict[reader.GetString("vorschlag2")] = v2 + 1;

                dict.TryGetValue(reader.GetString("vorschlag3"), out v3);
                dict[reader.GetString("vorschlag3")] = v3 + 1;

            }
            reader.Close();
            x.closeConnection();
            dict.Remove("");
            var sortedDict = (from entry in dict orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value).Take(10);



            foreach (KeyValuePair<string, int> entry in sortedDict)
            {
                listBox1.Items.Add(entry.Key + ": " + entry.Value);
            }


        }
    }
}
