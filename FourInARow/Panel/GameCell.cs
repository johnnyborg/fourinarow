using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInARow.Panel
{
    public partial class GameCell : PictureBox
    {
        public const int HEIGHT = 50;
        public const int WIDTH = 50;

        public const string EMPTY = "Cel-Leeg.gif";
        public const string RED = "Cel-Rood.gif";
        public const string BLUE = "Cel-Blauw.gif";

        public GameCell()
        {
            InitializeComponent();
        }

        public GameCell(string type, Point position) : base()
        {           
            Size size = new Size();
            size.Width = WIDTH;
            size.Height = HEIGHT;

            Location = position;

            SetType(type);
        }

        public virtual void SetType(string type)
        {
            switch (type)
            {
                case RED:
                    Image = new Bitmap(Properties.Resources.Cel_Rood);
                    break;
                case BLUE:
                    Image = new Bitmap(Properties.Resources.Cel_Blauw);
                    break;
                // Empty intentionally omitted
                default:
                    Image = new Bitmap(Properties.Resources.Cel_Leeg);
                    break;
            }
        }
    }
}
