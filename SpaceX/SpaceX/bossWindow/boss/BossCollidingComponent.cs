using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceX.bossWindow.hero;

namespace SpaceX.bossWindow
{
    class BossCollidingComponent : CollidingComponent
    {
        public List<int> CollisionID { set; get; }
        public BossHero Hero { set; get; }
        public Boss Boss { set; get; }

        public BossCollidingComponent(BossHero Hero, Boss Boss)
        {
            this.Hero = Hero;
            this.Boss = Boss;
            CollisionID = new List<int>();
        }

        public override void CollisionHandling()
        {
            UserData u = (UserData)fixtureB.Body.UserData;

            if (u != null && !IsOnList(fixtureB))
            {
                CollisionID.Add(fixtureB.Body.BodyId);

                if (u.Type == "HeroBullet")
                {
                    HeroBullet Bullet = (HeroBullet) GameObject.FindById(u.ID);
                    Bullet.Destroy();

                    Boss.BossHitAudio.Sound.Play();
                    Boss.ApplyDamage();

                    if (Boss.Health <= 0)
                    {
                        //GameOver!
                        BossWindow.IsOver = true;
                    }
                }
            }
        }

        public override void Destroy()
        {
            CollisionID.Clear();
        }

        public override void OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            this.fixtureA = fixtureA;
            this.fixtureB = fixtureB;
            this.contact = contact;
        }

        public override void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            CollisionID.Remove(fixtureB.Body.BodyId);
        }

        public override void Update()
        {
        }

        private bool IsOnList(Fixture f)
        {
            int id = f.Body.BodyId;

            foreach (int i in CollisionID)
            {
                if (i == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
