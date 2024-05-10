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
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            textBox3 = new TextBox();
            label16 = new Label();
            textBox4 = new TextBox();
            label17 = new Label();
            textBox5 = new TextBox();
            label18 = new Label();
            textBox6 = new TextBox();
            label19 = new Label();
            textBox7 = new TextBox();
            checkBox7 = new CheckBox();
            button5 = new Button();
            checkBox8 = new CheckBox();
            label20 = new Label();
            numericUpDown2 = new NumericUpDown();
            checkBox9 = new CheckBox();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            label21 = new Label();
            label22 = new Label();
            button9 = new Button();
            checkBox10 = new CheckBox();
            label23 = new Label();
            numericUpDown3 = new NumericUpDown();
            checkBox11 = new CheckBox();
            label24 = new Label();
            label25 = new Label();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            label26 = new Label();
            textBox12 = new TextBox();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            textBox15 = new TextBox();
            textBox16 = new TextBox();
            textBox17 = new TextBox();
            textBox18 = new TextBox();
            textBox19 = new TextBox();
            textBox20 = new TextBox();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(292, 424);
            button1.Name = "button1";
            button1.Size = new Size(196, 73);
            button1.TabIndex = 0;
            button1.Text = "Рассчитать коллаборативная фильтрация";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(579, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(579, 95);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(244, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(579, 17);
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
            label2.Location = new Point(579, 70);
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
            button2.Text = "Загрузить обучающий набор ratings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(12, 117);
            button3.Name = "button3";
            button3.Size = new Size(191, 66);
            button3.TabIndex = 6;
            button3.Text = "Загрузить обучающий набор movies";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.LightBlue;
            checkBox1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(17, 395);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(485, 23);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Использовать нормализацию оценок (Mean centering)";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.LightBlue;
            numericUpDown1.Location = new Point(218, 443);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 23);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightBlue;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(17, 428);
            label3.Name = "label3";
            label3.Size = new Size(195, 38);
            label3.TabIndex = 9;
            label3.Text = "Количество соседей\r\nдля предсказания k =";
            label3.Click += label3_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.LightBlue;
            checkBox2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.Location = new Point(18, 324);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(110, 23);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "Объектов";
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.LightBlue;
            checkBox3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox3.Location = new Point(18, 353);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(156, 23);
            checkBox3.TabIndex = 11;
            checkBox3.Text = "Пользователей";
            checkBox3.UseVisualStyleBackColor = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightBlue;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(18, 293);
            label4.Name = "label4";
            label4.Size = new Size(492, 19);
            label4.TabIndex = 12;
            label4.Text = "Подсчет схожести продуктов на основе средних оценок:";
            // 
            // button4
            // 
            button4.BackColor = Color.LightBlue;
            button4.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(211, 324);
            button4.Name = "button4";
            button4.Size = new Size(203, 65);
            button4.TabIndex = 13;
            button4.Text = "Рассчитать схожесть коллаборативная фильтрация";
            button4.UseVisualStyleBackColor = false;
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
            checkBox5.Location = new Point(211, 146);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(15, 14);
            checkBox5.TabIndex = 15;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.BackColor = Color.LightBlue;
            checkBox6.Location = new Point(420, 353);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(15, 14);
            checkBox6.TabIndex = 16;
            checkBox6.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(963, 126);
            label5.Name = "label5";
            label5.Size = new Size(23, 25);
            label5.TabIndex = 18;
            label5.Text = "5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(963, 543);
            label6.Name = "label6";
            label6.Size = new Size(23, 25);
            label6.TabIndex = 19;
            label6.Text = "1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1043, 616);
            label7.Name = "label7";
            label7.Size = new Size(23, 25);
            label7.TabIndex = 20;
            label7.Text = "1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(1443, 616);
            label8.Name = "label8";
            label8.Size = new Size(23, 25);
            label8.TabIndex = 21;
            label8.Text = "5";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(963, 437);
            label9.Name = "label9";
            label9.Size = new Size(23, 25);
            label9.TabIndex = 22;
            label9.Text = "2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(963, 333);
            label10.Name = "label10";
            label10.Size = new Size(23, 25);
            label10.TabIndex = 23;
            label10.Text = "3";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(963, 222);
            label11.Name = "label11";
            label11.Size = new Size(23, 25);
            label11.TabIndex = 24;
            label11.Text = "4";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(1144, 616);
            label12.Name = "label12";
            label12.Size = new Size(23, 25);
            label12.TabIndex = 25;
            label12.Text = "2";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(1250, 616);
            label13.Name = "label13";
            label13.Size = new Size(23, 25);
            label13.TabIndex = 26;
            label13.Text = "3";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(1346, 616);
            label14.Name = "label14";
            label14.Size = new Size(23, 25);
            label14.TabIndex = 27;
            label14.Text = "4";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(579, 122);
            label15.Name = "label15";
            label15.Size = new Size(306, 19);
            label15.TabIndex = 29;
            label15.Text = "Коэффициент детерминации (R^2)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(579, 147);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(244, 23);
            textBox3.TabIndex = 28;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(579, 173);
            label16.Name = "label16";
            label16.Size = new Size(107, 19);
            label16.TabIndex = 31;
            label16.Text = "Количество";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(579, 198);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(244, 23);
            textBox4.TabIndex = 30;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(579, 252);
            label17.Name = "label17";
            label17.Size = new Size(81, 19);
            label17.TabIndex = 33;
            label17.Text = "Accuracy";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(579, 277);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(244, 23);
            textBox5.TabIndex = 32;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(579, 307);
            label18.Name = "label18";
            label18.Size = new Size(83, 19);
            label18.TabIndex = 35;
            label18.Text = "Precision";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(579, 332);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(244, 23);
            textBox6.TabIndex = 34;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(579, 360);
            label19.Name = "label19";
            label19.Size = new Size(59, 19);
            label19.TabIndex = 37;
            label19.Text = "Recall";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(579, 385);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(244, 23);
            textBox7.TabIndex = 36;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox7.Location = new Point(18, 196);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(470, 23);
            checkBox7.TabIndex = 38;
            checkBox7.Text = "Использовать тренировочные данные для проверки";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.BackColor = Color.LightGreen;
            button5.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(12, 524);
            button5.Name = "button5";
            button5.Size = new Size(203, 65);
            button5.TabIndex = 39;
            button5.Text = "Рассчитать схожесть содержание";
            button5.UseVisualStyleBackColor = false;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.BackColor = Color.LightGreen;
            checkBox8.Location = new Point(221, 552);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(15, 14);
            checkBox8.TabIndex = 40;
            checkBox8.UseVisualStyleBackColor = false;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.LightGreen;
            label20.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(17, 634);
            label20.Name = "label20";
            label20.Size = new Size(195, 38);
            label20.TabIndex = 44;
            label20.Text = "Количество соседей\r\nдля предсказания k =";
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.LightGreen;
            numericUpDown2.Location = new Point(218, 649);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(49, 23);
            numericUpDown2.TabIndex = 43;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.BackColor = Color.LightGreen;
            checkBox9.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox9.Location = new Point(17, 601);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(485, 23);
            checkBox9.TabIndex = 42;
            checkBox9.Text = "Использовать нормализацию оценок (Mean centering)";
            checkBox9.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.LightGreen;
            button6.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(292, 630);
            button6.Name = "button6";
            button6.Size = new Size(290, 52);
            button6.TabIndex = 41;
            button6.Text = "Рассчитать содержание";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.LightCoral;
            button7.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(790, 784);
            button7.Name = "button7";
            button7.Size = new Size(290, 52);
            button7.TabIndex = 45;
            button7.Text = "Рассчитать Линейная регрессия";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.LightGoldenrodYellow;
            button8.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(292, 870);
            button8.Name = "button8";
            button8.Size = new Size(290, 52);
            button8.TabIndex = 46;
            button8.Text = "Рассчитать монолит";
            button8.UseVisualStyleBackColor = false;
            // 
            // textBox8
            // 
            textBox8.BackColor = Color.LightBlue;
            textBox8.Location = new Point(62, 808);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(55, 23);
            textBox8.TabIndex = 47;
            // 
            // textBox9
            // 
            textBox9.BackColor = Color.LightGreen;
            textBox9.Location = new Point(173, 808);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(55, 23);
            textBox9.TabIndex = 48;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.LightBlue;
            label21.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label21.Location = new Point(23, 812);
            label21.Name = "label21";
            label21.Size = new Size(33, 19);
            label21.TabIndex = 49;
            label21.Text = "w1";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.LightGreen;
            label22.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label22.Location = new Point(134, 812);
            label22.Name = "label22";
            label22.Size = new Size(33, 19);
            label22.TabIndex = 50;
            label22.Text = "w2";
            // 
            // button9
            // 
            button9.BackColor = Color.LemonChiffon;
            button9.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(285, 756);
            button9.Name = "button9";
            button9.Size = new Size(203, 65);
            button9.TabIndex = 51;
            button9.Text = "Рассчитать схожесть монолит";
            button9.UseVisualStyleBackColor = false;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Location = new Point(494, 784);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(15, 14);
            checkBox10.TabIndex = 52;
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.LemonChiffon;
            label23.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label23.Location = new Point(36, 874);
            label23.Name = "label23";
            label23.Size = new Size(195, 38);
            label23.TabIndex = 55;
            label23.Text = "Количество соседей\r\nдля предсказания k =";
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = Color.LemonChiffon;
            numericUpDown3.Location = new Point(237, 889);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(49, 23);
            numericUpDown3.TabIndex = 54;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.BackColor = Color.LemonChiffon;
            checkBox11.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox11.Location = new Point(36, 841);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(485, 23);
            checkBox11.TabIndex = 53;
            checkBox11.Text = "Использовать нормализацию оценок (Mean centering)";
            checkBox11.UseVisualStyleBackColor = false;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.LightGreen;
            label24.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label24.Location = new Point(1333, 836);
            label24.Name = "label24";
            label24.Size = new Size(57, 19);
            label24.TabIndex = 59;
            label24.Text = "w сод";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.LightBlue;
            label25.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label25.Location = new Point(1205, 836);
            label25.Name = "label25";
            label25.Size = new Size(58, 19);
            label25.TabIndex = 58;
            label25.Text = "w кол";
            // 
            // textBox10
            // 
            textBox10.BackColor = Color.LightGreen;
            textBox10.Location = new Point(1396, 836);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(55, 23);
            textBox10.TabIndex = 57;
            // 
            // textBox11
            // 
            textBox11.BackColor = Color.LightBlue;
            textBox11.Location = new Point(1269, 837);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(55, 23);
            textBox11.TabIndex = 56;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.BackColor = Color.LightCoral;
            label26.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label26.Location = new Point(1482, 837);
            label26.Name = "label26";
            label26.Size = new Size(58, 19);
            label26.TabIndex = 61;
            label26.Text = "w лин";
            // 
            // textBox12
            // 
            textBox12.BackColor = Color.LightCoral;
            textBox12.Location = new Point(1546, 836);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(55, 23);
            textBox12.TabIndex = 60;
            // 
            // button10
            // 
            button10.BackColor = Color.MediumSlateBlue;
            button10.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button10.Location = new Point(1256, 882);
            button10.Name = "button10";
            button10.Size = new Size(290, 52);
            button10.TabIndex = 62;
            button10.Text = "Рассчитать Ансамбль";
            button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            button11.BackColor = Color.LemonChiffon;
            button11.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button11.Location = new Point(20, 740);
            button11.Name = "button11";
            button11.Size = new Size(206, 62);
            button11.TabIndex = 63;
            button11.Text = "Рассчитать лучшие коэффициенты";
            button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            button12.BackColor = Color.MediumSlateBlue;
            button12.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button12.Location = new Point(1200, 761);
            button12.Name = "button12";
            button12.Size = new Size(401, 54);
            button12.TabIndex = 64;
            button12.Text = "Рассчитать лучшие коэффициенты";
            button12.UseVisualStyleBackColor = false;
            // 
            // textBox13
            // 
            textBox13.BackColor = Color.LightBlue;
            textBox13.Location = new Point(462, 356);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(87, 23);
            textBox13.TabIndex = 65;
            // 
            // textBox14
            // 
            textBox14.BackColor = Color.LightBlue;
            textBox14.Location = new Point(495, 463);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(87, 23);
            textBox14.TabIndex = 66;
            // 
            // textBox15
            // 
            textBox15.BackColor = Color.LightGreen;
            textBox15.Location = new Point(272, 552);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(87, 23);
            textBox15.TabIndex = 67;
            // 
            // textBox16
            // 
            textBox16.BackColor = Color.LightGreen;
            textBox16.Location = new Point(613, 659);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(87, 23);
            textBox16.TabIndex = 68;
            textBox16.TextChanged += textBox16_TextChanged;
            // 
            // textBox17
            // 
            textBox17.BackColor = Color.LightGoldenrodYellow;
            textBox17.Location = new Point(541, 787);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(87, 23);
            textBox17.TabIndex = 69;
            textBox17.TextChanged += textBox17_TextChanged;
            // 
            // textBox18
            // 
            textBox18.BackColor = Color.LightGoldenrodYellow;
            textBox18.Location = new Point(598, 899);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(87, 23);
            textBox18.TabIndex = 70;
            // 
            // textBox19
            // 
            textBox19.BackColor = Color.LightCoral;
            textBox19.Location = new Point(894, 870);
            textBox19.Name = "textBox19";
            textBox19.Size = new Size(87, 23);
            textBox19.TabIndex = 71;
            // 
            // textBox20
            // 
            textBox20.BackColor = Color.MediumSlateBlue;
            textBox20.Location = new Point(1595, 911);
            textBox20.Name = "textBox20";
            textBox20.Size = new Size(87, 23);
            textBox20.TabIndex = 72;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = Color.LightBlue;
            label27.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label27.Location = new Point(472, 334);
            label27.Name = "label27";
            label27.Size = new Size(61, 19);
            label27.TabIndex = 73;
            label27.Text = "время";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.BackColor = Color.LightBlue;
            label28.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label28.Location = new Point(504, 436);
            label28.Name = "label28";
            label28.Size = new Size(61, 19);
            label28.TabIndex = 74;
            label28.Text = "время";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = Color.LightGreen;
            label29.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label29.Location = new Point(285, 530);
            label29.Name = "label29";
            label29.Size = new Size(61, 19);
            label29.TabIndex = 75;
            label29.Text = "время";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = Color.LightGreen;
            label30.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label30.Location = new Point(624, 634);
            label30.Name = "label30";
            label30.Size = new Size(61, 19);
            label30.TabIndex = 76;
            label30.Text = "время";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.BackColor = Color.LightGoldenrodYellow;
            label31.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label31.Location = new Point(552, 765);
            label31.Name = "label31";
            label31.Size = new Size(61, 19);
            label31.TabIndex = 77;
            label31.Text = "время";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.BackColor = Color.LightGoldenrodYellow;
            label32.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label32.Location = new Point(611, 874);
            label32.Name = "label32";
            label32.Size = new Size(61, 19);
            label32.TabIndex = 78;
            label32.Text = "время";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.BackColor = Color.MediumSlateBlue;
            label33.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label33.Location = new Point(1599, 889);
            label33.Name = "label33";
            label33.Size = new Size(61, 19);
            label33.TabIndex = 79;
            label33.Text = "время";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.BackColor = Color.LightCoral;
            label34.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label34.Location = new Point(908, 848);
            label34.Name = "label34";
            label34.Size = new Size(61, 19);
            label34.TabIndex = 80;
            label34.Text = "время";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label35.Location = new Point(913, 252);
            label35.Name = "label35";
            label35.Size = new Size(199, 25);
            label35.TabIndex = 81;
            label35.Text = "Настоящий рейтинг";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label36.Location = new Point(1136, 659);
            label36.Name = "label36";
            label36.Size = new Size(241, 25);
            label36.TabIndex = 82;
            label36.Text = "Предсказанный рейтинг";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1756, 1061);
            Controls.Add(label36);
            Controls.Add(label35);
            Controls.Add(label34);
            Controls.Add(label33);
            Controls.Add(label32);
            Controls.Add(label31);
            Controls.Add(label30);
            Controls.Add(label29);
            Controls.Add(label28);
            Controls.Add(label27);
            Controls.Add(textBox20);
            Controls.Add(textBox19);
            Controls.Add(textBox18);
            Controls.Add(textBox17);
            Controls.Add(textBox16);
            Controls.Add(textBox15);
            Controls.Add(textBox14);
            Controls.Add(textBox13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(label26);
            Controls.Add(textBox12);
            Controls.Add(label24);
            Controls.Add(label25);
            Controls.Add(textBox10);
            Controls.Add(textBox11);
            Controls.Add(label23);
            Controls.Add(numericUpDown3);
            Controls.Add(checkBox11);
            Controls.Add(checkBox10);
            Controls.Add(button9);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(label20);
            Controls.Add(numericUpDown2);
            Controls.Add(checkBox9);
            Controls.Add(button6);
            Controls.Add(checkBox8);
            Controls.Add(button5);
            Controls.Add(checkBox7);
            Controls.Add(label19);
            Controls.Add(textBox7);
            Controls.Add(label18);
            Controls.Add(textBox6);
            Controls.Add(label17);
            Controls.Add(textBox5);
            Controls.Add(label16);
            Controls.Add(textBox4);
            Controls.Add(label15);
            Controls.Add(textBox3);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
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
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
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
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox textBox3;
        private Label label16;
        private TextBox textBox4;
        private Label label17;
        private TextBox textBox5;
        private Label label18;
        private TextBox textBox6;
        private Label label19;
        private TextBox textBox7;
        private CheckBox checkBox7;
        private Button button5;
        private CheckBox checkBox8;
        private Label label20;
        private NumericUpDown numericUpDown2;
        private CheckBox checkBox9;
        private Button button6;
        private Button button7;
        private Button button8;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label21;
        private Label label22;
        private Button button9;
        private CheckBox checkBox10;
        private Label label23;
        private NumericUpDown numericUpDown3;
        private CheckBox checkBox11;
        private Label label24;
        private Label label25;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label26;
        private TextBox textBox12;
        private Button button10;
        private Button button11;
        private Button button12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
    }
}