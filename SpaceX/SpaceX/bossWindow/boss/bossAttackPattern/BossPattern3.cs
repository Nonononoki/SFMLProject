using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.boss.bossAttackPattern
{
    class BossPattern3 : IBossAttackPattern
    {
        public Boss Boss { set; get; }
        public BossHero Hero { set; get; }
        public Stopwatch SW { set; get; }
        public BossWindowData BWD { set; get; }
        public Vector2[] FireDirection { set; get; }
        public BossFire Clone { set; get; }


        public BossPattern3(Boss Boss, BossHero Hero, BossFire Clone, BossWindowData BWD)
        {
            //Fire 5 fire balls
            const int NumFireBalls = 7;

            FireDirection = new Vector2[NumFireBalls];
            FireDirection[0] = new Vector2(0, 1);
            FireDirection[1] = new Vector2(1, 1);
            FireDirection[2] = new Vector2(-1, 1);
            FireDirection[3] = new Vector2(1, 0);
            FireDirection[4] = new Vector2(-1, 0);
            FireDirection[5] = new Vector2(0.5f, 1);
            FireDirection[6] = new Vector2(-0.5f, 1);

            Converter.ResizeVector(FireDirection, 1);

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
                Boss.PC.Move(new Vector2(1, 0));
            else if (Boss.PC.Body.Position.X > Hero.PC.Body.Position.X)
                Boss.PC.Move(new Vector2(-1, 0));

            if (SW.ElapsedMilliseconds >= BWD.BossFireCooldown)
            {
                SpawnFireBall();
            }

        }

        public void SpawnFireBall()
        {
            //Spawn 7 fire balls
            for (int i = 0; i < FireDirection.Length; i++)
            {
                BossFire Fire = Clone.Clone(FireDirection[i]);
                BossWindow.MyGameObjects.Add(Fire);
                Fire.Shoot();
                SW.Restart();
            }
        }
    }
}
