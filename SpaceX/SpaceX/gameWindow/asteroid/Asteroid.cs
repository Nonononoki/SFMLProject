using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using SpaceX.component;
using SpaceX.gameObject;
using SpaceX.gameOverWindow;
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
        public int Speed { set; get; }
        public int Mass { set; get; }
        public int Size { set; get; }
        public int Health { set; get; }
        public Vector2f Position { set; get; }
        public int SpawnDelay { set; get; }
        public int Points { set; get; }
        public int Duration { set; get; }
        public Texture Texture { set; get; }

        public Sprite[] ExplosionSprites { set; get; }
        public Sprite[] HitSprites { set; get; }
        public int AnimationSpeed { set; get; }

        public AsteroidLogicComponent ALC { set; get; }
        public AsteroidPhysicsComponent APC { set; get; }
        public RenderingComponent RC { set; get; }

        public AnimationComponent DestructionAnimation { set; get; }
        public AsteroidDestroyALC DestroyALC { set; get; }
        public AnimationComponent HitAnimation { set; get; }
        public AsteroidHitALC HitALC { set; get; }

        public AudioComponent AsteroidHitSFX { set; get; }
        public AudioComponent AsteroidDestroySFX { set; get; }
        public Ship Ship { set; get; }

        public void Start(GameWindowData gwd)
        {
            ALC = new AsteroidLogicComponent(this);
            APC = new AsteroidPhysicsComponent(this, ALC);
            APC.Body.Enabled = false;
            RC = new RenderingComponent(Position, Texture, new Vector2f(Size, Size), true);
            RC.AddPhysics(APC);
            RC.IsVisible = false;

            HitALC = new AsteroidHitALC(this);
            DestroyALC = new AsteroidDestroyALC(this);
            DestructionAnimation = new AnimationComponent(ExplosionSprites, AnimationSpeed, RC, DestroyALC, false);
            HitAnimation = new AnimationComponent(HitSprites, AnimationSpeed, RC, HitALC, false);

            AsteroidHitSFX = new AudioComponent(gwd.AsteroidHitPath, false);
            AsteroidDestroySFX = new AudioComponent(gwd.AsteroidDestroyPath, false);

            this.AddComponent(APC);
            this.AddComponent(RC);
            this.AddComponent(ALC);

            this.AddComponent(AsteroidHitSFX);
            this.AddComponent(AsteroidDestroySFX);

            this.AddComponent(HitAnimation);
            this.AddComponent(DestructionAnimation);
        }

        public void Spawn()
        {
            ALC.SW.Start();
            GameWindow.MyGameObjects.Add(this);

            //spawn and launch asteroids
            RC.IsVisible = true;
            APC.Body.Enabled = true;

            //calculate dir Vector and resize it to the length of 1
            Vector2 v = Converter.ResizeVector(Ship.SPC.Body.Position - APC.Body.Position, 1);
            APC.Move(v);

        }

        public void DestroyMe()
        {
            //destruction animation played, time to destroy
            GameWindow.ToBeRemoved.Add(this);
            GameWindow.MyGameObjects.Add(this);
        }

    }
}
