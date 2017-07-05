using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using SpaceX.bossWindow.boss;
using SpaceX.bossWindow.boss.bossAttackPattern;
using SpaceX.component;
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
        public AudioComponent BossHitAudio { set; get; }
        public int Health { set; get; }
        public Queue<IBossAttackPattern> Patterns { set; get; }
        public BossPatternChanger BPC { set; get; }
        public BossFire BossFire { set; get; }


        public BossPattern1 Pattern1 { set; get; }
        public BossPattern2 Pattern2 { set; get; }
        public BossPattern3 Pattern3 { set; get; }

        public Boss(BossWindowData BWD, BossHero Hero)
        {
            this.BWD = BWD;
            Health = BWD.BossHealth;

            BossHitAudio = new AudioComponent(BWD.BossHitPath, false);
            RC = new RenderingComponent(BWD.BossPosition, BWD.BossTexture, BWD.BossSize, false);
            Vertices v = PhysicsComponent.RechtangleVertices(Converter.RelativeWindow(Converter.Vector(BWD.BossSize)));
            BCC = new BossCollidingComponent(Hero, this);
            PC = new BossPhysicsComponent(BCC, BWD, v);
            RC.AddPhysics(PC);

            BossFire = new BossFire(BWD, this, new Vector2(0, 0));

            Pattern1 = new BossPattern1(this, Hero, BossFire, BWD);
            Pattern2 = new BossPattern2(this, Hero, BossFire, BWD);
            Pattern3 = new BossPattern3(this, Hero, BossFire, BWD);

            Patterns = new Queue<IBossAttackPattern>();
            Patterns.Enqueue(Pattern1);
            Patterns.Enqueue(Pattern2);
            Patterns.Enqueue(Pattern3);

            BPC = new BossPatternChanger(Patterns, this);

            this.AddComponent(BossHitAudio);
            this.AddComponent(RC);
            this.AddComponent(BCC);
            this.AddComponent(PC);
            this.AddComponent(BPC);
            
        }

        public void ApplyDamage()
        {
            Health--;
            BPC.ChangePattern(Health);
        }
    }
}
