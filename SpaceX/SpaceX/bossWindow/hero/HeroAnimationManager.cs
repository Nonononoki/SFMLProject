using SFML.Graphics;
using SpaceX.component;
using SpaceX.gameOverWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.hero
{
    class HeroAnimationManager : GameObject //empty gameobject
    {
        public AnimationComponent AnimationRight { set; get; }
        public AnimationComponent AnimationLeft { set; get; }
        public AnimationComponent AnimationUp { set; get; }
        public AnimationComponent AnimationDown { set; get; }

        public Sprite Up { set; get; }
        public Sprite Down { set; get; }
        public Sprite Left { set; get; }
        public Sprite Right { set; get; }

        private BossWindowData BWD;
        private BossHero Hero;

        public bool Idle { set; get; }

        public HeroDirections Direction { set;get; }

        public HeroAnimationManager(BossWindowData BWD, BossHero Hero)
        {
            //Default direction is up
            Direction = new HeroDirections()
            {
                Value = HeroDirections.Direction.Up
            };

            this.BWD = BWD;
            this.Hero = Hero;

            AnimationUp = new AnimationComponent(BWD.HeroUpAni, BWD.HeroAniSpeed, Hero.RC, null, true);
            AnimationDown = new AnimationComponent(BWD.HeroDownAni, BWD.HeroAniSpeed, Hero.RC, null, true);
            AnimationLeft = new AnimationComponent(BWD.HeroLeftAni, BWD.HeroAniSpeed, Hero.RC, null, true);
            AnimationRight = new AnimationComponent(BWD.HeroRightAni, BWD.HeroAniSpeed, Hero.RC, null, true);

            Up = BWD.HeroUp;
            Down = BWD.HeroDown;
            Left = BWD.HeroLeft;
            Right = BWD.HeroRight;

            Direction.AC = AnimationUp;
            Hero.AddComponent(Direction.AC);
            Hero.GetComponent<AnimationComponent>().Start();
        }


        public void ChangeDirection(HeroDirections.Direction NewDirection)
        {
            //only change if current direction is not the same
            if(NewDirection != this.Direction.Value)
            {
                Hero.RemoveComponent(Direction.AC);

                AnimationComponent newAni = null;

                if (NewDirection == HeroDirections.Direction.Up)
                    newAni = AnimationUp;
                else if (NewDirection == HeroDirections.Direction.Down)
                    newAni = AnimationDown;
                else if (NewDirection == HeroDirections.Direction.Left)
                    newAni = AnimationLeft;
                else if (NewDirection == HeroDirections.Direction.Right)
                    newAni = AnimationRight;

                Direction.Value = NewDirection;
                Direction.AC = newAni;
                Hero.AddComponent(Direction.AC);
                Hero.GetComponent<AnimationComponent>().Start();

            }

        }
    }
}
