using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private Thread th;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(open);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void open(object obj)
        {
            Application.Run(new Form1());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Вызываем метод для заполнения ComboBox при загрузке формы
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            // Очищаем список элементов в ComboBox
            comboBox1.Items.Clear();

            // Добавляем элементы в ComboBox
            comboBox1.Items.Add("Пользователь 1");
            comboBox1.Items.Add("Пользователь 2");
            comboBox1.Items.Add("Пользователь 3");

            // Устанавливаем выбранный элемент (если нужно)
            // comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // кнопка тре
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Дополнительный код для обработки изменения выбранного элемента в ComboBox
        }
    }
}
