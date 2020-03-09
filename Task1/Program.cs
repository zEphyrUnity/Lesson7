using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {
        struct Data
        {
            public int currentValue;
            public int progress;
        }

        private Button btnCommand2;
        private Button btnReset;
        private Label lblNumber;
        private Label lblCounter;
        private Button btnCommand1;
        private MenuStrip menuStrip1;
        private Button btnRollBack;

        public Form1()
        {
            InitializeComponent();

            ToolStripMenuItem menuItem = new ToolStripMenuItem("Меню");

            menuItem.DropDownItems.Add("Играть");
            menuItem.DropDownItems[0].Click += new System.EventHandler(this.menu_Click_1);

            menuStrip1.Items.Add(menuItem);

            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            this.Text = "Удвоитель";
        }

        private void InitializeComponent()
        {
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnRollBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(181, 46);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(75, 23);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click_1);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(181, 75);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(75, 23);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(181, 133);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(46, 55);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(13, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "0";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(49, 114);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(13, 13);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnRollBack
            // 
            this.btnRollBack.Location = new System.Drawing.Point(181, 162);
            this.btnRollBack.Name = "btnRollBack";
            this.btnRollBack.Size = new System.Drawing.Size(75, 23);
            this.btnRollBack.TabIndex = 6;
            this.btnRollBack.Text = "Ход назад";
            this.btnRollBack.UseVisualStyleBackColor = true;
            this.btnRollBack.Click += new System.EventHandler(this.btnRollBack_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRollBack);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    
    static void Main()
        {
            Form1 form = new Form1();
            Application.Run(form);
        }

        private int counter = 0;
        private int score = 0;
        private Stack<Data> playerData = new Stack<Data>();

        private void btnCommand1_Click_1(object sender, EventArgs e)
        {
            counter++;
            score++;
            playerData.Push(new Data { currentValue = score,  progress = counter});

            var data = playerData.Peek();

            lblNumber.Text = (data.currentValue).ToString();
            lblCounter.Text = (data.progress).ToString();
        }

        private void btnCommand2_Click_1(object sender, EventArgs e)
        {
            counter++;
            score *= 2;
            playerData.Push(new Data { currentValue = score, progress = counter });

            var data = playerData.Peek();

            lblNumber.Text = (data.currentValue).ToString();
            lblCounter.Text = (data.progress).ToString();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            counter = 0;
            score = 0;

            playerData.Clear();
            playerData.Push(new Data { currentValue = score, progress = counter });

            var data = playerData.Peek();

            lblNumber.Text = (data.currentValue).ToString();
            lblCounter.Text = (data.progress).ToString();
        }

        private void btnRollBack_Click(object sender, EventArgs e)
        {
            try
            {
                playerData.Pop();

                var data = playerData.Peek();

                counter = data.progress;
                score = data.currentValue;

                lblNumber.Text = (data.currentValue).ToString();
                lblCounter.Text = (data.progress).ToString();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Окончен бал, погасли свечи");

                counter = 0;
                score = 0;

                lblNumber.Text = "0";
                lblCounter.Text = "0";
            }
        }

        private void menu_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("128.000 тысяч вы должны получить за минимальное число ходов");

            counter = 0;
            score = 0;

            playerData.Clear();
            playerData.Push(new Data { currentValue = score, progress = counter });

            var data = playerData.Peek();

            lblNumber.Text = (data.currentValue).ToString();
            lblCounter.Text = (data.progress).ToString();
        }
    }
}
