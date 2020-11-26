using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClicker
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public Form1()
        {
            InitializeComponent();
        }

        int clickingInterval;

        public void StartIntervalClicking()
        {
            clickingInterval = Convert.ToInt32(numericUpDown1.Value);
            timer1.Start();
        }

        public void StartClickingAtSpecificTime()
        {
            timer2.Start();
        }
        public void StartIntervalDoubleClicking()
        {
            clickingInterval = Convert.ToInt32(numericUpDown1.Value);
            timer3.Start();
        }

        public void StartDoubleClickingAtSpecificTime()
        {
            timer4.Start();
        }

        //Start Button
        private void button1_Click(object sender, EventArgs e)
        {
            if ( (button1.Text == "Start") 
                && (checkBox1.Checked == false))
            {
                if (comboBox1.Text == "Clicking Interval")
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    StartIntervalClicking();
                }
                else if (comboBox1.Text == "Clicking at a specific time")
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    StartClickingAtSpecificTime();
                }
            }
            else if ((button1.Text == "Start")
                && (checkBox1.Checked == true))
            {
                if (comboBox1.Text == "Clicking Interval")
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    StartIntervalDoubleClicking();
                }
                else if (comboBox1.Text == "Clicking at a specific time")
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    StartDoubleClickingAtSpecificTime();
                }
            }
        }


        //Timer for interval clicking
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Milliseconds")
            {
                timer1.Interval = clickingInterval;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
            else if (comboBox2.Text == "Seconds")
            {
                timer1.Interval = clickingInterval * 1000;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
            else if (comboBox2.Text == "Minutes")
            {
                timer1.Interval = clickingInterval * 60000;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
            else if (comboBox2.Text == "Hours")
            {
                timer1.Interval = clickingInterval * 3600000;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CheckTime())
            {
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
        }

        public bool CheckTime()
        {
            if ((int)DateTime.Now.TimeOfDay.TotalSeconds == (int)dateTimePicker1.Value.TimeOfDay.TotalSeconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Milliseconds")
            {
                timer3.Interval = clickingInterval;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
            else if (comboBox2.Text == "Seconds")
            {
                timer3.Interval = clickingInterval * 1000;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
            else if (comboBox2.Text == "Minutes")
            {
                timer3.Interval = clickingInterval * 60000;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
            else if (comboBox2.Text == "Hours")
            {
                timer3.Interval = clickingInterval * 3600000;
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (CheckTime())
            {
                int X = Convert.ToInt32(Cursor.Position.X);
                int Y = Convert.ToInt32(Cursor.Position.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Clicking Interval")
            {
                dateTimePicker1.Enabled = false;
                numericUpDown1.Enabled = true;
                comboBox2.Enabled = true;
            }
            else if (comboBox1.Text == "Clicking at a specific time")
            {
                dateTimePicker1.Enabled = true;
                numericUpDown1.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            button2.Enabled = false;
            button1.Enabled = true;
        }
    }
}
