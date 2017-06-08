using SFML.System;
using SpaceX.gameObject;
using SpaceX.gameWindow.hud;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidPool : IComponent, ISpawner
    {
        public bool Spawning { set; get; }
        public List<Asteroid> Asteroids { set; get; }
        public int LevelDuration { set; get; }
        public Stopwatch SW { set; get; }
        public AsteroidPool(LevelData ld, Ship Ship)
        {

            LevelDuration = ld.LevelDuration;

            //generate Asteroids
            Asteroids = new List<Asteroid>();
            for (int i = 0; i < ld.AsteroidCount; i++)
            {
                Asteroid Asteroid = new Asteroid();
                Asteroid.Mass = ld.AsteroidMass.ElementAt(i);
                Asteroid.Health = ld.AsteroidHealth.ElementAt(i);
                Asteroid.Speed = ld.AsteroidSpeed.ElementAt(i);

                Asteroid.Size = ld.AsteroidSize.ElementAt(i);
                Asteroid.SpawnDelay = ld.SpawnDelay.ElementAt(i);
                Asteroid.Points = ld.Points.ElementAt(i);

                Asteroid.Position = Converter.RelativeWindow(ld.SpawnPosition.ElementAt(i));
                Asteroid.Duration = ld.AsteroidDuration;
                Asteroid.Texture = ld.AsteroidTexture;
                Asteroid.Ship = Ship;
                Asteroid.Components();
                Asteroids.Add(Asteroid);

            }

            SW = new Stopwatch();
            SW.Start();
            Spawning = true;
            StartFiring();
        }

        public void StartFiring()
        {
            //launch asteroids with delay
            //https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */

                for(int i = 0; i < Asteroids.Count && Spawning; i++)
                {
                    Asteroids.ElementAt(i).Spawn();
                    Thread.Sleep(Asteroids.ElementAt(i).SpawnDelay);
                }

            }).Start();
        }

        public void Update()
        {
            if (SW.ElapsedMilliseconds >= LevelDuration)
            {
                GameWindow.LoadNextLevel();
                Destroy();
            }
        }


        public void Destroy()
        {
            Spawning = false;
        }
    }
}
