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
            if (checkBox4.Checked && checkBox5.Checked && checkBox6.Checked)
            {
                textBox1.Text = Convert.ToString(rs.MAE(rs.GetTestData(testDataPath), Convert.ToInt32(numericUpDown1.Value), checkBox1.Checked));
                textBox2.Text = Convert.ToString(rs.RMSE(rs.GetTestData(testDataPath), Convert.ToInt32(numericUpDown1.Value), checkBox1.Checked));
            }
            else
            {
                MessageBox.Show("¬ведите необходимые данные");

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
            rs = new(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\trainData.csv");
            rs.CreateItemUserColumnMatrix();
            rs.CreateItemUserRowMatrix();
            if (checkBox2.Checked)
            {
                rs.CteateItemItemSimilarityMatrix();
            }
            else
            {
                rs.CteateItemItemSimilarityMatrixAC();
            }
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
    }
}