using FarseerPhysics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiled.SFML;

namespace SpaceX.bossWindow.boss.bossAttackPattern
{
    class BossPattern5 : IBossAttackPattern
    {
        public Boss Boss { set; get; }
        public BossHero Hero { set; get; }
        public Stopwatch SW { set; get; }
        public BossWindowData BWD { set; get; }
        public Vector2 FireDirection { set; get; }
        public BossFire BossFire { set; get; }
        public BossFirePillar FirePillar { set; get; }
        public BossArena Arena { set; get; }


        private int FireInterval;
        private float FireBallSpeed = 0.5f;

        public BossPattern5(Boss Boss, BossHero Hero, BossFire BossFire, BossWindowData BWD)
        {
            //move boss to middle, hurl fireballs at Hero
            //fire twice as fast with fire balls moving twice as slow

            FireDirection = new Vector2(0, 0);
            this.Boss = Boss;
            this.Hero = Hero;
            this.BWD = BWD;
            this.BossFire = BossFire;
            this.Arena = Arena;

            FireInterval = BWD.BossFireCooldown;
            FirePillar = new BossFirePillar(BWD, BossWindow.Arena.Tiles.First(), FireInterval);

            SW = new Stopwatch();
            SW.Start();
        }

        public void Destroy()
        {
            //throw new NotImplementedException();
            SW = null;
        }

        public void Update()
        {
            //fire!
            if (SW.ElapsedMilliseconds >= FireInterval)
            {
                //spawn Fire Balls
                SpawnFireBall();

                //spawn fire pillars
                SpawnFirePillars();
            }
        }

        public void SpawnFireBall()
        {
            FireDirection = Hero.PC.Body.Position - Boss.PC.Body.Position;
            FireDirection = Converter.ResizeVector(FireDirection, 1f * FireBallSpeed);

            BossFire Fire = BossFire.Clone(FireDirection);
            BossWindow.MyGameObjects.Add(Fire);
            Fire.Shoot();
            SW.Restart();
        }

        public void SpawnFirePillars()
        {
            Random rnd = new Random();
            //optional: check if tile already has a firepillar on it
            for(int i = 0; i < BWD.BossFirePillarCount; i++)
            {
                //chose random
                
                int j = rnd.Next(1, BossWindow.Arena.Tiles.Count);

                //get tile at random number
                Tile t = BossWindow.Arena.Tiles.ElementAt(j);

                //place fire
                BossFirePillar p = FirePillar.Clone(t);

                BossWindow.MyGameObjects.Add(p);
            }
        }
    }
}
