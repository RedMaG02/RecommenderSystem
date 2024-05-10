using Microsoft.VisualBasic.ApplicationServices;
using MyMediaLite.Eval;
using MyMediaLite.IO;
using MyMediaLite.RatingPrediction;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace RecommenderSystem
{
    public partial class Form1 : Form
    {
        private string trainDataPath;
        private string movieDataPath;
        private string testDataPath;
        RecommenderSystem rs;
        public Form1()
        {
            InitializeComponent();
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox2.Checked = true;
            label35.AutoSize = false;
            label35.Paint += Label35_Paint;
            rs = new RecommenderSystem();
        }

        private void Label35_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(label35.Text, label35.Font);
            label35.Width = (int)textSize.Height + 2;
            label35.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-label35.Height / 2, label35.Width / 2);
            e.Graphics.DrawString(label35.Text, label35.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }

        private void ProcessRating(RecommendationTypes type, int k = 1, bool useNormalisation = false)
        {
            (double[,] data, double mae, double rmse, double r, int count, double accuracy, double precision, double recall) = rs.ProcessTest(rs._testData, k, useNormalisation, type);


            textBox1.Text = Convert.ToString(mae);
            textBox2.Text = Convert.ToString(rmse);
            textBox3.Text = Convert.ToString(r);
            textBox4.Text = Convert.ToString(count);
            textBox5.Text = Convert.ToString(accuracy);
            textBox6.Text = Convert.ToString(precision);
            textBox7.Text = Convert.ToString(recall);

            CreateChart(data, (1000, 500));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.CollaborativeFiltering, Convert.ToInt32(numericUpDown1.Value), checkBox1.Checked);
        }

        private void CreateChart(double[,] data, (int, int) position)
        {


            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    this.Controls.Remove(control);
                    control.Dispose();
                }
            }

            int size = 100;

            var pb = new PictureBox();
            pb.Size = new Size(size * 5, size / 2);
            pb.Location = new Point(position.Item1, (int)(position.Item2 - size * 4.75));

            int startX = 0;


            Bitmap image = new Bitmap(size * 5, size);
            int totalRectangles = 100;
            int rectWidth = size * 5 / totalRectangles;


            using (Graphics g = Graphics.FromImage(image))
            {

                for (int i = 0; i < totalRectangles; i++)
                {


                    double hue = 240 + 120 * ((double)i / totalRectangles);
                    double saturation = 1;
                    double value = 0.3 + 0.7 * ((double)i / totalRectangles);

                    Color color = ColorFromHSV(hue, saturation, value);


                    Rectangle rectangle = new Rectangle(startX, 0, rectWidth, 50);


                    g.FillRectangle(new SolidBrush(color), rectangle);


                    startX += rectWidth;

                    if ((i - 10) % 20 == 0 && i != 10)
                    {
                        Font font = new Font("Arial", 14.25f, FontStyle.Bold);
                        double valueInRange = (i - 10) / 100.0;
                        g.DrawString(valueInRange.ToString("0.0"), font, Brushes.White, startX - 14 * rectWidth, 15);
                    }
                    if (i == 5)
                    {
                        Font font = new Font("Arial", 14.25f, FontStyle.Bold);
                        g.DrawString("0", font, Brushes.White, 10, 15);
                    }
                    if (i == 99)
                    {
                        Font font = new Font("Arial", 14.25f, FontStyle.Bold);
                        g.DrawString("1", font, Brushes.White, 474, 15);
                    }
                }


            }

            pb.Image = image;
            Controls.Add(pb);




            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    pb = new PictureBox();
                    pb.Size = new Size(size, size);
                    pb.Location = new Point(position.Item1 + (j * size), position.Item2 - (i * size));
                    image = new Bitmap(size, size);
                    using (Graphics g = Graphics.FromImage(image))
                    {
                        double hue = 240 + 120 * data[i, j];
                        double saturation = 1;
                        double value = 0.3 + 0.7 * data[i, j];


                        g.Clear(ColorFromHSV(hue, saturation, value));
                        string text = Convert.ToString(Math.Round(data[i, j], 2));
                        Font font = new Font("Arial", 12, FontStyle.Bold);
                        SizeF textSize = g.MeasureString(text, font);
                        g.DrawString(text, font, Brushes.White, new PointF((size - textSize.Width) / 2, (size - textSize.Height) / 2));

                        Pen borderPen = new Pen(Color.White, 2);
                        g.DrawRectangle(borderPen, 0, 0, size - 1, size - 1);

                    }
                    pb.Image = image;
                    this.Controls.Add(pb);

                }
            }
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = !checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox3.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                trainDataPath = openFileDialog1.FileName;
                testDataPath = trainDataPath;
                checkBox4.Checked = true;
                if (checkBox_UseTrainDataAsTest.Checked)
                {
                    rs.CreateItemUserMatrixes(trainDataPath, false);
                    rs.GetTestData(trainDataPath);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rs.CteateItemItemSimilarityMatrix();
            }
            else
            {
                rs.CteateItemItemSimilarityMatrixAC();
            }

            //rs.CteateItemItemSimilarityMatrixGenresBasedV2();
            checkBox6.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                movieDataPath = openFileDialog1.FileName;
                checkBox5.Checked = true;
                rs.GetGenresData(movieDataPath);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rs = new();
            //rs.CreateItemTagMatrix(@"C:\Users\RedMa\OneDrive\Рабочий стол\Курсач\ml-25m\genome-scores.csv", true);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var training_data = RatingData.Read(@"C:\Users\RedMa\OneDrive\Рабочий стол\Курсач\ml-1m\ratings.dat");
            var test_data = RatingData.Read(@"C:\Users\RedMa\OneDrive\Рабочий стол\Курсач\ml-1m\ratings.dat");


            var recommender = new UserItemBaseline();
            recommender.Ratings = training_data;
            recommender.Train();


            var results = recommender.Evaluate(test_data);
            MessageBox.Show($"RMSE={results["RMSE"]} MAE={results["MAE"]}");
            MessageBox.Show(results.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.LinearRegression);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_UseTrainDataAsTest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_ContentSimilarityMatrix_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                Stopwatch sw = Stopwatch.StartNew();
                rs.CteateItemItemSimilarityMatrixGenresBasedV1();
                sw.Stop();
                timeTextBox_ContentSimilarity.Text = $"{sw.ElapsedMilliseconds}";
                checkBox8.Checked = true;
            }
            else
            {
                MessageBox.Show("Заполните информацию о данных");
            }
        }

        private void button_ContentBasedResult_Click(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.ContentBasedFiltering, Convert.ToInt32(numericUpDown2.Value), checkBox9.Checked);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_MonolithResult_Click(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.MonolithHybrid, Convert.ToInt32(numericUpDown3.Value), checkBox11.Checked);
        }

        private void button_AnsambleResult_Click(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.AnsembleHybrid);
        }

        private void uniform_Click(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.UniformRandom);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.NormalRandom);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ProcessRating(RecommendationTypes.Num);
        }
    }
}