using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.hud
{
    class HUD : GameObject
    {
        Health Health;
        Level Level;
        Score Score;

        public HUD(GameWindowData gwd)
        {
            Health = new Health(gwd);
            Level = new Level(gwd);
            Score = new Score(gwd);

            AddComponent(Health);
            AddComponent(Level);
            AddComponent(Score);
        }
    }
}
