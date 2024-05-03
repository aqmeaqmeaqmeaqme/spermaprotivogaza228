namespace WinFormsApp2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            Справочники = new Button();
            Настройки = new Button();
            Отчеты = new Button();
            Помощь = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            Расходы = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(2, 182);
            button2.Name = "button2";
            button2.Size = new Size(153, 39);
            button2.TabIndex = 1;
            button2.Text = "Доходы";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(2, 227);
            button3.Name = "button3";
            button3.Size = new Size(153, 39);
            button3.TabIndex = 2;
            button3.Text = "Долги";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(2, 272);
            button4.Name = "button4";
            button4.Size = new Size(153, 39);
            button4.TabIndex = 3;
            button4.Text = "Пользователи";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 112);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Справочники
            // 
            Справочники.Location = new Point(2, 317);
            Справочники.Name = "Справочники";
            Справочники.Size = new Size(153, 39);
            Справочники.TabIndex = 5;
            Справочники.Text = "Справочники";
            Справочники.UseVisualStyleBackColor = true;
            Справочники.Click += button1_Click_1;
            // 
            // Настройки
            // 
            Настройки.Location = new Point(2, 362);
            Настройки.Name = "Настройки";
            Настройки.Size = new Size(153, 39);
            Настройки.TabIndex = 6;
            Настройки.Text = "Настройки";
            Настройки.UseVisualStyleBackColor = true;
            Настройки.Click += button5_Click;
            // 
            // Отчеты
            // 
            Отчеты.Location = new Point(2, 407);
            Отчеты.Name = "Отчеты";
            Отчеты.Size = new Size(153, 39);
            Отчеты.TabIndex = 7;
            Отчеты.Text = "Отчеты";
            Отчеты.UseVisualStyleBackColor = true;
            Отчеты.Click += Отчеты_Click;
            // 
            // Помощь
            // 
            Помощь.Location = new Point(2, 452);
            Помощь.Name = "Помощь";
            Помощь.Size = new Size(153, 39);
            Помощь.TabIndex = 8;
            Помощь.Text = "Помощь";
            Помощь.UseVisualStyleBackColor = true;
            Помощь.Click += Помощь_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(275, 37);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(672, 454);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 538);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 10;
            label1.Text = "Тип отчёта:";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(87, 535);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 573);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 12;
            label2.Text = "Интервал времени от:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(147, 570);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(40, 23);
            textBox2.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(193, 573);
            label3.Name = "label3";
            label3.Size = new Size(23, 15);
            label3.TabIndex = 14;
            label3.Text = "до:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(222, 570);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(40, 23);
            textBox3.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 538);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 16;
            label4.Text = "Пользователь:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(415, 535);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(93, 23);
            textBox4.TabIndex = 17;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(325, 567);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(25, 23);
            textBox5.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(356, 570);
            label5.Name = "label5";
            label5.Size = new Size(140, 15);
            label5.TabIndex = 19;
            label5.Text = "По всем пользователям";
            // 
            // Расходы
            // 
            Расходы.Location = new Point(2, 137);
            Расходы.Name = "Расходы";
            Расходы.Size = new Size(153, 39);
            Расходы.TabIndex = 0;
            Расходы.Text = "Расходы";
            Расходы.UseVisualStyleBackColor = true;
            Расходы.Click += button1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(551, 535);
            button1.Name = "button1";
            button1.Size = new Size(153, 39);
            button1.TabIndex = 20;
            button1.Text = "Построить";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1109, 693);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(Помощь);
            Controls.Add(Отчеты);
            Controls.Add(Настройки);
            Controls.Add(Справочники);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Расходы);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
        private Button Справочники;
        private Button Настройки;
        private Button Отчеты;
        private Button Помощь;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
        private Button Расходы;
        private Button button1;
    }
}
