using SFML.Graphics;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class Health : IComponent
    {
        public static int Value { set; get; }
        public Text Text { set; get; }
        public String String { set; get; }

        public Health(GameWindowData gwd)
        {
            String = "Health: ";
            Value = gwd.HealthValue;
            Text = new Text()
            {
                Font = gwd.Font,
                CharacterSize = gwd.FontSize,
                FillColor = gwd.TextColor,

                Position = Converter.RelativeWindow(gwd.HealthPosition)
            };
        }

        public void Destroy()
        {
            Text.DisplayedString = "";
        }

        public void Update()
        {
            Text.DisplayedString = String + Value;
            Program.Window.Draw(Text);
        }
    }
}
