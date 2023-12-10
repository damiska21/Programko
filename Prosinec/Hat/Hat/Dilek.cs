using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hat
{
    public class Dilek: Label
    {
        public Dilek(Point location, Color barva) {
            this.Location = new Point(location.X * 20,location.Y*20);
            this.BackColor = barva;
            this.Size = new Size(20, 20);
            this.Text = "";
            this.Font = new Font("Consolas", 15);
            this.ForeColor = Color.White;
        }
        public Point location { get; set; }
    }
}
