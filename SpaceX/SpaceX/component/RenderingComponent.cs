using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool Fading { set; get; }
        public Stopwatch SW;
        public IWindow Window { set; get; }

        public RenderingComponent(Vector2f Position, Texture Texture, Vector2f Size, bool IsCircle)
        {
            IsVisible = true;
            Fading = false;

            //Position is in percentage
            Sprite = new Sprite();
            Sprite.Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            Sprite.Position = Converter.RelativeWindow(Position);
            Sprite.Texture = Texture;

            //Size is also in percentage
            if (IsCircle) Sprite.Scale = new Vector2f(Size.X * Program.Window.Size.X / Texture.Size.X, Size.Y * Program.Window.Size.X / Texture.Size.Y) / 100 * 2;
            else Sprite.Scale = new Vector2f(Size.X / Texture.Size.X * Program.Window.Size.X, Size.Y / Texture.Size.Y * Program.Window.Size.Y) / 100;
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

            if (Fading)
                Fade();

            Draw();
        }

        public void Destroy()
        {
            IsVisible = false;
            Sprite = null;
        }

        public void Fade()
        {
            if (SW == null)
            {
                SW = new Stopwatch();
                SW.Start();
            }

            if (SW.ElapsedMilliseconds >= Program.FadeSpeed)
            {
                SW.Restart();
                int newOpacity = Sprite.Color.A - Program.FadeStep;
                Sprite.Color = new Color(Sprite.Color.R, Sprite.Color.G, Sprite.Color.B, (byte)newOpacity);
            }

            if (Sprite != null && Sprite.Color.A <= 0)
            {
                if(RemoveWindow && Program.Windows.Contains(Window))
                    RemoveWindowAfterFading();

                SW.Reset();
                Destroy();
            }
        }

        public bool RemoveWindow = false;
        public void RemoveWindowAfterFading()
        {
            Program.Windows.Remove(Window);
        }
    }
}
