using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Základní_Ovládací_prvky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score = 0;
        private void Form1_Click(object sender, EventArgs e)
        {
            //Form1.ActiveForm.BackColor= Color.Red;
            Random random = new Random();
            int x = random.Next(0, 1500);
            int y = random.Next(0, 800);
            //Form1.ActiveForm.Location = new Point(x, y);
            score++;
            label8.Text = "Skóre: " + score;
            label6.Text = "X: "+ Form1.ActiveForm.Location.X;
            label7.Text = "Y: " + Form1.ActiveForm.Location.Y;
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            Form1.ActiveForm.BackColor = Color.Green;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            Form1.ActiveForm.BackColor = Color.Blue;
            /*int x = Form1.ActiveForm.Location.X + 50;
            int y = Form1.ActiveForm.Location.Y + 50; //tohle dává okno na kompletně náhodné místo na monitoru
            Form1.ActiveForm.Location = new Point(x, y);*/ 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form Form1 = sender as Form1;
            label8.Text = "Skóre: " + score;
            label6.Text = "X: " + Form1.Location.X;
            label7.Text = "Y: " + Form1.Location.Y;
            label9.Text = "Start X: ";
            label10.Text = "Start Y: ";
        }
        int startX = 0;
        int startY = 0;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label9.Text = "startX: " + Convert.ToString(startX);
            label10.Text = "startY: " + Convert.ToString(startY);
            Graphics graphics = CreateGraphics();
            Pen pero = new Pen(Color.Blue);
            if (e.Button == MouseButtons.Left && startX == 0)
            {
                startX = e.X;
                startY = e.Y;
            }
            if (e.Button == MouseButtons.Left) {
                
                graphics.DrawLine(pero, startX, startY, e.X, e.Y);
                startX = e.X;
                startY = e.Y;
            }
            if (e.Button == MouseButtons.None)
            {
                startX = 0;
                startY = 0;
            }
            /*else if (e.Button == MouseButtons.Right) label11.Text = "Tlačítko: Pravé tlačítko";
            else if (e.Button == MouseButtons.Middle) label11.Text = "Tlačítko: Střední tlačítko";*/
            //else if (e.Button == MouseButtons.None) label11.Text = "Tlačítko: Žádné tlačítko";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tady udělat detekci barvy
        }
    }
}
