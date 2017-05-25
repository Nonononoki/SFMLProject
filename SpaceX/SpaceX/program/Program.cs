using SFML.Graphics;
using SFML.Window;
using SpaceX.program;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    class Program
    {
        static void Main(string[] args)
        {
            //load data for Program
            ProgramData PG = new ProgramData("ProgramData");
            RenderWindow Window = new RenderWindow(new VideoMode((uint)PG.WindowSize.X, (uint)PG.WindowSize.Y), "SpaceX", Styles.Default);

            //begin with StartWindow
            StartWindow SW = new StartWindow(Window);
        }
    }
}
