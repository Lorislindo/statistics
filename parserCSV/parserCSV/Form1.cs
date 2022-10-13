using System;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace parserCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          
            openFileDialog1.Title = "Select file to be upload.";
         
            openFileDialog1.Filter = "Select Valid Document(*.csv)|*.csv";
            

            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        string[] lines = System.IO.File.ReadAllLines(path);

                        foreach (string line in lines)
                        {
                            string[] columns = line.Split(',');

                            richTextBox1.AppendText("\r\n");
                            richTextBox1.AppendText(columns[0] + " ");
                            string size = columns[7];
                            richTextBox1.AppendText(size);


                            foreach (string column in columns)
                            {

                                //richTextBox1.AppendText(column+" ");

                            }


                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

