using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceX.component;

namespace SpaceX.bossWindow.boss
{
    class BossPhysicsComponent : PhysicsComponent
    {
        public BossPhysicsComponent(CollidingComponent CC, BossWindowData BWD, Vertices v)
            : base(Converter.RelativeWindow(Converter.Vector(BWD.BossPosition)), Converter.Vector(BWD.BossSize), v, BossWindow.World, false)
        {
            Fixture.OnCollision += OnCollision;
            Fixture.OnSeparation += OnSeparation;
            this.CC = CC;

            Speed = BWD.BossSpeed;

            Body.BodyType = BodyType.Dynamic;
            Body.Mass = BWD.BossMass;
            Body.CollisionCategories = Category.Cat3;
            Body.CollidesWith = Category.Cat1 | Category.Cat2;
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
