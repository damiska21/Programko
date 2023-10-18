using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace barvičky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //jestli je cokoliv nepochopitelného, napiš. Šmíd se s tim patlal tak zatraceně dlouho, že jsem začal flexit a redukovat kód na absolutní minimum a vypadá tak :D
            //TODO: zbavit se intů red, green, blue
        }
        int red = 0; //pracuji s intama namísto samotných sliderů jako Šmíd, je to trochu čistší
        int green = 0;
        int blue = 0;
        //když se pohne slider nastaví int na jeho hodnotu a spustí funkci na aktualizování barvy panelu
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            red = e.NewValue;
            set();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            green = e.NewValue;
            set();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            blue = e.NewValue;
            set();
        }
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                red = Convert.ToInt32(textBox1.Text);
            }catch { red = 0; }
            red = numCheck(red);//moje vlastní funkce, je zapsaná níže
            set();//taky moje vlastní funkce, nastavuje barvu toho panelu
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
            try { blue = Convert.ToInt32(textBox3.Text); }
            catch { blue = 0; }
            blue = numCheck(blue);
            set();
            hScrollBar3.Value = blue;
            
        }
        //kontroluje vložené číslo do text baru jestli je hodnota rgb, když není vrátí nejbližší správnou
        int numCheck(int num)
        {
            if (num > 255) {return 255;}
            /*hezčí if (kdyžtak mi o tomhle písni xd)
                   podmínka    true :  false*/
            return (num < 0) ?    0 :  num;
            //vrací zkontrolovanou a případně přepsanou hodnotu num (čísla, co jsme tam vložili)
        }
        //akorát nastavuje barvy panelu, nechtělo se mi to kopírovat tak je to funkce :D
        void set()
        {
            panel1.BackColor = Color.FromArgb(255, red, green, blue); 
            label1.Text = red.ToString(); label2.Text = green.ToString(); label3.Text = blue.ToString();//nastavuje texty za slidery na hodnoty čísel
            textBox1.Text = red.ToString(); textBox2.Text = green.ToString(); textBox3.Text = blue.ToString(); //nastavuje text v editovatelných text boxech
            hScrollBar1.Value = red; hScrollBar2.Value = green; hScrollBar3.Value = blue;
        }
        //speciální slider na šedou. hýbe se všemi třemi slidry najednou
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try //try catch proto, aby nespadl program po vložení písmenka
            {
                blue = Convert.ToInt32(textBox4.Text); blue = numCheck(blue);
                green = Convert.ToInt32(textBox4.Text);green = numCheck(green);
                red = Convert.ToInt32(textBox4.Text); red = numCheck(red);
            }
            catch { blue = 0; red = 0; green = 0; } //pokud se tak stane, je to černá
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            /*red = ((Bitmap)pictureBox1.Image).GetPixel(e.X, e.Y).R; green = ((Bitmap)pictureBox1.Image).GetPixel(e.X, e.Y).G; blue = ((Bitmap)pictureBox1.Image).GetPixel(e.X, e.Y).B;
            set();*/
            label5.Text = "X: " + e.X + " Y: " + e.Y;
        }

        int startX = 0;
        int startY = 0;
        int bb = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            if (bb == 0)
            {
                Bitmap b = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = b;
                bb++;
            }
            Pen pero = new Pen(Color.FromArgb(255, red, green, blue));
            if (e.Button == MouseButtons.Left && startX == 0)
            {
                startX = e.X;
                startY = e.Y;
            }
            if (e.Button == MouseButtons.Left)
            {
                //graphics.DrawLine(pero, startX, startY, e.X, e.Y);
                using (var graphics = Graphics.FromImage(b))
                {
                    graphics.DrawLine(pero, startX, startY, e.X, e.Y);
                }
                startX = e.X;
                startY = e.Y;
            }
            if (e.Button == MouseButtons.None)
            {
                startX = 0;
                startY = 0;
            }
        }
    }
}
