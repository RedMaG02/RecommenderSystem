namespace RecommenderSystem
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            label4 = new Label();
            button4 = new Button();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(12, 195);
            button1.Name = "button1";
            button1.Size = new Size(112, 39);
            button1.TabIndex = 0;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(457, 166);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(313, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(457, 214);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(313, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(457, 144);
            label1.Name = "label1";
            label1.Size = new Size(313, 19);
            label1.TabIndex = 3;
            label1.Text = "Средняя абсолютная ошибка (MAE)";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(457, 192);
            label2.Name = "label2";
            label2.Size = new Size(326, 19);
            label2.TabIndex = 4;
            label2.Text = "Среднеквадратичная ошибка (RMSE)";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(12, 29);
            button2.Name = "button2";
            button2.Size = new Size(191, 70);
            button2.TabIndex = 5;
            button2.Text = "Загрузить обучающий набор данных";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(12, 126);
            button3.Name = "button3";
            button3.Size = new Size(191, 63);
            button3.TabIndex = 6;
            button3.Text = "Загрузить тестовый набор данных";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(12, 263);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(485, 23);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Использовать нормализацию оценок (Mean centering)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(343, 214);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 23);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(142, 195);
            label3.Name = "label3";
            label3.Size = new Size(195, 38);
            label3.TabIndex = 9;
            label3.Text = "Количество соседей\r\nдля предсказания k =";
            label3.Click += label3_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.Location = new Point(12, 325);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(110, 23);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "Объектов";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox3.Location = new Point(12, 354);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(156, 23);
            checkBox3.TabIndex = 11;
            checkBox3.Text = "Пользователей";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 300);
            label4.Name = "label4";
            label4.Size = new Size(492, 19);
            label4.TabIndex = 12;
            label4.Text = "Подсчет схожести продуктов на основе средних оценок:";
            // 
            // button4
            // 
            button4.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(275, 29);
            button4.Name = "button4";
            button4.Size = new Size(188, 70);
            button4.TabIndex = 13;
            button4.Text = "Рассчитать схожесть";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(211, 60);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 14;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(209, 153);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(15, 14);
            checkBox5.TabIndex = 15;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(469, 60);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(15, 14);
            checkBox6.TabIndex = 16;
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 404);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button button3;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label label4;
        private Button button4;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
    }
}