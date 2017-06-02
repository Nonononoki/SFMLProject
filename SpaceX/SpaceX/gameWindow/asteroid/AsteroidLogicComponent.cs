using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidLogicComponent : ILogicComponent
    {
        public int AsteroidHealth;

        public AsteroidLogicComponent(int AsteroidHealth)
        {
            this.AsteroidHealth = AsteroidHealth;
        }
        public void Destroy()
        {
        }

        public void Update()
        {
        }

        public void OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            UserData u = (UserData)fixtureB.UserData;

            if (u != null)
            {
                if (u.Type == "Bullet" )
                {
                    //reduce asteroid hp
                    AsteroidHealth--;

                    if (AsteroidHealth <= 0)
                    {
                        //find gameobject of fixture B and play destruction Animation
                        UserData ud = (UserData)fixtureB.Body.UserData;
                        GameObject.FindById(ud.ID).GetComponent<RenderingComponent>().PlayDestructionAnimation(ud);
                        //afterwards, destroy gameobject
                        GameObject.FindById(ud.ID).Destroy();
                    }
                }
            }
        }
    }
}
