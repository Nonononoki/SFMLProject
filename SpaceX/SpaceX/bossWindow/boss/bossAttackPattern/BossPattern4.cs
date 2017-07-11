using FarseerPhysics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.boss.bossAttackPattern
{
    class BossPattern4 : IBossAttackPattern
    {
        //Pattern1 Move to Player X

        public Boss Boss { set; get; }
        public BossHero Hero { set; get; }
        public Stopwatch SW { set; get; }
        public BossWindowData BWD { set; get; }
        public Vector2 FireDirection { set; get; }
        public BossFire Clone { set; get; }

        private bool IsOnPoint = false;
        private Vector2 Point;

        private float factor = 0.5f;

        public BossPattern4(Boss Boss, BossHero Hero, BossFire Clone, BossWindowData BWD)
        {
            //move boss to middle, hurl fireballs at Hero
            //fire twice as fast with fire balls moving twice as slow

            FireDirection = new Vector2(0, 0);
            this.Boss = Boss;
            this.Hero = Hero;
            this.BWD = BWD;
            this.Clone = Clone;

            Point = ConvertUnits.ToSimUnits( new Vector2(Program.Window.Size.X / 2, Program.Window.Size.Y / 2) );

            SW = new Stopwatch();
            SW.Start();
        }

        public void Destroy()
        {
            //throw new NotImplementedException();
            SW = null;
            Boss.PC.Body.BodyType = FarseerPhysics.Dynamics.BodyType.Dynamic;
        }

        public void Update()
        {
            if(!IsOnPoint)
            {
                Boss.PC.Body.LinearVelocity = new Vector2(0, 0);

                //move boss to center
                Vector2 dir = Point - Boss.PC.Body.Position;
                dir = Converter.ResizeVector(dir, 1);
                Boss.PC.Move(dir);

                //teleport to Position if close enough
                float margin = 0.1f;
                if (Boss.PC.Body.Position.X <= Point.X + margin &&
                    Boss.PC.Body.Position.X >= Point.X - margin &&
                    Boss.PC.Body.Position.Y <= Point.Y + margin &&
                    Boss.PC.Body.Position.Y >= Point.Y - margin)
                {
                    Boss.PC.Body.Position = Point;               
                    IsOnPoint = true;
                }
            }

            else
            {
                Boss.PC.Body.BodyType = FarseerPhysics.Dynamics.BodyType.Static;

                //spawn random lava on board


                //here
            }

            //fire!
            if (SW.ElapsedMilliseconds * factor >= BWD.BossFireCooldown)
            {
                SpawnFireBall();
            }
        }

        public void SpawnFireBall()
        {
            FireDirection = Hero.PC.Body.Position - Boss.PC.Body.Position;
            FireDirection = Converter.ResizeVector(FireDirection, 1f * factor);

            BossFire Fire = Clone.Clone(FireDirection);
            BossWindow.MyGameObjects.Add(Fire);
            Fire.Shoot();
            SW.Restart();
        }
    }
}
