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
    //http://answers.unity3d.com/questions/7877/how-do-you-use-a-pool-of-objects-rather-than-creat.html

    class BulletPool
    {
        public Bullet[] Bullets;
        private int bulletCache = 0;
        private int activeBullet = 0;
        public bool Firing;

        public BulletPool(GameWindowData gwd, Ship Ship)
        {
            Firing = true;
            Bullets = new Bullet[gwd.MyBulletMax];

            for (int i = 0; i < gwd.MyBulletMax; i++)
            {
                Bullets[i] = new Bullet(gwd, Ship);
            }

            bulletCache = (Bullets.Length);

            StartFiring();
        }

        void FireBullet()
        {
            Bullets[activeBullet].Spawn(); // fire the bullet
            activeBullet += 1;

            if (activeBullet > bulletCache - 1)
            {
                activeBullet = 0;//reset the loop
            }
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
                    FireBullet();
                    Thread.Sleep(Bullet.Delay);
                }
                

            }).Start();
        }
    }
}
