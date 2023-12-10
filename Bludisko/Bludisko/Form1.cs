using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bludisko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] pole = new int[20, 20];
        bool endPlaced = false;
        #region barvičky
        Color[] color = new Color[]{Color.Bisque, Color.Black, Color.AliceBlue, Color.Blue,
			Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse,
			Color.Chocolate, Color.Coral, Color.Cornsilk, Color.Crimson, Color.Cyan, Color.DarkBlue,
			Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen, Color.DarkKhaki,
			Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange, Color.DarkOrchid, Color.DarkRed,
			Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray,	Color.DarkTurquoise,
			Color.DarkViolet, Color.DeepPink, Color.DeepSkyBlue, Color.DimGray, Color.DodgerBlue,
			Color.Firebrick, Color.FloralWhite, Color.ForestGreen, Color.Fuchsia, Color.Gainsboro,
			Color.GhostWhite, Color.Gold, Color.Goldenrod, Color.Gray, Color.Green, Color.GreenYellow,
			Color.Honeydew, Color.HotPink, Color.IndianRed, Color.Indigo, Color.Ivory, Color.Khaki,
			Color.Lavender, Color.LavenderBlush, Color.LawnGreen, Color.LemonChiffon, Color.LightBlue,
			Color.LightCoral, Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen,
			Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray,
			Color.LightSteelBlue, Color.LightYellow, Color.Lime, Color.LimeGreen, Color.Linen, Color.Magenta,
			Color.Maroon, Color.MediumAquamarine, Color.MediumBlue, Color.MediumOrchid, Color.MediumPurple,
			Color.MediumSeaGreen, Color.MediumSlateBlue, Color.MediumSpringGreen, Color.MediumTurquoise,
			Color.MediumVioletRed, Color.MidnightBlue, Color.MintCream, Color.MistyRose, Color.Moccasin,
			Color.NavajoWhite, Color.Navy, Color.OldLace, Color.Olive, Color.OliveDrab, Color.Orange,
			Color.OrangeRed, Color.Orchid, Color.PaleGoldenrod, Color.PaleGreen, Color.PaleTurquoise,
			Color.PaleVioletRed, Color.PapayaWhip, Color.PeachPuff, Color.Peru, Color.Pink, Color.Plum,
			Color.PowderBlue, Color.Purple, Color.Red, Color.RosyBrown, Color.RoyalBlue, Color.SaddleBrown,
			Color.Salmon, Color.SandyBrown, Color.SeaGreen, Color.SeaShell, Color.Sienna, Color.Silver,
			Color.SlateBlue, Color.SlateGray, Color.Snow, Color.SpringGreen, Color.SteelBlue, Color.Tan,
			Color.Teal, Color.Thistle, Color.Tomato, Color.Transparent, Color.Turquoise, Color.Violet,
			Color.Wheat, Color.WhiteSmoke, Color.Yellow, Color.YellowGreen };
        #endregion
        private void Start_label_MouseDown(object sender, MouseEventArgs e) { DoDragDrop(-2, DragDropEffects.Copy); }
        private void End_label_MouseDown(object sender, MouseEventArgs e) { DoDragDrop(-3, DragDropEffects.Copy); }

        int activeX = 0;
        int activeY = 0;
        public bool vlnaGenerated = false;
        private int nig(int endOn, bool exitOnEnd)
        {
            vlnaGenerated = true;
            #region první bod okolo
            try
            {
                if (pole[activeX - 1, activeY] == 0)
                {
                    pole[activeX - 1, activeY] = 1;
                }
            }
            catch { }
            try
            {
                if (pole[activeX + 1, activeY] == 0)
                {
                    pole[activeX + 1, activeY] = 1;
                }
            }
            catch { }
            try
            {
                if (pole[activeX, activeY - 1] == 0)
                {
                    pole[activeX, activeY - 1] = 1;
                }
            }
            catch { }
            try
            {
                if (pole[activeX, activeY + 1] == 0)
                {
                    pole[activeX, activeY + 1] = 1;
                }
            }
            catch { }
            #endregion
            int index = 1;
            while (true)
            {
                bool added = false;
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (pole[i, j] == index)
                        {
                            switch (checkniOkolo(i, j))
                            {
                                case 0:
                                    added = true;
                                    break;
                                case 2:
                                    if (exitOnEnd)
                                    {
                                        return index;
                                    }
                                    break;
                            }
                        }
                    }
                }
                index++;
                if ((!added || index == endOn) && exitOnEnd && endPlaced) {return -1;}
                if (!added || index == endOn) {return index;}
            }
        }
        private void Vlna_button_Click(object sender, EventArgs e)
        {
            if (vlnaGenerated)
            {
                poleClear();
            }
            nig(0, true);
            grid1.Refresh();
        }
        int checkniOkolo(int x, int y)
        {
            int truec = 1;
            try
            {
                if (pole[x + 1, y] == 0)
                {
                    pole[x + 1, y] = pole[x, y] + 1;
                    truec = 0;
                }
                else if (pole[x + 1, y] == -3)
                {
                    return 2;
                }
            }
            catch { }
            try
            {
                if (pole[x - 1, y] == 0)
                {
                    pole[x - 1, y] = pole[x, y] + 1;
                    truec = 0;
                }
                else if (pole[x - 1, y] == - 3)
                {
                    return 2;
                }

            }
            catch { }
            try
            {
                if (pole[x, y + 1] == 0)
                {
                    pole[x, y + 1] = pole[x, y] + 1;
                    truec = 0;
                }
                else if (pole[x, y + 1] == -3)
                {
                    return 2;
                }
            }
            catch { }
            try
            {
                if (pole[x, y - 1] == 0)
                {
                    pole[x, y - 1] = pole[x, y] + 1;
                    return 0;
                }else if (pole[x, y - 1] == -3)
                {
                    return 2;
                }
            }
            catch { }
            return truec;
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            pole = new int[20, 20];
            cesta = new int[20, 20];
            grid1.Refresh();
        }
        private void grid1_Paint(object sender, PaintEventArgs e)
        {
            endPlaced = false;
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    try
                    {
                        if (cesta[i, j] == 1)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(i * 21, j * 21, 21, 21));
                        }
                    }
                    catch { }
                    if (pole[i, j] == -1)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(i * 21, j * 21, 21, 21));
                    }
                    else if (pole[i, j] == -2)
                    {
                        e.Graphics.DrawString("Z", new Font("Arial", 16), new SolidBrush(Color.Green), i * 21, j * 21, new StringFormat());
                        activeX = i;
                        activeY = j;
                    }
                    else if (pole[i, j] == -3)
                    {
                        e.Graphics.DrawString("K", new Font("Arial", 16), new SolidBrush(Color.Red), i * 21, j * 21, new StringFormat());
                        konecX = i; konecY = j; endPlaced = true;
                    }
                    else if (pole[i, j] > 0)
                    {
                        try
                        {
                            e.Graphics.DrawString(Convert.ToString(pole[i, j]), new Font("Arial", 10), new SolidBrush(color[pole[i, j]]), i * 21, j * 21, new StringFormat());
                        }catch
                        {
                            e.Graphics.DrawString(Convert.ToString(pole[i, j]), new Font("Arial", 10), new SolidBrush(color[pole[i, j]-(pole[i, j]%131)*131]), i * 21, j * 21, new StringFormat());
                        }
                    }
                }
            }
        }

        private void grid1_DragDrop(object sender, DragEventArgs e)
        {
            pole[grid1.PointToClient(Cursor.Position).X / 21, grid1.PointToClient(Cursor.Position).Y / 21] = (int)e.Data.GetData(typeof(int));
            grid1.Refresh();
        }

        private void grid1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        //tohle by šlo hodně optimalizovat
        private void grid1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    int poleV = pole[e.X / 21, e.Y / 21];
                    if (poleV != -2 || poleV != -3)
                    {
                        if (pole[e.X / 21, e.Y / 21] != -1)
                        {
                            pole[e.X / 21, e.Y / 21] = -1;
                        }
                    }
                }
                catch { }
            }else if(e.Button == MouseButtons.Right)
            {
                try
                {
                    int poleV = pole[e.X / 21, e.Y / 21];
                    if (poleV != -2 || poleV != -3)
                    {
                        pole[e.X / 21, e.Y / 21] = 0;
                    }
                }
                catch { }
            }
            
        }
        private void grid1_MouseUp(object sender, MouseEventArgs e)
        {
            grid1.Refresh();
        }

        private void Cesta_button_Click(object sender, EventArgs e)
        {
            if (!vlnaGenerated) { nig(0, true); }
            cestaZpet(konecX, konecY);
            grid1.Refresh();
        }
        void cestaZpet(int startX, int startY)
        {
            int index = 1000;
            int activeCX = startX;
            int activeCY = startY;
            #region sem nekoukej :D
            try
            {
                if (pole[activeCX - 1, activeCY] < index && pole[activeCX - 1, activeCY] > 0)
                {
                    index = pole[activeCX - 1, activeCY];
                }
            }
            catch { }
            try { 
                if (pole[activeCX + 1, activeCY] < index && pole[activeCX + 1, activeCY] >0)
                {
                    index = pole[activeCX + 1, activeCY];
                }
            }
            catch { }
            try { 
            if (pole[activeCX, activeCY-1] < index && pole[activeCX, activeCY - 1] >0)
                {
                    index = pole[activeCX, activeCY - 1];
                }
            }
            catch { }
            try {
                if (pole[activeCX, activeCY + 1] < index && pole[activeCX, activeCY + 1] >0)
                {
                    index = pole[activeCX, activeCY + 1];
                }
            }
            catch { }
            

            try
            {
                if (pole[activeCX - 1, activeCY] == index)
                {
                    cesta[activeCX - 1, activeCY] = 1; activeCX--;goto Con;
                }
            }
            catch { }
            try { 
                if (pole[activeCX + 1, activeCY] == index)
                {
                    cesta[activeCX + 1, activeCY] = 1; activeCX++; goto Con;
                }
            }
            catch { }
            try { 
                if (pole[activeCX, activeCY - 1] == index)
                {
                    cesta[activeCX, activeCY - 1] = 1; activeCY--; goto Con;
                }
            }
            catch { }
            try { 
                if (pole[activeCX, activeCY + 1] == index)
                {
                    cesta[activeCX, activeCY + 1] = 1; activeCY++;
                }
            }
            catch { }
            Con:
            #endregion
            for (int i = index; i > 0; i--)
            {
                Point nega = kdeDalsiCesta(activeCX, activeCY);
                cesta[activeCX, activeCY] = 1;
                activeCX = nega.X;
                activeCY = nega.Y;
            }
        }
        int[,] cesta = new int[20, 20];
        Point kdeDalsiCesta(int x, int y)
        {
            try
            {
                if (pole[x, y] - 1 == pole[x + 1, y])
                {
                    return new Point(x + 1, y);
                }
            }
            catch { }
            try
            {
                if (pole[x, y] - 1 == pole[x - 1, y])
                {
                    return new Point(x - 1, y);
                }
            }
            catch { }
            try
            {
                if (pole[x, y] - 1 == pole[x, y + 1])
                {
                    return new Point(x, y + 1);
                }
            }
            catch { }
            try
            {
                if (pole[x, y] - 1 == pole[x, y - 1])
                {
                    return new Point(x, y - 1);
                }
            }
            catch { }
            return new Point(x, y);
        }
        int konecX; int konecY;
        private void grid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    int poleV = pole[e.X / 21, e.Y / 21];
                    if (poleV != -2 || poleV != -3)
                    {
                        if (pole[e.X / 21, e.Y / 21] != -1)
                        {
                            pole[e.X / 21, e.Y / 21] = -1;
                        }
                    }
                }
                catch { }
            }
            else if (e.Button == MouseButtons.Right)
            {
                try
                {
                    int poleV = pole[e.X / 21, e.Y / 21];
                    if (poleV != -2 || poleV != -3)
                    {
                        pole[e.X / 21, e.Y / 21] = 0;
                    }
                }
                catch { }
            }
        }
        private void generate_Click(object sender, EventArgs e)
        {
            Restart:
            pole = new int[20, 20];
            cesta = new int[20, 20];

               bool generatedStart = false;
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++) {
                    int random = r.Next(0, 100);
                    if (random < 5 && !generatedStart)
                    {
                        pole[i, j] = -2;
                        generatedStart = true;
                    }else if (random < 35)
                    {
                        pole[i, j] = -1;
                    }
                }
            }
            int nigga = nig(0, false);
            MessageBox.Show(nigga.ToString());
            if (nigga < 8)
            {
                goto Restart;
            }
            bool endGenerated = false;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (pole[i, j] > nigga-2 && !endGenerated)
                    {
                        pole[i, j] = -3;endGenerated = true;
                    }
                    if (pole[i, j] >0)
                    {
                        pole[i, j] = 0;
                    }
                }
            }
            cesta = new int[20, 20];
            vlnaGenerated = false;
            grid1.Refresh();
        }
        Random r = new Random();
        void poleClear()
        {
            vlnaGenerated = false;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (pole[i, j] > 0)
                    {
                        pole[i, j] = 0;
                    }
                }
            }
        }

        /*private void import_Click(object sender, EventArgs e)
        {
            int[,] import = new int[20, 20];
            string box = richTextBox1.Text;
            string[] bb = box.Split(';');


            for (int i = 0;i<bb.Length-1;i++)
            {
                string[] ee = bb[i].Split(',');

                for (int j = 0;j<ee.Length;j++)
                {
                    import[i, j] = Convert.ToInt32(ee[j]);
                }
            }
            pole = import;
        }

        private void export_Click(object sender, EventArgs e)
        {
            string export = "";

            for (int i = 0;i < 20; i++)
            {
                for(int j = 0;j < 20; j++)
                {
                    if (j != 19)
                    {
                        export += pole[j, i].ToString() + ",";
                    }
                    else
                    {

                        export += pole[j, i].ToString();
                    }
                }
                export += ";";
            }
            richTextBox1.Text = export;
        }*/
    }
}
