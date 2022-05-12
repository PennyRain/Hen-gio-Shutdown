using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace HenGioShutdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int soGiayTatMay;

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text.Trim(), out soGiayTatMay))
            {
                button1.Enabled = false;
                timer1.Interval = 1000;
                timer1.Enabled = true;
                soGiayTatMay = Math.Abs(soGiayTatMay) * 60;
            }
            else
            {
                MessageBox.Show("Hãy nhập vào số phút cần hẹn.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (soGiayTatMay > 0)
            {
                label1.Text = "Sẽ tắt máy sau " + soGiayTatMay + " giây.";
                soGiayTatMay = soGiayTatMay - 1;
            }
            else
            {
                System.Diagnostics.Process.Start("shutdown", "/s /f /t 0");
                Application.Exit();
            }
        }
    }
}

