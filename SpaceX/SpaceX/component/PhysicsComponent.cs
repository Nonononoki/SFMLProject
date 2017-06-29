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
using SpaceX.window;
using SpaceX.component;

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
        public World World { set; get; }
        public CollidingComponent CC { set; get; }

        public PhysicsComponent(Vector2 Position, Vector2 Size, Vertices vertices, World World, bool IsCircle)
        {
            this.World = World;

            if(IsCircle)
            {
                //Make it relative to window, need to do it manually for non-circles
                Vector2 nSize = Converter.RelativeWindow(Size);
                //Body and Fixture for circles
                Body = BodyFactory.CreateCircle(World, ConvertUnits.ToSimUnits(nSize.X), density);
                Fixture = FixtureFactory.AttachCircle(ConvertUnits.ToSimUnits(nSize.X), density, Body);
            }
            else
            {
                //Body and Fixture for polygons
                Vertices = vertices;
                Body = BodyFactory.CreatePolygon(World, vertices, density);
                Fixture = FixtureFactory.AttachPolygon(Vertices, density, Body);
            }

            Body.Position = ConvertUnits.ToSimUnits(Position);
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
            Vector2 impulse = Direction * Speed / Body.Mass;          
            Body.ApplyLinearImpulse(impulse);           
        }

        public void Destroy()
        {
            World.RemoveBody(Body);
            Fixture = null;
            Vertices = null;
            Body = null;
        }
    }
}
