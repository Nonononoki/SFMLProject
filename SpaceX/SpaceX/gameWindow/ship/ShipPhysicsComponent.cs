﻿using System;
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
        public ShipPhysicsComponent(GameWindowData gwd, ShipLogicComponent SLC, Ship Ship) 
            : base(Ship.Position, gwd.MyShipSize, gwd.MyShipVertices, false)
        {
            Fixture.OnCollision += OnCollision;
            Fixture.OnSeparation += OnSeparation;
            this.SLC = SLC;

            Body.BodyType = BodyType.Dynamic;
            Body.Mass = gwd.MyShipMass;
            Body.CollisionCategories = Category.Cat1;
            Body.CollidesWith = Category.Cat2;
        }

        private void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            SLC.OnSeparation(fixtureA, fixtureB);
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            SLC.OnCollision(fixtureA, fixtureB, contact);
            return true;
        }
    }
}
