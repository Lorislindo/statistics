using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HW5
{
    public partial class Form1 : Form
    {
       
            Bitmap b;
            Graphics g;
            
            EditableRec r1;
            EditableRec r2;

        public Form1()
        {
            InitializeComponent();

            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new EditableRec(20, 20, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1, this);
            r2 = new EditableRec(pictureBox1.Width / 2 + 300, pictureBox1.Height / 2, 100, 200, pictureBox1, this);

            g.DrawRectangle(Pens.Green, r1.r);
            g.DrawRectangle(Pens.Red, r2.r);

            pictureBox1.Image = b;

            timer1.Start();
        }
            

            private void timer1_Tick(object sender, EventArgs e)
            {
                g.Clear(pictureBox1.BackColor);
               
            drawHistogram_horizontal();
            drawHistogram_vertical();

                pictureBox1.Image = b;
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
            
        

        private void drawHistogram_horizontal()
        {
            Dictionary<string, int> numb = distibution();

            g.FillRectangle(Brushes.Black, r1.r);
            g.DrawRectangle(Pens.Red, r1.r);



            int maxvalue = numb.Values.Max();

            int height = r1.r.Bottom - r1.r.Top - 20;
            int width = r1.r.Right - r1.r.Left;

            int intervals = numb.Keys.Count();
            int hwidth = width / intervals;

            int start = r1.r.X;

            foreach (KeyValuePair<string, int> n in numb)
            {
                int rect_height = (int)(((double)n.Value / (double)maxvalue) * ((double)height));
                Rectangle hist_rect = new Rectangle(start, r1.r.Bottom - rect_height, hwidth, rect_height);

                g.FillRectangle(Brushes.Yellow, hist_rect);
                g.DrawRectangle(Pens.Red, hist_rect);

                string text = n.Key;

                Rectangle rec = new Rectangle(start, r1.r.Bottom + 20, hwidth, hwidth);
                Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);

                StringFormat strfor = new StringFormat();

                strfor.Alignment = StringAlignment.Center;
                strfor.LineAlignment = StringAlignment.Center;

                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                

                g.DrawString(text, font1, Brushes.Black, rec, strfor);

                start += hwidth;
            }

            pictureBox1.Image = b;
        }


        private void drawHistogram_vertical()

        {
            Dictionary<string, int> numb = distibution();


            g.FillRectangle(Brushes.Black, r2.r);
            g.DrawRectangle(Pens.Blue, r2.r);



            int maxvalue = numb.Values.Max();

            int height = r2.r.Bottom - r2.r.Top;
            int width = r2.r.Right - r2.r.Left - 20;

            int intervals = numb.Keys.Count();
            int hwidth = height / intervals;

            int start = r2.r.Y;

            foreach (KeyValuePair<string, int> n in numb)
            {
                int rect_height = (int)(((double)n.Value / (double)maxvalue) * ((double)width));
                Rectangle hist_rect = new Rectangle(r2.r.Left, start, rect_height, hwidth);

                g.FillRectangle(Brushes.Yellow, hist_rect);
                g.DrawRectangle(Pens.Blue, hist_rect);

                string text = n.Key;
                Rectangle rec = new Rectangle(r2.r.Left - (hwidth * 5), start, hwidth * 5, hwidth);
                Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);

                StringFormat strfor = new StringFormat();

                strfor.Alignment = StringAlignment.Center;
                strfor.LineAlignment = StringAlignment.Center;

                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;


                g.DrawString(text, font1, Brushes.Black, rec, strfor);

                start += hwidth;
            }

            pictureBox1.Image = b;
        }

        private Dictionary<string, int> distibution()
        {
            Dictionary<string, int> numb = new Dictionary<string, int>();
            Random rand = new Random();

            string path = "../../wireshark_statistics.csv";
            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] rows = line.Split(',');

                string prot = rows[4];

                if (!numb.ContainsKey(prot))
                {
                    numb.Add(prot, 1);
                }
                else
                {
                    numb[prot]++;
                }
            }
            return numb;
        }

    }
    }