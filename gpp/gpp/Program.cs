
//System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SFML
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

namespace gpp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //window object
            RenderWindow window = new RenderWindow(new VideoMode(200, 200), "hello world!");
            //simple circle
            CircleShape circle = new CircleShape(100);

            //fill it with color
            circle.FillColor = Color.Red;

            // activate window
            window.SetActive();
            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();

                //draw circle
                window.Draw(circle);

                window.Display();
            }
        }
    }
}
