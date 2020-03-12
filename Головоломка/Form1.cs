using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

/* Папкин Игорь
 * Игра головоломка как у Евгения Шитова
 * Матрица кнопок 4 на 4
 * При нажатии кнопки, менется ее цвет на цвет номер 2, а также менются цвета кнопок с лева - с права от неё, и сверху - снизу от неё, 
 * при повторном нажатии все цвета меняются обратно таким же образом, собрать все поле одинакового цвета */

namespace StrangeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TableBuild();
        }

        static int rndMethod(Random rnd)
        {
            return rnd.Next(0, 2);
        }

        //Генерация таблицы кнопок, привязка к ним события button_Click
        private int cells;
        public void TableBuild()
        {
            var colors = new[] {Color.SteelBlue, Color.Coral, Color.White };
            Random rnd = new Random();

            cells = tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
            for (int i = 0; i < cells; i++)
            {
                tableLayoutPanel1.Controls.Add(new Button());
                tableLayoutPanel1.Controls[i].Dock = System.Windows.Forms.DockStyle.Fill;
                tableLayoutPanel1.Controls[i].BackColor = colors[rndMethod(rnd)];
                tableLayoutPanel1.Controls[i].Name = $"{i}";
                tableLayoutPanel1.Controls[i].Click += button_Click;
            }
        }

        private int buttonNum;
        private Button pushedButton;
        private bool win = true;

        private void button_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            buttonNum = Int32.Parse(pushedButton.Name);
            
            //Смена цвета целевой кнопки
            pushedButton.BackColor = pushedButton.BackColor == Color.Coral ? Color.SteelBlue : Color.Coral;

            //Вся логика игры - смена цветов кнопок.
            //Менются цвета кнопок с лева - с права от целевой кнопки, и сверху - снизу от неё, 
            //при повторном нажатии все цвета меняются обратно таким же образом.

            switch (buttonNum)
            {
                case 1:
                case 2:
                    tableLayoutPanel1.Controls[buttonNum + 1].BackColor = tableLayoutPanel1.Controls[buttonNum + 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 1].BackColor = tableLayoutPanel1.Controls[buttonNum - 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum + 4].BackColor = tableLayoutPanel1.Controls[buttonNum + 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 13:
                case 14:
                    tableLayoutPanel1.Controls[buttonNum + 1].BackColor = tableLayoutPanel1.Controls[buttonNum + 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 1].BackColor = tableLayoutPanel1.Controls[buttonNum - 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 4].BackColor = tableLayoutPanel1.Controls[buttonNum - 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 5:               
                case 6:                     
                case 9:    
                case 10:
                    tableLayoutPanel1.Controls[buttonNum + 1].BackColor = tableLayoutPanel1.Controls[buttonNum + 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 1].BackColor = tableLayoutPanel1.Controls[buttonNum - 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum + 4].BackColor = tableLayoutPanel1.Controls[buttonNum + 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 4].BackColor = tableLayoutPanel1.Controls[buttonNum - 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 7:
                case 11:
                    tableLayoutPanel1.Controls[buttonNum + 4].BackColor = tableLayoutPanel1.Controls[buttonNum + 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 4].BackColor = tableLayoutPanel1.Controls[buttonNum - 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 1].BackColor = tableLayoutPanel1.Controls[buttonNum - 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 8:
                case 4:
                    tableLayoutPanel1.Controls[buttonNum + 4].BackColor = tableLayoutPanel1.Controls[buttonNum + 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 4].BackColor = tableLayoutPanel1.Controls[buttonNum - 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum + 1].BackColor = tableLayoutPanel1.Controls[buttonNum + 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 0:
                    tableLayoutPanel1.Controls[buttonNum + 1].BackColor = tableLayoutPanel1.Controls[buttonNum + 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum + 4].BackColor = tableLayoutPanel1.Controls[buttonNum + 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 12:
                    tableLayoutPanel1.Controls[buttonNum + 1].BackColor = tableLayoutPanel1.Controls[buttonNum + 1].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 4].BackColor = tableLayoutPanel1.Controls[buttonNum - 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 3:
                    tableLayoutPanel1.Controls[buttonNum - 1].BackColor = tableLayoutPanel1.Controls[buttonNum - 1].BackColor
                       == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum + 4].BackColor = tableLayoutPanel1.Controls[buttonNum + 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
                case 15:
                    tableLayoutPanel1.Controls[buttonNum - 1].BackColor = tableLayoutPanel1.Controls[buttonNum - 1].BackColor
                       == Color.Coral ? Color.SteelBlue : Color.Coral;
                    tableLayoutPanel1.Controls[buttonNum - 4].BackColor = tableLayoutPanel1.Controls[buttonNum - 4].BackColor
                        == Color.Coral ? Color.SteelBlue : Color.Coral;
                    break;
            }

            //Проверка одинаковы ли все цвета у кнопок
            for(int i = 1; i < cells; i++)
            {
                if(tableLayoutPanel1.Controls[0].BackColor != tableLayoutPanel1.Controls[i].BackColor)
                {
                    win = false;
                    break;
                }
            }

            //Если цвета одинаковы
            if (win) MessageBox.Show("Ты побелитель братюня!");
        }
    }
}
