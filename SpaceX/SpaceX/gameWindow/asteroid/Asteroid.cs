using SFML.System;
using SpaceX.gameWindow.asteroid;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class Asteroid : GameObject
    {
        public Integer Health { set; get; }
        public AsteroidLogicComponent ALC { set; get; }
        public int Speed { set; get; }
        public int Mass { set; get; }
        public int Size { set; get; }
        public Vector2f SpawnPosition { set; get; }
        public int SpawnDelay { set; get; }
        public int Points { set; get; }

        public Asteroid()
        {
            //ALC = new AsteroidLogicComponent(Health);
        }

        public void Spawn()
        {
            //spawn and launch asteroids
        }

    }
}
