namespace RecommenderSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecommenderSystem rs = new(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\u.data.csv");
            rs.CreateItemUserColumnMatrix();
            rs.CteateItemItemSimilarityMatrix();
            rs.PrintUserItemMatrix(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\userItemMatrix.csv");
            rs.PrintItemItemMatrix(@"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\itemItemMatrix.csv");
        }
    }
}