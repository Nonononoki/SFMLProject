using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
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
            this.Position = position;
            this.Vertices = vertices;
            this.Size = size;
            this.Texture = texture;
             
            Body = BodyFactory.CreatePolygon(world, Vertices, density, Position);
            Fixture = FixtureFactory.AttachPolygon(Vertices, density, Body);

            //Sprite handling
            Sprite = new Sprite();
            Sprite.Scale = new Vector2f(Size.X / Texture.Size.X, Size.Y / Texture.Size.Y);
            Sprite.Position = new Vector2f(Position.X, Position.Y);
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            Sprite.Texture = texture;

            ID();

        }

        //Circle
        public void Set(Vector2 position, Texture texture, Vector2 size, ref World world)
        {
            this.Position = position;
            this.Size = size;
            this.Texture = texture;

            Body = BodyFactory.CreateCircle(world, Size.X, density, Position);
            Fixture = FixtureFactory.AttachCircle(Size.X, density, Body);

            //Sprite handling
            Sprite = new Sprite();
            Sprite.Scale = new Vector2f(Size.X / Texture.Size.X, Size.Y / Texture.Size.Y);
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            Sprite.Position = new Vector2f(Position.X, Position.Y);
            Sprite.Texture = texture;

            ID();
        }

        //move body with sprite while moving
        public void Move(Vector2 v)
        {
            Sprite.Position = new Vector2f(Sprite.Position.X + v.X, Sprite.Position.Y + v.Y);
            Body.Position = Body.Position + v;

            ID();
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
