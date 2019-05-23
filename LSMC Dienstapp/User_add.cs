using MySql.Data.MySqlClient;
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
    public partial class User_add : Form
    {
        public dbConnection dbzugriff;
        public User_add()
        {
            InitializeComponent();
        }

        private void BtnUseradd_Click(object sender, EventArgs e)
        {
            // Name realistisch angegegben, dann gehts weiter
            if (check_username(Txtmembername.Text))
            {
                if (Txtforumname.Text != "")
                {
                    int userid;
                    if (int.TryParse(Txtuserid.Text, out userid))
                    {
                        int phonenumber;
                        if (int.TryParse(Txtphonenumber.Text, out phonenumber))
                        {
                            dbConnection dbabfrage = new dbConnection();
                            dbabfrage.openConnection();
                            var abfrage = dbabfrage.readerSQL("SELECT Count(*) FROM User WHERE `id`= '" + userid + "'");
                            abfrage.Read();
                            if (abfrage[0].ToString() != "0")
                            {
                                MessageBox.Show("User existiert bereits!");
                            } else
                            {
                                var api_key = Generate_api();
                                dbConnection insertquery = new dbConnection();
                                insertquery.openConnection();
                                insertquery.ExecuteSQL("INSERT INTO User (apikey, id, username, forumname, beitritt, telefon, rang, email, abteilung) VALUES ('" + api_key + "', '" + userid + "', '" + Txtmembername.Text + "', '" + Txtforumname.Text + "', NOW(), '" + phonenumber + "', '0', NULL, NULL)");
                                insertquery.closeConnection();
                                MessageBox.Show("Generierter API Key: " + api_key);
                                Clipboard.SetText(api_key);
                                MessageBox.Show("Ausgabe: " + abfrage[0]);
                            }
                            dbabfrage.closeConnection();
                        } else
                        {
                            MessageBox.Show("Die Eingabe der Telefonnummer ist keine Zahl!");
                        }
                    } else
                    {
                        MessageBox.Show("Die Eingabe der Userid ist keine Zahl!");
                    }
                } else
                {
                    MessageBox.Show("Kein Forumsname angegeben!");
                }
            } // Benötigt keine else da in der Funktion der else Teil ist.
        }

        private string Generate_api()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var api_key = new char[32];
            var random = new Random();

            for(int i = 0; i < api_key.Length; i++)
            {
                api_key[i] = chars[random.Next(chars.Length)];
            }

            var final_api = new String(api_key);
            return final_api;
        }

        private bool check_username(string user)
        {
            if (user != "")
            {
                if (user.Contains("_"))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Der Name enthält kein _!");
                    return false;
                }
            } else
            {
                MessageBox.Show("Kein Username eingetragen!");
                return false;
            }
        }
    }
}
