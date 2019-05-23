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
    public partial class Fuhrpark : Form
    {
        public Fuhrpark()
        {
            InitializeComponent();
        }

        private void Fuhrpark_Load(object sender, EventArgs e)
        {
            if (Form1.rang < 10)
            {
                menuStrip1.Enabled = false;
            }
            update();
        }
        private void update()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Nummer";
            dgvButton.FlatStyle = FlatStyle.Flat;




            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Typ";
            dataGridView1.Columns[1].Name = "Nummer";
            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Letzter Fahrer";
            dataGridView1.Columns[3].Name = "Kontroliert von";
            dataGridView1.Columns[4].Name = "Kontroliert am";
           // dataGridView1.Columns[5].Name = "Vollständig";

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Fahrzeuge");
            while (reader.Read())
            {
                string nmb = reader.GetString("nummer");
                string typ = reader.GetString("typ");
                string letzterFahrer = reader.GetString("letzterfahrer");
                
                if (reader.GetString("kontroliert").Contains(';'))
                {
                    string[] kontroliert = reader.GetString("kontroliert").Split(';');
                    dataGridView1.Rows.Add(typ, nmb, letzterFahrer, kontroliert[0], kontroliert[1]);
                }
                else
                {
                    string kontroliert = reader.GetString("kontroliert").ToString();
                    dataGridView1.Rows.Add(typ, nmb, letzterFahrer, kontroliert, "");
                }



            }
            reader.Close();
            x.closeConnection();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                fahrzeugKontrolle x = new fahrzeugKontrolle();
                fahrzeugKontrolle.nummer = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                x.ShowDialog();
                if (x.DialogResult == DialogResult.OK)
                {
                    update();
                }
            }
        }

        private void fahrzeugHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fahrzeugverwaltung x = new Fahrzeugverwaltung();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                update();
            }
        }
    }
}
