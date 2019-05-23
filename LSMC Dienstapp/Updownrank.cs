using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace LSMC_Dienstapp
{
    public partial class Updownrank : Form
    {
        private List<List<string>> mitarbeiter;
        public Updownrank()
        {

            InitializeComponent();

            Insert_Mitarbeiter();
            Lblrang.Text = "";
        }

        private void Insert_Mitarbeiter()
        {
            dbConnection abfragemitarbeiter = new dbConnection();
            abfragemitarbeiter.openConnection();
            var res = abfragemitarbeiter.readerSQL("SELECT * FROM User");

            mitarbeiter = new List<List<string>>();

            while (res.Read())
            {
                List<string> temp = new List<string>();
                CBMitarbeiter.Items.Add(res[2]);
                temp.Add(res[2].ToString()); // 0 = Username
                temp.Add(res[1].ToString()); // 1 = ID
                temp.Add(res[6].ToString()); // 2 = rang

                mitarbeiter.Add(temp);
            }
            abfragemitarbeiter.closeConnection();
        }

        private void CBMitarbeiter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CBMitarbeiter.SelectedIndex != -1)
            {
                var pos = Suche_Mitarbeiter();
                Lblrang.Text = mitarbeiter[pos][2];
                CBnewrang.Text = mitarbeiter[pos][2];
            }
        }

        private int Suche_Mitarbeiter()
        {
            for(int i = 0; i < CBMitarbeiter.Items.Count; i++)
            {
                if(mitarbeiter[i][0] == CBMitarbeiter.Text)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Setze_Werte()
        {
            Lblrang.Text = "";
            CBMitarbeiter.SelectedIndex = -1;
            CBnewrang.SelectedIndex = -1;
            CBchange.SelectedIndex = -1;
            TBbemerkung.Text = "";
        }

        private void Btnaccept_Click(object sender, EventArgs e)
        {
            if(CBchange.Text != "")
            {
                var pos = Suche_Mitarbeiter(); // Suche nach aktuell ausgewählten Mitarbieter
                dbConnection userchange = new dbConnection();
                userchange.openConnection();
                userchange.ExecuteSQL("UPDATE User SET rang = '" + CBnewrang.Text + "' WHERE username = '" + CBMitarbeiter.Text + "' LIMIT 1");
                userchange.closeConnection();
                dbConnection addrangupdate = new dbConnection();
                addrangupdate.openConnection();
                addrangupdate.ExecuteSQL("INSERT INTO updownrank (userid, datum, rang, art, bemerkung) VALUES ('" + mitarbeiter[pos][1] + "', NOW(), '" + CBnewrang.Text + "', '" + CBchange.Text + "', '" + MySQLEscape(TBbemerkung.Text) + "')");
                addrangupdate.closeConnection();
                MessageBox.Show("Rangänderung durchgeführt");

                Setze_Werte();
            } else
            {
                MessageBox.Show("Welche Art der Rangänderung ist es?");
            }
        }

        private static string MySQLEscape(string str)
        {
            return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
                delegate (Match match)
                {
                    string v = match.Value;
                    switch (v)
                    {
                        case "\x00":            // ASCII NUL (0x00) character
                    return "\\0";
                        case "\b":              // BACKSPACE character
                    return "\\b";
                        case "\n":              // NEWLINE (linefeed) character
                    return "\\n";
                        case "\r":              // CARRIAGE RETURN character
                    return "\\r";
                        case "\t":              // TAB
                    return "\\t";
                        case "\u001A":          // Ctrl-Z
                    return "\\Z";
                        default:
                            return "\\" + v;
                    }
                });
        }
    }
}
