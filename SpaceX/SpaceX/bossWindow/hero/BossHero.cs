﻿using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using SFML.Graphics;
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
        public HPbar HealthBar { set; get; }
        public int Health { set; get; }

        public AudioComponent HeroDeathAudio { set; get; }
        public AudioComponent HeroHitAudio { set; get; }
        public Vector2 FacingDirection { set; get; }
        public HeroBullet Bullet { set; get; }
        public HeroAnimationManager AM { set; get; }


        public BossHero(BossWindowData BWD)
        {
            this.BWD = BWD;
            FacingDirection = new Vector2(0, -1);
            Health = BWD.HeroHealth;

            //components
            Coll = new BossHeroCollidingComponent(this);
            RC = new RenderingComponent(BWD.HeroPosition, BWD.HeroTexture, BWD.HeroSize, false);
            Vertices v = PhysicsComponent.RechtangleVertices(Converter.RelativeWindow(Converter.Vector(BWD.HeroSize)));
            PC = new BossHeroPhysicsComponent(Coll, BWD, v);
            HCC = new BossHeroControllerComponent(this, BWD);
            HeroHitAudio = new AudioComponent(BWD.HeroHitPath, false);
            HeroDeathAudio = new AudioComponent(BWD.HeroDeathPath, false);
            HealthBar = new HPbar(BWD.HeroHPBarPosition, BWD.HeroHPBarSize, null, Color.Green, Health, BWD);

            AM = new HeroAnimationManager(BWD, this);
            BossWindow.MyGameObjects.Add(AM);

            //connect components
            RC.AddPhysics(PC);
            PC.CC = Coll;

            this.AddComponent(RC);
            this.AddComponent(PC);
            this.AddComponent(HCC);
            this.AddComponent(Coll);
            this.AddComponent(HealthBar);
            

            Bullet = new HeroBullet(BWD, this, FacingDirection);
        }

        public void ApplyDamage()
        {
            HeroHitAudio.Sound.Play();
            Health--;

            if (Health <= 0)
            {
                HeroDeathAudio.Sound.Play();
                //GameOver!
                BossWindow.IsOver = true;
            }

            //Resize HealthBar
            HealthBar.Resize(Health);
        }
    }
}
