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
    public partial class strafkatalog : Form
    {
        public strafkatalog()
        {
            InitializeComponent();
        }

        private void strafkatalog_Load(object sender, EventArgs e)
        {
            leicht();
            if(Form1.rang < 9)
            {
                this.dataGridView1.ReadOnly = false;
                hinzufügenToolStripMenuItem.Enabled = false;
                entfernenToolStripMenuItem.Enabled = false;
            }


        }
        private void leicht()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Vergehen";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Vergehen";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Punkte";
            dataGridView1.Columns[3].Name = "";
            dataGridView1.Columns[4].Name = "0-2";
            dataGridView1.Columns[5].Name = "3-5";
            dataGridView1.Columns[6].Name = "6-9";
            dataGridView1.Columns[7].Name = "10-12";

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=1");
            while (reader.Read())
            {
                string id = reader.GetString("id");
                string Vergehen = reader.GetString("Vergehen");
                string Punkte = reader.GetString("Punkte");
                string[] geld = reader.GetString("Geld").Split(';');
                dataGridView1.Rows.Add(id, Vergehen, Punkte, "", geld[0]+"$", geld[1] + "$", geld[2] + "$", geld[3] + "$");
            }
            reader.Close();
            x.closeConnection();
        }
        private void minimalschwer()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Vergehen";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Vergehen";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Punkte";
            dataGridView1.Columns[3].Name = "";
            dataGridView1.Columns[4].Name = "0-2";
            dataGridView1.Columns[5].Name = "3-5";
            dataGridView1.Columns[6].Name = "6-9";
            dataGridView1.Columns[7].Name = "10-12";

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=2");
            while (reader.Read())
            {
                string id = reader.GetString("id");
                string Vergehen = reader.GetString("Vergehen");
                string Punkte = reader.GetString("Punkte");
                string[] geld = reader.GetString("Geld").Split(';');
                dataGridView1.Rows.Add(id, Vergehen, Punkte, "", geld[0] + "$", geld[1] + "$", geld[2] + "$", geld[3] + "$");
            }
            reader.Close();
            x.closeConnection();
        }
        private void mittelschwer()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Vergehen";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Vergehen";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Punkte";
            dataGridView1.Columns[3].Name = "";
            dataGridView1.Columns[4].Name = "0-2";
            dataGridView1.Columns[5].Name = "3-5";
            dataGridView1.Columns[6].Name = "6-9";
            dataGridView1.Columns[7].Name = "10-12";

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=3");
            while (reader.Read())
            {
                string id = reader.GetString("id");
                string Vergehen = reader.GetString("Vergehen");
                string Punkte = reader.GetString("Punkte");
                string[] geld = reader.GetString("Geld").Split(';');
                dataGridView1.Rows.Add(id, Vergehen, Punkte, "", geld[0] + "$", geld[1] + "$", geld[2] + "$", geld[3] + "$");
            }
            reader.Close();
            x.closeConnection();
        }
        private void schwer()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Vergehen";
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Vergehen";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[2].Name = "Punkte";
            dataGridView1.Columns[3].Name = "";
            dataGridView1.Columns[4].Name = "0-2";
            dataGridView1.Columns[5].Name = "3-5";
            dataGridView1.Columns[6].Name = "6-9";
            dataGridView1.Columns[7].Name = "10-12";

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Strafkatalog WHERE Typ=4");
            while (reader.Read())
            {
                string id = reader.GetString("id");
                string Vergehen = reader.GetString("Vergehen");
                string Punkte = reader.GetString("Punkte");
                string[] geld = reader.GetString("Geld").Split(';');
                dataGridView1.Rows.Add(id, Vergehen, Punkte, "", geld[0] + "$", geld[1] + "$", geld[2] + "$", geld[3] + "$");
            }
            reader.Close();
            x.closeConnection();
        }

        private void leichteVergehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leicht();
        }

        private void minimalschwereVergehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimalschwer();
        }

        private void mittelschwereVergehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mittelschwer();
        }

        private void schwereVergehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schwer();
        }

        private void hinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strafkatalog_add f = new strafkatalog_add();
            strafkatalog_add.add = true;
            f.Show();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {

                if (e.RowIndex == -1)
                    return;
               
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                strafkatalog_bearbeiten_loeschen.id = int.Parse(id);
                strafkatalog_bearbeiten_loeschen f = new strafkatalog_bearbeiten_loeschen();
                f.ShowDialog();
                if(f.DialogResult == DialogResult.OK)
                {
                    leicht();
                }


            }
        }
    }
    
}
