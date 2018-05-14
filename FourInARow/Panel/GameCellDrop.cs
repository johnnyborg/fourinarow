using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FourInARow.Engine.GameField;

namespace FourInARow.Panel
{
    public partial class GameCellDrop : PictureBox
    {
        public GameCellDrop()
        {
            InitializeComponent();
        }

        public GameCellDrop(Player player, Point position) : base()
        {
            Size size = new Size();
            size.Width = GameCell.WIDTH;
            size.Height = GameCell.HEIGHT;

            Location = position;

            SetType(player);
        }

        public void SetType(Player type)
        {
            switch (type)
            {
                case Player.RED:
                    Image = new Bitmap(Properties.Resources.Leeg_Rood);
                    break;
                case Player.BLUE:
                    Image = new Bitmap(Properties.Resources.Leeg_Blauw);
                    break;
            }
        }
    }
}
