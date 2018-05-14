using FourInARow.Engine;
using FourInARow.Panel;
using System;
using System.Windows.Forms;

namespace FourInARow
{
    public class GameTimer
    {
        public const int TIMER_TIMEOUT = 150;

        public bool inputToLeft { get; set; }
        public bool inputToRight { get; set; }

        protected GameField GameField;
        protected GamePanel GamePanel;
        protected Timer Timer;
        protected int CompleteUpdates;

        public GameTimer(GameField gameField, GamePanel gamePanel)
        {
            Timer = new Timer();
            Timer.Interval = TIMER_TIMEOUT;
            Timer.Tick += new EventHandler(this.Tick);
            Timer.Start();

            inputToLeft = false;
            inputToRight = false;

            GameField = gameField;
            GamePanel = gamePanel;
            CompleteUpdates = 0;
        }

        public void Tick(object sender, EventArgs e)
        {
            Update();

            if (GameField.GameHasFinished())
            {
                CompleteUpdates++;
            }

            if (CompleteUpdates > 15)
            {
                CompleteUpdates = 0;
                GameField.Reset();
            }
        }

        public void ForceUpdate()
        {
            Timer.Stop();
            Update();

            // Setting a new interval and calling start will reset the timer
            Timer.Interval = TIMER_TIMEOUT;
            Timer.Start();
        }

        public void Drop()
        {
            GameField.Drop();
            GamePanel.Draw();
        }

        private void Update()
        {
            if (inputToLeft)
            {
                GameField.PositionToDrop.ToLeft();
            }

            if (inputToRight)
            {
                GameField.PositionToDrop.ToRight();
            }

            GamePanel.Draw();
        }
    }
}
