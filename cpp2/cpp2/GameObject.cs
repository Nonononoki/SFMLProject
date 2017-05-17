using FarseerPhysics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2
{
    class GameObject
    {

        private const float density = 1f;
        public Vector2 Position { set; get; }
        public Vector2 DefaultPosition { set; get; }
        public Sprite Sprite { set; get; }
        public Texture Texture { set; get; }
        public Body Body { set; get; }
        public Vector2 Direction { set; get; }
        public float Speed { set; get; }
        public Fixture Fixture { set; get; }
        public Vertices Vertices { set; get; }
        public Vector2 Size { set; get; } //width, height or diameter of circles

        private uint id = 0; //current id, no two are the same
        public static uint _id = 0; //counter for Id 
        public static List<GameObject> _list;


        //polygon
        public void Set(Vector2 position, Texture texture, Vertices vertices, Vector2 size, World world)
        {
            Vertices = vertices;
            Body = BodyFactory.CreatePolygon(world, vertices, density);
            Fixture = FixtureFactory.AttachPolygon(Vertices, density, Body);

            BasicSet(position, texture, size, world);
        }

        //Circle
        public void Set(Vector2 position, Texture texture, Vector2 size, World world)
        {
            Body = BodyFactory.CreateCircle(world, ConvertUnits.ToSimUnits(size.X), density);
            Fixture = FixtureFactory.AttachCircle(ConvertUnits.ToSimUnits(size.X), density, Body);
            Body.ResetMassData();

            BasicSet(position, texture, size, world);

            Sprite.Scale = new Vector2f(Size.X*2 / Texture.Size.X, Size.Y*2 / Texture.Size.Y);
        }

        //sets all basic attributes
        private void BasicSet(Vector2 position, Texture texture, Vector2 size, World world)
        {
            Speed = 1f;
            Direction = new Vector2(0, 0);

            this.Size = size;
            this.Position = position;
            this.Texture = texture;
            this.DefaultPosition = Position;

            //Sprite handling
            Sprite = new Sprite();
            Sprite.Position = new Vector2f(Position.X, Position.Y);
            Sprite.Scale = new Vector2f(Size.X / Texture.Size.X, Size.Y / Texture.Size.Y);
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2); 
            Sprite.Texture = texture;

            //Body settings
            Body.Position = ConvertUnits.ToSimUnits(Position);
            //Body.Position = position;
            Body.Awake = true;

            ID();
        }

        //move body with sprite while moving
        public void Move()
        {
            Vector2 impulse = Direction * Speed * Body.Mass;
            Body.LinearVelocity = new Vector2(0, 0);
            Body.ApplyLinearImpulse(impulse);

            //Body.ApplyForce(impulse);
        }

        private void ID() //assign id, count id
        {
            if (_list == null)
            {
                _list = new List<GameObject>();
            }

            id = _id++;
            _list.Add(this);
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

        //for debugging
        public GameObject FindById(uint id)
        {
            foreach (GameObject g in _list)
            {
                if (g.id == id)
                {
                    return g;
                }
            }
            return null;
        }

        //update sprite and with body Position
        public void UpdatePosition()
        {   
            Position = ConvertUnits.ToDisplayUnits(Body.Position);
            Sprite.Position = new Vector2f(Position.X, Position.Y);                     
        }

        //instantly move go to position
        public void SetPosition(Vector2 v)
        {
            Position = v;
            Body.Position = ConvertUnits.ToSimUnits(v);
            Sprite.Position = new Vector2f(v.X, v.Y);
        }

        //destroy GameObject
        public void Destroy()
        {
            _list.Remove(this);
            this.Body.Dispose();
            this.Sprite.Dispose();
        }

        //destroy every gameObject on the list
        public static void DestroyAll()
        {
            foreach(GameObject g in _list)
            {
                g.Body.Dispose();
                g.Sprite.Dispose();
            }
        }
    }
}
