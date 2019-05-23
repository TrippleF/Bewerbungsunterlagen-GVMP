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
    public partial class Personalabteilung : Form
    {
        public Personalabteilung()
        {
            InitializeComponent();
        }
        List<List<string>> bemerkungen = new List<List<string>>();
        int fenster = 1;
        private void Personalabteilung_Load(object sender, EventArgs e)
        {
            verwaltung();
            if (Form1.rang < 10)
            {
                gesprächFallbeispieleVerwaltenToolStripMenuItem.Enabled = false;
            }
            
        }
        private void verwaltung()
        {
            fenster = 1;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "ID";

            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Forumname";
            dataGridView1.Columns[3].Name = "Telefon";
            dataGridView1.Columns[4].Name = "Rang";
            dataGridView1.Columns[5].Name = "";
            //dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
            //dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dataGridView1.Columns[7].Name = "Bemerkung";
            dataGridView1.Columns[7].HeaderCell.Style.Padding = new Padding(80, 0, 80, 0);
            dbConnection x = new dbConnection();

            x.openConnection();
            var readMitarbeiter = x.readerSQL("SELECT id,username,forumname,telefon,rang,personalBemerkung,sanktionspunkte from User ORDER BY rang DESC");
            while (readMitarbeiter.Read())
            {
                dataGridView1.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString(), readMitarbeiter[3].ToString(), readMitarbeiter[4].ToString(), readMitarbeiter[5].ToString());
                List<string> tmp = new List<string>();
                tmp.Add(readMitarbeiter[0].ToString());
                tmp.Add(readMitarbeiter.GetString("personalBemerkung"));
                //MessageBox.Show(readMitarbeiter[4].ToString())
                bemerkungen.Add(tmp);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //MessageBox.Show(readMitarbeiter[0].ToString());
                    try
                    {
                        if (row.Cells[0].Value.ToString() == readMitarbeiter[0].ToString())
                        {
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {

                                if (column.HeaderText == "Bemerkung")
                                {
                                    for (int y = 0; y < bemerkungen.Count; y++)
                                    {

                                        if (bemerkungen[y][0] == readMitarbeiter[0].ToString())
                                        {
                                            dataGridView1.Rows[row.Index].Cells[column.Index].Value = bemerkungen[y][1];
                                        }
                                    }

                                }

                            }
                        }
                    }
                    catch (Exception ex) { }

                }
            }
            readMitarbeiter.Close();
            x.closeConnection();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void terminEintragenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Termin_eintragen x = new Termin_eintragen();
            x.ShowDialog();
            if(x.DialogResult == DialogResult.OK)
            {
                Termine();
            }
        }
        private void Termine()
        {
            fenster = 2;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Name";

            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(0, dgvButton);
            dataGridView1.Columns[1].Name = "Datum";
            dataGridView1.Columns[2].Name = "Uhrzeit";
            dataGridView1.Columns[3].Name = "";
            dataGridView1.Columns[4].Name = "Status";
            dataGridView1.Columns[0].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dataGridView1.Columns[4].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);

            dbConnection x = new dbConnection();

            x.openConnection();
            var readMitarbeiter = x.readerSQL("SELECT name,datum,uhrzeit,aktiv,status FROM Bewerbungstermine");
            while (readMitarbeiter.Read())
            {
                string info;
                if (readMitarbeiter[3].ToString() == "1")
                {
                    if (readMitarbeiter[4].ToString() == "2")
                    {
                        info = "Angenommen";
                    }
                    else if (readMitarbeiter[4].ToString() == "3")
                    {
                        info = "Abgelehnt";
                    }
                    else
                    {
                        info = "Eingeladen";
                    }


                    dataGridView1.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString() + " Uhr", "", info);
                }

            }
            readMitarbeiter.Close();
            x.closeConnection();
        }
        private void termineAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Termine();
        }

        private void verwaltungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verwaltung();
        }

        private void gesprächFallbeispieleVerwaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FallbeispielVerwalten x = new FallbeispielVerwalten();
            x.ShowDialog();

            if(x.DialogResult == DialogResult.OK)
            {
                verwaltung();
            }

        }

        private void furhparkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuhrpark x = new Fuhrpark();
            x.Show();
        }

        private void sanktionVergebenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sanktion x = new sanktion();
            x.Show();

        }
        List<List<string>> sanktionen = new List<List<string>>();
        private void sanktionenAnschauenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sanktionenload();
            
        }

        private void sanktionenload()
        {
            fenster = 3;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";

            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Vergehen";
            dataGridView1.Columns[3].Name = "Datum";
            dataGridView1.Columns[4].Name = "Strafe";
            dataGridView1.Columns[5].Name = "Bezahlt";
            dataGridView1.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dataGridView1.Columns[2].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);


            dbConnection x = new dbConnection();

            x.openConnection();

            var reader = x.readerSQL("SELECT id,Vergehen FROM Strafkatalog");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("id"));
                tmp.Add(reader.GetString("Vergehen"));
                sanktionen.Add(tmp);
            }
            reader.Close();




            reader = x.readerSQL("SELECT * FROM Sanktionen");

            while (reader.Read())
            {
                string name = reader.GetString("username");
                string sanktionsid = reader.GetString("sanktion");
                string datum = reader.GetString("datum");
                string aktiv = reader[5].ToString();
                string sanktion = sanktionen[Suche_Sanktion(sanktionsid)][1];
                string strafe = reader.GetString("strafe");
                if (aktiv != "3")
                {
                    if (aktiv == "1" || aktiv == "true")
                    {
                        aktiv = "Nein";
                    }
                    else
                    {
                        aktiv = "Ja";
                    }
                    //

                    dataGridView1.Rows.Add(reader.GetString("id"), name, sanktion, datum,strafe+"$", aktiv);
                }
               
            }
            reader.Close();
            x.closeConnection();
        }
        private void sanktionenArchiv()
        {
            fenster = 4;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";


            dataGridView1.Columns[2].Name = "SanktionsID";
            dataGridView1.Columns[3].Name = "Datum";
            dataGridView1.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dataGridView1.Columns[2].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);


            dbConnection x = new dbConnection();

            x.openConnection();

            var reader = x.readerSQL("SELECT id,Vergehen FROM Strafkatalog");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("id"));
                tmp.Add(reader.GetString("Vergehen"));
                sanktionen.Add(tmp);
            }
            reader.Close();




            reader = x.readerSQL("SELECT * FROM Sanktionen  WHERE aktiv = 3");

            while (reader.Read())
            {
                string name = reader.GetString("username");
                string sanktionsid = reader.GetString("sanktion");
                string datum = reader.GetString("datum");
                string sanktion = sanktionen[Suche_Sanktion(sanktionsid)][1];
                   dataGridView1.Rows.Add(reader.GetString("id"), name, sanktion, datum);
                

            }
            reader.Close();
            x.closeConnection();
        }
        private int Suche_Sanktion(string sanktionsID)
        {
            for (int i = 0; i < sanktionen.Count; i++)
            {
                if (sanktionen[i][0] == sanktionsID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void sanktionsarchivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sanktionenArchiv();
        }
        private void terminarchiv()
        {
            fenster = 4;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Name";

            
            dataGridView1.Columns[1].Name = "Datum";
            dataGridView1.Columns[2].Name = "Uhrzeit";
            dataGridView1.Columns[3].Name = "";
            dataGridView1.Columns[4].Name = "Status";
            dataGridView1.Columns[0].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dataGridView1.Columns[4].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);

            dbConnection x = new dbConnection();

            x.openConnection();
            var readMitarbeiter = x.readerSQL("SELECT name,datum,uhrzeit,aktiv,status FROM Bewerbungstermine");
            while (readMitarbeiter.Read())
            {
                string info;
                if (readMitarbeiter[3].ToString() == "0")
                {
                    if (readMitarbeiter[4].ToString() == "2")
                    {
                        info = "Angenommen";
                    }
                    else if (readMitarbeiter[4].ToString() == "3")
                    {
                        info = "Abgelehnt";
                    }
                    else if (readMitarbeiter[4].ToString() == "4")
                    {
                        info = "Termin gelöscht";
                    }
                    else
                    {
                        info = "Eingeladen";
                    }


                    dataGridView1.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString() + " Uhr", "", info);
                }

            }
            readMitarbeiter.Close();
            x.closeConnection();

        }
        private void archivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terminarchiv();
        }

        private void einweisungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theorieEnweisung x = new theorieEnweisung();
            x.Show();
        }



        private void archivToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fenster = 5;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";


            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Link";
            dataGridView1.Columns[3].Name = "Gefehlt";
            dataGridView1.Columns[4].Name = "Woche";
            dataGridView1.Columns[1].HeaderCell.Style.Padding = new Padding(50, 0, 50, 0);
            dataGridView1.Columns[2].HeaderCell.Style.Padding = new Padding(30, 0, 50, 0);
            dataGridView1.Columns[3].HeaderCell.Style.Padding = new Padding(80, 0, 50, 0);

            dbConnection x = new dbConnection();

            x.openConnection();
            var readMitarbeiter = x.readerSQL("SELECT * from FahrzeugbeladungArchiv");
            while (readMitarbeiter.Read())
            {
               
                dataGridView1.Rows.Add(readMitarbeiter[0].ToString(), readMitarbeiter[1].ToString(), readMitarbeiter[2].ToString(), readMitarbeiter[3].ToString(), readMitarbeiter[4].ToString());
            }
            readMitarbeiter.Close();
            x.closeConnection();
        }

        private void falscheBeladungEintragenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beladung_eintragen x = new beladung_eintragen();
            x.Show();
        }

        private void strafkatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strafkatalog f = new strafkatalog();
            f.Show();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (fenster == 1)
            {
                if (e.ColumnIndex == 1)
                {
                    //  MessageBox.Show(e.RowIndex.ToString());
                    if (e.RowIndex == -1)
                        return;
                    string name = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                    User_Manage x = new User_Manage();
                    User_Manage.name = name;
                    User_Manage.id = int.Parse(id);
                    x.ShowDialog();

                    if (x.DialogResult == DialogResult.OK)
                    {
                        verwaltung();
                    }
                }
            }
            if (fenster == 2)
            {
                if (e.ColumnIndex == 0)
                {
                    //  MessageBox.Show(e.RowIndex.ToString());
                    if (e.RowIndex == -1)
                        return;
                    string name = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    Termine_manage x = new Termine_manage();
                    Termine_manage.name = name;
                    //Termine_manage.id = int.Parse(id);
                    x.ShowDialog();

                    if (x.DialogResult == DialogResult.OK)
                    {
                        Termine();
                    }
                }
            }
            if (fenster == 3)
            {
                if (e.ColumnIndex == 1)
                {
                    //  MessageBox.Show(e.RowIndex.ToString());
                    if (e.RowIndex == -1)
                        return;
                    string id = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                    string aktiv = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (aktiv == "Nein")
                    {
                        DialogResult x = MessageBox.Show("Wurde die Sanktion Bezahlt?", "", MessageBoxButtons.YesNo);

                        if (x == DialogResult.Yes)
                        {
                            dbConnection con = new dbConnection();
                            con.openConnection();
                            //MessageBox.Show(id);
                            con.ExecuteSQL("UPDATE Sanktionen SET aktiv='0' WHERE id='" + id + "'");
                            con.closeConnection();
                            sanktionenload();
                        }
                    }
                    else
                    {
                        DialogResult x = MessageBox.Show("Willst du die Sanktion ins Archiv verschieben?", "", MessageBoxButtons.YesNo);

                        if (x == DialogResult.Yes)
                        {
                            dbConnection con = new dbConnection();
                            con.openConnection();
                            //MessageBox.Show(id);
                            con.ExecuteSQL("UPDATE Sanktionen SET aktiv='3' WHERE id='" + id + "'");
                            con.closeConnection();
                            sanktionenload();
                        }
                    }

                }
            }
        }

        private void urlaubslisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fenster = 6;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Name";


            dataGridView1.Columns[1].Name = "Abwesend ab";
            dataGridView1.Columns[2].Name = "Abwesend bis";
            dataGridView1.Columns[3].Name = "Begründung";


            dbConnection x = new dbConnection();

            x.openConnection();
            
            var reader = x.readerSQL("SELECT * FROM Urlaub");
            while (reader.Read())
            {
                   dataGridView1.Rows.Add(reader.GetString("name"), reader.GetString("von"), reader.GetString("bis"), reader.GetString("begründung"));

            }
            reader.Close();
            x.closeConnection();
        }
    }
}
