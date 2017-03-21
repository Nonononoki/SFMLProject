using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp
{
    class Program
    {
        # include <SFML/Graphics.hpp>

        static void Main(string[] args)
        {
            // create the window
            sf::RenderWindow window(sf::VideoMode(800, 600), "My window");

            // run the program as long as the window is open
            while (window.isOpen())
            {
                // check all the window's events that were triggered since the last iteration of the loop
                sf::Event event;
            while (window.pollEvent(event))
            {
                // "close requested" event: we close the window
                if (event.type == sf::Event::Closed)
                    window.close();
            }

            // clear the window with black color
            window.clear(sf::Color::Black);

            // draw everything here...
            // window.draw(...);

            // end the current frame
            window.display();
    }

    return 0;
        }
    }
}
