using SpaceX.component;
using SpaceX.gameOverWindow;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.background
{
    class GameBackground : GameObject
    {
        public RenderingComponent RC { set; get; }
        public AnimationComponent AC { set; get; }
        public AudioComponent BGM { set; get; }

        public GameBackground(GameWindowData gwd)
        {
            RC = new RenderingComponent(gwd.BackgroundPosition, gwd.BackgroundTexture, gwd.BackgroundSize, false);
            AC = new AnimationComponent(gwd.BackgroundAnimation, gwd.BackGroundSpeed, RC, null, true);
            BGM = new AudioComponent(gwd.BackgroundBGM, true);

            this.AddComponent(AC);
            this.AddComponent(RC);
            this.AddComponent(BGM);

            BGM.Sound.Play();
            AC.Start();
        }
    }
}
