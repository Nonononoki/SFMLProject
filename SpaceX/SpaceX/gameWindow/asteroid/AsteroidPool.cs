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
        public Stopwatch LevelSW { set; get; }
        public Stopwatch DelaySW { set; get; }
        public int CurrentAsteroid { set; get; }


        public AsteroidPool(LevelData ld, GameWindowData gwd, Ship Ship)
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

                Asteroid.Start(gwd);
                Asteroids.Add(Asteroid);
            }

            CurrentAsteroid = 0;

            LevelSW = new Stopwatch();
            LevelSW.Start();

            DelaySW = new Stopwatch();
            DelaySW.Start();
            Spawning = true;
        }



        public void Update()
        {
            //spawn enemies in interval
            if (CurrentAsteroid < Asteroids.Count && DelaySW.ElapsedMilliseconds >= Asteroids.ElementAt(CurrentAsteroid).SpawnDelay)
            {
                Asteroids.ElementAt(CurrentAsteroid).Spawn();
                CurrentAsteroid++;
                DelaySW.Restart();
            }

            //move to next level after a period of time
            if (LevelSW.ElapsedMilliseconds >= LevelDuration)
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
