using System.Windows.Forms;

namespace HW6
{
    public partial class Form1 : Form
    {
        string[][] rows;
        string[] columns;

        string[] values;

        readonly int runs = 150;

        float[] mean;
        float[] variance;

        public Form1()
        {
            InitializeComponent();
        }

        private void computeVarianceAndMean()
        {
            Random random = new Random();
            int definedNumber = (int)numericUpDown1.Value;
            mean = new float[runs];
            variance = new float[runs];
            for (int j = 0; j < runs; j++)
            {
                float[] samples = new float[definedNumber];
                float sum = 0;
                for (int i = 0; i < samples.Length; i++)
                {
                    float value = float.Parse(values[random.Next(values.Length)]);
                    samples[i] = value;
                    sum += value;
                }
                mean[j] = sum / definedNumber;
                float varianceAcc = 0;
                for (int i = 0; i < samples.Length; i++)
                {
                    float current = samples[i] - mean[j];
                    varianceAcc += current * current;
                }
                variance[j] = varianceAcc / definedNumber;
            }

            Bitmap bmean = new Bitmap(meanBox.Width, meanBox.Height);
            Bitmap bvar = new Bitmap(varianceBox.Width, varianceBox.Height);

            Graphics gmean = Graphics.FromImage(bmean);
            Graphics gvar = Graphics.FromImage(bvar);

            gmean.Clear(SystemColors.Control);
            gvar.Clear(SystemColors.Control);

            Pen p = new Pen(Brushes.Black, 2);

            Dictionary<float, float> meanHisto = new Dictionary<float, float>();

            foreach (float current in mean)
            {
                float step = 0.5F;
                float lowerBound = 0;
                while (current > lowerBound)
                {
                    lowerBound += step;
                }
                meanHisto[lowerBound - step] = meanHisto.GetValueOrDefault(lowerBound - step, 0) + 1;
            }
            float maxHeight = meanHisto.Values.Max() + 10;
            float lower = meanHisto.Keys.Min() - 5;
            float upper = meanHisto.Keys.Max() + 5;
            foreach (KeyValuePair<float, float> kp in meanHisto)
            {
                gmean.DrawLine(p, (kp.Key - lower) * meanBox.Width / (upper - lower), meanBox.Height, (kp.Key - lower) * meanBox.Width / (upper - lower), meanBox.Height - (kp.Value * meanBox.Height / maxHeight));
            }

            Dictionary<float, float> varHisto = new Dictionary<float, float>();

            foreach (float current in variance)
            {
                float step = 5F;
                float lowerBound = 0;
                while (current > lowerBound)
                {
                    lowerBound += step;
                }
                varHisto[lowerBound - step] = varHisto.GetValueOrDefault(lowerBound - step, 0) + 1;
            }
            maxHeight = varHisto.Values.Max() + 10;
            lower = varHisto.Keys.Min() - 5;
            upper = varHisto.Keys.Max() + 5;
            p = new Pen(Brushes.Black, 1);
            foreach (KeyValuePair<float, float> kp in varHisto)
            {
                gvar.DrawLine(p, (kp.Key - lower) * (varianceBox.Width / (upper - lower)), varianceBox.Height, (kp.Key - lower) * (varianceBox.Width / (upper - lower)), varianceBox.Height - (kp.Value * (varianceBox.Height / maxHeight)));
            }

            meanBox.Image = bmean;
            varianceBox.Image = bvar;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            int index = Array.IndexOf(columns, selected);
            values = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                values[i] = rows[i][index];
            }
            
            computeVarianceAndMean();
        }

        private void openFile_Click_1(object sender, EventArgs e)
        {
            
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = openFileDialog2.OpenFile();

                string fileContent;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                string[] lines = fileContent.Split(Environment.NewLine);
                columns = lines[0].Split(',');
                rows = new string[lines.Length - 1][];
                //Array.Copy(lines, 1, rows, 0, rows.Length - 1);

                for (int i = 1; i < lines.Length; i++)
                {
                    rows[i - 1] = lines[i].Split(',');
                }

                comboBox1.Items.AddRange(columns);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void meanBox_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            computeVarianceAndMean();
        }
    }
}