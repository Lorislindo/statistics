using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Random r = new Random();
        double sum = 0;
        int total = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 50;
            this.timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double c = r.NextDouble();
            this.sum += c;
            this.total += 1;
            this.richTextBox1.AppendText(Environment.NewLine + c);
            this.richTextBox2.Text = "AVG: " + sum / total + 
                Environment.NewLine + "Lanci: "+ total;
            this.richTextBox1.ScrollToCaret();
        }
    }
}