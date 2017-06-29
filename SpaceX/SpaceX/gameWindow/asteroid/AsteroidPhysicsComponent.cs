using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using SpaceX.window;
using SFML.System;
using SpaceX.component;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidPhysicsComponent : PhysicsComponent
    {
        public CollidingComponent ALC { set; get; }
        public AsteroidPhysicsComponent(Asteroid Asteroid, AsteroidLogicComponent ALC) 
            : base(Converter.Vector(Asteroid.Position), Converter.Vector(Converter.RelativeWindow(new Vector2f(Asteroid.Size, Asteroid.Size))), null, GameWindow.World, true)
        {
            Fixture.OnCollision += OnCollision;
            Fixture.OnSeparation += OnSeparation;
            this.ALC = ALC;

            Body.BodyType = BodyType.Dynamic;
            Body.Mass = Asteroid.Mass;
            this.Speed = Asteroid.Speed;
            Body.UserData = new UserData("Asteroid", Asteroid.id);

            Body.CollisionCategories = Category.Cat2;
            Body.CollidesWith = Category.Cat1 | Category.Cat3;
        }

        private void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            ALC.OnSeparation(fixtureA, fixtureB);
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            ALC.OnCollision(fixtureA, fixtureB, contact);
            GameWindow.CollisionList.Add(ALC);
            return true;
        }
    }
}
