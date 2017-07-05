using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using SpaceX.bossWindow.hero;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class BossHero : GameObject
    {
        public BossWindowData BWD { set; get; }
        public BossHeroControllerComponent HCC { set; get; }
        public RenderingComponent RC { set; get; }
        public BossHeroPhysicsComponent PC { set; get; }
        public BossHeroCollidingComponent Coll { set; get; }
        public static bool IsInvincible { set; get; }
        public static int InvincibilityCoolDown { set; get; }

        public AudioComponent HeroHitAudio { set; get; }
        public Vector2 FacingDirection { set; get; }
        public HeroBullet Bullet { set; get; }
        public HeroAnimationManager AM { set; get; }


        public BossHero(BossWindowData BWD)
        {
            this.BWD = BWD;
            IsInvincible = false;
            FacingDirection = new Vector2(0, -1);

            //components
            Coll = new BossHeroCollidingComponent(this);
            RC = new RenderingComponent(BWD.HeroPosition, BWD.HeroTexture, BWD.HeroSize, false);
            Vertices v = PhysicsComponent.RechtangleVertices(Converter.RelativeWindow(Converter.Vector(BWD.HeroSize)));
            PC = new BossHeroPhysicsComponent(Coll, BWD, v);
            HCC = new BossHeroControllerComponent(this, BWD);
            HeroHitAudio = new AudioComponent(BWD.HeroHitPath, false);

            AM = new HeroAnimationManager(BWD, this);
            BossWindow.MyGameObjects.Add(AM);

            //connect components
            RC.AddPhysics(PC);
            PC.CC = Coll;

            this.AddComponent(RC);
            this.AddComponent(PC);
            this.AddComponent(HCC);
            this.AddComponent(Coll);
            

            Bullet = new HeroBullet(BWD, this, FacingDirection);
        }

        public void BecomeInvincible()
        {
            //create new thread and wait for cooldown

        }
    }
}
