using Microsoft.Win32;
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
    public partial class aktivieren : Form
    {
        public aktivieren()
        {
            InitializeComponent();
        }

        private void aktivieren_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains('_'))
            {
                MessageBox.Show("Gib deinen Namen mit Unterstrich ein!");
                return;

            }
            if(textBox2.Text == "")
            {
                MessageBox.Show("Gib deinen API-Key ein");
                return;
            }
            string name = textBox1.Text;
            string key = textBox2.Text;
            string hwid = GetMachineGuid();

            dbConnection con = new dbConnection();
            con.openConnection();
            string api="";
            string id = "";
            var reader = con.readerSQL("SELECT apikey,id FROM User WHERE username='" + name + "'");
            while (reader.Read())
            {
                if(reader[0] != null)
                    api = reader[0].ToString();
                id = reader[1].ToString();
                
            }
            reader.Close();
            if(api == "" || api != key)
            {
                MessageBox.Show("API-Key falsch!");
                return;
            }

            con.ExecuteSQL("UPDATE User SET hwid='"+GetMachineGuid()+"' WHERE id='"+id+"'");
            con.closeConnection();

            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LSMC-DienstApp");
            reg.SetValue("Name", name);
            reg.SetValue("ID", id);
            reg.SetValue("API", key);
            reg.Close();

            MessageBox.Show("Erfolgreich eingetragen! \n Bitte starte das Programm neu!");
            Application.Exit();

        }
        private string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }
    }
}
