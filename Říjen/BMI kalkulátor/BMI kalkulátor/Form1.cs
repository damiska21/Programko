using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_kalkulátor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //váha / výška na druhou
        private void button1_Click(object sender, EventArgs e)
        {
            double vyska = Convert.ToDouble(textBox1.Text)/100;
            double vaha = Convert.ToDouble(textBox2.Text);
            double bmi = vaha / (vyska * vyska);
            label4.Text = "Vaše BMI: " + Convert.ToString(bmi);

            Label label02 = new Label();
            label02.Text = "Vaše BMI: ";
            label02.Location = new Point(50, 50);

            if (bmi < 15)
            {
                label5.Text = "Velmi sevérní podváha";
                label02.Text = "Velmi sevérní podváha";
            }
            else if (bmi < 16)
            {
                label5.Text = "sevérní podváha";
                label02.Text = "Sevérní Podváha";
            }
            else if (bmi < 18.5)
            {
                label5.Text = "Podváha";
                label02.Text = "Podváha";
            }
            else if(bmi < 25)
            {
                label5.Text = "Normální BMI";
                label02.Text = "Normální BMI";
            }
            else
            {
                label5.Text = "Obezita";
                label02.Text = "Obezita";
            }

            Form form = new Form();
            form.Show();

            Label label01 = new Label();
            label01.Text = "Vaše BMI: " + bmi;
            label01.Location = new Point(10, 10);
            form.Controls.Add(label01);

            form.Controls.Add(label02);

        }
    }
}
