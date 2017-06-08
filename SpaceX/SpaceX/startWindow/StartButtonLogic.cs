using SFML.Graphics;
using SFML.Window;
using SpaceX.component;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Keyboard;

namespace SpaceX.startWindow.logic
{
    class StartButtonLogic : ILogicComponent
    {
        public Key Enter { set; get; }
        public RenderWindow Window { set; get; }
        public StartWindow StartWindow { set; get; }
 
        public StartButtonLogic(Key Enter, StartWindow StartWindow)
        {
            this.Enter = Enter;
            this.Window = Window;
            this.StartWindow = StartWindow;
        }
        public void Destroy()
        {
            Window = null;
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Enter))
            {
                StartWindow.LoadNextWindow();
            }
        }
    }
}
