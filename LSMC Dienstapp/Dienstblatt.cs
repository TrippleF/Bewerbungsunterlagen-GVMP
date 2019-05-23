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
    public partial class Dienstblatt : Form
    {
        private int columns = 4;
        private int rows = 7;
        private List<List<GroupBox>> gbs;
        private List<List<RichTextBox>> rbs;
        private MysqlClass db;
        private static string[] STATUS = new string[] {"Aktiv","Inaktiv","S0","S1","S2","S3","S4","S5","S6","S7","ID","Leitstelle","Besprechung","Bewerbung","Buero","Event","Fortbildung","FST","Pruefung","Verwaltung","EHK","A - Duty","Einweisung","Freistellung","Bereitschaft" };
        private static List<string> FUNK = new List<string>() { "AUS", "1010", "1010.1", "1010.2", "1010.3", "1010.4", "1010.5", "1010.6", "1010.7", "1010.8", "1010.9", "1000", "1000.4" };
        private string fahrzeug = "";

        // Einsatztelefone Googletabellen
        private static string EINSATZTELEFON_APPNAME = "Test des Tools";
        private static string EINSATZTELEFON_SHEETID = "1Ys3X7DXWsQw_S4ZH1VJNaGRVFmbGn1clhmNsFEwFa6g";
        private bool Telefon = false;
        private string Telefonname = "";

        // Schwarzes Brett
        private List<string>[] Schwarzes_Brett;
        private int Schwarzes_Brett_Zaehler;
        private int Schwarzes_Brett_Vergleichszaehler = 0;
        // Dienstzeit
        private List<string>[] Dienstzeit;
        private int Dienstzeit_Zaehler;
        private int Meine_Dienstzeit;
        // User auflisten
        private List<string>[] User;
        private int User_Zaehler;
        // Freistellungen
        private List<string>[] Freistellung;
        private int Freistellung_Zaehler;

        public Dienstblatt()
        {
            InitializeComponent();
            spreadsheetapi google = new spreadsheetapi();
            db = new MysqlClass();

            // Lade notwendigen Ausgaben am Anfang
            Einsatztelefone(); // Lade Einsatztelefone
            Load_Database();
            Load_SB(); // Lade Schwarzes Brett
            Load_DB(); // Lade das Dienstblatt
            Load_Status(); // lade Status in die Combobox1
        }

        private void Austragen(bool offduty = false)
        {
            var select_fz = db.Select("SELECT * FROM Dienstzeit WHERE fahrzeug = '" + fahrzeug + "' AND ausgetragen IS NULL", "Dienstzeit");
            var count_select_fz = db.zaehler;
            if (count_select_fz == 1 || Check_Krankenhaus(select_fz[5][0]))
            {
                db.Update("UPDATE Dienstzeit SET ausgetragen = NOW() WHERE user = '" + Form1.userid + "' AND ausgetragen IS NULL");
            }
            else
            {
                var uebergabe = MessageBox.Show("Möchtest du alle Austragen/Umtragen?", "Austragung", MessageBoxButtons.YesNo);
                if (uebergabe == DialogResult.Yes)
                {
                    db.Update("UPDATE Dienstzeit SET ausgetragen = NOW() WHERE fahrzeug = '" + fahrzeug + "' AND ausgetragen IS NULL");
                    if (!offduty)
                    {
                        if (button1.Text == "Status wechseln")
                        {
                            for (int i = 0; i < count_select_fz; i++)
                            {
                                if (int.Parse(select_fz[1][i]) != Form1.userid)
                                {
                                    Eintragen(select_fz[1][i]);
                                }
                            }
                        }
                    }
                }
                else if (uebergabe == DialogResult.No)
                {
                    db.Update("UPDATE Dienstzeit SET ausgetragen = NOW() WHERE user = '" + Form1.userid + "' AND ausgetragen IS NULL");
                }
            }
            Load_DB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (button1.Text)
            {
                case "Eintragen":
                    button1.Enabled = false;
                    button2.Enabled = false;
                    if (Eintragen())
                    {
                        button1.Text = "Status wechseln";
                        notification.Show("Ins Dienstblatt eingetragen!", AlertType.success);
                        button1.Enabled = true;
                        button2.Enabled = true;
                    }
                    break;
                case "Status wechseln":

                    button1.Enabled = false;
                    button2.Enabled = false;
                    Austragen();
                    if (Eintragen("", fahrzeug))
                    {
                        notification.Show("Status gewechselt!", AlertType.success);

                        button1.Enabled = true;
                        button2.Enabled = true;
                    }
                    break;
                case "Freistellen":
                    if (comboBox2.SelectedIndex != -1)
                    {
                        if (dateTimePicker1.Text != dateTimePicker2.Text)
                        {
                            if (comboBox1.SelectedIndex == 23)
                            {
                                db.Insert("INSERT INTO Freistellung (userid, name, beginn, ende) VALUES ('" + Form1.userid + "', '" + comboBox2.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                                notification.Show("Freistellung eingetragen!", AlertType.success);
                                comboBox1.SelectedIndex = 0;
                                comboBox2.SelectedIndex = -1;
                                comboBox2.Items.Clear();
                                //Load_DB();
                            }

                        }
                        else
                        {
                            notification.Show("Zeiten müssen unterschiedlich sein!", AlertType.warning);
                        }
                    }
                    else
                    {
                        notification.Show("Kein Mitarbeiter gewählt!", AlertType.warning);
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (button2.Text)
            {
                case "Austragen":
                    button1.Text = "Eintragen";
                    button2.Enabled = false;
                    button1.Enabled = false;
                    Austragen(true);
                    if (Telefonname == Form1.username)
                    {
                        Uebernehme_Einsatztelefon(true);
                    }
                    notification.Show("Aus Dienstblatt ausgetragen!", AlertType.success);
                    System.Threading.Thread.Sleep(1000);
                    button1.Enabled = true;
                    break;
                case "Aufheben":
                    if (comboBox2.SelectedIndex != -1)
                    {
                        if (comboBox1.SelectedIndex == 23)
                        {
                            db.Update("UPDATE Freistellung SET ende = NOW(), aufgehoben = '" + Form1.userid + "' WHERE name = '" + comboBox2.Text + "' AND ende > NOW()");
                            notification.Show("Freistellung aufgehoben!", AlertType.success);
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex = -1;
                            comboBox2.Items.Clear();
                            Load_DB();
                        }
                    }
                    else
                    {
                        notification.Show("Kein Mitarbeiter gewählt!", AlertType.warning);
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form1.rang > 0)
            {
                if (button3.Text == "Übernehmen")
                {
                    Uebernehme_Einsatztelefon();
                }
                else
                {
                    Uebernehme_Einsatztelefon(true);
                }
            }
        }

        private bool Check_Krankenhaus(string fzg)
        {
            if (fzg == "Krankenhaus 1") return true;
            if (fzg == "Krankenhaus 2") return true;
            if (fzg == "Krankenhaus 3") return true;
            if (fzg == "Sandy Shores") return true;
            if (fzg == "Paleto") return true;
            return false;
        }

        private string Convert_to_Time(string zeit)
        {
            return zeit.Substring(11);
        }

        // Standard Richtextbox
        private RichTextBox Create_RB()
        {
            RichTextBox rb = new RichTextBox();
            rb.ReadOnly = true;
            rb.Size = new Size(260, 65);
            rb.Location = new Point(10, 25);
            rb.Font = new Font(FontFamily.GenericSansSerif, 10.00f, FontStyle.Regular);
            rb.BorderStyle = BorderStyle.None;
            return rb;
        }

        private void Dienstblatt_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 21:
                    if (Form1.team == 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        button2.Text = "Austragen";
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        label36.Visible = false;
                        comboBox2.Visible = false;
                        button3.Visible = false;
                        label43.Visible = false;
                        Load_DB();
                    }
                    break;
                case 23:
                    if (Form1.rang >= 10)
                    {
                        button1.Text = "Freistellen";
                        button2.Text = "Aufheben";
                        radioButton1.Text = "Neue";
                        radioButton2.Text = "Bestehende";
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        label34.Visible = true;
                        label35.Visible = true;
                        dateTimePicker1.Visible = true;
                        dateTimePicker2.Visible = true;
                        comboBox2.Visible = true;
                        label36.Visible = true;
                        radioButton2.Enabled = true;
                        button2.Enabled = true;
                        radioButton1.Checked = true;
                        label38.Visible = false;
                        comboBox3.Visible = false;
                        button3.Visible = false;
                        label43.Visible = false;
                        Load_Mitarbeiterlist();
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    break;
                case 24:
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    label34.Visible = false;
                    label35.Visible = false;
                    label36.Visible = false;
                    comboBox2.Visible = false;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    button3.Visible = false;
                    label43.Visible = false;
                    Load_Funk();
                    break;
                default:
                    button2.Text = "Austragen";
                    radioButton1.Visible = true;
                    radioButton1.Text = "Fahrzeugeintragung";
                    radioButton2.Visible = true;
                    radioButton2.Text = "Zu jemanden Eintragen";
                    radioButton1.Checked = true;
                    button1.Enabled = true;
                    label34.Visible = false;
                    label35.Visible = false;
                    label38.Visible = true;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    comboBox2.Visible = true;
                    comboBox3.Visible = true;
                    label36.Visible = true;
                    label36.Text = "Fahrzeug wählen:";
                    Load_DB();
                    Load_Fahrzeuge();
                    Load_Funk();
                    if (Form1.username == Telefonname)
                    {
                        button3.Text = "Ablegen";
                    }
                    else
                    {
                        button3.Text = "Übernehmen";
                    }
                    button3.Visible = true;
                    label43.Visible = true;
                    break;
            }
        }

        private void Einsatztelefone()
        {
            spreadsheetapi Einsatztelefon = new spreadsheetapi(EINSATZTELEFON_APPNAME, EINSATZTELEFON_SHEETID);
            IList<IList<Object>> ausgabe = Einsatztelefon.GetSheetData("Tabellenblatt1!B1:C6");

            if (ausgabe.Count > 0 && ausgabe != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (ausgabe[i][0].ToString() == "Besetzt")
                    {
                        if (i == 0) label1.Text = "91" + i;
                        if (i == 1) label2.Text = "91" + i;
                        if (i == 2) label3.Text = "91" + i;
                        if (i == 3) label4.Text = "91" + i;
                        if (i == 4)
                        {
                            label5.Text = "91" + i;
                            Telefon = true;
                            label42.Text = ausgabe[i][1].ToString();
                            Telefonname = ausgabe[i][1].ToString();
                        }
                        if (i == 5) label6.Text = "91" + i;
                    }
                    else if (ausgabe[i][0].ToString() == "Unbesetzt")
                    {
                        if (i == 0) label1.Text = "---";
                        if (i == 1) label2.Text = "---";
                        if (i == 2) label3.Text = "---";
                        if (i == 3) label4.Text = "---";
                        if (i == 4)
                        {
                            label5.Text = "---";
                            Telefon = false;
                            label42.Text = "---";
                            Telefonname = "";
                        }
                        if (i == 5) label6.Text = "---";
                    }
                }
            }
        }

        private bool Eintragen(string useruebergabe = "", string farhzeuguebergabe = "")
        {
            if (useruebergabe == "") { useruebergabe = Form1.userid.ToString(); }
            if(fahrzeug != "") { farhzeuguebergabe = fahrzeug;  }
            if(farhzeuguebergabe == "" || comboBox2.Text != "") { farhzeuguebergabe = comboBox2.Text;  }

            

            switch (comboBox1.SelectedIndex)
            {
                case 21: // A-Duty
                    db.Insert("INSERT INTO Dienstzeit (user, eingetragen, aktivitaet) VALUES ('" + useruebergabe + "', NOW(), '21')");
                    break;
                case 24: // Bereitschaft
                    db.Insert("INSERT INTO Dienstzeit (user, eingetragen, aktivitaet, funk) VALUES ('" + useruebergabe + "', NOW(), '24', '" + comboBox3.Text + "')");
                    break;
                case 23:
                    break;
                default:
                        if (farhzeuguebergabe == "")
                        {
                            notification.Show("Kein Fahzeug ausgewählt!", AlertType.error);
                            button1.Enabled = true;
                            return false;
                        }
                    if (farhzeuguebergabe != "")
                    {
                        if (!Telefon && Form1.rang > 0 && useruebergabe == Form1.userid.ToString())
                        {
                            var ergebnis = MessageBox.Show("Übernimmst du das Leitstellentelefon?", "Leitstellentelefon", MessageBoxButtons.YesNo);
                            if (ergebnis == DialogResult.Yes)
                            {
                                Uebernehme_Einsatztelefon();
                            }
                        }
                        fahrzeug = farhzeuguebergabe;
                        db.Insert("INSERT INTO Dienstzeit (user, eingetragen, aktivitaet, funk, fahrzeug) VALUES ('" + useruebergabe + "', NOW(), '" + comboBox1.SelectedIndex + "', '" + comboBox3.Text + "', '" + farhzeuguebergabe + "')");
                    }
                    break;
            }
            Load_DB();
            return true;
        }

        private void First_Load_Diensttabelle()
        {
            var count_eintragungen = -1;
            var count_temp = 0;
            var fzg = "";
            string[] temp_text = new string[16];
            string[] temp_fzg = new string[16];
            int[] temp_status = new int[16];
            var user_ausgabe = -1;
            try
            {
                if (Dienstzeit_Zaehler != 0)
                {
                    for (int i = 0; i < Dienstzeit_Zaehler; i++)
                    {
                        if (int.Parse(Dienstzeit[4][i]) != 21 && int.Parse(Dienstzeit[4][i]) != 23 && int.Parse(Dienstzeit[4][i]) != 24)
                        {
                            if (Dienstzeit[5][i] != "Krankenhaus 1" && Dienstzeit[5][i] != "Krankenhaus 2" && Dienstzeit[5][i] != "Krankenhaus 3" && Dienstzeit[5][i] != "Sandy Shores" && Dienstzeit[5][i] != "Paleto")
                            {
                                if (Dienstzeit[5][i] != fzg) { count_eintragungen++; count_temp = 0; temp_text[count_eintragungen] = ""; fzg = Dienstzeit[5][i]; temp_fzg[count_eintragungen] = fzg; temp_status[count_eintragungen] = int.Parse(Dienstzeit[4][i]); }
                                if (count_temp != 0) temp_text[count_eintragungen] += "\r|------------------------------------------------------------|\r";
                                if (User[1].Contains(Dienstzeit[1][i])) { user_ausgabe = User[1].IndexOf(Dienstzeit[1][i]); }
                                temp_text[count_eintragungen] += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + " | Funk: " + Dienstzeit[6][i];
                                count_temp++;
                            }
                        }
                    }
                    count_eintragungen++;
                    Load_Diensttabelle(count_eintragungen, temp_text, temp_fzg, temp_status);
                }
            }
            catch
            {
                MessageBox.Show("Der User wurde nicht gefunden.\rFehlercode: #First_Load_Diensttabelle\rGebe dies an den Administrator weiter!");
            }
        }

        private void Load_ADuty()
        {
            var temp_text = "";
            if (Dienstzeit[4].Contains("21"))
            {
                int z = 0;
                var user_ausgabe = -1;
                try
                {
                    for (int i = 0; i < Dienstzeit_Zaehler; i++)
                    {
                        if (Dienstzeit[4][i] == "21")
                        {
                            if (z != 0) temp_text += "\r";
                            if (User[1].Contains(Dienstzeit[1][i])) { user_ausgabe = User[1].IndexOf(Dienstzeit[1][i]); }
                            temp_text += User[2][user_ausgabe] + " | " + User[6][user_ausgabe];
                            z++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Der User wurde nicht gefunden.\rFehlercode: #Aduty\rGebe dies an den Administrator weiter!");
                }
            }
            if (richTextBox25.Text != temp_text) richTextBox25.Text = temp_text;
        }

        private void Load_Bereitschaft()
        {
            var temp_text = "";
            if (Dienstzeit[4].Contains("24"))
            {
                int z = 0;
                var user_ausgabe = -1;
                try
                {
                    for (int i = 0; i < Dienstzeit_Zaehler; i++)
                    {
                        if (Dienstzeit[4][i] == "24")
                        {
                            if (i != 0) temp_text += "\r|------------------------------------------------------------|\r";
                            if (User[1].Contains(Dienstzeit[1][i])) { user_ausgabe = User[1].IndexOf(Dienstzeit[1][i]); }
                            temp_text += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + "\rFunk: " + Dienstzeit[6][i] + " Telefon: " + User[5][user_ausgabe];
                            z++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Der User wurde nicht gefunden.\rFehlercode: #Bereitschaft\rGebe dies an den Administrator weiter!");
                }
            }
            if (richTextBox27.Text != temp_text) richTextBox27.Text = temp_text;
        }

        private void Load_Database()
        {
            Schwarzes_Brett = db.Select("SELECT * FROM Schwarzes_Brett WHERE aktiv = '1'", "Schwarzes_Brett");
            Schwarzes_Brett_Zaehler = db.zaehler;
            Dienstzeit = db.Select("SELECT * FROM Dienstzeit WHERE ausgetragen IS NULL ORDER BY fahrzeug", "Dienstzeit");
            Dienstzeit_Zaehler = db.zaehler;
            if (Dienstzeit[1].Contains(Form1.userid.ToString()))
            {
                Meine_Dienstzeit = Dienstzeit[1].IndexOf(Form1.userid.ToString());
                fahrzeug = Dienstzeit[5][Meine_Dienstzeit];
            } else
            {
                Meine_Dienstzeit = -1;
            }
            User = db.Select("SELECT * FROM User WHERE uninvite != 2", "User");
            User_Zaehler = db.zaehler;
            Freistellung = db.Select("SELECT * FROM Freistellung WHERE ende > NOW()", "Freistellung");
            Freistellung_Zaehler = db.zaehler;
        }

        // Lade das Dienstblatt
        private void Load_DB()
        {
            Load_Database();
            if(comboBox1.SelectedIndex != 23)
            {
                if (Meine_Dienstzeit != -1)
                {
                    button1.Text = "Status wechseln";
                    button2.Enabled = true;
                   // fahrzeug = Dienstzeit[5][Meine_Dienstzeit];
                } else
                {
                    button1.Text = "Eintragen";
                    button2.Enabled = false;
                  //  fahrzeug = "";
                }

            }
            
            Load_ADuty();
            Load_Freistellung();
            Load_Bereitschaft();
            First_Load_Diensttabelle();
            Load_Krankenhaeuser();
            
        }

        private void Load_Diensttabelle(int count, string[] text, string[] fzg, int[] status)
        {
            for (int i = 0; i < 16; i++)
            {
                var temp_text = "";
                var temp_status = "";
                var temp_fzg = "";
                if (i < count)
                {
                    temp_text = text[i];
                    temp_status = STATUS[status[i]].ToString();
                    temp_fzg = fzg[i];
                }
                switch (i)
                {
                    case 0:
                        if (text[i] != richTextBox5.Text)
                        {
                            richTextBox5.Text = temp_text;
                            label14.Text = temp_status;
                            groupBox7.Text = temp_fzg;
                        }
                        break;
                    case 1:
                        if (text[i] != richTextBox6.Text)
                        {
                            richTextBox6.Text = temp_text;
                            label15.Text = temp_status;
                            groupBox8.Text = temp_fzg;
                        }
                        break;
                    case 2:
                        if (text[i] != richTextBox7.Text)
                        {
                            richTextBox7.Text = temp_text;
                            label16.Text = temp_status;
                            groupBox9.Text = temp_fzg;
                        }
                        break;
                    case 3:
                        if (text[i] != richTextBox8.Text)
                        {
                            richTextBox8.Text = temp_text;
                            label17.Text = temp_status;
                            groupBox10.Text = temp_fzg;
                        }
                        break;
                    case 4:
                        if (text[i] != richTextBox9.Text)
                        {
                            richTextBox9.Text = temp_text;
                            label18.Text = temp_status;
                            groupBox11.Text = temp_fzg;
                        }
                        break;
                    case 5:
                        if (text[i] != richTextBox10.Text)
                        {
                            richTextBox10.Text = temp_text;
                            label19.Text = temp_status;
                            groupBox12.Text = temp_fzg;
                        }
                        break;
                    case 6:
                        if (text[i] != richTextBox11.Text)
                        {
                            richTextBox11.Text = temp_text;
                            label20.Text = temp_status;
                            groupBox13.Text = temp_fzg;
                        }
                        break;
                    case 7:
                        if (text[i] != richTextBox12.Text)
                        {
                            richTextBox12.Text = temp_text;
                            label21.Text = temp_status;
                            groupBox14.Text = temp_fzg;
                        }
                        break;
                    case 8:
                        if (text[i] != richTextBox13.Text)
                        {
                            richTextBox13.Text = temp_text;
                            label22.Text = temp_status;
                            groupBox15.Text = temp_fzg;
                        }
                        break;
                    case 9:
                        if (text[i] != richTextBox14.Text)
                        {
                            richTextBox14.Text = temp_text;
                            label23.Text = temp_status;
                            groupBox16.Text = temp_fzg;
                        }
                        break;
                    case 10:
                        if (text[i] != richTextBox15.Text)
                        {
                            richTextBox15.Text = temp_text;
                            label24.Text = temp_status;
                            groupBox17.Text = temp_fzg;
                        }
                        break;
                    case 11:
                        if (text[i] != richTextBox16.Text)
                        {
                            richTextBox16.Text = temp_text;
                            label25.Text = temp_status;
                            groupBox18.Text = temp_fzg;
                        }
                        break;
                    case 12:
                        if (text[i] != richTextBox17.Text)
                        {
                            richTextBox17.Text = temp_text;
                            label26.Text = temp_status;
                            groupBox19.Text = temp_fzg;
                        }
                        break;
                    case 13:
                        if (text[i] != richTextBox18.Text)
                        {
                            richTextBox18.Text = temp_text;
                            label27.Text = temp_status;
                            groupBox20.Text = temp_fzg;
                        }
                        break;
                    case 14:
                        if (text[i] != richTextBox19.Text)
                        {
                            richTextBox19.Text = temp_text;
                            label28.Text = temp_status;
                            groupBox21.Text = temp_fzg;
                        }
                        break;
                    case 15:
                        if (text[i] != richTextBox20.Text)
                        {
                            richTextBox20.Text = temp_text;
                            label29.Text = temp_status;
                            groupBox22.Text = temp_fzg;
                        }
                        break;
                }
            }
        }

        private void Load_Fahrzeuge()
        {
            comboBox2.Items.Clear();
            var select_res_veh = db.Select("SELECT * FROM Dienstzeit WHERE ausgetragen IS NULL", "Dienstzeit");
            var count_res_veh = db.zaehler;
            if (count_res_veh == 0) radioButton2.Enabled = false; else radioButton2.Enabled = true;
            if (radioButton1.Checked)
            {
                var select_veh = db.Select("SELECT * FROM Fahrzeuge ORDER BY typ, nummer", "Fahrzeuge");
                for (int i = 0; i < db.zaehler; i++)
                {
                    comboBox2.Items.Add(select_veh[1][i] + "-" + select_veh[0][i]);
                }
                for (int i = 0; i < count_res_veh; i++)
                {
                    comboBox2.Items.Remove(select_res_veh[5][i]);
                }
                comboBox2.Items.Add("Krankenhaus 1");
                comboBox2.Items.Add("Krankenhaus 2");
                comboBox2.Items.Add("Krankenhaus 3");
                comboBox2.Items.Add("Sandy Shores");
                comboBox2.Items.Add("Paleto");
            }
            if (radioButton2.Checked)
            {
                for (int i = 0; i < count_res_veh; i++)
                {
                    if (select_res_veh[5][i] != "")
                    {
                        if (!comboBox2.Items.Contains(select_res_veh[5][i]))
                        {

                            comboBox2.Items.Add(select_res_veh[5][i]);
                        }
                    }
                }
            }
        }

        private void Load_Freistellung()
        {
            var temp_text = "";
            if (Freistellung_Zaehler != 0)
            {
                int z = 0;
                var user_ausgabe = -1;
                for (int i = 0; i < Freistellung_Zaehler; i++)
                {
                    if (i != 0) temp_text += "\r|------------------------------------------------------------|\r";
                    if (User[2].Contains(Freistellung[2][i])) { user_ausgabe = User[2].IndexOf(Freistellung[2][i]); }
                    temp_text += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + "\r" + Convert_to_Time(Freistellung[3][i]) + " - " + Convert_to_Time(Freistellung[4][i]);
                }
            }
            if (richTextBox26.Text != temp_text) richTextBox26.Text = temp_text;
        }

        private void Load_Funk()
        {
            comboBox3.Items.Clear();
            if (comboBox1.SelectedIndex != 24)
            {
                for (int i = 0; i < FUNK.Count; i++)
                {
                    comboBox3.Items.Add(FUNK[i]);
                }
            } else
            {
                comboBox3.Items.Add("AUS");
                comboBox3.Items.Add("1010.9");
            }
            comboBox3.SelectedIndex = 0;
        }

        private void Load_Krankenhaeuser()
        {
            var b_ausgabe = db.Select("SELECT * FROM Dienstzeit WHERE fahrzeug = 'Krankenhaus 1' AND ausgetragen IS NULL", "Dienstzeit");
            var count = db.zaehler;
            string[] temp_text = new string[5] { "", "", "", "", "" };
            int[] z = new int[5] { 0, 0, 0, 0, 0 };
            var user_ausgabe = -1;
            try
            {
                for (int i = 0; i < Dienstzeit_Zaehler; i++)
                {
                    if (User[1].Contains(Dienstzeit[1][i])) { user_ausgabe = User[1].IndexOf(Dienstzeit[1][i]); }
                    switch (Dienstzeit[5][i])
                    {
                        case "Krankenhaus 1":
                            if (z[0] != 0) temp_text[0] += "\r|------------------------------------------------------------|\r";
                            temp_text[0] += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + " | Funk: " + Dienstzeit[6][i] + " | " + STATUS[int.Parse(Dienstzeit[4][i])];
                            z[0]++;
                            break;
                        case "Krankenhaus 2":
                            if (z[1] != 0) temp_text[1] += "\r|------------------------------------------------------------|\r";
                            temp_text[1] += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + " | Funk: " + Dienstzeit[6][i] + " | " + STATUS[int.Parse(Dienstzeit[4][i])];
                            z[1]++;
                            break;
                        case "Krankenhaus 3":
                            if (z[2] != 0) temp_text[2] += "\r|------------------------------------------------------------|\r";
                            temp_text[2] += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + " | Funk: " + Dienstzeit[6][i] + " | " + STATUS[int.Parse(Dienstzeit[4][i])];
                            z[2]++;
                            break;
                        case "Sandy Shores":
                            if (z[3] != 0) temp_text[3] += "\r|------------------------------------------------------------|\r";
                            temp_text[3] += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + " | Funk: " + Dienstzeit[6][i] + " | " + STATUS[int.Parse(Dienstzeit[4][i])];
                            z[3]++;
                            break;
                        case "Paleto":
                            if (z[4] != 0) temp_text[4] += "\r|------------------------------------------------------------|\r";
                            temp_text[4] += User[2][user_ausgabe] + " | " + User[6][user_ausgabe] + " | Funk: " + Dienstzeit[6][i] + " | " + STATUS[int.Parse(Dienstzeit[4][i])];
                            z[4]++;
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Der User wurde nicht gefunden.\rFehlercode: #Load_Krankenhaeuser\rGebe dies an den Administrator weiter!");
            }
            if (richTextBox24.Text != temp_text[0]) { richTextBox24.Text = temp_text[0]; }
            if (richTextBox23.Text != temp_text[1]) { richTextBox23.Text = temp_text[1]; }
            if (richTextBox22.Text != temp_text[2]) { richTextBox22.Text = temp_text[2]; }
            if (richTextBox21.Text != temp_text[3]) { richTextBox21.Text = temp_text[3]; }
            if (richTextBox28.Text != temp_text[4]) { richTextBox28.Text = temp_text[4]; }
        }

        private void Load_Mitarbeiterlist()
        {

            label36.Text = "Mitarbeiter wählen:";
            if (comboBox1.SelectedIndex == 23 && radioButton2.Checked)
            {
                comboBox2.Items.Clear();
                var freistellung = db.Select("SELECT * FROM Freistellung WHERE ende > NOW()", "Freistellung");
                for (int i = 0; i < db.zaehler; i++)
                {
                    comboBox2.Items.Add(freistellung[2][i]);
                }
                button1.Enabled = false;
                button2.Enabled = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
            }
            else
            {
                comboBox2.Items.Clear();
                var mitarbeiter = db.Select("SELECT * FROM User WHERE uninvite != 2", "User");
                for (int i = 0; i < db.zaehler; i++)
                {
                    comboBox2.Items.Add(mitarbeiter[2][i]);
                }
                button1.Enabled = true;
                button2.Enabled = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label34.Visible = true;
                label35.Visible = true;
                db.Select("SELECT * FROM Freistellung WHERE ende > NOW()", "Freistellung");
                if (db.zaehler == 0)
                {
                    radioButton2.Enabled = false;
                    button2.Enabled = false;
                }
            }
        }

        // Lade das Schwarze Brett
        private void Load_SB()
        {
            if (Schwarzes_Brett_Vergleichszaehler != Schwarzes_Brett_Zaehler)
            {
                Schwarzes_Brett_Vergleichszaehler = Schwarzes_Brett_Zaehler;
                var zahlen = Shufflenumbers();
                if (Schwarzes_Brett_Vergleichszaehler > 0)
                {
                    SB_Enter(Schwarzes_Brett, groupBox3, richTextBox1, zahlen[0]);
                    if (Schwarzes_Brett_Vergleichszaehler > 1)
                    {
                        SB_Enter(Schwarzes_Brett, groupBox4, richTextBox2, zahlen[1]);
                        if (Schwarzes_Brett_Vergleichszaehler > 2)
                        {
                            SB_Enter(Schwarzes_Brett, groupBox5, richTextBox3, zahlen[2]);
                            if (Schwarzes_Brett_Vergleichszaehler > 3)
                            {
                                SB_Enter(Schwarzes_Brett, groupBox6, richTextBox4, zahlen[3]);
                            } else
                            {
                                SB_Enter(Schwarzes_Brett, groupBox6, richTextBox4);
                            }
                        } else
                        {
                            SB_Enter(Schwarzes_Brett, groupBox5, richTextBox3);
                        }
                    } else
                    {
                        SB_Enter(Schwarzes_Brett, groupBox4, richTextBox2);
                    }
                } else
                {
                    SB_Enter(Schwarzes_Brett, groupBox3, richTextBox1);
                }
            }
        }

        // Lade die möglichen Status in die Combobox
        private void Load_Status()
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < STATUS.Length; i++)
            {
                comboBox1.Items.Add(STATUS[i]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
            if (comboBox1.SelectedIndex == 23) { Load_Mitarbeiterlist(); }
            else
            {
                Load_Fahrzeuge();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
            if (comboBox1.SelectedIndex == 23) { Load_Mitarbeiterlist(); } else
            {
                Load_Fahrzeuge();
            }
        }

        // Erstelle den jeweiligen Eintrag fürs Schwarze Brett
        private void SB_Enter(List<string>[] entry, GroupBox gb, RichTextBox rb, int index = -1)
        {
            if (index != -1)
            {
                gb.BackColor = Color.LightGoldenrodYellow;
                rb.BackColor = Color.LightGoldenrodYellow;
                gb.ForeColor = Color.Black;
                rb.ForeColor = Color.Black;
                gb.Text = "Information";
                rb.Text = entry[2][index];
                if (int.Parse(entry[1][index]) == 1)
                {
                    gb.BackColor = Color.OrangeRed;
                    rb.BackColor = Color.OrangeRed;
                    gb.ForeColor = Color.White;
                    rb.ForeColor = Color.White;
                    gb.Text = "Anweisung";
                }
            } else
            {
                gb.BackColor = SystemColors.Control;
                rb.BackColor = SystemColors.Control;
                gb.ForeColor = Color.Black;
                rb.ForeColor = Color.Black;
                gb.Text = "";
                rb.Text = "";
            }
            
        }

        private void schwarzesBrettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schwarzes_Brett sb = new Schwarzes_Brett();
            sb.ShowDialog();
        }

        private int[] Shufflenumbers()
        {
            int maxshuffle = 4;
            int value;
            if (Schwarzes_Brett_Zaehler < 4) maxshuffle = Schwarzes_Brett_Zaehler;
            int[] numbers = new int[4] { Schwarzes_Brett_Zaehler + 1, Schwarzes_Brett_Zaehler + 1, Schwarzes_Brett_Zaehler + 1, Schwarzes_Brett_Zaehler + 1 };
            
            Random random = new Random();

            for(int i = 0; i < maxshuffle; i++)
            {
                do
                {
                    value = random.Next(Schwarzes_Brett_Zaehler);
                } while (numbers.Contains(value));
                numbers[i] = value;
            }

            return numbers;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Lade notwendigen Ausgaben am Anfang

            Einsatztelefone();
            Load_Database();
            Load_SB();
            Load_DB();
        }

        private void Uebernehme_Einsatztelefon(bool ablegen = false)
        {

            string AppName = "Test des Tools";
            string SheetId = "1Ys3X7DXWsQw_S4ZH1VJNaGRVFmbGn1clhmNsFEwFa6g";
            spreadsheetapi telefone = new spreadsheetapi(AppName, SheetId);

            List<IList<Object>> objNewRecords = new List<IList<Object>>();

            IList<Object> obj = new List<Object>();
            if (ablegen)
            {
                obj.Add("Unbesetzt");
                obj.Add("---");
                Telefonname = "";
                button3.Text = "Übernehmen";
            }
            else
            {
                obj.Add("Besetzt");
                obj.Add(Form1.username);
                Telefonname = Form1.username;
                button3.Text = "Ablegen";
            }
            objNewRecords.Add(obj);
            telefone.updateTable("Tabellenblatt1!B5:C5", objNewRecords);
        }
    }
}
