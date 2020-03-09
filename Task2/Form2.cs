using System;
using System.Windows.Forms;
using System.Drawing;

namespace Task2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            var p = new Point(15, 15); 
        }

        public static string textBoxValue
        {
            get => textBox2.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.button1_Click(sender, e);
        }
    }
}
