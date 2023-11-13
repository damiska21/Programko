using System.Drawing;
using System.Windows.Forms;

namespace piškvory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            pole[e.Y / 21, e.X / 21] = (hrajeX) ? "X" : "O";
            hrajeX = !hrajeX;
            label1.Text = (hrajeX) ? "Hraje X" : "Hraje O";
            check = checkni(e.Y / 21, e.X / 21);
            grid1.Refresh();
        }
        string[,] pole = new string[20, 20];
        bool hrajeX = true;
        int[] check = new int[4];
        private void grid1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    if (pole[i, j] == "X")
                    {
                        e.Graphics.DrawLine(new Pen(Color.Blue), j * 21, i * 21, (j + 1) * 21, (i + 1) * 21);
                        e.Graphics.DrawLine(new Pen(Color.Blue), (j + 1) * 21,i * 21, j * 21, (i + 1) * 21);
                    }else if (pole[i, j] == "O") {
                        e.Graphics.DrawEllipse(new Pen(Color.Red), new Rectangle(j * 21, i * 21, 21, 21));
                    }
                }
            }
            
            if (check[0] != -10)
            {
                e.Graphics.DrawLine(new Pen(Color.Blue, 4), check[1] * 21+10, check[0] * 21+10, ((check[3] + 1) * 21)-10, ((check[2] + 1) * 21)-10);
            }
        }
        int[] checkni(int i/*<-Y  X->*/, int j)
        {
            int count = 0;
                        //nahoru a dolu
                        int winX2 = (i); int winY2 = (j);
                        for (int k = 0; k < 5;k++)
                        {
                try
                {
                    if (pole[i - k, j] == pole[i, j])
                    {
                        count++; winX2 = (i - k); winY2 = (j);
                    }
                    else { break; }
                }
                catch { }
                        }
                        int winX1 = (i); int winY1 = (j);
                        for (int l = 0; l < 5; l++)
                        {
                try
                {
                    if (pole[i + l, j] == pole[i, j])
                    {
                        count++; winX1 = (i + l); winY1 = (j);
                    }
                    else { break; }
                } catch { }
                        }
                        if (count > 5) { MessageBox.Show(pole[i, j] + " vyhrál!"); int[] ret1 = new int[4]{ winX1, winY1, winX2, winY2 }; return ret1; }
                        count = 0;

                        //ze strany do strany
                        winX2 = (i); winY2 = (j);
                        for (int k = 0; k < 5; k++)
                        {
                try
                {
                    if (pole[i, j - k] == pole[i, j])
                    {
                        count++; winX2 = (i); winY2 = (j - k);
                    }
                    else { break; }
                }
                catch { }
                        }
                        winX1 = (i); winY1 = (j);
                        for (int l = 0; l < 5; l++)
                        {
                try
                {
                    if (pole[i, j + l] == pole[i, j])
                    {
                        count++; winX1 = (i); winY1 = (j + l);
                    }
                    else { break; }
                }
                catch { }
                        }
                        if (count > 5) { MessageBox.Show(pole[i, j] + " vyhrál!"); int[] ret2 = new int[4] { winX1, winY1, winX2, winY2 }; return ret2; }
                        count = 0;

                        //vertikál zleva nahoře vpravo dole
                        winX2 = (i); winY2 = (j);
                        for (int k = 0; k < 5; k++)
                        {
                try
                {
                    if (pole[i - k, j - k] == pole[i, j])
                    {
                        count++; winX2 = (i - k); winY2 = (j - k);
                    }
                    else { break; }
                }
                catch { }
            }
                        winX1 = (i); winY1 = (j);
                        for (int l = 0; l < 5; l++)
                        {
                try
                {
                    if (pole[i + l, j + l] == pole[i, j])
                    {
                        count++; winX1 = (i + l); winY1 = (j + l);
                    }
                    else { break; }
                }
                catch { }
            }
                        if (count > 5) { MessageBox.Show(pole[i, j] + " vyhrál!"); int[] ret3 = new int[4] { winX1, winY1, winX2, winY2 }; return ret3; } count = 0;

                        //vertikál zprava nahoře vlevo dole
                        winX2 = (i); winY2 = (j);
                        for (int k = 0; k < 5; k++)
                        {
                try
                {
                    if (pole[i + k, j - k] == pole[i, j])
                    {
                        count++; winX2 = (i + k); winY2 = (j - k);
                    }
                    else { break; }
                }
                catch { }
            }
                        winX1 = (i) - 1; winY1 = (j);
                        for (int l = 0; l < 5; l++)
                        {
                
                try
                {
                    if (pole[i - l, j + l] == pole[i, j])
                    {
                        count++; winX1 = (i - l); winY1 = (j + l);
                    }
                    else { break; }
                }
                catch { }
            }
                        if (count>5) {MessageBox.Show(pole[i, j] + " vyhrál!"); int[] ret4 = new int[4] { winX1, winY1, winX2, winY2 }; return ret4; }
                    
            return new int[1] { -10 };
        }
        //tutoriál jsme fakt dělat nemuseli, ale já se nudim xd
        //všechno pod tímhle kromě posledních dvou závorek je k ničemu
        private void button1_Click(object sender, System.EventArgs e)
        {
            #region Kód generovaný retardem co nemá co na práci

            Form tutorial = new Form();

            Label tutLabel1 = new Label();
            tutLabel1.Location = new Point(10, 10);
            tutLabel1.Size = new Size(100, 20);
            tutLabel1.Text = "Tutoriálek UwU";
            tutorial.Controls.Add(tutLabel1);

            Label tutLabel2 = new Label();
            tutLabel2.Location = new Point(10, 40);
            tutLabel2.Size = new Size(250, 40);
            tutLabel2.Text = "Hráči se střídají sami. V pravém horním rohu je vidět, kdo je na tahu.";
            tutorial.Controls.Add(tutLabel2);

            Label tutLabel3 = new Label();
            tutLabel3.Location = new Point(10, 80);
            tutLabel3.Size = new Size(250, 40);
            tutLabel3.Text = "Cíl je získat pět políček v řadě, jak rovně, tak šikmo.";
            tutorial.Controls.Add(tutLabel3);

            Label tutLabel4 = new Label();
            tutLabel4.Location = new Point(150, 150);
            tutLabel4.Size = new Size(100, 40);
            tutLabel4.Text = "Tuto hru vyhrál křížek.";
            tutorial.Controls.Add(tutLabel4);

            TableLayoutPanel tutGrid = new TableLayoutPanel();
            tutGrid.ColumnCount = 5;
            tutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.Location = new System.Drawing.Point(10, 120);
            tutGrid.Name = "grid1";
            tutGrid.RowCount = 5;
            tutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tutGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tutGrid.Size = new Size(106, 106);
            
            tutorial.Controls.Add(tutGrid);
            tutGrid.Paint += new PaintEventHandler(this.tutGrid_Paint);

            tutorial.ShowDialog();

            tutGrid.Refresh();
            #endregion

        }
        private void tutGrid_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0;i<5;i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Blue), i * 21, i * 21, (i + 1) * 21, (i + 1) * 21);
                e.Graphics.DrawLine(new Pen(Color.Blue), (i + 1) * 21, i* 21, i * 21, (i + 1) * 21);
            }
            e.Graphics.DrawLine(new Pen(Color.Blue), 3 * 21, 4 * 21, (3 + 1) * 21, (4 + 1) * 21);
            e.Graphics.DrawLine(new Pen(Color.Blue), (3 + 1) * 21, 4 * 21, 3 * 21, (4 + 1) * 21);
            for (int i = 2; i<5;i++) { e.Graphics.DrawEllipse(new Pen(Color.Red), new Rectangle((i-2) * 21, (i) * 21, 21, 21)); }
            e.Graphics.DrawEllipse(new Pen(Color.Red), new Rectangle(1 * 21, 2 * 21, 21, 21));
            e.Graphics.DrawEllipse(new Pen(Color.Red), new Rectangle(2 * 21, 1 * 21, 21, 21));

            e.Graphics.DrawLine(new Pen(Color.Blue, 4), 0 * 21 + 10, 0 * 21 + 10, ((4 + 1) * 21) - 10, ((4 + 1) * 21) - 10);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            pole = new string[20, 20];
            grid1.Refresh();
        }
    }
}
