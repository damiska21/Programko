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

        int time = 0;
        int seconds = 0;
        int minutes = 0;
        int hours = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            time += 47;//zvyšuje milisekundy o 47 protože tak často se spouští tahle funkce
            if (time >=1000){seconds++;time -= 1000; }//zvyšuje sekundy
            if (seconds >= 60) { minutes++; seconds -= 60;}
            if (minutes >= 60) { minutes -= 60; hours++; }
            //ten dolar dělá to že můžu do {} zapisovat konstanty a počítají se jako string
            label1.Text = $"{hours}:{minutes}:{seconds}:{time}"; //nastavuje label
        }
        //reset časovače
        private void button3_Click(object sender, EventArgs e)
        {
            time = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
            label1.Text = $"{hours}:{minutes}:{seconds}:{time}";//aby se na stisknutí změnili čísla na 0
        }
        //spouštění a vypínaní časovače
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer2.Enabled)
            {
                //když není zaplý tak ho zapne a přepne nápis tlačítka na Zastavit
                timer2.Enabled = true;
                button1.Text = "Zastavit";
            }
            else
            {
                timer2.Enabled = false;
                button1.Text = "Spustit";
            }
        }
    }
}