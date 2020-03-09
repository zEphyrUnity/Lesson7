using System;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        private static int textForm2 = 0;
        private static Random rnd = new Random();
        private static int randomNum;
        private static int count = 0;

        public Form1()
        {
            InitializeComponent();

            randomNum = rnd.Next(1, 100);

            ToolStripMenuItem gameMenu = new ToolStripMenuItem("Меню");

            gameMenu.DropDownItems.Add("Играть");
            gameMenu.DropDownItems[0].Click += new System.EventHandler(this.menu_Click);

            menuStrip1.Items.Add(gameMenu);
        }

        public static void button1_Click(object sender, EventArgs e)
        {
            label3.Text = $"{++count}";

            try
            {
                textForm2 = Int32.Parse(Form2.textBoxValue);

                if (textForm2 < 0 || textForm2 > 100)
                {
                    throw new System.FormatException();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите число от 1 до 100");
            }

            if(textForm2 == randomNum)
            {
                MessageBox.Show("Бинго! Да ты прирожденный провидец");
                labelPredict.Text = "Угадай";
                randomNum = rnd.Next(1, 100);
                count = 0;
            }
            else if(textForm2 > randomNum)
            {
                labelPredict.Text = "Больше";
            }
            else if(textForm2 < randomNum)
            {
                labelPredict.Text = "Меньше";
            }

            Form2.textBox2.Clear();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Угадайте число от 1 до 100 {randomNum}");   
        }
    }
}
