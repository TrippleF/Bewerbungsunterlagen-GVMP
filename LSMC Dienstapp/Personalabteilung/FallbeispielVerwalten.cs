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
    public partial class FallbeispielVerwalten : Form
    {
        public FallbeispielVerwalten()
        {
            InitializeComponent();
        }

        private void FallbeispielVerwalten_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            

            
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Beispiel";
            dataGridView1.Columns[2].Name = "Antwort";
            dataGridView1.Columns[3].Name = "Atkiv";

            dataGridView1.Columns[1].HeaderCell.Style.Padding = new Padding(100, 0, 50, 0);

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM BewerbungFallbeispiele");
            while (reader.Read())
            {
                string id = reader.GetString("id");
                string beispiel = reader.GetString("beispiel");
                string antwort = reader.GetString("richtig");
                string aktiv = reader.GetString("aktiv");
                dataGridView1.Rows.Add(id,beispiel,antwort,aktiv);
            }
            reader.Close();
            x.closeConnection();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbConnection x = new dbConnection();
            x.openConnection();
            var item = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (item == null)
                item = "";
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            string header = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if(header == "Beispiel")
            {
                x.ExecuteSQL("UPDATE BewerbungFallbeispiele SET beispiel='" + item.ToString() + "' WHERE id=" + id);
            }
            if (header == "Antwort")
            {
                x.ExecuteSQL("UPDATE BewerbungFallbeispiele SET richtig='" + item.ToString() + "' WHERE id=" + id);
            }
            if (header == "Atkiv")
            {
                x.ExecuteSQL("UPDATE BewerbungFallbeispiele SET aktiv='" + item.ToString() + "' WHERE id=" + id);
            }
            if (header == "ID")
                return;

            x.closeConnection();
        }
    }
}
