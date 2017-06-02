using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using SpaceX.gameObject;
using SpaceX.window;

namespace SpaceX.gameWindow
{
    class ShipPhysicsComponent : PhysicsComponent
    {
        public ShipLogicComponent SLC { set; get; }
        public ShipPhysicsComponent(GameWindowData gwd, ShipLogicComponent SLC) 
            : base(gwd.MyShipPosition, gwd.MyShipSize, gwd.MyShipVertices, false)
        {
            Fixture.OnCollision += OnCollision;
            this.SLC = SLC;

            Body.BodyType = BodyType.Dynamic;
            Body.Mass = gwd.MyShipMass;
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            SLC.OnCollision(fixtureA, fixtureB, contact);
            return true;
        }
    }
}
