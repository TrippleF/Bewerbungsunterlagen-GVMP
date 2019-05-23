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
    public partial class Ausbildungsabteilung : Form
    {
        public Ausbildungsabteilung()
        {
            InitializeComponent();
        }
        int fenster = 1;

        private void Ausbildungsabteilung_Load(object sender, EventArgs e)
        {
            if(Form1.rang == 9)
            {
                Verwaltung();
                menuStrip1.Items[3].Enabled = false;
                
            }
            else if(Form1.rang<9)
            {
                Schulungen();
                menuStrip1.Items[0].Enabled = false;
                menuStrip1.Items[3].Enabled = false;
            }
            else
            {
                Verwaltung();
            }
            
        }

        
        List<List<string>> bemerkungen = new List<List<string>>();

        private void Verwaltung()
        {
            fenster = 1;
            dbConnection x = new dbConnection();
            x.openConnection();
            this.dGAusbildung.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dGAusbildung.Rows.Clear();
            dGAusbildung.Columns.Clear();
            int headerCount = 0;
            //int headerCount = x.readerSQLScalar("SELECT COUNT(id) FROM Pruefungsliste");
            //MessageBox.Show(headerCount.ToString());
            dGAusbildung.ColumnCount = 5;
            dGAusbildung.Columns[0].Name = "ID";

            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;

            dGAusbildung.Columns.Insert(1, dgvButton);
            dGAusbildung.Columns[2].Name = "Forumname";
            dGAusbildung.Columns[3].Name = "Rang";
            dGAusbildung.Columns[4].Name = "";
            //dGAusbildung.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            //dGAusbildung.Columns[4].DefaultCellStyle.BackColor = Color.Gray;
            dGAusbildung.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);

            var readListe = x.readerSQL("SELECT * from Pruefungsliste");

            while (readListe.Read())
            {
                headerCount++;
                if (readListe[3].ToString() == "1")
                {
                    dGAusbildung.ColumnCount++;
                    dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = "Ja/Nein";

                    dGAusbildung.ColumnCount++;
                    dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = readListe[1].ToString();

                    if (readListe[4].ToString() != "")
                    {
                        dGAusbildung.ColumnCount++;
                        dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = readListe[4].ToString();

                    }
                    dGAusbildung.ColumnCount++;
                    dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = "";
                   // dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
            readListe.Close();
            dGAusbildung.ColumnCount++;
            dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = "Bemerkung";
            dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            
            var readMitarbeiter = x.readerSQL("SELECT id,username,forumname,rang,ausbilderBemerkung from User ORDER BY rang DESC");
            while (readMitarbeiter.Read())
            {
                dGAusbildung.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString(), readMitarbeiter[3].ToString());
                List<string> tmp = new List<string>();
                tmp.Add(readMitarbeiter[0].ToString());
                tmp.Add(readMitarbeiter.GetString("ausbilderBemerkung"));
                bemerkungen.Add(tmp);

                foreach (DataGridViewRow row in dGAusbildung.Rows)
                {
                    if (row.Cells[0].Value.ToString() == readMitarbeiter[0].ToString())
                    {
                        foreach (DataGridViewColumn column in dGAusbildung.Columns)
                        {
                          
                            if (column.HeaderText == "Bemerkung")
                            {
                                for (int y = 0; y < bemerkungen.Count; y++)
                                {

                                    if (bemerkungen[y][0] == readMitarbeiter[0].ToString())
                                    {
                                        dGAusbildung.Rows[row.Index].Cells[column.Index].Value = bemerkungen[y][1];
                                    }
                                }

                            }

                        }
                    }
                }

            }
            readMitarbeiter.Close();

            var reader = x.readerSQL("SELECT * from Pruefungen");
            while (reader.Read())
            {
                for (int i = 0; i <= headerCount; i++)
                {
                    string uid = reader.GetString("userid");
                    string pruefung = reader.GetString("pruefung");
                    int bestanden = int.Parse(reader[3].ToString());
                    string bemerkung = reader.GetString("bemerkung");
                    string prüfer = reader.GetString("pruefer");

                    foreach (DataGridViewRow row in dGAusbildung.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == uid)
                        {
                            foreach (DataGridViewColumn column in dGAusbildung.Columns)
                            {
                                if (column.HeaderText == pruefung)
                                {
                                    dGAusbildung.Rows[row.Index].Cells[column.Index].Value = prüfer;
                                    if (bestanden == 1)
                                    {
                                        dGAusbildung.Rows[row.Index].Cells[column.Index - 1].Value = "Ja";
                                    }
                                    else
                                    {
                                        dGAusbildung.Rows[row.Index].Cells[column.Index - 1].Value = "Nein";
                                    }

                                    if (bemerkung != "")
                                    {
                                        dGAusbildung.Rows[row.Index].Cells[column.Index + 1].Value = bemerkung;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            reader.Close();
            x.closeConnection();

            SizeForm();
        }

        private void Schulungen()
        {
            this.dGAusbildung.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            fenster = 1;
            dbConnection x = new dbConnection();
            x.openConnection();
            dGAusbildung.Rows.Clear();
            dGAusbildung.Columns.Clear();
            int headerCount = 0;
            dGAusbildung.ColumnCount = 5;
            dGAusbildung.Columns[0].Name = "ID";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;

            dGAusbildung.Columns.Insert(1, dgvButton);
            dGAusbildung.Columns[2].Name = "Forumname";
            dGAusbildung.Columns[3].Name = "Rang";
            dGAusbildung.Columns[4].Name = "";
            //dGAusbildung.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            //dGAusbildung.Columns[4].DefaultCellStyle.BackColor = Color.Gray;
            dGAusbildung.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);

            var readListe = x.readerSQL("SELECT * from Schulungsliste");

            while (readListe.Read())
            {
                headerCount++;
                if (int.Parse(readListe[2].ToString()) == 1)
                {
                    dGAusbildung.ColumnCount++;
                    dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = readListe[1].ToString();

                }
                dGAusbildung.ColumnCount++;
                dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = "";
                //dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].DefaultCellStyle.BackColor = Color.Gray;

            }
            readListe.Close();


            var readMitarbeiter = x.readerSQL("SELECT id,username,forumname,rang from User");
            while (readMitarbeiter.Read())
            {
                dGAusbildung.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString(), readMitarbeiter[3].ToString());
            }
            readMitarbeiter.Close();


            var reader = x.readerSQL("SELECT * from Schulungen");
            while (reader.Read())
            {
                for (int i = 0; i <= headerCount; i++)
                {
                    string uid = reader.GetString("userid");
                    string pruefung = reader.GetString("schulung");
                    string prüfer = reader.GetString("pruefer");
                    foreach (DataGridViewRow row in dGAusbildung.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == uid)
                        {
                            foreach (DataGridViewColumn column in dGAusbildung.Columns)
                            {
                                if (column.HeaderText == pruefung)
                                {
                                    dGAusbildung.Rows[row.Index].Cells[column.Index].Value = prüfer;


                                }

                            }
                        }
                    }

                }
            }
            reader.Close();
            x.closeConnection();
            
        }

        private void FST()
        {
            this.dGAusbildung.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            fenster = 1;
            dbConnection x = new dbConnection();
            x.openConnection();

            dGAusbildung.Rows.Clear();
            dGAusbildung.Columns.Clear();
            int headerCount = 0;

            dGAusbildung.ColumnCount = 5;
            dGAusbildung.Columns[0].Name = "ID";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dGAusbildung.Columns.Insert(1, dgvButton);
            dGAusbildung.Columns[2].Name = "Forumname";
            dGAusbildung.Columns[3].Name = "Rang";
            dGAusbildung.Columns[4].Name = "";

            //dGAusbildung.Columns[4].DefaultCellStyle.BackColor = Color.Gray;
            //dGAusbildung.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            dGAusbildung.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);



           
            var readListe = x.readerSQL("SELECT * from FSTListe");


            while (readListe.Read())
            {

                headerCount++;

                if (int.Parse(readListe[2].ToString()) == 1)
                {
                    dGAusbildung.ColumnCount++;
                    dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = readListe[1].ToString();

                }
                dGAusbildung.ColumnCount++;
                dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].Name = "";
                //dGAusbildung.Columns[dGAusbildung.ColumnCount - 1].DefaultCellStyle.BackColor = Color.Gray;

            }
            readListe.Close();


            var readMitarbeiter = x.readerSQL("SELECT id,username,forumname,rang from User");
            while (readMitarbeiter.Read())
            {
                dGAusbildung.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString(), readMitarbeiter[3].ToString());
            }
            readMitarbeiter.Close();


            var reader = x.readerSQL("SELECT * from FST");
            while (reader.Read())
            {
                for (int i = 0; i <= headerCount; i++)
                {
                    string uid = reader.GetString("userid");
                    string pruefung = reader.GetString("fst");
                    string prüfer = reader.GetString("pruefer");
                    foreach (DataGridViewRow row in dGAusbildung.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == uid)
                        {
                            foreach (DataGridViewColumn column in dGAusbildung.Columns)
                            {
                                if (column.HeaderText == pruefung)
                                {
                                    dGAusbildung.Rows[row.Index].Cells[column.Index].Value = prüfer;


                                }

                            }
                        }
                    }

                }
            }
            reader.Close();
            x.closeConnection();
 
        }

        private void übersichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Verwaltung();
        }

        private void schulungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schulungen();
        }

        private void fahrsicherheitstrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FST();
        }

        private void verwaltungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ausbildung_Prüfungsverwaltung x = new Ausbildung_Prüfungsverwaltung();
            x.Show();
        }

        private void prüfungstermineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.meistertask.com/app/project/5Q3kfcQc/prufungstermine");
        }

        private void prüfungsverteilungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.meistertask.com/app/project/eZay9GyV/prufungsverteilung");
        }

        private void einweisungChecklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            einweisung_checklist x = new einweisung_checklist();
            x.Show();
        }

        private void prüfungseinladungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://docs.google.com/document/d/19bbDu2bGYMq7BagOY6rp-Hbg38dI14fiqsbLkX7MS3o/edit");
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://sites.google.com/view/lsmcausbildungsabteilung/startseite");
        }

        private void termineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            termine();
        }
        private void termine()
        {
            fenster = 2;
            dGAusbildung.Rows.Clear();
            dGAusbildung.Columns.Clear();

            dGAusbildung.ColumnCount = 8;
            dGAusbildung.Columns[0].Name = "ID";

            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dGAusbildung.Columns.Insert(1, dgvButton);
            dGAusbildung.Columns[2].Name = "Prüfung";
            dGAusbildung.Columns[3].Name = "Wochentage";
            dGAusbildung.Columns[4].Name = "Uhrzeit";
            dGAusbildung.Columns[5].Name = "";
            dGAusbildung.Columns[6].Name = "Termin";
            dGAusbildung.Columns[7].Name = "Prüfer";
            dGAusbildung.Columns[8].Name = "Status";
            dGAusbildung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dbConnection x = new dbConnection();

            x.openConnection();
            var readMitarbeiter = x.readerSQL("SELECT * FROM AusbildungsTermine");
            while (readMitarbeiter.Read())
            {
                string status = readMitarbeiter.GetString("status");
                if (status == "0")
                    status = "Anfrage";
                else if (status == "1")
                    status = "Termin erhalten";
                else if (status == "2")
                    status = "Termin bestätigt";
                else if (status == "4")
                    status = "Termin abgesagt";
                else if (status == "3")
                    status = "Termin abgelehnt";
                else
                    status = "-";

                if(readMitarbeiter.GetString("status") != "5")
                    dGAusbildung.Rows.Add(readMitarbeiter.GetString("id"), readMitarbeiter.GetString("prüfling"), readMitarbeiter.GetString("prüfung"), readMitarbeiter.GetString("wochentage"), readMitarbeiter.GetString("uhrzeit"), "",readMitarbeiter.GetString("prüfer"), readMitarbeiter.GetString("termin"),status);

            }
            readMitarbeiter.Close();
            x.closeConnection();
            
        }



        private void dGAusbildung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fenster == 1)
            {
                if (e.ColumnIndex == 1)
                {

                    if (e.RowIndex == -1)
                        return;
                    string name = dGAusbildung.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string id = dGAusbildung.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                    Ausbildung_User_Manage x = new Ausbildung_User_Manage();
                    Ausbildung_User_Manage.name = name;
                    Ausbildung_User_Manage.id = id;
                    x.ShowDialog();
                    if (x.DialogResult == DialogResult.OK)
                    {
                        Verwaltung();
                    }
                    if (x.DialogResult == DialogResult.Yes)
                    {
                        Schulungen();
                    }
                    if (x.DialogResult == DialogResult.No)
                    {
                        FST();
                    }

                }
            }
            if (fenster == 2)
            {
                if (e.ColumnIndex == 1)
                {

                    if (e.RowIndex == -1)
                        return;
                    string name = dGAusbildung.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string id = dGAusbildung.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                    string prüfung = dGAusbildung.Rows[e.RowIndex].Cells[2].Value.ToString();
                    termin_manage x = new termin_manage();
                    termin_manage.name = name;
                    termin_manage.id = id;
                    termin_manage.prüfung = prüfung;
                    x.ShowDialog();
                    if (x.DialogResult == DialogResult.OK)
                    {
                        termine();
                    }
                }
            }
        }
        private void SizeForm()
        {
            if (SystemInformation.VirtualScreen.Width < 2000 && SystemInformation.VirtualScreen.Width > 1680)
            {
                this.MaximumSize = new Size(1800, 900);
            }
            else if (SystemInformation.VirtualScreen.Width <= 1680 && SystemInformation.VirtualScreen.Width > 1280)
            {
                this.MaximumSize = new Size(1500, 900);
            }
            else if (SystemInformation.VirtualScreen.Width <= 1280)
            {
                this.MaximumSize = new Size(1000, 600);
            }
            else
            {
                this.MaximumSize = new Size(int.MaxValue, int.MaxValue);
            }


            this.Width = dGAusbildung.Width;
            int dgv_width = dGAusbildung.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)+60;
            int dgv_height = dGAusbildung.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 500;
            this.Width = dgv_width;
            dGAusbildung.Width = this.Width;
            this.Height = dgv_height;
        }
    }

}
