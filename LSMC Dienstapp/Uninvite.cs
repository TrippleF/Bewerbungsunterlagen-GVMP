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
    public partial class Uninvite : Form
    {
        public Uninvite()
        {
            InitializeComponent();
        }

        private void BtnQuest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vorschlag - Alle Mitarbeiter werden geladen, wenn Vorschlag gedrückt. Sonst sind nur Vorgeschlagene angezeigt.\r\n" +
                "Entlassen - Anzukreuzen wenn Mitarbeiter IC entlassen wurde!\r\n" +
                "Gemeldet - Wurde der Mitarbeiter bei der Fraktionsverwaltung gemeldet! - Nur sichtbar wenn er es Muss!\r\n" +
                "Ausgetragen - Wurde der Mitarbeiter aus sämtlichen Dokumenten ausgetragen - Dienstapp passiert Automatisch");
        }

        private void CBVorschlag_CheckedChanged(object sender, EventArgs e)
        {
            if (CBVorschlag.Checked)
            {
                CBuninvite.Enabled = false;
                CBMeldung.Enabled = false;
                CBDocuments.Enabled = false;
            } else
            {
                CBuninvite.Enabled = true;
                CBMeldung.Enabled = true;
                CBDocuments.Enabled = true;

                CBMitarbeiter.Items.Add("Mik_Mathews");
            }
        }

        private void LadeMitarbeiterliste()
        {
            CBMitarbeiter.Items.Clear();
        }
    }
}
