using FarseerPhysics;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Dynamics.Contacts;

namespace SpaceX
{
    class PhysicsComponent : IComponent
    {
        private const float density = 1f;
        public Body Body { set; get; }
        public Vector2 Direction { set; get; }
        public float Speed { set; get; }
        public Fixture Fixture { set; get; }
        public Vertices Vertices { set; get; }

        public PhysicsComponent(Vector2 Position, Vector2 Size, Vertices vertices, bool IsCircle, World World)
        {
            if(IsCircle)
            {
                //Body and Fixture for polygon
                Body = BodyFactory.CreateCircle(World, ConvertUnits.ToSimUnits(Size.X), density);
                Fixture = FixtureFactory.AttachCircle(ConvertUnits.ToSimUnits(Size.X), density, Body);
            }
            else
            {
                //Body and Fixture for Circles
                Vertices = vertices;
                Body = BodyFactory.CreatePolygon(World, vertices, density);
                Fixture = FixtureFactory.AttachPolygon(Vertices, density, Body);
            }

            Body.Position = Position;

            Body.Awake = true;
            Direction = new Vector2(0, 0);
            Speed = 0;
        }

        public void AddGameObjectID(GameObject go)
        {
            //Add gameobject id to body userdata
            uint id = go.id;
            Body.UserData = id;
        }

        //create rechtangle vertices
        public static Vertices RechtangleVertices(Vector2 size)
        {
            size = ConvertUnits.ToSimUnits(size);
            Vertices v = new Vertices();
            v.Add(new Vector2(size.X / 2, size.Y / 2));
            v.Add(new Vector2(size.X / 2, -size.Y / 2));
            v.Add(new Vector2(-size.X / 2, size.Y / 2));
            v.Add(new Vector2(-size.X / 2, -size.Y / 2));

            return v;
        }

        public void Update()
        {

        }

        public void Move()
        {
            Vector2 impulse = Direction * Speed * Body.Mass;
            Body.LinearVelocity = new Vector2(0, 0);
            Body.ApplyLinearImpulse(impulse);
        }

        public void Destroy()
        {
            Body = null;
        }
    }
}
