using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW8._2
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Pen pen = new Pen(Color.Black);
        Bitmap b;
        Graphics g;


       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            Rectangle window1 = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, window1);


            double minValue = -3;
            double maxValue = 3;


            double delta = maxValue - minValue;
            double nintervals = 150;
            double intervalsSize = delta / nintervals;


            int nTrials = (int)numericUpDown1.Value;

            Dictionary<double, int> istogramDict = new Dictionary<double, int>();
            double tempValue = minValue;
            for (int i = 0; i <= nintervals; i++)
            {
                tempValue = minValue + (intervalsSize * i);
                tempValue = Math.Round(tempValue, 2);
                istogramDict[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value1 = 0;
               

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);

                value1 = xRnd;


                foreach (double key in istogramDict.Keys)
                {
                    double range = key + intervalsSize;
                    if (range > maxValue) range = maxValue;
                    if (value1 < range && value1 > key)
                    {
                        istogramDict[key] += 1;
                        if (total < istogramDict[key])
                        {
                            total = istogramDict[key];
                        }
                        break;
                    }
                }
            }

            

            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in istogramDict.Keys)
            {
                lastKeyY = key;
                int newHeight = istogramDict[key] * this.b.Height / total;
                int newX = (widthIstogram * idIstogram) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                int nextWidthIstogram = (int)(widthIstogram * idIstogram * 1);

                g.DrawRectangle(Pens.Black, isto);
                g.FillRectangle(Brushes.LightBlue, isto);

            }

            this.pictureBox1.Image = b;
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            Rectangle window1 = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, window1);


            double minValue = 0;
            double maxValue = 4;

            double delta = maxValue - minValue;
            double nintervals = 150;
            double intervalsSize = delta / nintervals;

            int nTrials = (int)numericUpDown1.Value;

            Dictionary<double, int> istogramDict = new Dictionary<double, int>();
            double tempValue = minValue;
            for (int i = 0; i <= nintervals; i++)
            {
                tempValue = minValue + (intervalsSize * i);
                tempValue = Math.Round(tempValue, 2);
                istogramDict[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                
                double value2 = 0;

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);

                
                value2 = xRnd * xRnd;
               

                foreach (double key in istogramDict.Keys)
                {
                    double range = key + intervalsSize;
                    if (range > maxValue) range = maxValue;
                    if (value2 < range && value2 > key)
                    {
                        istogramDict[key] += 1;
                        if (total < istogramDict[key])
                        {
                            total = istogramDict[key];
                        }
                        break;
                    }
                }
            }



            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in istogramDict.Keys)
            {
                lastKeyY = key;
                int newHeight = istogramDict[key] * this.b.Height / total;
                int newX = (widthIstogram * idIstogram) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                int nextWidthIstogram = (int)(widthIstogram * idIstogram * 1);

                g.DrawRectangle(Pens.Black, isto);
                g.FillRectangle(Brushes.LightBlue, isto);

            }

            this.pictureBox1.Image = b;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            Rectangle window1 = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, window1);


            double minValue = -8;
            double maxValue = 8;



            double delta = maxValue - minValue;
            double nintervals = 150;
            double intervalsSize = delta / nintervals;


            int nTrials = (int)numericUpDown1.Value;

            Dictionary<double, int> istogramDict = new Dictionary<double, int>();
            double tempValue = minValue;
            for (int i = 0; i <= nintervals; i++)
            {
                tempValue = minValue + (intervalsSize * i);
                tempValue = Math.Round(tempValue, 2);
                istogramDict[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value3 = 0;
              
                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);

                
                value3 = xRnd / (yRnd * yRnd);
               

                foreach (double key in istogramDict.Keys)
                {
                    double range = key + intervalsSize;
                    if (range > maxValue) range = maxValue;
                    if (value3 < range && value3 > key)
                    {
                        istogramDict[key] += 1;
                        if (total < istogramDict[key])
                        {
                            total = istogramDict[key];
                        }
                        break;
                    }
                }
            }



            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in istogramDict.Keys)
            {
                lastKeyY = key;
                int newHeight = istogramDict[key] * this.b.Height / total;
                int newX = (widthIstogram * idIstogram) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                int nextWidthIstogram = (int)(widthIstogram * idIstogram * 1);

                g.DrawRectangle(Pens.Black, isto);
                g.FillRectangle(Brushes.LightBlue, isto);

            }

            this.pictureBox1.Image = b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            Rectangle window1 = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, window1);


            double minValue = 0;
            double maxValue = 4;


            double delta = maxValue - minValue;
            double nintervals = 150;
            double intervalsSize = delta / nintervals;


            int nTrials = (int)numericUpDown1.Value;

            Dictionary<double, int> istogramDict = new Dictionary<double, int>();
            double tempValue = minValue;
            for (int i = 0; i <= nintervals; i++)
            {
                tempValue = minValue + (intervalsSize * i);
                tempValue = Math.Round(tempValue, 2);
                istogramDict[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
               
                double value4 = 0;
              

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);

               
                value4 = (xRnd * xRnd) / (yRnd * yRnd);
             
                foreach (double key in istogramDict.Keys)
                {
                    double range = key + intervalsSize;
                    if (range > maxValue) range = maxValue;
                    if (value4 < range && value4 > key)
                    {
                        istogramDict[key] += 1;
                        if (total < istogramDict[key])
                        {
                            total = istogramDict[key];
                        }
                        break;
                    }
                }
            }



            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in istogramDict.Keys)
            {
                lastKeyY = key;
                int newHeight = istogramDict[key] * this.b.Height / total;
                int newX = (widthIstogram * idIstogram) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                int nextWidthIstogram = (int)(widthIstogram * idIstogram * 1);

                g.DrawRectangle(Pens.Black, isto);
                g.FillRectangle(Brushes.LightBlue, isto);

            }

            this.pictureBox1.Image = b;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            Rectangle window1 = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, window1);


            double minValue = -10;
            double maxValue = 10;


            double delta = maxValue - minValue;
            double nintervals = 150;
            double intervalsSize = delta / nintervals;

            int nTrials = (int)numericUpDown1.Value;

            Dictionary<double, int> istogramDict = new Dictionary<double, int>();
            double tempValue = minValue;
            for (int i = 0; i <= nintervals; i++)
            {
                tempValue = minValue + (intervalsSize * i);
                tempValue = Math.Round(tempValue, 2);
                istogramDict[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value5 = 0;

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);

               
                value5 = xRnd / yRnd;


                foreach (double key in istogramDict.Keys)
                {
                    double range = key + intervalsSize;
                    if (range > maxValue) range = maxValue;
                    if (value5 < range && value5 > key)
                    {
                        istogramDict[key] += 1;
                        if (total < istogramDict[key])
                        {
                            total = istogramDict[key];
                        }
                        break;
                    }
                }
            }



            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in istogramDict.Keys)
            {
                lastKeyY = key;
                int newHeight = istogramDict[key] * this.b.Height / total;
                int newX = (widthIstogram * idIstogram) + 1;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                int nextWidthIstogram = (int)(widthIstogram * idIstogram * 1);

                g.DrawRectangle(Pens.Black, isto);
                g.FillRectangle(Brushes.LightBlue, isto);

            }

            this.pictureBox1.Image = b;
        }
    }
}