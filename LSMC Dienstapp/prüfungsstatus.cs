using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSMC_Dienstapp
{
    public partial class prüfungsstatus : Form
    {
        public prüfungsstatus()
        {
            InitializeComponent();
        }

        private void prüfungsstatus_Load(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {

                if (e.RowIndex == -1)
                    return;
                string name = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string termin = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if(status == "Termin erhalten")
                {
                    DialogResult diag = MessageBox.Show("Ist dieser Termin möglich?", "", MessageBoxButtons.YesNoCancel);
                    if(diag == DialogResult.Yes)
                    {
                        dbConnection x = new dbConnection();
                        x.openConnection();
                        x.ExecuteSQL("UPDATE AusbildungsTermine SET status='2' WHERE id='"+id+"'");
                        x.closeConnection();
                        update();
                    }
                    if (diag == DialogResult.No)
                    {
                        dbConnection x = new dbConnection();
                        x.openConnection();
                        x.ExecuteSQL("UPDATE AusbildungsTermine SET status='3' WHERE id='" + id + "'");
                        x.closeConnection();
                        update();
                    }
                }
                if (status == "Termin bestätigt")
                {
                    string tmp = termin.Replace("-", "");
                    string dateString = tmp;
                    DateTime now = DateTime.Now;
                    DateTime myDate = DateTime.Parse(dateString);
                    TimeSpan test = myDate - now;
                    if(test.TotalHours < 1) {
                        MessageBox.Show("Du kannst deine Prüfung nur bis zu 1 Stunde vorher absagen! \n bitte kontaktiere zur Not deinen Prüfer über das Forum!");
                    }
                    else
                    {
                        DialogResult diag = MessageBox.Show("Sicher,dass du den Termin absagen willst?", "", MessageBoxButtons.YesNo);
                        if (diag == DialogResult.Yes)
                        {
                            dbConnection x = new dbConnection();
                            x.openConnection();
                            x.ExecuteSQL("UPDATE AusbildungsTermine SET status='4' WHERE id='" + id + "'");
                            x.closeConnection();
                            update();
                        }
                    }
                    
                    
                }

            }
        }
        private void update()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnCount = 4;


            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.HeaderText = "Prüfung";
            dgvButton.FlatStyle = FlatStyle.Flat;


            dataGridView1.Columns.Insert(1, dgvButton);
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[2].Name = "Termin";
            dataGridView1.Columns[3].Name = "Prüfer";
            dataGridView1.Columns[4].Name = "Status";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * from AusbildungsTermine WHERE prüfling='" + Form1.username + "'");
            while (reader.Read())
            {
                string status = reader.GetString("status");
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
                
                

                    string termin = reader.GetString("termin");
               int id = int.Parse(reader.GetString("id"));
                if (termin == "")
                {
                    termin = " - ";
                }
                if (reader.GetString("status") != "5") {
                    dataGridView1.Rows.Add(id, reader.GetString("prüfung"), termin, reader.GetString("prüfer"), status);
                }
             
            }
            reader.Close();
        }
    }
}

