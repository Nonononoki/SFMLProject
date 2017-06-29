using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics;
using SpaceX.component;
using FarseerPhysics.Dynamics.Contacts;

namespace SpaceX.bossWindow.hero
{
    class BossHeroPhysicsComponent : PhysicsComponent
    {
        public BossHeroPhysicsComponent(CollidingComponent CC, BossWindowData BWD, Vertices v) 
            : base(Converter.RelativeWindow(Converter.Vector(BWD.HeroPosition)), Converter.Vector(BWD.HeroSize), v, BossWindow.World, false)
        {
            Fixture.OnCollision += OnCollision;
            Fixture.OnSeparation += OnSeparation;
            this.CC = CC;

            Speed = BWD.HeroSpeed;

            Body.BodyType = BodyType.Dynamic;
            Body.Mass = BWD.HeroMass;
            Body.CollisionCategories = Category.Cat1;
            Body.CollidesWith = Category.Cat3 | Category.Cat4;
        }

        private void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            CC.OnSeparation(fixtureA, fixtureB);
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            CC.OnCollision(fixtureA, fixtureB, contact);
            BossWindow.CollisionList.Add(CC);
            return true;
        }
    }
}
