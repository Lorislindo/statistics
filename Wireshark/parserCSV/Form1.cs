using System;
using System.Collections.Generic;
using System.Windows.Forms;


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
            bool headerSet = false;

            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        var lines = System.IO.File.ReadAllLines(path);






                        foreach (var s in lines)
                        {
                            var fields = s.Split(',');


                            if (!headerSet)
                            {
                                foreach (var field in fields)
                                    dataGridView1.Columns.Add(field, field);
                                headerSet = true;
                            }
                            else
                                dataGridView1.Rows.Add(fields);


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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Dictionary<string, int> valuePairs = new Dictionary<string, int>();

            dataGridView2.Rows.Clear();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var value = (string)dataGridView1[e.ColumnIndex, i].Value;
                if (!valuePairs.ContainsKey(value))
                    valuePairs.Add(value, 1);
                else
                    valuePairs[value]++;
            }

            foreach (var pair in valuePairs)
                dataGridView2.Rows.Add(pair.Key, $"{pair.Value} / {dataGridView1.Rows.Count} ({(double)pair.Value / dataGridView1.Rows.Count * 100:N2}%)");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}