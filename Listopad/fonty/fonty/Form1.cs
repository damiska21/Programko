using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fonty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fontString = "Arial";
        int fontSize = 12;
        FontStyle fontStyle = FontStyle.Regular;
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Blue;
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Green;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            fontSize = hScrollBar1.Value;
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
            label2.Location = new Point(371 - hScrollBar1.Value, 86 - hScrollBar1.Value);
            label1.Text = Convert.ToString(hScrollBar1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fontString = "Times New Roman";
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fontString = "Consolas";
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fontString = "Arial";
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                fontStyle = FontStyle.Regular;
            }
            else
            {
                checkshit();
            }
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {//můj způsob
                fontStyle ^= FontStyle.Bold;
            }
            else
            {
                checkshit();
            }
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                fontStyle ^= FontStyle.Underline;
            }
            else
            {
                checkshit();
            }
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }
        

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                fontStyle ^= FontStyle.Strikeout;
            }
            else
            {
                checkshit();
            }
            Font font = new Font(fontString, fontSize, fontStyle);
            label2.Font = font;
        }
        private void checkshit() //šmíd měl tohle nakopírovaný v těch elsech, tohle je trochu čistší
        {
            fontStyle = new FontStyle();
            //tyhle svislice používá šmíd, já našel ty stříšky
            if (checkBox1.Checked) { fontStyle = fontStyle |= FontStyle.Regular; }
            if (checkBox2.Checked) { fontStyle = fontStyle |= FontStyle.Bold; }
            if (checkBox3.Checked) { fontStyle = fontStyle |= FontStyle.Underline; }
            if (checkBox4.Checked) { fontStyle = fontStyle |= FontStyle.Strikeout; }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = true;
            fontDialog1.ShowEffects = true;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Font = fontDialog1.Font;
                label2.ForeColor = fontDialog1.Color;
            }
        }
    }
}
