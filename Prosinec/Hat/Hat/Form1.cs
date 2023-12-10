using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
#pragma warning disable IDE0044
namespace Hat
{
    public partial class Form1 : Form
    {
        public Smer smer = new Smer();
        Dilek player;
        Dilek apple;
        Random random = new Random();
        List<Dilek> tail = new List<Dilek>();

        int tailLength = 1;
        public Form1()
        {
            InitializeComponent();
            apple = new Dilek(new Point(random.Next(0, 20), random.Next(0, 20)), Color.Red);
            player = new Dilek(new Point(random.Next(0, 20), random.Next(0, 20)), Color.Blue);
            tail.Add(new Dilek(new Point(random.Next(0, 20), random.Next(0, 20)), Color.LightBlue));
            Controls.Add(apple); Controls.Add(player); Controls.Add(tail[0]);
            smer = Smer.nikam;
        }
        void mainLoop()
        {
            for (int i = tail.Count-1; i > 0; i--)
            {
                try{ tail[i].Location = tail[i-1].Location; } catch { }
            }
            tail[0].Location = player.Location;
            switch (smer)
            {
                case Smer.vpravo:
                    player.Location = new Point(player.Location.X + 20, player.Location.Y);
                    break;
                case Smer.vlevo:
                    player.Location = new Point(player.Location.X - 20, player.Location.Y);
                    break;
                case Smer.dolu:
                    player.Location = new Point(player.Location.X, player.Location.Y+20);
                    break;
                case Smer.nahoru:
                    player.Location = new Point(player.Location.X, player.Location.Y-20);
                    break;
                default:
                    break;
            }

            if (player.Location == apple.Location)
            {
                tail.Add(new Dilek((player.Location), Color.LightBlue));
                Controls.Add(tail[tail.Count-1]);
                newApple:
                apple.Location = new Point(random.Next(0, 20)*20, random.Next(0, 20)*20);
                for (int i = 0; i < tail.Count; i++)
                {
                    if (apple.Location == tail[i].Location)
                    {
                        goto newApple;
                    }
                }
                player.Text = tail.Count.ToString();
                if (Convert.ToInt32(player.Text) > 9)
                {
                    player.Font = new Font("Consolas", 8);
                }
                if (Convert.ToInt32(player.Text) > 99)
                {
                    player.Font = new Font("Consolas", 7);
                }
                if (timer1.Interval > 50)
                {
                    timer1.Interval -= 20;
                    tail[0].Text = timer1.Interval.ToString();
                    tail[0].Font = new Font("Consolas", 7);
                }
            }
            for(int i = 0; i < tail.Count-1; i++)
            {
                if (player.Location == tail[i].Location)
                {
                    smer = Smer.nikam;
                    player.Location = tail[0].Location;
                    timer1.Stop();
                    MessageBox.Show("Prohrál jsi!");
                }
            }
            if (player.Location.X < 0 || player.Location.Y < 0 || player.Location.X >= 500 || player.Location.Y >= 500)
            {
                smer = Smer.nikam;
                player.Location = tail[0].Location;
                timer1.Stop();
                MessageBox.Show("Prohrál jsi!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mainLoop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    smer = Smer.nahoru;
                    break;
                case Keys.A:
                    smer = Smer.vlevo;
                    break;
                case Keys.D:
                    smer = Smer.vpravo;
                    break;
                case Keys.S:
                    smer = Smer.dolu;
                    break;
            }
        }
    }
}