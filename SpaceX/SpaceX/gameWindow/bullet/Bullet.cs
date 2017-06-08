using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using SpaceX.gameObject;
using SpaceX.spawner;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SpaceX.gameWindow
{
    class Bullet : GameObject, IPrototype
    {
        public static int Delay { set; get; } //in milliseconds
        public int Duration { set; get; }
        public BulletPhysicsComponent BPC { set; get; }
        public RenderingComponent RC { set; get; }
        public BulletLogicComponent BLC { set; get; }
        public Vector2 Position { set; get; } //position is relative to ship size
        public GameWindowData gwd { set; get; }

        public Bullet(GameWindowData gwd)
        {           
            this.gwd = gwd;
            this.Position = BulletSpawner.Position;

            BLC = new BulletLogicComponent(this);
            BPC = new BulletPhysicsComponent(gwd, this);
            RC = new RenderingComponent(Converter.Vector(gwd.MyBulletPosition), gwd.MyBulletTexture, Converter.Vector(gwd.MyBulletSize), false);
            RC.AddPhysics(BPC);

            this.AddComponent(BLC);
            this.AddComponent(BPC);
            this.AddComponent(RC);

            Duration = gwd.MyBulletDuration; //Time after Bullet resets itself

             Spawn();
        }

        public void Spawn()
        {
            BLC.Spawn();
        }

        public Bullet Clone()
        {
            return new Bullet(gwd);
        }
    }
}
