using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wwl;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Timers;
namespace wallpuper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Asterisk;
            this.ShowInTaskbar = false;
            notifyIcon1.Click += notifyIcon1_Click;
        }
        int i = 0;
        string returnwal = wwl.Wallpaper.GetBackgroud();
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = (1000*int.Parse(textBox1.Text));
            timer1.Enabled = true;
            timer2.Interval = (1000*int.Parse(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 1;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string setwal = (Directory.GetCurrentDirectory() + "/schwarzenegger.jpg");
            wwl.Wallpaper.Set(setwal);
            timer2.Enabled = true;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            wwl.Wallpaper.Set(returnwal);
            timer1.Enabled=true;
            timer2.Enabled = false;
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (i != 1)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
