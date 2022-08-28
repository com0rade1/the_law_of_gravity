using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Закон_всемирного_тяготения
{
    public partial class Form1 : Form
    {
        double x0, y0, x1, y1, h, M, vx0, vy0, k,tempx,tempy;

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textBoxTimer.Text);
            timer1.Start();
            timer1.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBoxVY0.Text = Convert.ToString(Math.Sqrt(2)*Math.Sqrt(k * M / Convert.ToDouble(textBoxX0.Text)));
            textBoxVX0.Text = "0";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBoxVX0.Text = "0";
            textBoxVY0.Text = Convert.ToString(Math.Sqrt(k * M / Convert.ToDouble(textBoxX0.Text)));
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            tempx = x1 * (((-k * M) / Math.Pow((Math.Sqrt(x1 * x1 + y1 * y1)), 3)) * h * h + 2) - x0;
            tempy = y1 * (((-k * M) / Math.Pow((Math.Sqrt(x1 * x1 + y1 * y1)), 3)) * h * h + 2) - y0;
            g.DrawLine(new Pen(Color.Black), pictureBox1.Width / 2 + (float)x1, pictureBox1.Height / 2 + (float)y1, pictureBox1.Width / 2 + (float)tempx, pictureBox1.Height / 2 + (float)tempy);
            x0 = x1;
            y0 = y1;
            x1 = tempx;
            y1 = tempy;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            x0 = Convert.ToDouble(textBoxX0.Text);
            y0 = 0;
            h = Convert.ToDouble(textBoxStep.Text);
            vx0 = Convert.ToDouble(textBoxVX0.Text);
            vy0 = Convert.ToDouble(textBoxVY0.Text);
            M = Convert.ToDouble(textBoxM.Text);
            k = Convert.ToDouble(textBoxG.Text);
            x1 = x0 + h * vx0;
            y1 = y0 + h * vy0;
            g.DrawEllipse(new Pen(Color.Black, 2), pictureBox1.Width / 2 - 20, pictureBox1.Height / 2 - 20, 40,40);
            g.DrawLine(new Pen(Color.Black), pictureBox1.Width / 2 + (float)x0, pictureBox1.Height / 2 + (float)y0, pictureBox1.Width / 2 + (float)x1, pictureBox1.Height / 2 + (float)y1);

        }
    }
}
