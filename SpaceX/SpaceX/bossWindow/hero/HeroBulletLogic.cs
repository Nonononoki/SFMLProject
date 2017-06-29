using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.hero
{
    class HeroBulletLogic : ILogicComponent
    {
        HeroBullet Bullet { set; get; }
        BossHero Hero { set; get; }

        public HeroBulletLogic(HeroBullet Bullet, BossHero Hero)
        {
            this.Hero = Hero;
            this.Bullet = Bullet;
        }

        public void Destroy()
        {
           // throw new NotImplementedException();
        }

        public void Update()
        {
           // throw new NotImplementedException();
        }


    }
}
