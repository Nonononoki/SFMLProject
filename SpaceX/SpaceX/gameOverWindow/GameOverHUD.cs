using SpaceX.gameWindow;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameOverWindow
{
    class GameOverHUD : GameObject
    {
        GameOverScore Score;

        public GameOverHUD(GameOverWindowData gowd, int score)
        {
            Score = new GameOverScore(gowd, score);
            AddComponent(Score);
        }
    }
}
