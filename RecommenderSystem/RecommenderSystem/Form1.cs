using System.Drawing;
using System.Windows.Forms;

namespace RecommenderSystem
{
    public partial class Form1 : Form
    {
        private string trainDataPath;
        private string testDataPath;
        RecommenderSystem rs;
        public Form1()
        {
            InitializeComponent();
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RecommenderSystem rs = new(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\trainData.csv");
            //rs.CreateItemUserColumnMatrix();
            //rs.CreateItemUserRowMatrix();
            //rs.CteateItemItemSimilarityMatrixAC();
            //rs.PrintUserItemMatrix(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\userItemMatrix.csv");
            //rs.PrintItemItemMatrix(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\itemItemMatrix.csv");




            //if (checkBox4.Checked && checkBox5.Checked && checkBox6.Checked)
            //{
            //    textBox1.Text = Convert.ToString(rs.MAE(rs._testData, Convert.ToInt32(numericUpDown1.Value), checkBox1.Checked));
            //    textBox2.Text = Convert.ToString(rs.RMSE(rs._testData, Convert.ToInt32(numericUpDown1.Value), checkBox1.Checked));
            //}
            //else
            //{
            //    MessageBox.Show("Введите необходимые данные");

            //}

            //rs.GetTestData(testDataPath);
            (double[,] data, double mae, double rmse, double r) = rs.ProcessTest(rs._testData, Convert.ToInt32(numericUpDown1.Value), checkBox1.Checked);

            textBox1.Text = Convert.ToString(mae);
            textBox2.Text = Convert.ToString(rmse);

            CreateChart(data, (1000, 500));

        }

        private void CreateChart(double[,] data, (int, int) position) 
        {
            
            int size = 100;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    var pb = new PictureBox();
                    pb.Size = new Size(size, size);
                    pb.Location = new Point(position.Item1 + (j * size), position.Item2 - (i * size));
                    Bitmap image = new Bitmap(size, size);
                    for (int k = 0; k< size; k++)
                    {
                        for (int l = 0; l < size; l++)
                        {
                            image.SetPixel(k, l, Color.FromArgb(255, 0, 0, (int)(255 * data[i, j])));
                        }
                    }
                    pb.Image = image;
                    var lb = new Label();
                    //lb.Location = pb.Location;
                    lb.Text = Convert.ToString(data[i, j]);
                    this.Controls.Add(pb);
                    pb.Controls.Add(lb);
                    
                }
            }
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
                checkBox4.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rs = new();
            //rs.CreateItemUserColumnMatrix(trainDataPath);
            //rs.CreateItemUserRowMatrix(trainDataPath);
            rs.CreateItemUserMatrixes(trainDataPath);
            //if (checkBox2.Checked)
            //{
            //    rs.CteateItemItemSimilarityMatrix();
            //}
            //else
            //{
            //    rs.CteateItemItemSimilarityMatrixAC();
            //}
            rs.GetGenresData(testDataPath);
            rs.CteateItemItemSimilarityMatrixGenresBasedV2();
            checkBox6.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                testDataPath = openFileDialog1.FileName;
                checkBox5.Checked = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rs = new();
            //rs.CreateItemTagMatrix(@"C:\Users\RedMa\OneDrive\Рабочий стол\Курсач\ml-25m\genome-scores.csv", true);
        }

    }
}