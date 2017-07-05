using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.hero
{
    class HeroBulletLogic : ILogicComponent
    {
        public int DestroyTime { set; get; }
        public HeroBullet Bullet { set; get; }
        public Stopwatch SW { set; get; }

        public HeroBulletLogic(int DestroyTime, HeroBullet Bullet)
        {
            this.DestroyTime = DestroyTime;
            this.Bullet = Bullet;
            SW = new Stopwatch();
        }

        public void Start()
        {
            SW.Start();
        }

        public void Destroy()
        {
            // throw new NotImplementedException();
            BossWindow.ToBeRemoved.Add(Bullet);
        }

        public void Update()
        {
            // throw new NotImplementedException();
            if (SW.ElapsedMilliseconds >= DestroyTime)
                Destroy();
        }


    }
}
