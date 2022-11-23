using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Windows.Forms;

namespace HW8
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Pen pen = new Pen(Color.Black);
        Bitmap b;
        Graphics g;


        Bitmap b2;
        Graphics g2;

        Bitmap b3;
        Graphics g3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private int FromXRealToXVirtual(double X, double minX, double maxX, int Left, int W)
        {
            if (maxX - minX == 0)
            {
                return 0;
            }
            else
            {
                return (int)(Left + W * (X - minX) / (maxX - minX));
            }
        }

        private int FromYRealToYVirtual(double Y, double minY, double maxY, int Top, int H)
        {
            if (maxY - minY == 0)
            {
                return 0;
            }
            else
            {
                return (int)(Top + H - H * (Y - minY) / (maxY - minY));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            
            this.g.Clear(Color.White);

            Rectangle window = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, window);

            int nPoints = (int)trackBar1.Value;

            double minX = -100;
            double maxX = 100;
            double minY = -100;
            double maxY = 100;

            List<double> X = new List<double>();
            List<double> Y = new List<double>();


            for (int i = 0; i < nPoints; i++)
            {
                double ray = r.NextDouble() * 100;
                double angle = r.Next(0, 360);
                double xCoord = ray * Math.Cos(angle);
                double yCoord = ray * Math.Sin(angle);

                int xDevice = FromXRealToXVirtual(xCoord, minX, maxX, window.Left, window.Width);
                int yDevice = FromYRealToYVirtual(yCoord, minY, maxY, window.Top, window.Height);

                Rectangle rect = new Rectangle(xDevice, yDevice, 1, 1);
                g.DrawRectangle(pen, rect);
                g.FillRectangle(Brushes.Black, rect);

                X.Add(xDevice);
                Y.Add(yDevice);

            }

            this.pictureBox1.Image = b;

            this.b2 = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            this.g2 = Graphics.FromImage(b2);
            this.g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g2.Clear(Color.White);

            Rectangle Window2 = new Rectangle(0, 0, this.b2.Width - 1, this.b2.Height - 1);
            g2.DrawRectangle(Pens.Black, Window2);

            double minValueX = X.Min();
            double maxValueX = X.Max();
            double delta = maxValueX - minValueX;
            double nintervals = 15;
            double intervalsSize = delta / nintervals;

            Dictionary<double, int> Xisto = new Dictionary<double, int>();

            double tempValue = minValueX;
            for (int i = 0; i < nintervals; i++)
            {
                Xisto[tempValue] = 0;
                tempValue = tempValue + intervalsSize;
            }

            int total = 0;

            foreach (double value in X)
            {
                foreach (double key in Xisto.Keys)
                {
                    if (value < key + intervalsSize)
                    {
                        Xisto[key] += 1;
                        if (total < Xisto[key])
                        {
                            total = Xisto[key];
                        }
                        break;
                    }
                }
            }


            g2.TranslateTransform(0, this.b2.Height);
            g2.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b2.Width / nintervals);
            double lastKey = 0;

            foreach (double key in Xisto.Keys)
            {
                lastKey = key;
                int newHeight = Xisto[key] * this.b2.Height / total;
                int newX = (widthIstogram * idIstogram) + 1;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                
                g2.DrawRectangle(Pens.Black, isto);
                g2.FillRectangle(Brushes.LightBlue, isto);
            }


            this.pictureBox2.Image = b2;

            
            this.b3 = new Bitmap(this.pictureBox3.Width, this.pictureBox3.Height);
            this.g3 = Graphics.FromImage(b3);
            this.g3.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g3.Clear(Color.White);

            Rectangle VirtualWindow3 = new Rectangle(0, 0, this.b3.Width - 1, this.b3.Height - 1);
            g3.DrawRectangle(Pens.Black, VirtualWindow3);

            double minValueY = Y.Min();
            double maxValueY = Y.Max();
            double deltaY = maxValueY - minValueY;
            double intervalsYSize = deltaY / nintervals;

            Dictionary<double, int> Yisto = new Dictionary<double, int>();

            double tempValueY = minValueY;
            for (int i = 0; i < nintervals; i++)
            {
                Yisto[tempValueY] = 0;
                tempValueY = tempValueY + intervalsYSize;
            }

            int totalY = 0;

            foreach (double value in Y)
            {
                foreach (double key in Yisto.Keys)
                {
                    if (value < key + intervalsYSize)
                    {
                        Yisto[key] += 1;
                        if (totalY < Yisto[key])
                        {
                            totalY = Yisto[key];
                        }
                        break;
                    }
                }
            }

            g3.TranslateTransform(0, this.b3.Height);
            g3.ScaleTransform(1, -1);

            idIstogram = 0;
            int widthIstogramY = (int)(this.b3.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in Yisto.Keys)
            {
                lastKeyY = key;
                int newHeight = Yisto[key] * this.b3.Height / totalY;
                int newX = (widthIstogramY * idIstogram) + 1;
                Rectangle isto = new Rectangle(newX, 0, widthIstogramY, newHeight);
                idIstogram++;

                g3.DrawRectangle(Pens.Black, isto);
                g3.FillRectangle(Brushes.LightBlue, isto);


            }

            
        this.pictureBox3.Image = b3;

        }

        

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}