using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FourInARow.Engine.GameField;

namespace FourInARow.Engine
{
    public class PositionToDrop
    {
        private GameField GameField;
        private int DropLocation;

        public PositionToDrop(GameField gameField)
        {
            GameField = gameField;
            DropLocation = 0;
        }

        public int GetDropLocation()
        {
            // Sanity check
            if (DropLocation < 0 || DropLocation > GameField.SizeX -1)
            {
                // Just set the cursor back, dont have clue what to do
                DropLocation = 0;
            }

            return DropLocation;
        }

        public void ToLeft()
        {
            int positionToDropProposal = DropLocation;

            do
            {
                positionToDropProposal--;

                if (positionToDropProposal < 0)
                {
                    positionToDropProposal = GameField.SizeX - 1;
                    break;
                }
            }
            while (GameField.GetValue(positionToDropProposal, 0) != Player.EMPTY);

            DropLocation = positionToDropProposal;
        }

        public void ToRight()
        {
            int positionToDropProposal = DropLocation;
            
            do
            {
                positionToDropProposal++;

                if (positionToDropProposal == GameField.SizeX)
                {
                    positionToDropProposal = 0;
                    break;
                }
            }
            while (GameField.GetValue(positionToDropProposal, 0) != Player.EMPTY);

            DropLocation = positionToDropProposal;
        }

        public void CheckCurrentDropLocationAvailable()
        {
            if (GameField.GetValue(DropLocation, 0) != Player.EMPTY)
            {
                ToRight();
            }
        }
    }
}
