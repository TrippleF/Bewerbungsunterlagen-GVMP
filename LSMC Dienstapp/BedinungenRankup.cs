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
    public partial class BedinungenRankup : Form
    {
        public BedinungenRankup()
        {
            InitializeComponent();
        }
        private List<List<string>> bedinungen = new List<List<string>>();

        private void BedinungenRankup_Load(object sender, EventArgs e)
        {

            dbConnection x = new dbConnection();
            x.openConnection();
            var reader = x.readerSQL("SELECT * FROM Pruefungsliste");
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader.GetString("name"));
                adjustListSize(checkedListBox1);

            }

            reader.Close();
            reader = x.readerSQL("SELECT * FROM Schulungsliste");
            while (reader.Read())
            {
                checkedListBox2.Items.Add(reader.GetString("name"));
                adjustListSize(checkedListBox2);
            }
            reader.Close();

            reader = x.readerSQL("SELECT * FROM rankupBedinungen");
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.Add(reader.GetString("rang"));
                tmp.Add(reader.GetString("prüfungen"));
                tmp.Add(reader.GetString("schulungen"));
                tmp.Add(reader.GetString("wochen"));
                bedinungen.Add(tmp);
            }
            reader.Close();


            update();
            x.closeConnection();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            update();

        }
        private void update()
        {
            string[] prüfungen = bedinungen[int.Parse(numericUpDown1.Value.ToString()) - 1][1].ToString().Split(';');
            string[] schulungen = bedinungen[int.Parse(numericUpDown1.Value.ToString()) - 1][2].ToString().Split(';');
            string wochen = bedinungen[int.Parse(numericUpDown1.Value.ToString()) - 1][3].ToString();
            //MessageBox.Show(prüfungen + "\n" + schulungen + "\n" + wochen);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
                for (int y = 0; y < prüfungen.Length; y++)
                {
                    
                    if ((string)checkedListBox1.Items[i] == prüfungen[y].ToString())
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }

                }

            }

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
                for (int y = 0; y < schulungen.Length; y++)
                {
                   
                    if ((string)checkedListBox2.Items[i] == schulungen[y].ToString())
                    {
                        checkedListBox2.SetItemChecked(i, true);
                    }

                }

            }
            numericUpDown2.Value = int.Parse(wochen);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string prüfungen = "";
            foreach (string s in checkedListBox1.CheckedItems)
                prüfungen += s + ";";
            string schulungen = "";
            foreach (string s in checkedListBox2.CheckedItems)
                schulungen += s + ";";
            string wochen = numericUpDown2.Value.ToString();
            //MessageBox.Show(prüfungen + "\n" + schulungen + "\n" + wochen + "wochen");
            dbConnection x = new dbConnection();
            x.openConnection();
            x.ExecuteSQL("UPDATE rankupBedinungen SET prüfungen ='" + prüfungen + "',schulungen='" + schulungen + "',wochen='" + wochen + "' WHERE rang=" + numericUpDown1.Value);
            x.closeConnection();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemCheckState(i,  CheckState.Unchecked);
            update();
        }
        private static void adjustListSize(ListBox lst)
        {
            int h = lst.ItemHeight * lst.Items.Count;
            lst.Height = h + lst.Height - lst.ClientSize.Height;
        }
    }
}
