using FarseerPhysics;
using Microsoft.Xna.Framework;
using SFML.System;
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
    class BulletSpawner : ISpawner, IComponent
    {
        public bool Firing;
        public static Vector2 Position { set; get; }
        public Vector2 Offset { set; get; }
        public Bullet Bullet { set; get; }        //create instance of bullet
        public Ship Ship { set; get; }
        public int Delay { set; get; }
        public Stopwatch SW { set; get; }
        public BulletSpawner(GameWindowData gwd, Ship Ship)
        {
            this.Ship = Ship;
            Offset = gwd.MyBulletPosition;
            Position = ConvertUnits.ToDisplayUnits(Ship.SPC.Body.Position) + Offset;

            this.Delay = gwd.MyBulletDelay;
            this.Firing = true;

            this.Bullet = new Bullet(gwd);

            SW = new Stopwatch();
            SW.Start();
        }

        public void Fire()
        {
             Bullet newBullet = Bullet.Clone();
             newBullet.Spawn();
             newBullet.AC.Sound.Play();
        }

        public void Update()
        {
            Position = ConvertUnits.ToDisplayUnits(Ship.SPC.Body.Position) + Offset;

            if(SW.ElapsedMilliseconds >= Delay)
            {
                Fire();
                SW.Restart();
            }
        }

        public void Destroy()
        {
            Firing = false;
        }
    }
}
