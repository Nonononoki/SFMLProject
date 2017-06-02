using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SpaceX.gameObject;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class Bullet : GameObject
    {
        public static int Delay { set; get; } //in milliseconds
        public int Duration { set; get; }
        public BulletPhysicsComponent BPC { set; get; }
        public RenderingComponent RC { set; get; }
        public BulletLogicComponent BLC { set; get; }
        public Ship Ship { set; get; }
        public Vector2 Position { set; get; } //position is relative to ship size
        public Stopwatch SW  { set; get; }

        public Bullet(GameWindowData gwd, Ship Ship)
        {
            
            this.Ship = Ship;
            if (Delay == 0f) Delay = gwd.MyBulletDelay;
            Position = gwd.MyBulletPosition;

            BLC = new BulletLogicComponent(this);
            BPC = new BulletPhysicsComponent(gwd, this);
            RC = new RenderingComponent(Converter.Vector(gwd.MyBulletPosition), gwd.MyBulletTexture, Converter.Vector(gwd.MyBulletSize), false);
            RC.AddPhysics(BPC);
            RC.IsVisible = false;

            this.AddComponent(BLC);
            this.AddComponent(BPC);
            this.AddComponent(RC);

            SW = new Stopwatch();
            Duration = gwd.MyBulletDuration; //Time after Bullet resets itself
            SW.Start();
        }

        public void Spawn()
        {
            BLC.Spawn();
        }

        public void Reset()
        {
            BLC.Reset();
        }
    }
}
