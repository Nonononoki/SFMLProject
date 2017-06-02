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
using SFML.System;

namespace SpaceX
{
    class PhysicsComponent : IComponent
    {
        private const float density = 1f;
        public Body Body { set; get; }
        public float Speed { set; get; }
        public Vector2 Size { set; get; } //in World Units
        public Fixture Fixture { set; get; }
        public Vertices Vertices { set; get; }
        public Vector2 Direction { set; get; }

        public PhysicsComponent(Vector2 Position, Vector2 Size, Vertices vertices, bool IsCircle)
        {
            if(IsCircle)
            {
                //Body and Fixture for circles
                Body = BodyFactory.CreateCircle(Program.World, ConvertUnits.ToSimUnits(Size.X), density);
                Fixture = FixtureFactory.AttachCircle(ConvertUnits.ToSimUnits(Size.X), density, Body);
            }
            else
            {
                //Body and Fixture for polygons
                Vertices = vertices;
                Body = BodyFactory.CreatePolygon(Program.World, vertices, density);
                Fixture = FixtureFactory.AttachPolygon(Vertices, density, Body);
            }

            Vector2 newPos = ConvertUnits.ToSimUnits(Converter.Vector( new Vector2f(Position.X * Program.Window.Size.X, Position.Y * Program.Window.Size.Y) / 100));
            Body.Position = newPos;

            this.Size = Size;

            Direction = new Vector2(0, 0);

            Body.Awake = true;
            Speed = 0;
        }
        public void AddUserData(GameObject go, String type)
        {
            UserData ud = new UserData(type, go.id);
            Body.UserData = ud;           
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

        public void Move(Vector2 Direction)
        {            
            Vector2 impulse = Direction * Speed * Body.Mass;          
            Body.ApplyLinearImpulse(impulse);           
        }

        public void Destroy()
        {
            Body = null;
        }
    }
}
