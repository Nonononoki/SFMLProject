using SFML.Graphics;
using SFML.Window;
using SpaceX.component;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.startWindow.logic
{
    class StartButtonLogic : ILogicComponent
    {
        public String Enter { set; get; }
        public RenderWindow Window { set; get; }

        public StartButtonLogic(String Enter, RenderWindow Window)
        {
            this.Enter = Enter;
            this.Window = Window;
        }
        public void Destroy()
        {
            Enter = null;
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Converter.StringKey(Enter)))
            {
                //Open new Window
                GameWindow GW = new GameWindow(Window);
            }
        }
    }
}
