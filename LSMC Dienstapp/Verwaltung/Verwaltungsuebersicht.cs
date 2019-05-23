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
    public partial class Verwaltungsuebersicht : Form
    {
        public dbConnection dbzugriff;
        private Verwaltung_Manage x;

        public Verwaltungsuebersicht()
        {
            InitializeComponent();
            Header();
            Uebersicht();
        }

        private void Header()
        {
            dGVerwaltung.BackgroundColor = Color.FromName("Control");
            dGVerwaltung.BorderStyle = BorderStyle.None;
            dGVerwaltung.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dGVerwaltung.EnableHeadersVisualStyles = false;
            dGVerwaltung.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237);
            dGVerwaltung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dGVerwaltung.ColumnCount = 20;
            dGVerwaltung.Columns[0].Name = "ID";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Name";
            dgvButton.FlatStyle = FlatStyle.Flat;
            dGVerwaltung.Columns.Insert(1, dgvButton);
            dGVerwaltung.Columns[2].Name = "Forum Name";
            dGVerwaltung.Columns[3].Name = "Beitritt";
            dGVerwaltung.Columns[4].Name = "Telefon";
            dGVerwaltung.Columns[5].Name = "Info";
            dGVerwaltung.Columns[6].Name = "Rang";
            dGVerwaltung.Columns[7].Name = "Beförderung";
            dGVerwaltung.Columns[8].Name = "X";
            dGVerwaltung.Columns[9].Name = "Letzte Bef.";
            dGVerwaltung.Columns[10].Name = "E-Mail";
            dGVerwaltung.Columns[11].Name = "Urlaub von";
            dGVerwaltung.Columns[12].Name = "Urlaub bis";
            dGVerwaltung.Columns[13].Name = "Unentschuldigt 1x";
            dGVerwaltung.Columns[14].Name = "Unentschuldigt 2x";
            dGVerwaltung.Columns[15].Name = "Unentschuldigt 3x";
            dGVerwaltung.Columns[16].Name = "RTW Solo";
            dGVerwaltung.Columns[17].Name = "Innendienst";
            dGVerwaltung.Columns[18].Name = "Approbation Prozent";
            dGVerwaltung.Columns[19].Name = "Ausbilder Bemerkungen";
            dGVerwaltung.Columns[20].Name = "Bemerkungen";

        }

        public void Uebersicht()
        {
            // dGVerwaltung.Enabled = false;
            dGVerwaltung.Rows.Clear();
            dbConnection Auslesen = new dbConnection();
            Auslesen.openConnection();
            var A = Auslesen.readerSQL("SELECT * FROM User WHERE uninvite != '2' ORDER BY rang DESC, beitritt ASC");
            var rowcount = 0;
            while (A.Read())
            {
                this.dGVerwaltung.Rows.Add(A[1],A[2],A[3],A[4],A[5],"",A[6]);
                // Wenn eine Kündigung vorgeschlagen wurde
                if (Convert.ToInt32(A[12]) == 1)
                {
                    dGVerwaltung.Rows[rowcount].Cells[7].Value = "Uninvite";
                    dGVerwaltung.Rows[rowcount].Cells[7].Style.BackColor = Color.Red;
                    dGVerwaltung.Rows[rowcount].Cells[7].Style.ForeColor = Color.White;
                    dGVerwaltung.Rows[rowcount].Cells[8].Value = "X";
                    dGVerwaltung.Rows[rowcount].Cells[8].Style.BackColor = Color.Cyan;
                }
                rowcount++;
            }
            Auslesen.closeConnection();
        }

        private void mitarbeiterHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_add user_Add = new User_add();
            user_Add.Show();
        }

        private void mitarbeiterUpDownrankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updownrank updownrank = new Updownrank();
            updownrank.Show();
        }
        private void accountZurücksetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetAccount x = new resetAccount();
            x.Show();
        }

        private void dGVerwaltung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex != -1)
                {
                    x = new Verwaltung_Manage();
                    x.Formular = "Verwaltung";
                    x.Id = Convert.ToInt32(dGVerwaltung.Rows[e.RowIndex].Cells[0].Value);
                    x.Beitritt = Convert.ToDateTime(dGVerwaltung.Rows[e.RowIndex].Cells[3].Value);
                    x.Rang = Convert.ToInt32(dGVerwaltung.Rows[e.RowIndex].Cells[6].Value);
                    x.PruefeUser();
                    x.ShowDialog();
                }
            }
        }

        public void rankUpBedinungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BedinungenRankup x = new BedinungenRankup();
            x.Show();
        }
    }
}
