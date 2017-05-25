using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.window
{
    class StartWindow
    {
        public StartWindowData SD;
        public RenderWindow Window;

        public StartWindow(RenderWindow Window)
        {
            this.Window = Window;

            SD = new StartWindowData(Window, "StartWindowData");

            //Start GameLoop
            Update();
        }


        public void Update()
        {
            //main game loop
            bool running = true;

            //DeltaTime
            DeltaTime dt = new DeltaTime();

            while (running)
            {
                dt.Start();

                Window.Clear(Color.Black);
                Window.DispatchEvents();
                Window.Closed += (sender, evtArgs) => running = false;

                //draw sprites
                foreach (GameObject go in GameObject._list)
                {
                    go.Update();
                    go.Draw(Window);
                }

                  Window.Display();

                dt.Stop();
            }
        }
    }
}
