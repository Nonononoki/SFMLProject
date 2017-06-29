using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.boss.bossAttackPattern
{
    class BossPattern1 : IBossAttackPattern
    {
        //Pattern1 Move to Player X

        public Boss Boss { set; get; }
        public BossHero Hero { set; get; }
        public Stopwatch SW { set; get; }
        public BossWindowData BWD { set; get; }
        public Vector2 FireDirection { set; get; }
        public BossFire Clone { set; get; }
        

        public BossPattern1(Boss Boss, BossHero Hero, BossFire Clone, BossWindowData BWD)
        {
            FireDirection = new Vector2(0, 1);
            this.Boss = Boss;
            this.Hero = Hero;
            this.BWD = BWD;
            this.Clone = Clone;

            SW = new Stopwatch();
            SW.Start();
        }

        public void Destroy()
        {
            //throw new NotImplementedException();
        }

        public void Update()
        {
            Boss.PC.Body.LinearVelocity = new Vector2(0, 0);

            //move to player x axis
            if (Boss.PC.Body.Position.X < Hero.PC.Body.Position.X)
                Boss.PC.Move(new Vector2(1,0));
            else if (Boss.PC.Body.Position.X > Hero.PC.Body.Position.X)
                Boss.PC.Move(new Vector2(-1,0));

            if(SW.ElapsedMilliseconds >= BWD.BossFireCooldown)
            {
                SpawnFireBall();
            }

        }

        public void SpawnFireBall()
        {
            BossFire Fire = Clone.Clone(FireDirection);
            BossWindow.MyGameObjects.Add(Fire);
            Fire.Shoot();
            SW.Restart();
        }
    }


}
