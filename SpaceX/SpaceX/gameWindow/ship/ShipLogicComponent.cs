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

namespace SpaceX.gameWindow
{
    class ShipLogicComponent : ILogicComponent
    {
        public List<int> CollisionID { set; get; }

        public ShipLogicComponent()
        {
            CollisionID = new List<int>();
        }

        public void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            CollisionID.Remove(fixtureB.Body.BodyId);
        }

        public void OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            UserData u = (UserData)fixtureB.Body.UserData;

            if (u != null && !IsOnList(fixtureB))
            {
                CollisionID.Add(fixtureB.Body.BodyId);

                if (u.Type == "Asteroid")
                {
                    Health.Value -= 1;

                    if (Health.Value <= 0)
                    {
                        //GameOver!
                        GameWindow.GameOver();
                    }

                    //find gameobject of fixture B and play destruction Animation
                    UserData ud = (UserData)fixtureB.Body.UserData;
                    GameObject Asteroid = GameObject.FindById(ud.ID);
                    GameObject.Destroy(Asteroid);
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

        public void Destroy()
        {
        }

        public void Update()
        {
        }
    }
}
