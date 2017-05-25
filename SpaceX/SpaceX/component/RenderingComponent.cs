using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    class RenderingComponent : IComponent
    {
        public Sprite Sprite { set; get; }
        PhysicsComponent _physics { set; get; } //reference to _physics of GameObject

        public RenderingComponent(Vector2f Position, Texture Texture, Vector2f Size, RenderWindow Window, bool IsCirlce)
        {
            //Position is in percentage
            Sprite = new Sprite();
            Sprite.Position = new Vector2f(Position.X/100 * Window.Size.X, Position.Y/100 * Window.Size.Y);        

            Sprite.Texture = Texture;
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);

            //Size is also in percentage
            if(IsCirlce) Sprite.Scale = new Vector2f((Size.X * 2 / 100) * Window.Size.X / Texture.Size.X, (Size.Y * 2 / 100) * Window.Size.X / Texture.Size.Y);
            else Sprite.Scale = new Vector2f( (Size.X * 2 / 100) * Window.Size.X  / Texture.Size.X, (Size.Y * 2 / 100) * Window.Size.Y / Texture.Size.Y);
        }

        public void Update()
        {
            if (_physics != null)
            {
                Vector2f v = new Vector2f(ConvertUnits.ToDisplayUnits(_physics.Body.Position.X), ConvertUnits.ToDisplayUnits(_physics.Body.Position.Y));
                this.Sprite.Position = v;
            }
        }

        public void Destroy()
        {
            Sprite = null;
        }
    }
}
