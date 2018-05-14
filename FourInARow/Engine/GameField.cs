using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow.Engine
{
    public class GameField
    {
        public enum Player {
            EMPTY,
            RED, 
            BLUE
        };

        public int SizeY { get; }
        public int SizeX { get; }
        public Player Playing { get; private set; }
        public Player Winner { get; private set; }
        public PositionToDrop PositionToDrop { get; private set; }

        // x, y
        private Player[,] Field;

        public GameField(int y, int x)
        {
            // Human vs array; game logic starts counting form 0
            SizeY = y;
            SizeX = x;
            PositionToDrop = new PositionToDrop(this);

            // Change later
            Playing = Player.RED;

            Field = new Player[x, y];
            Reset();
        }

        public Player GetValue(int x, int y)
        {
            if (x < SizeX && y < SizeY)
            {
                return Field[x, y];
            }

            // Display nicely, so count from 1 instead of 0
            throw new IndexOutOfRangeException(string.Format("Field is {0}, {1} but requested {2}, {3}.", SizeX, SizeY, x + 1, y + 1));
        }

        public void Drop()
        {
            if (!GameHasFinished())
            {
                int firstAvaiableVerticalPosition = GetFirstAvailableVerticalPosition(PositionToDrop.GetDropLocation());

                // Switch the player and put the right coin in the field
                switch (Playing)
                {
                    case Player.RED:
                        Field[PositionToDrop.GetDropLocation(), firstAvaiableVerticalPosition] = Player.RED;
                        Playing = Player.BLUE;
                        break;
                    case Player.BLUE:
                        Field[PositionToDrop.GetDropLocation(), firstAvaiableVerticalPosition] = Player.BLUE;
                        Playing = Player.RED;
                        break;
                }
            }

            if (!GameHasAWinner())
            {                
                PositionToDrop.CheckCurrentDropLocationAvailable();
            }
        }

        public int GetFirstAvailableVerticalPosition(int x)
        {
            // We'll be counting from 0, but we store in in the human format not the array
            for (int yLoop = SizeX; yLoop >= 0; yLoop--)
            {
                if (Field[x, yLoop] == Player.EMPTY)
                {
                    return yLoop;
                }
            }

            return 0;
        }

        public bool GameHasAWinner()
        {
            // Early out, once we've got a winner we do not check it again
            if (Winner != Player.EMPTY)
            {
                return true;
            }

            Player yPlayer = Player.EMPTY;
            Player xPlayer = Player.EMPTY;

            int xSame = 0;
            int ySame = 0;

            // Check for any horizontal winner
            for (int xLoop = 0; xLoop < SizeX; xLoop++)
            {
                for (int yLoop = SizeY - 1; yLoop < 0; yLoop--)
                {
                    // Break out the loop when no coins are above our point
                    if (Field[xLoop, yLoop] == Player.EMPTY)
                    {
                        xSame = 0;
                        xPlayer = Player.EMPTY;
                        continue;
                    }

                    // Keep track of vertical the same, with a player as reference
                    if (xPlayer == Field[xLoop, yLoop])
                    {
                        xSame++;
                    }
                    if (xPlayer != Field[xLoop, yLoop])
                    {
                        xPlayer = Field[xLoop, yLoop];
                        xSame = 0;
                    }

                    if (xSame == 3)
                    {
                        Winner = xPlayer;

                        // Break out the loop
                        return true;
                    }
                }

                // Reset the yLoop before going into a new x row
                ySame = 0;
                yPlayer = Player.EMPTY;

                // We'll be counting from bottom (5) to 0 (top)
                for (int yLoop = SizeY - 1; yLoop >= 0; yLoop--)
                {
                    // Skip empty values
                    if (Field[xLoop, yLoop] == Player.EMPTY)
                    {
                        ySame = 0;
                        yPlayer = Player.EMPTY;
                        continue;
                    }

                    // Keep track of horizontal the same, with a player as reference
                    if (yPlayer == Field[xLoop, yLoop])
                    {
                        ySame++;
                    }
                    if (yPlayer != Field[xLoop, yLoop])
                    {
                        yPlayer = Field[xLoop, yLoop];
                        ySame = 0;
                    }

                    // We're counting from 0
                    if (ySame == 3)
                    {
                        Winner = yPlayer;

                        // break out the loop
                        return true;
                    }
                }                
            }

            return false;
        }

        public bool GameHasFinished()
        {
            if (Winner != Player.EMPTY)
            {
                return true;
            }

            for (int xLoop = 0; xLoop < SizeX; xLoop++)
            {
                for(int yLoop = 0; yLoop < SizeY; yLoop++)
                {
                    if (Field[xLoop, yLoop] == Player.EMPTY)
                    {
                        return false;
                    }
                }
            }

            // We did not find any empty cells
            return true;
        }

        public void Reset()
        {
            for (int yLoop = 0; yLoop < SizeY; yLoop++)
            {
                for (int xLoop = 0; xLoop < SizeX; xLoop++)
                {
                    Field[xLoop, yLoop] = Player.EMPTY;
                }
            }

            Winner = Player.EMPTY;
        }
    }
}
