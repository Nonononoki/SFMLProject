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
        public bool IsVisible { set; get; }
        PhysicsComponent _physics { set; get; } //reference to _physics of GameObject

        public RenderingComponent(Vector2f Position, Texture Texture, Vector2f Size, bool IsCircle)
        {
            IsVisible = true;

            //Position is in percentage
            Sprite = new Sprite();
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            Sprite.Position = Converter.RelativeWindow(Position);
            Sprite.Texture = Texture;

            //Size is also in percentage
            if (IsCircle) Sprite.Scale = new Vector2f(Size.X * Program.Window.Size.X / Texture.Size.X, Size.Y * Program.Window.Size.X / Texture.Size.Y) / 100 * 2;
            else Sprite.Scale = new Vector2f( Size.X / Texture.Size.X * Program.Window.Size.X, Size.Y / Texture.Size.Y * Program.Window.Size.Y) / 100;
        }

        public void AddPhysics(PhysicsComponent pc)
        {
            _physics = pc;
        }

        public void Draw()
        {
            if (Sprite != null && IsVisible)
                Program.Window.Draw(Sprite);
        }

        public void Update()
        {
            
            if (_physics != null && _physics.Body != null)
            {
                Vector2f v = new Vector2f(ConvertUnits.ToDisplayUnits(_physics.Body.Position.X),
                ConvertUnits.ToDisplayUnits(_physics.Body.Position.Y));
                this.Sprite.Position = v;
            }
            

            Draw();
        }

        public void Destroy()
        {
            IsVisible = false;
            Sprite = null; 
        }
    }
}
