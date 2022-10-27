using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HW4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        Random random = new Random();
        public int width = 0;
        public int height = 500;
        public Bitmap b, b2 , b1 ,b3;
        public Graphics g, g2 ,g3,g4;
        Pen pen = new Pen(Color.Green);
        private Random r = new Random();
        public int[] results;

        private void button4_Click(object sender, EventArgs e)
        {
            b = new Bitmap(1000, 500);
            b2 = new Bitmap(250, 500);
            b1 = new Bitmap(1000, 500);
            b3 = new Bitmap(1000, 500);
            g = Graphics.FromImage(b);
            g2 = Graphics.FromImage(b2);
            g3 = Graphics.FromImage(b1);
            g4 = Graphics.FromImage(b3);


            pictureBox2.Image = null;
            pictureBox1.Image = null;
            pictureBox2.Update();
            pictureBox2: Refresh();
            pictureBox1.Update();
            pictureBox1.Refresh();
            
        }

        public Pen pen3;

        private void Form1_Load(object sender, EventArgs e)
        {
            results = new int[500];
            b = new Bitmap(1000, 500);
            b2 = new Bitmap(250, 500);
            b1 = new Bitmap(1000, 500);
            b3 = new Bitmap(1000, 500);
            g = Graphics.FromImage(b);
            g2 = Graphics.FromImage(b2);
            g3 = Graphics.FromImage(b1);
            g4 = Graphics.FromImage(b3);


            Pen pen2 = new Pen(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen2.Width = 2;
            g.DrawLine(pen2, 0, 500, 600, 500);
            g.DrawLine(pen2, 0, 500, 0, 0);
            pictureBox1.Image = b;
            pen3 = new Pen(Color.Black);
            pen3.Width = 5;
            pictureBox2.Image = b2;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            
            Point[] points = new Point[1000];

            for (int j = 0; j < numericUpDown1.Value; j++)
            {
                for (int i = 1; i < 1000; i++)
                {
                    int xval = r.Next(2);

                    Point point = new Point();
                    if (xval > 0)
                    {
                        point.X = i ;
                        point.Y = 250+(1000 / i);
                    }
                    else
                    {
                        point.X = i;
                        point.Y = 250-(1000/i);
                    }

                        points[i] = point;
                }
                g3.DrawLines(Pens.Red, points);
            }
            

            pictureBox1.Image = b1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Point[] points = new Point[1000];

            for (int j = 0; j < numericUpDown1.Value; j++)
            {
                for (int i = 1; i < 1000; i++)
                {
                    int xval = r.Next(2);

                    Point point = new Point();
                    if (xval > 0)
                    {
                        point.X = i;
                        point.Y = (250 + (1000 / i))/(int)(Math.Sqrt(i));
                    }
                    else
                    {
                        point.X = i;
                        point.Y = (250 - (1000 / i)) /(int)(Math.Sqrt(i));
                    }

                    points[i] = point;
                }
                g4.DrawLines(Pens.Blue, points);

            }


            pictureBox1.Image = b3;
        }

        public void disegna(int result)
        {
            if (result == 0)
            {

                g.DrawLine(pen, width, height, width + 20, height);
                width += 20;

            }
            else
            {
                g.DrawLine(pen, width, height, width + 20, height - 20);
                width += 20;
                height -= 20;
            }
            pictureBox1.Image = b;



        }

       


       
    private void button1_Click_1(object sender, EventArgs e)
        {

            for (int j = 0; j < numericUpDown1.Value; j++)
            {
                for (int i = 0; i < 30; i++)
                {
                    if (r.Next(2)> 0)
                        disegna(1);
                    else
                        disegna(0);

                }
                if (height <= 500)
                    results[height] += 1;
                g2.DrawLine(pen3, 0, height, results[height], height);
                pictureBox2.Image = b2;
                pictureBox2.Update();
                width = 0;
                height = 500;
                pictureBox1.Update();
                


            }




        }




    }
}