using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourInARow.Engine;
using static FourInARow.Engine.GameField;

namespace FourInARow.Panel
{
    public partial class GamePanel : UserControl
    {
        public const int HEIGHT = 400;
        public const int WIDTH = 400;

        // x ,y
        private GameCell[,] Field;
        private GameField GameField;

        private GameCellDrop PositionToDrop;

        public GamePanel(GameField gameField)
        {
            InitializeComponent();

            // register ticker
            Size size = new Size();
            size.Height = GamePanel.HEIGHT;
            size.Width = GamePanel.WIDTH;
            Size = size;

            Point location = new Point(0, 0);
            Location = location;
            SendToBack();

            GameField = gameField;

            // build field
            Field = new GameCell[gameField.SizeX, gameField.SizeY];
            for (int xLoop = 0; xLoop < gameField.SizeX; xLoop++)
            {
                for (int yLoop = 0; yLoop < gameField.SizeY; yLoop++)
                {
                    Point position = new Point();
                    position.X = Location.X + GameCell.WIDTH + (GameCell.WIDTH * xLoop);
                    position.Y = Location.Y + GameCell.HEIGHT + (GameCell.HEIGHT * yLoop);

                    GameCell cell = new GameCell(GameCell.EMPTY, position);               
                    
                    Field[xLoop, yLoop] = cell;

                    Controls.Add(cell);

                    cell.BringToFront();
                }
            }

            PositionToDrop = new GameCellDrop(GameField.Playing, CalculatePositionToDropPoint());

            Controls.Add(PositionToDrop);
            PositionToDrop.BringToFront();
        }       

        public void Draw()
        {
            for(int xLoop = 0; xLoop < GameField.SizeX; xLoop++)
            {
                for (int yLoop = 0; yLoop < GameField.SizeY; yLoop++)
                {
                    switch (GameField.GetValue(xLoop, yLoop))
                    {
                        case Player.EMPTY:
                            Field[xLoop, yLoop].SetType(GameCell.EMPTY);
                            break;
                        case Player.BLUE:
                            Field[xLoop, yLoop].SetType(GameCell.BLUE);
                            break;
                        case Player.RED:
                            Field[xLoop, yLoop].SetType(GameCell.RED);
                            break;
                    }                    
                }
            }

            if (GameField.GameHasFinished())
            {
                PositionToDrop.Visible = false;
            }
            else
            {
                PositionToDrop.Location = CalculatePositionToDropPoint();
                PositionToDrop.SetType(GameField.Playing);
                PositionToDrop.Visible = true;
            }            

            Invalidate();
        }

        public Point CalculatePositionToDropPoint()
        {
            Point point = new Point((GameField.PositionToDrop.GetDropLocation() + 1) * GameCell.WIDTH, 0);
            return point;
        }
    }
}
