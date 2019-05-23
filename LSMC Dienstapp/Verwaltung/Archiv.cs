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

namespace LSMC_Dienstapp
{
    public partial class Archiv : Form
    {
        private Verwaltung_Manage x;

        public Archiv()
        {
            InitializeComponent();
            Header();
            Uebersicht();
        }

        public void Header()
        {
            dG.ColumnCount = 7;
            dG.Columns[0].Name = "K-ID";
            dG.Columns[1].Name = "ID";
            dG.Columns[2].Name = "Rang";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;
            dG.Columns.Insert(3, dgvButton);
            dG.Columns[4].Name = "Beitritt";
            dG.Columns[5].Name = "Austritt";
            DataGridViewButtonColumn dgvButton2 = new DataGridViewButtonColumn();
            dgvButton2.HeaderText = "Entlassen";
            dgvButton2.FlatStyle = FlatStyle.Flat;
            dG.Columns.Insert(6, dgvButton2);
            DataGridViewButtonColumn dgvButton3 = new DataGridViewButtonColumn();
            dgvButton3.HeaderText = "Gemeldet";
            dgvButton3.FlatStyle = FlatStyle.Flat;
            dG.Columns.Insert(7, dgvButton3);
            DataGridViewButtonColumn dgvButton4 = new DataGridViewButtonColumn();
            dgvButton4.HeaderText = "Dokumente";
            dgvButton4.FlatStyle = FlatStyle.Flat;
            dG.Columns.Insert(8, dgvButton4);
            dG.Columns[9].Name = "Wiedereingestellt";
            DataGridViewButtonColumn dgvButton5 = new DataGridViewButtonColumn();
            dgvButton5.HeaderText = "Blacklist";
            dgvButton5.FlatStyle = FlatStyle.Flat;
            dG.Columns.Insert(10, dgvButton5);
            dG.Columns[11].Name = "Bemerkung";
        }

        public void Uebersicht()
        {
            dG.Rows.Clear();
            dbConnection Auslesen = new dbConnection();
            Auslesen.openConnection();
            var A = Auslesen.readerSQL("SELECT id, userid, rang, beitritt, austritt, entlassen, gemeldet, dokumente, wiedereingestellt, blacklist, bemerkung FROM Archiv");
            var zaehler = 0;
            while (A.Read())
            {
                dG.Rows.Add();
                dG.Rows[zaehler].Cells[0].Value = A[0];
                dG.Rows[zaehler].Cells[1].Value = A[1];
                dG.Rows[zaehler].Cells[2].Value = A[2];
                dbConnection Auslesenname = new dbConnection();
                Auslesenname.openConnection();
                var N = Auslesenname.readerSQL("SELECT username FROM User WHERE id = '" + A[1] + "'");
                while (N.Read())
                {
                    dG.Rows[zaehler].Cells[3].Value = N[0];
                }
                dG.Rows[zaehler].Cells[4].Value = A[3];
                dG.Rows[zaehler].Cells[5].Value = A[4];
                dG.Rows[zaehler].Cells[6].Value = Ausgabejanein(Convert.ToInt32(A[5]));
                //Gemeldet 
                DateTime B = Convert.ToDateTime(A[3]);
                DateTime Au = Convert.ToDateTime(A[4]);
                TimeSpan sp = Au - B;
                if (Convert.ToInt32(A[6]) == 0)
                {
                    if (Convert.ToInt32(A[2]) == 0 && Convert.ToInt32(sp.Days) >= 15 && Convert.ToInt32(sp.Days) <= 30)
                    {
                        dG.Rows[zaehler].Cells[7].Style.BackColor = Color.Red;
                        dG.Rows[zaehler].Cells[7].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToInt32(A[2]) != 0 && Convert.ToInt32(sp.Days) <= 30)
                    {
                        dG.Rows[zaehler].Cells[7].Style.BackColor = Color.Red;
                        dG.Rows[zaehler].Cells[7].Style.ForeColor = Color.White;
                    }
                }
                    dG.Rows[zaehler].Cells[7].Value = Ausgabejanein(Convert.ToInt32(A[6]));


                dG.Rows[zaehler].Cells[8].Value = Ausgabejanein(Convert.ToInt32(A[7]));
                dG.Rows[zaehler].Cells[9].Value = Ausgabejanein(Convert.ToInt32(A[8]));
                dG.Rows[zaehler].Cells[10].Value = Ausgabejanein(Convert.ToInt32(A[9]));
                dG.Rows[zaehler].Cells[11].Value = A[10];

                Auslesenname.closeConnection();
                zaehler++;
            }
            Auslesen.closeConnection();
        }

        public string Ausgabejanein(int z)
        {
            if(z == 0)
            {
                return "Nein";
            } else
            {
                return "Ja";
            }
        }

