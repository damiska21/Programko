using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barvičky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int red = 0;
        int green = 0;
        int blue = 0;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            red = e.NewValue;
            set();
            textBox1.Text = red.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            green = e.NewValue;
            set();
            textBox2.Text = green.ToString();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            blue = e.NewValue;
            set();
            textBox3.Text = blue.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                red = Convert.ToInt32(textBox1.Text);
            }catch { red = 0; }
            red = numCheck(red);
            set();
            hScrollBar1.Value = red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                green = Convert.ToInt32(textBox2.Text);
            }
            catch { green = 0; }
            green = numCheck(green);
            set();
            hScrollBar2.Value = green;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                blue = Convert.ToInt32(textBox3.Text);
            }
            catch { blue = 0; }
            blue = numCheck(blue);
            set();
            hScrollBar3.Value = blue;
            
        }
        int numCheck(int num)
        {
            if (num > 255)
            {
                num = 255;
            }
            else if (num < 0)
            {
                num = 0;
            }
            return num;
        }
        void set()
        {
            panel1.BackColor = Color.FromArgb(255, red, green, blue);
            label1.Text = red.ToString(); label2.Text = green.ToString(); label3.Text = blue.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                blue = Convert.ToInt32(textBox4.Text); blue = numCheck(blue);
                green = Convert.ToInt32(textBox4.Text);green = numCheck(green);
                red = Convert.ToInt32(textBox4.Text); red = numCheck(red);
            }
            catch { blue = 0; red = 0; green = 0; }
            set();
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            blue = e.NewValue; blue = numCheck(blue);
            green = e.NewValue; green = numCheck(green);
            red = e.NewValue; red = numCheck(red);
            set();
            label4.Text = Convert.ToString(e.NewValue);
        }
        private Color GetColorAt(Point point)
        {
            return ((Bitmap)pictureBox1.Image).GetPixel(point.X, point.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap harambe = new Bitmap(pictureBox1.Image);
            Color pixelColor;
            pixelColor = GetColorAt(e.Location);
            label5.Text = "X: " + e.X + " Y: " + e.Y;
            red = pixelColor.R;
            green = pixelColor.G;
            blue = pixelColor.B;
            set();
            hScrollBar1.Value = red;
            hScrollBar2.Value = green;
            hScrollBar3.Value = blue;
            textBox1.Text = red.ToString();
            textBox2.Text = green.ToString();
            textBox3.Text = blue.ToString();
        }
        //getPixel
    }
}
