using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class HPbar : IComponent
    {
        public int Value { set; get; }
        public Text Text { set; get; }
        RectangleShape Bar { set; get; }

        public HPbar(Vector2f Position, Vector2f Size, String Text, Color Color, int Value, BossWindowData BWD)
        {
            this.Value = Value;

            //experimental, not tested, not displayed
            this.Text = new Text()
            {
                DisplayedString = Text + ": " + Value,
                Font = BWD.Font,
                CharacterSize = BWD.FontSize,
                FillColor = BWD.FontColor
            };

            Bar = new RectangleShape();
            Bar.Position = Converter.RelativeWindow(Position);
            Bar.Size = Converter.RelativeWindow(Size);             
            Bar.Origin = new Vector2f(Bar.Size.X / 2, Bar.Size.Y / 2);
            Bar.FillColor = Color;
        }

        public void Resize(int newValue)
        {
            //calculate percentage
            float p = (float)newValue / (float)Value;
            //original scales of 1
            Bar.Scale = new Vector2f(1 * p, 1);
        }

        public void Update()
        {
            //throw new NotImplementedException();
            Program.Window.Draw(Bar);
            //Program.Window.Draw(Text);
        }

        public void Destroy()
        {
            //throw new NotImplementedException();
        }
    }
}
