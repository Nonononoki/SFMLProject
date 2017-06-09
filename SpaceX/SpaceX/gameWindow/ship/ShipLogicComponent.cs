using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceX.component;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceX.gameWindow.hud;
using SpaceX.window;
using SpaceX.gameObject;

namespace SpaceX.gameWindow
{
    class ShipLogicComponent : ICollidingComponent
    {
        public List<int> CollisionID { set; get; }
        public Ship Ship { set; get; }

        public ShipLogicComponent(Ship ship)
        {
            CollisionID = new List<int>();
            this.Ship = ship;
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

                if (u.Type == "Asteroid")
                {
                    Ship.ShipHitAudio.Sound.Play();
                    Health.Value -= 1;

                    if (Health.Value <= 0)
                    {
                        //GameOver!
                        GameWindow.GameOver();
                    }

                    //find gameobject of fixture B and play destruction Animation
                    UserData ud = (UserData)fixtureB.Body.UserData;
                    GameObject Asteroid = GameObject.FindById(ud.ID);
                    //GameObject.Destroy(Asteroid);
                    GameWindow.ToBeRemoved.Add(Asteroid);
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

        public override void Destroy()
        {
            CollisionID = null;
        }

        public override void Update()
        {
        }
    }
}
