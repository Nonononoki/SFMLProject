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
             
            this.Body = BodyFactory.CreatePolygon(world, Vertices, density, Position);
            this.Body.Position = this.Position;

            Sprite = new Sprite();
            Sprite.Texture = texture;
        }

        //Circle
        public void Set(Vector2 position, Texture texture, Vector2 size, ref World world)
        {
            this.Position = position;
            this.Size = size;

            this.Body = BodyFactory.CreateCircle(world, Size.X, density, Position);
            this.Body.Position = this.Position;

            Sprite = new Sprite();
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
