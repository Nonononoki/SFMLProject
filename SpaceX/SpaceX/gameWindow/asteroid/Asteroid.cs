using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using SpaceX.component;
using SpaceX.gameObject;
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
        public int Health { set; get; }
        public int Speed { set; get; }
        public int Mass { set; get; }
        public int Size { set; get; }
        public Vector2f Position { set; get; }
        public int SpawnDelay { set; get; }
        public int Points { set; get; }
        public int Duration { set; get; }
        public Texture Texture { set; get; }
        public AsteroidLogicComponent ALC { set; get; }
        public AsteroidPhysicsComponent APC { set; get; }
        public RenderingComponent RC { set; get; }
        public AudioComponent AsteroidHit { set; get; }
        public AudioComponent AsteroidDestroy { set; get; }
        public Ship Ship { set; get; }

        public void Start(GameWindowData gwd)
        {
            ALC = new AsteroidLogicComponent(this);
            APC = new AsteroidPhysicsComponent(this, ALC);
            APC.Body.Enabled = false;
            RC = new RenderingComponent(Position, Texture, new Vector2f(Size, Size), true);
            RC.AddPhysics(APC);
            RC.IsVisible = false;
            AsteroidHit = new AudioComponent(gwd.AsteroidHitPath, false);
            AsteroidDestroy = new AudioComponent(gwd.AsteroidDestroyPath, false);

            this.AddComponent(APC);
            this.AddComponent(RC);
            this.AddComponent(ALC);
            this.AddComponent(AsteroidHit);
            this.AddComponent(AsteroidDestroy);
        }

        public void Spawn()
        {
            ALC.SW.Start();

            //spawn and launch asteroids
            RC.IsVisible = true;
            APC.Body.Enabled = true;

            //calculate dir Vector and resize it to the length of 1
            Vector2 v = Converter.ResizeVector(Ship.SPC.Body.Position - APC.Body.Position, 1);
            APC.Move(v);

        }

    }
}
