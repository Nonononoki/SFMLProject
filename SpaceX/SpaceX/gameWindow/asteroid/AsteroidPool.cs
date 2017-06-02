using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidPool
    {
        public List<Asteroid> Asteroids { set; get; }
        public bool Firing { set; get; }

        public AsteroidPool(LevelData ld)
        {
            Firing = true;

            //generate Asteroids
            Asteroids = new List<Asteroid>();
            for (int i = 0; i < ld.AsteroidCount; i++)
            {
                Asteroid Asteroid = new Asteroid();
                Asteroid.Mass = ld.AsteroidMass.ElementAt(i);
                Asteroid.Health = new Integer(ld.AsteroidHealth.ElementAt(i));
                Asteroid.Speed = ld.AsteroidSpeed.ElementAt(i);
                Asteroid.Size = Converter.RelativeWindow(ld.AsteroidSize.ElementAt(i));
                Asteroid.SpawnDelay = ld.SpawnDelay.ElementAt(i);
                Asteroid.Points = ld.Points.ElementAt(i);
                Asteroid.SpawnPosition = ld.SpawnPosition.ElementAt(i);
                Asteroids.Add(Asteroid);
            }


        }

        public void StartFiring()
        {
            //launch asteroids with delay
            //https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */

                while (Firing)
                {
                    FireBullet();
                    Thread.Sleep(Bullet.Delay);
                }


            }).Start();
        }
    }
}
