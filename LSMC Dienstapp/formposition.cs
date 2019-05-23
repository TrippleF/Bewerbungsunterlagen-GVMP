using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace LSMC_Dienstapp
{
    class formposition
    {
        private static string credPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal) + "/LSMC Dienstapp/formposition/";

        public static void RestoreWindowPosition(Form formular)
        {
            if (Properties.Settings.Default.HasSetDefaults)
            {
                formular.Location = Properties.Settings.Default.Location;
                formular.WindowState = Properties.Settings.Default.WindowState;
                formular.Size = Properties.Settings.Default.Size;
            }
        }

        public static void SaveWindowPosition(Form formular)
        {
            Properties.Settings.Default.WindowState = formular.WindowState;

            if (formular.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Location = formular.Location;
                Properties.Settings.Default.Size = formular.Size;
            }
            else
            {
                Properties.Settings.Default.Location = formular.RestoreBounds.Location;
                Properties.Settings.Default.Size = formular.RestoreBounds.Size;
            }

            Properties.Settings.Default.HasSetDefaults = true;

            Properties.Settings.Default.Save();
        }

        public static void WritePosition(Form formular, string xmldatei)
        {
            if (!Directory.Exists(credPath))
            {
                Directory.CreateDirectory(credPath);
            }
                XmlWriter xmlWriter = XmlWriter.Create(credPath + "/" + xmldatei + ".xml");
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(xmldatei);

                if (formular.WindowState == FormWindowState.Normal)
                {

                    xmlWriter.WriteStartElement("Location");
                    xmlWriter.WriteString(formular.Location.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("Size");
                    xmlWriter.WriteString(formular.Size.ToString());
                    xmlWriter.WriteEndElement();

                }
                else
                {

                    xmlWriter.WriteStartElement("Location");
                    xmlWriter.WriteString(formular.RestoreBounds.Location.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("Size");
                    xmlWriter.WriteString(formular.RestoreBounds.Size.ToString());
                    xmlWriter.WriteEndElement();

                }

                xmlWriter.WriteStartElement("WindowState");
                xmlWriter.WriteString(formular.WindowState.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
        }

        public static void ReadPosition(Form formular, string xmldatei)
        {
            if(!File.Exists(credPath + "/" + xmldatei + ".xml")) { WritePosition(formular, xmldatei); }
            XmlTextReader reader = new XmlTextReader(credPath + "/" +  xmldatei + ".xml");
            var count = 0;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        switch (count) {
                            case 3:
                                string LocremoveParts = reader.Value.Replace("}", "");
                                LocremoveParts = LocremoveParts.Replace("{X=", "");
                                LocremoveParts = LocremoveParts.Replace("Y=", "");
                                string[] LocationParts = LocremoveParts.Split(',');
                                int left = int.Parse(LocationParts[0]);
                                int top = int.Parse(LocationParts[1]);
                                Point point = new Point(left, top);
                                formular.Location = point;
                                break;
                            case 6:
                                string removeParts = reader.Value.Replace("}", "");
                                removeParts = removeParts.Replace("{Width=", "");
                                removeParts = removeParts.Replace("Height=", "");
                                string[] sizeParts = removeParts.Split(',');
                                int height = int.Parse(sizeParts[0]);
                                int width = int.Parse(sizeParts[1]);
                                Size mySize = new Size(height, width);
                                formular.Size = mySize;
                                break;
                            case 9:
                                formular.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), reader.Value);
                                break;
                }
                        break;
                }
                count++;
            }
            reader.Close();
        }
    }
}
