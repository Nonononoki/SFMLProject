using FarseerPhysics;
using Microsoft.Xna.Framework;
using SpaceX.component;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class BulletLogicComponent : ILogicComponent
    {
        public Bullet Bullet { set; get; }
        private Stopwatch SW { set; get; }

        public BulletLogicComponent(Bullet Bullet)
        {
            this.Bullet = Bullet;
            SW = new Stopwatch();
        }
        public void Spawn()
        {
            SW.Start();

            //shoot upwards
            Bullet.BPC.Move(new Vector2(0, -1));
        }

        public void Update()
        {
            if (SW.ElapsedMilliseconds >= Bullet.Duration)
            {
                Destroy();
                //Bullet.Destroy();
                GameWindow.ToBeRemoved.Add(Bullet);
            }
        }

        public void Destroy()
        {
        }
    }
}
