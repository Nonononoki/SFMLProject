﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameOverWindow
{
    class GameOverBackground : GameObject
    {
        public RenderingComponent RC { set; get; }
        public GameOverBackgroundLogicComponent GOBGLC { set; get; }
        public GameOverBackground(GameOverWindowData gowd, GameOverWindow gow)
        {
            RC = new RenderingComponent(gowd.BackgroundPosition, gowd.BackgroundTexture, gowd.BackgroundSize, false);
            GOBGLC = new GameOverBackgroundLogicComponent(gowd, gow);
            this.AddComponent(RC);
            this.AddComponent(GOBGLC);
        }
    }
}