        private void dG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                switch (e.ColumnIndex.ToString())
                {
                    case "3":
                        x = new Verwaltung_Manage();
                        x.Formular = "Archiv";
                        x.Archivierung = this;
                        x.Id = Convert.ToInt32(dG.Rows[e.RowIndex].Cells[1].Value);
                        x.DBId = Convert.ToInt32(dG.Rows[e.RowIndex].Cells[0].Value);
                        x.PruefeUser();
                        x.ShowDialog();
                        break;
                    case "6":
                        if (dG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Nein")
                        {
                            var abfrage = MessageBox.Show("Wurde " + dG.Rows[e.RowIndex].Cells[3].Value + " entlassen?", "Entlassen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (abfrage == DialogResult.Yes)
                            {
                                MessageBox.Show("Wurde umgetragen!");
                                dbConnection Update = new dbConnection();
                                Update.openConnection();
                                Update.ExecuteSQL("UPDATE Archiv SET entlassen = '1' WHERE id = '" + dG.Rows[e.RowIndex].Cells[0].Value + "'");
                                Update.closeConnection();

                                Uebersicht();
                            }
                            else if (abfrage == DialogResult.No)
                            {
                                MessageBox.Show("Dann leite das in die Wege!");
                            }
                        }
                        break;

                    case "7":
                        if (dG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Nein")
                        {
                            var abfrage = MessageBox.Show("Wurde " + dG.Rows[e.RowIndex].Cells[3].Value + " an die Fraktiosverwaltung gemeldet?", "Gemeldet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (abfrage == DialogResult.Yes)
                            {
                                MessageBox.Show("Wurde umgetragen!");
                                dbConnection Update = new dbConnection();
                                Update.openConnection();
                                Update.ExecuteSQL("UPDATE Archiv SET gemeldet = '1' WHERE id = '" + dG.Rows[e.RowIndex].Cells[0].Value + "'");
                                Update.closeConnection();

                                Uebersicht();
                            }
                            else if (abfrage == DialogResult.No)
                            {
                                MessageBox.Show("Dann leite das in die Wege!");
                            }
                        }
                        break;

                    case "8":
                        if (dG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Nein")
                        {
                            var abfrage = MessageBox.Show("Wurde " + dG.Rows[e.RowIndex].Cells[3].Value + " aus den Dokumenten ausgetragen?", "Dokumente?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (abfrage == DialogResult.Yes)
                            {
                                MessageBox.Show("Wurde umgetragen!");
                                dbConnection Update = new dbConnection();
                                Update.openConnection();
                                Update.ExecuteSQL("UPDATE Archiv SET dokumente = '1' WHERE id = '" + dG.Rows[e.RowIndex].Cells[0].Value + "'");
                                Update.closeConnection();

                                Uebersicht();
                            }
                            else if (abfrage == DialogResult.No)
                            {
                                MessageBox.Show("Dann leite das in die Wege!");
                            }
                        }
                        break;
                    case "10":
                        if(dG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Nein")
                        {
                            var abfrage = MessageBox.Show("Willst du " + dG.Rows[e.RowIndex].Cells[3].Value + " blacklisten?", "Blacklist?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (abfrage == DialogResult.OK)
                            {
                                MessageBox.Show(dG.Rows[e.RowIndex].Cells[3].Value + " ist nun in der Blacklist!");
                                dbConnection Update = new dbConnection();
                                Update.openConnection();
                                Update.ExecuteSQL("UPDATE Archiv SET blacklist = '1' WHERE id = '" + dG.Rows[e.RowIndex].Cells[0].Value + "'");
                                Update.closeConnection();
                                Update = null;

                                Uebersicht();
                            } else if(abfrage == DialogResult.Cancel)
                            {
                                MessageBox.Show("Antrag zurückgezogen");
                            }
                        }
                        else
                        {
                            var abfrage = MessageBox.Show("Willst du " + dG.Rows[e.RowIndex].Cells[3].Value + " von der Blacklist entfernen?", "Blacklist?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (abfrage == DialogResult.OK)
                            {
                                MessageBox.Show(dG.Rows[e.RowIndex].Cells[3].Value + " ist nun entfernt aus der Blacklist!");
                                dbConnection Update = new dbConnection();
                                Update.openConnection();
                                Update.ExecuteSQL("UPDATE Archiv SET blacklist = '0' WHERE id = '" + dG.Rows[e.RowIndex].Cells[0].Value + "'");
                                Update.closeConnection();

                                Uebersicht();
                            }
                            else if (abfrage == DialogResult.Cancel)
                            {
                                MessageBox.Show("Antrag zurückgezogen");
                            }
                        }
                        break;
                }
            }
        }
    }
}
