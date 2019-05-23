
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Principal;
using System.Management;
using System.Diagnostics;
using System.Reflection;

namespace LSMC_Dienstapp
{
    public partial class Form1 : Form
    {
        public static dbConnection dbzugriff;

        public static MysqlClass db;

        public string version = "0.03";

        public bool aktiviert = true;
        public static int rang = -1;
        public static int abteilung;
        public static int userid;
        public static int admin = 0;
        public static int team = 0;
        public static string username;
        private static int cl;
        DateTime prüfung;
        

        public Form1()
        {
            InitializeComponent();
            db = new MysqlClass();
            //dbzugriff = new dbConnection();
            //dbzugriff.openConnection();

            /*Uninvite test = new Uninvite();
            test.Show();*/
            if (!IsRunningAsAdministrator())
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);

                processStartInfo.UseShellExecute = true;
                processStartInfo.Verb = "runas";
                this.Hide();

                Process.Start(processStartInfo);
                Process.GetCurrentProcess().Kill();

                Application.Exit();
                
            }

            spreadsheetapi loading = new spreadsheetapi();
        }
        public static bool IsRunningAsAdministrator()
        {
   
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);


            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //formposition.RestoreWindowPosition(this);
            formposition.ReadPosition(this, "Form1");
            Rechte_Load();
            var new_cl = db.Select("SELECT * FROM changelog ORDER BY id DESC LIMIT 1", "changelog");
            if(int.Parse(new_cl[0][0]) != cl)
            {
                Changelog changelog = new Changelog();
                changelog.Show();
            }
        }

        private void check_API()
        {

        }

        private void Rechte_Load()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LSMC-DienstApp");
            if (key.GetValue("API") == null)
            {
                MessageBox.Show("Programm nicht aktiviert!");
                aktiviert = false;
                this.Hide();
                aktivieren x = new aktivieren();
                x.ShowDialog();
                return;
            }
            var neworupdate = 0;
            string name = key.GetValue("Name").ToString();
            username = name;
            string id = key.GetValue("ID").ToString();
            userid = int.Parse(id);
            string api = key.GetValue("API").ToString();
            label1.Text = "Hallo " + name;
            dbConnection usercheck = new dbConnection();
            usercheck.openConnection();
            // hwid,apikey,rang,admin,team,abteilung
            var reader = usercheck.readerSQL("SELECT * FROM User WHERE id='" + id + "'");
            while (reader.Read())
            {
                if (reader.GetString("hwid") == "~")
                {
                    Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\LSMC-DienstApp");
                    MessageBox.Show("Dein Account wurde erfolgreich von deinem PC entfernt, bitte Starte das Programm neu und gib deine Daten erneut ein!");
                    Application.Exit();
                }
                if (reader.GetString("hwid") != GetMachineGuid())
                {
                    MessageBox.Show("FEHLER! \n Versuchst du dich auf einem anderen PC einzuloggen? \n Bitte kontaktiere eine Person aus der Leaderschaft");
                    Application.Exit();
                }
                if (reader.GetString("apikey") != api)
                {
                    MessageBox.Show("Es ist ein falscher API-Key gespeichert!");
                    Application.Exit();
                }
                if (rang == -1) neworupdate = 1; else 
                if (rang != int.Parse(reader.GetString("rang"))) neworupdate = 2;
                rang = int.Parse(reader.GetString("rang"));
                admin = int.Parse(reader.GetString("admin"));
                team = int.Parse(reader.GetString("team"));
                cl = int.Parse(reader.GetString("cl"));
                try
                {
                    abteilung = int.Parse(reader.GetString("abteilung"));
                } catch
                {
                    MessageBox.Show("Kann Abteilung nicht laden!");
                }
                if (neworupdate == 1)
                {
                    notification.Show("Erfolgreich eingeloggt!", AlertType.success);
                } else if(neworupdate == 2)
                {
                    notification.Show("Rechte aktualisiert!", AlertType.success);
                }
            }
            reader.Close();
            reader = usercheck.readerSQL("SELECT * FROM motd");
            while (reader.Read())
            {
                richTextBox1.Text = reader[0].ToString();
            }
            reader.Close();
            key.Close();
            usercheck.closeConnection();
            GetTermine();
        }

        private string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }

        private void BtnVerwaltung_Click(object sender, EventArgs e)
        {
            if (aktiviert == false)
                return;
            if(rang>9 || admin == 1)
            {
                Verwaltung vwlt = new Verwaltung();
                vwlt.Show();
            }
            else
            {
                notification.Show("Du hast keinen Zugriff darauf!", AlertType.error);
            }
            
        }

        private string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }

        private void btnAusbildung_Click(object sender, EventArgs e)
        {
            if (aktiviert == false)
                return;

            if(abteilung == 2 || admin == 1 || rang >= 10)
            {
                Ausbildungsabteilung x = new Ausbildungsabteilung();
                x.Show();
            }
            else
            {
                notification.Show("Du hast keinen Zugriff darauf!", AlertType.error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (aktiviert == false)
                return;
            if (abteilung == 1 || admin == 1 || rang >= 10)
            {
                Personalabteilung x = new Personalabteilung();
                x.Show();
            }
            else
            {
                notification.Show("Du hast keinen Zugriff darauf!",AlertType.error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prüfungsanmeldung x = new prüfungsanmeldung();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prüfungsstatus f = new prüfungsstatus();
            f.Show();

        }
       
        private void GetTermine()
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM AusbildungsTermine WHERE status = 2 AND prüfling='"+username+"'");
            while (reader.Read())
            {
                string tmp = reader.GetString("termin").Replace("-", "");


                prüfung = DateTime.Parse(tmp);
                
                //MessageBox.Show("Termin"+prüfung.ToShortDateString());
                notificationTimer.Start();
            }
            reader.Close();
            x.closeConnection();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DateTime x = DateTime.Now;
            int prüfungTime2 = -1;
            int prüfungTime = DateTime.Compare(new DateTime(prüfung.Year, prüfung.Month, prüfung.Day, prüfung.Hour-1, prüfung.Minute, 0), new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0));
            try
            {
                prüfungTime2 = DateTime.Compare(new DateTime(prüfung.Year, prüfung.Month, prüfung.Day, prüfung.Hour, prüfung.Minute - 45, 0), new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0));
            }
            catch { }
            
            
            if (prüfungTime == 0)
            {
                
                notificationTimer.Stop();
                notification.Show("Deine Prüfung beginnt in 1 Stunde!", AlertType.warning);
            }
            if (prüfungTime2 == 0)
            {

                notificationTimer.Stop();
                notification.Show("Deine Prüfung beginnt in 15 Minuten!", AlertType.warning);
            }


            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                int mdwTime1 = DateTime.Compare(new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0), new DateTime(x.Year,x.Month,x.Day,18,0,0));
                int mdwTime2 = DateTime.Compare(new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0), new DateTime(x.Year,x.Month,x.Day,19,0,0));
                int mdwTime3 = DateTime.Compare(new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0), new DateTime(x.Year,x.Month,x.Day,19,45,0));
                int besprechungTime = DateTime.Compare(new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0), new DateTime(x.Year,x.Month,x.Day,19,55,0));

                if(mdwTime1 == 0 || mdwTime2 == 0 || mdwTime3 == 0)
                {
                    notification.Show("Falls noch nicht erledigt: Für MdW abstimmen!", AlertType.info);
                }
                if(besprechungTime == 0)
                {
                    notification.Show("Die Besprechung beginnt in 5 Minuten!", AlertType.info);
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            CultureInfo CUI = CultureInfo.CurrentCulture;
            int kw = CUI.Calendar.GetWeekOfYear(DateTime.Now, CUI.DateTimeFormat.CalendarWeekRule, CUI.DateTimeFormat.FirstDayOfWeek);
            int anzahl = x.readerSQLScalar("SELECT Count(1) FROM mdw WHERE username='" + username + "' AND kw = "+kw);
            if(anzahl == 1)
            {
                notification.Show("Du hast diese Woche schon abgestimmt!", AlertType.error);
                return;
            }
            mdw  mdw = new mdw();
            mdw.Show();
            x.closeConnection();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(abteilung == 4 || abteilung == 3 || rang>9 || admin == 1)
            {
                mdwListe f = new mdwListe();
                f.Show();
            }
            else
            {
                notification.Show("Du hast keinen Zugriff darauf!", AlertType.error);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dienstblatt fff = new Dienstblatt();
            fff.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Urlaub f = new Urlaub();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Urlaubsliste f = new Urlaubsliste();
            f.Show();
        }

        private void bunifuCustomTextbox1_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            Rechte_Load();
            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM motd");
            while (reader.Read())
            {
                richTextBox1.Text = reader[0].ToString();
            }
            reader.Close();
            bool red = false;
            reader = x.readerSQL("SELECT status from AusbildungsTermine WHERE prüfling='" + username + "' AND status=1");
            while (reader.Read())
            {
                if(reader.GetString("status") == "1")
                {
                    red = true;
                }
            }
            reader.Close();
            x.closeConnection();
            if (red)
            {
                button3.BackColor = Color.Red;
            }
            else
            {
                button3.ResetBackColor();
                button3.UseVisualStyleBackColor = true;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void schliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bugtrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bitbucket.org/1812luca/lsmc-dienstapp/issues/new");
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changelog changelog = new Changelog();
            changelog.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //formposition.SaveWindowPosition(this);
            formposition.WritePosition(this, "Form1");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bitbucket.org/1812luca/lsmc-dienstapp/issues/new");
        }
    }
}
