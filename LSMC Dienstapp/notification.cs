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
    public partial class notification : Form
    {
        public notification(string msg,AlertType type)
        {
            InitializeComponent();
            label1.Text = msg;
            switch (type){
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    pictureBox1.Image = imageList1.Images[1];
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    pictureBox1.Image = imageList1.Images[2];
                    break;
                case AlertType.warning:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    pictureBox1.Image = imageList1.Images[0];
                    break;
                case AlertType.error:
                    this.BackColor = Color.Crimson;
                    pictureBox1.Image = imageList1.Images[0];
                    break;
            }
        }

        private void notification_Load(object sender, EventArgs e)
        {
            //this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 20;
            this.Top = -1 * (this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 20;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            close.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            close.Start();
        }
        int intervall = 0;
        private void show_Tick(object sender, EventArgs e)
        {
            if(this.Top< 20)
            {
                this.Top += intervall;
                intervall += 2;
            }
            else
            {
                show.Stop();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity-=0.1;
            }
            else
            {
                this.Close();
            }
        }

        public static void Show(string msg, AlertType type)
        {
            new notification(msg, type).Show();
        }
    }

    public enum AlertType
    {
        success,info,warning,error
    }
}
