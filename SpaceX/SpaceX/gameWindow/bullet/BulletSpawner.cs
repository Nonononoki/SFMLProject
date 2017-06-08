using FarseerPhysics;
using Microsoft.Xna.Framework;
using SFML.System;
using SpaceX.gameObject;
using SpaceX.window;
using System;
using System.Collections.Generic;
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

        public BulletSpawner(GameWindowData gwd, Ship Ship)
        {
            this.Ship = Ship;
            Offset = gwd.MyBulletPosition;
            Position = ConvertUnits.ToDisplayUnits(Ship.SPC.Body.Position) + Offset;

            this.Delay = gwd.MyBulletDelay;
            this.Firing = true;

            this.Bullet = new Bullet(gwd);

            StartFiring();
        }

        public void StartFiring()
        {
            //create bullets during runtime and shoot!
            //https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */

                while (Firing)
                {
                    Bullet.Clone();
                    Thread.Sleep(Delay);
                }


            }).Start();
        }

        public void Update()
        {
            Position = ConvertUnits.ToDisplayUnits(Ship.SPC.Body.Position) + Offset;
        }

        public void Destroy()
        {
            Firing = false;
        }
    }
}
