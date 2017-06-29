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
        public BossPattern1 Pattern1 { set; get; }
        public Queue<IBossAttackPattern> Patterns { set; get; }
        public BossFire BossFire { set; get; }

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
            Patterns = new Queue<IBossAttackPattern>();
            Patterns.Enqueue(Pattern1);

            this.AddComponent(BossHitAudio);
            this.AddComponent(RC);
            this.AddComponent(BCC);
            this.AddComponent(PC);
            this.AddComponent(Patterns.Dequeue());
        }

        public void ApplyDamage()
        {
            Health--;
        }
    }
}
