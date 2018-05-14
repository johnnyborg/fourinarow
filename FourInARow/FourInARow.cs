using FourInARow.Engine;
using FourInARow.Panel;
using System;
using System.Windows.Forms;

namespace FourInARow
{
    public partial class FourInARow : Form
    {
        protected GameField GameField;
        protected GamePanel GamePanel;
        protected GameTimer GameThread;

        public FourInARow()
        {
            InitializeComponent();
            ResetGame();
        }

        private void FourInARow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                GameThread.inputToLeft = true;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                GameThread.inputToRight = true;
            }

            // This only for the keyDown else the game will end quickly
            if (e.KeyCode == Keys.S)
            {
                GameThread.Drop();
            }

            // Update directly after recieving this trigger
            GameThread.ForceUpdate();
        }

        private void FourInARow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                GameThread.inputToLeft = false;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                GameThread.inputToRight = false;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            GameField = new GameField(7, 6);
            GamePanel = new GamePanel(GameField);
            GameThread = new GameTimer(GameField, GamePanel);

            Controls.Add(GamePanel);
        }
    }
}
