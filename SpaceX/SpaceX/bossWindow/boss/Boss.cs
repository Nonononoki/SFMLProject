﻿using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using SpaceX.bossWindow.boss;
using SpaceX.bossWindow.boss.bossAttackPattern;
using SpaceX.component;
using SpaceX.gameOverWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class Boss : GameObject
    {
        public RenderingComponent RC { set; get; }
        public BossPhysicsComponent PC { set; get; }
        public BossCollidingComponent BCC { set; get; }
        public BossWindowData BWD { set; get; }
        public AudioComponent HitAudio { set; get; }
        public AudioComponent DeathAudio { set; get; }
        public int Health { set; get; }
        public Queue<IBossAttackPattern> Patterns { set; get; }
        public BossPatternChanger BPC { set; get; }
        public BossFire BossFire { set; get; }
        public AnimationComponent IdleAnimation { set; get; }
        public HPbar HealthBar { set; get; }


        public BossPattern1 Pattern1 { set; get; }
        public BossPattern2 Pattern2 { set; get; }
        public BossPattern3 Pattern3 { set; get; }
        public BossPattern4 Pattern4 { set; get; }
        public BossPattern5 Pattern5 { set; get; }

        public Boss(BossWindowData BWD, BossHero Hero)
        {
            this.BWD = BWD;
            Health = BWD.BossHealth;

            DeathAudio = new AudioComponent(BWD.BossDeathPath, false);
            HitAudio = new AudioComponent(BWD.BossHitPath, false);
            RC = new RenderingComponent(BWD.BossPosition, BWD.BossTexture, BWD.BossSize, false);
            Vertices v = PhysicsComponent.RechtangleVertices(Converter.RelativeWindow(Converter.Vector(BWD.BossSize)));
            BCC = new BossCollidingComponent(Hero, this);
            PC = new BossPhysicsComponent(BCC, BWD, v);
            IdleAnimation = new AnimationComponent(BWD.BossIdleAni, BWD.BossAniSpeed, RC, null, true);
            IdleAnimation.Start();
            RC.AddPhysics(PC);

            HealthBar = new HPbar(BWD.BossHPBarPosition, BWD.BossHPBarSize, "Boss", BWD.BossHPBarColor, Health, BWD);

            BossFire = new BossFire(BWD, this, new Vector2(0, 0));

            Pattern1 = new BossPattern1(this, Hero, BossFire, BWD);         
            Pattern2 = new BossPattern2(this, Hero, BossFire, BWD);           
            Pattern3 = new BossPattern3(this, Hero, BossFire, BWD);
            Pattern4 = new BossPattern4(this, Hero, BossFire, BWD);         
            Pattern5 = new BossPattern5(this, Hero, BossFire, BWD);
            
            Patterns = new Queue<IBossAttackPattern>();
            
            Patterns.Enqueue(Pattern1);
            Patterns.Enqueue(Pattern2);
            Patterns.Enqueue(Pattern3);
            Patterns.Enqueue(Pattern4);
            Patterns.Enqueue(Pattern5);


            BPC = new BossPatternChanger(Patterns, this);

            this.AddComponent(HitAudio);
            this.AddComponent(RC);
            this.AddComponent(BCC);
            this.AddComponent(PC);
            this.AddComponent(BPC);
            this.AddComponent(IdleAnimation);
            this.AddComponent(HealthBar);
            
        }

        public void ApplyDamage()
        {
            Health--;
            HitAudio.Sound.Play();
            BPC.ChangePattern(Health);

            if (Health <= 0)
            {
                DeathAudio.Sound.Play();
                //GameOver!
                BossWindow.IsOver = true;
            }

            //Resize HealthBar
            HealthBar.Resize(Health);
        }
    }
}
