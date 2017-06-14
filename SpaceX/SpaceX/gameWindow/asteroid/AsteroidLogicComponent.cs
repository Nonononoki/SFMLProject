using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceX.component;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidLogicComponent : ICollidingComponent
    {
        public Asteroid Asteroid { set; get; }
        public List<int> CollisionID { set; get; }
        public Stopwatch SW { set; get; }

        public AsteroidLogicComponent(Asteroid Asteroid)
        {
            this.Asteroid = Asteroid;
            CollisionID = new List<int>();

            SW = new Stopwatch();
        }

        public override void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            CollisionID.Remove(fixtureB.Body.BodyId);
        }

        public override void OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            this.fixtureA = fixtureA;
            this.fixtureB = fixtureB;
            this.contact = contact;
        }

        public override void CollisionHandling()
        {
            UserData u = (UserData)fixtureB.Body.UserData;

            if (u != null && !IsOnList(fixtureB))
            {
                CollisionID.Add(fixtureB.Body.BodyId);

                if (u.Type == "Bullet")
                {
                    //Destroy Bulllet
                    UserData bulletData = (UserData)fixtureB.Body.UserData;
                    GameObject Bullet = GameObject.FindById(bulletData.ID);

                    //GameObject.Destroy(Bullet);
                    GameWindow.ToBeRemoved.Add(Bullet);

                    //reduce asteroid hp
                    Asteroid.Health--;

                    //Play Hit Animation
                    Asteroid.HitAnimation.Start();

                    if (Asteroid.Health <= 0)
                    {
                        Score.Value += Asteroid.Points;
                        DestroyAsteroidWithAnimation();
                    }
                    else
                    {
                        Asteroid.AsteroidHitSFX.Sound.Play();
                    }
                }
            }
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


        public override void Update()
        {
            //self destruct after a while
            if (SW.ElapsedMilliseconds >= Asteroid.Duration)
            {
                Asteroid.Destroy();
                SW.Reset();
            }
        }

        public override void Destroy()
        {
            //throw new NotImplementedException();
        }

        public void DestroyAsteroidWithAnimation()
        {
            Asteroid.APC.Body.CollisionCategories = Category.Cat3;
            Asteroid.AsteroidDestroySFX.Sound.Play();
            Asteroid.DestructionAnimation.Start();
        }
    }
}
