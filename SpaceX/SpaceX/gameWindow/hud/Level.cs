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
            Text = new Text();
            Text.Font = gwd.Font;
            Text.CharacterSize = gwd.FontSize;
            Text.FillColor = gwd.TextColor;

            Text.Position = Converter.RelativeWindow(gwd.LevelPosition);
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
