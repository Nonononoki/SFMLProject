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
        public Sprite Sprite { set; get; }
        public Texture Texture { set; get; }
        public Body Body { set; get; }
        public Vector2 Direction { set; get; }
        public float Speed { set; get; }


        //debugging
        public SFML.Graphics.Shape Shape { set; get; }

        //public FarseerPhysics.Collision.Shapes.Shape Shape { set; get; }
        public Fixture Fixture { set; get; }
        public Vertices Vertices { set; get; }
        public Vector2 Size { set; get; } //width, height or radius

        private uint id = 0; //current id, no two are the same
        public static uint _id = 0; //counter for Id 
        public static List<GameObject> _list;


        //polygon
        public void Set(Vector2 position, Texture texture, Vertices vertices, Vector2 size, ref World world)
        {
            BasicSet(position, texture, size, ref world);

            Vertices = vertices;           
            Body = BodyFactory.CreatePolygon(world, Vertices, density, Position);
            Body.BodyType = BodyType.Dynamic;
            Body.Awake = true;
            Fixture = FixtureFactory.AttachPolygon(Vertices, density, Body);

            //debugging
            Shape = new SFML.Graphics.RectangleShape(new Vector2f(Size.X, Size.Y));
            Shape.Origin = new Vector2f(Size.X / 2, Size.Y / 2);
            Shape.Position = new Vector2f(Position.X, Position.Y);
        }

        //Circle
        public void Set(Vector2 position, Texture texture, Vector2 size, ref World world)
        {
            BasicSet(position, texture, size, ref world);

            this.Size = size/2; //radius is only half the size
            Body = BodyFactory.CreateCircle(world, Size.X, density, Position);
            Body.BodyType = BodyType.Dynamic;
            Body.Awake = true;
            Fixture = FixtureFactory.AttachCircle(Size.X, density, Body);

            //debugging
            Shape = new SFML.Graphics.CircleShape(Size.X);
            Shape.FillColor = Color.Red;
            Shape.Origin = new Vector2f(Size.X, Size.Y);
            Shape.Position = new Vector2f(Position.X, Position.Y);
        }

        //sets all basic attributes
        private void BasicSet(Vector2 position, Texture texture, Vector2 size, ref World world)
        {
            Speed = 1f;
            Direction = new Vector2(0, 0);

            this.Size = size;
            this.Position = position;
            this.Texture = texture;
            
            //Sprite handling
            Sprite = new Sprite();
            Sprite.Position = new Vector2f(Position.X, Position.Y);
            Sprite.Scale = new Vector2f(Size.X / Texture.Size.X, Size.Y / Texture.Size.Y);
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2); 
            Sprite.Texture = texture;

            ID();
        }

        //move body with sprite while moving
        public void Move(float dt)
        {
            Body.ApplyLinearImpulse(Direction * Speed);
            Position = Body.Position;
      
            Sprite.Position = new Vector2f(Position.X, Position.Y);
            Shape.Position = new Vector2f(Position.X, Position.Y);
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
    }
}
