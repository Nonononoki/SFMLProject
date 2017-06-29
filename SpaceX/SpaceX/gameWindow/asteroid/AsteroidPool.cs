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
                Asteroid Asteroid = new Asteroid()
                {
                    Mass = ld.AsteroidMass.ElementAt(i),
                    Speed = ld.AsteroidSpeed.ElementAt(i),
                    Health = ld.AsteroidHealth.ElementAt(i),

                    Size = ld.AsteroidSize.ElementAt(i),
                    SpawnDelay = ld.SpawnDelay.ElementAt(i),
                    Points = ld.Points.ElementAt(i),

                    Position = Converter.RelativeWindow(ld.SpawnPosition.ElementAt(i)),
                    Duration = ld.AsteroidDuration,
                    Texture = ld.AsteroidTexture,
                    Ship = Ship,

                    AnimationSpeed = ld.AnimationSpeed,
                    ExplosionSprites = ld.ExplosionSprites,
                    HitSprites = ld.HitSprites
                };

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
            //LevelSW = null;
            //DelaySW = null;
        }
    }
}
