using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceX.component;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceX.gameWindow.hud;

namespace SpaceX.gameWindow
{
    class ShipLogicComponent : ILogicComponent
    {
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
                if (u.Type == "Asteroid")
                {
                    Health.Value--;

                    if (Health.Value <= 0)
                    {
                        //GameOver!
                    }

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
