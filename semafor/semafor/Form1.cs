using System;
using System.Drawing;
using System.Windows.Forms;

namespace semafor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reset();//aby se spuštěním aplikace byly všechny panely černé
        }
        //po každém ticku se číslo zvyšuje až do 5
        public int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //pokud je k danému číslu přiřazená změna
            switch (count)
            {
                case 0: //když je číslo 0 tak se první panel nastaví na červenou
                    reset();//všechny černé
                    panel1.BackColor = Color.Red;//červená
                    break;
                case 1:
                    panel2.BackColor = Color.Orange; 
                    break;
                case 2:
                    reset();
                    panel3.BackColor = Color.Green;
                    break;
                case 4:
                    reset();
                    panel2.BackColor = Color.Orange; 
                    break;
                case 5:
                    reset();
                    panel1.BackColor = Color.Red;
                    count = 0;//nastavuju číslo na 0 aby byly dva ticky červené
                    break;
            }
            count++;
        }
        //funkce na nastavení všech tří panelů na černou
        void reset()
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
        }
    }
}