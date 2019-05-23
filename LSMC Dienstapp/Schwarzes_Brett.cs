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
    public partial class Schwarzes_Brett : Form
    {
        private MysqlClass db;
        public Schwarzes_Brett()
        {
            InitializeComponent();

            db = new MysqlClass();

            Rechte_Check();
            Header();
            Content();
            timer1.Interval = 60000;
            timer1.Start();
        }

        private void Header()
        {
            
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Autor";
            //dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Name = "Type";
            //dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Name = "Eintrag";
            dataGridView1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[4].Name = "Datum";
            if (Form1.rang > 9)
            {
                DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
                dgvButton.HeaderText = "Status";
                dgvButton.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Insert(5, dgvButton);
            }
            dataGridView1.Columns[0].Visible = false;
            
        }

        private void Content()
        {
            var where_clause = "";
            if (Form1.rang < 10) where_clause = " WHERE aktiv = '1'";
            try
            {
                var count = db.Count("SELECT COUNT(*) FROM Schwarzes_Brett" + where_clause);
                dataGridView1.Rows.Clear();
                try
                {
                    var auslesen = db.Select("SELECT * FROM Schwarzes_Brett" + where_clause, "Schwarzes_Brett");
                    for (int i = 0; i < count; i++)
                    {
                        try
                        {
                            var username = db.Select("SELECT * FROM User WHERE id = '" + auslesen[4][i] + "'", "User");
                            var type = "Info";
                            if (int.Parse(auslesen[1][i]) == 1) type = "Anweisung";
                            if (Form1.rang > 9)
                            {
                                var status = "Aktiv";
                                if (int.Parse(auslesen[5][i]) == 0) status = "Inaktiv";
                                dataGridView1.Rows.Add(auslesen[0][i], username[2][0], type, auslesen[2][i], auslesen[3][i], status);
                            }
                            else
                            {
                                dataGridView1.Rows.Add(auslesen[0][i], username[2][0], type, auslesen[2][i], auslesen[3][i]);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Abfragefehler: #0003 - Schwarzes Brett \r Bitte wenden Sie sich an einen Administrator!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Abfragefehler: #0002 - Schwarzes Brett \r Bitte wenden Sie sich an einen Administrator!");
                }
            }
            catch
            {
                MessageBox.Show("Abfragefehler: #0001 - Schwarzes Brett \r Bitte wenden Sie sich an einen Administrator!");
            }
        }

        private void Rechte_Check()
        {
            if(Form1.rang < 10)
            {
                radioButton2.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                var type = 0;
                if (radioButton2.Checked) type = 1;
                db.Insert("INSERT INTO Schwarzes_Brett (type, eintrag, eingetragen, autor, aktiv) VALUES ('" + type + "', '" + richTextBox1.Text + "', NOW(), '" + Form1.userid + "', '1')");
                notification.Show("Eintrag erfolgreich!", AlertType.success);
                Content();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Content();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                if(e.ColumnIndex == 5)
                {
                    var status = 0;
                    if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "Inaktiv") status = 1;
                    var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    db.Update("UPDATE Schwarzes_Brett SET aktiv = '" + status + "' WHERE id = '" + id + "'");
                    Content();
                    notification.Show("Erfolgreich aktualisiert!", AlertType.success);
                }
            }
        }

        private void Schwarzes_Brett_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
