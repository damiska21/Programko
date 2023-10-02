using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulačka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string checkedSign = "+";
        public double firstNum = 0;
        public double secondNum = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkedSign = "+";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkedSign = "-";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkedSign = "/";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkedSign = "*";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { firstNum = Convert.ToInt32(textBox1.Text.Trim()); } catch { firstNum = 0; }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { secondNum = Convert.ToInt32(textBox2.Text.Trim()); } catch { secondNum = 0; }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(checkedSign)
            {
                case "+":
                    label3.Text = "Výsledek: " + Convert.ToString(firstNum + secondNum);
                    break; 
                case "-":
                    label3.Text = "Výsledek: " + Convert.ToString(firstNum - secondNum);
                    break;
                case "/":
                    if (secondNum == 0)
                    {
                        label3.Text = "Výsledek: Nulou se dělit nedá!";return;
                    }
                    label3.Text = "Výsledek: " + Convert.ToString(firstNum / secondNum);
                    break;
                case "*":
                    label3.Text = "Výsledek: " + Convert.ToString(firstNum * secondNum);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox3.Text);
            int[] bincisla = new int[num];
            int[] zbytky = new int[num + 1]; zbytky[0] = num;
            int breakNum = 0;
            listBox1.Items.Clear();
            for (int i = 0; i < num; i++)
            {
                bincisla[i] = zbytky[i] % 2;
                listBox1.Items.Add(bincisla[i]);
                zbytky[i + 1] = zbytky[i] / 2;
                if (zbytky[i] == 1)
                {
                    breakNum = i+1;
                    continue;
                }

            }
            string bincislareturn = "";
            for (int i = 0; i < breakNum; i++)
            {
                bincislareturn += Convert.ToString(bincisla[i]);
            }
            label6.Text = Reverse(bincislareturn);
        }
        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
