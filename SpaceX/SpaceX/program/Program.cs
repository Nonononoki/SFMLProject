using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.Window;
using SpaceX.program;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    class Program
    {
        public static List<IWindow> Windows;
        //public static List<Stopwatch> Stopwatches;
        public static RenderWindow Window;
        public static int FadeStep { set; get; }
        public static int FadeSpeed { set; get; }

        static void Main(string[] args)
        {
            //load data for Program
            ProgramData PG = new ProgramData("ProgramData");
            Window = new RenderWindow(new VideoMode((uint)PG.WindowSize.X, (uint)PG.WindowSize.Y), "SpaceX", Styles.Default);

            FadeStep = PG.FadeStep;
            FadeSpeed = PG.FadeSpeed;

            Windows = new List<IWindow>();
            Running Running = new Running();

            //DeltaTime
            DeltaTime dt = new DeltaTime();

            //begin with StartWindow
            StartWindow SW = new StartWindow();

            //update open windows
            Update(dt);
        }

        public static void Update(DeltaTime dt)
        {
            while (Running.IsRunning)
            {
                dt.Start();

                Window.Clear(Color.Black);
                Window.DispatchEvents();
                Window.Closed += (sender, evtArgs) => Running.IsRunning = false;

                //update Windows
                foreach (IWindow w in Windows.ToList<IWindow>())
                {
                    w.Update();
                }

                Window.Display();
                dt.Stop();
            }
        }
    }
}
