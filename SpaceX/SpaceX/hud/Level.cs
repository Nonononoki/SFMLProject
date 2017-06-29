using SFML.Graphics;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class Level : IComponent
    {
        public static int Value { set; get; }
        public Text Text { set; get; }
        public String String { set; get; }

        public Level(GameWindowData gwd)
        {
            String = "Level: ";
            Value = 1;
            Text = new Text()
            {
                Font = gwd.Font,
                CharacterSize = gwd.FontSize,
                FillColor = gwd.TextColor,

                Position = Converter.RelativeWindow(gwd.LevelPosition)
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
