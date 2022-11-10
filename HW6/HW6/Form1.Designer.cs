namespace HW6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.meanBox = new System.Windows.Forms.PictureBox();
            this.varianceBox = new System.Windows.Forms.PictureBox();
            this.openFile = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.meanBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varianceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // meanBox
            // 
            this.meanBox.Location = new System.Drawing.Point(12, 106);
            this.meanBox.Name = "meanBox";
            this.meanBox.Size = new System.Drawing.Size(590, 378);
            this.meanBox.TabIndex = 0;
            this.meanBox.TabStop = false;
            this.meanBox.Click += new System.EventHandler(this.meanBox_Click);
            // 
            // varianceBox
            // 
            this.varianceBox.Location = new System.Drawing.Point(608, 106);
            this.varianceBox.Name = "varianceBox";
            this.varianceBox.Size = new System.Drawing.Size(549, 378);
            this.varianceBox.TabIndex = 1;
            this.varianceBox.TabStop = false;
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(27, 42);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(112, 34);
            this.openFile.TabIndex = 2;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(968, 46);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(180, 31);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(163, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 33);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 531);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.varianceBox);
            this.Controls.Add(this.meanBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.meanBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varianceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox meanBox;
        private PictureBox varianceBox;
        private Button openFile;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private OpenFileDialog openFileDialog2;
    }
}