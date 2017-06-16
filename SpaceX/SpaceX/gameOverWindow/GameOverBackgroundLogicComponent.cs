using SFML.Window;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Keyboard;

namespace SpaceX.gameOverWindow
{
    class GameOverBackgroundLogicComponent : ILogicComponent
    {
        public Key Enter { set; get; }
        public GameOverWindow GOW { set; get; }
        public GameOverBackgroundLogicComponent(GameOverWindowData gowd, GameOverWindow gow)
        {
            this.Enter = gowd.Enter;
            this.GOW = gow;

        }
        public void Destroy()
        {
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Enter))
            {
                GOW.LoadNextWindow();
            }
        }
    }
}
