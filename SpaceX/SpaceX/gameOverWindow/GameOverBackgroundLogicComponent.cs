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
        public GameOverBackgroundLogicComponent(GameOverWindowData gowd)
        {
            this.Enter = gowd.Enter;

        }
        public void Destroy()
        {
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Enter))
            {
                GameOverWindow.LoadNextWindow();
            }
        }
    }
}
