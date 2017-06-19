using SFML.Graphics;
using SFML.System;
using SpaceX.gameOverWindow;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class Score : IComponent
    {
        public static int Value { set; get; }
        public Text Text { set; get; }
        public String String { set; get; }

        public Score(GameWindowData gwd)
        {
            String = "Score: ";
            Value = 0;
            Text = new Text();
            Text.Font = gwd.Font;
            Text.CharacterSize = gwd.FontSize;
            Text.FillColor = gwd.TextColor;

            Text.Position = Converter.RelativeWindow(gwd.ScorePosition);
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
