using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.component
{
    abstract class CollidingComponent : ILogicComponent
    {
        public Fixture fixtureA;
        public Fixture fixtureB;
        public Contact contact;

        public abstract void OnSeparation(Fixture fixtureA, Fixture fixtureB);
        public abstract void OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact);
        public abstract void CollisionHandling();

        public abstract void Update();

        public abstract void Destroy();
    }
}
