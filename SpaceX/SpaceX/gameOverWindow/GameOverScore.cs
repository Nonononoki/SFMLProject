using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameOverWindow
{
    class GameOverScore : IComponent
    {
        public int StartValue { set; get; }
        public int Value { set; get; }
        public Text Text { set; get; }
        public String String { set; get; }

        public GameOverScore(GameOverWindowData gwd, int score)
        {
            StartValue = 0;
            String = "Score: ";
            Value = score;
            Text = new Text();
            Text.Font = gwd.Font;
            Text.CharacterSize = gwd.FontSize;
            Text.FillColor = gwd.TextColor;

            ////center text
            FloatRect textRect = Text.GetLocalBounds();
            Text.Origin = new Vector2f(textRect.Left + textRect.Width / 2.0f,
            textRect.Top + textRect.Height / 2.0f);
            Text.Position = Converter.RelativeWindow(gwd.ScorePosition);
        }

        public void Update()
        {
            if (StartValue < Value)
                StartValue++;
            else
                StartValue = Value;

            Text.DisplayedString = StartValue.ToString();
            Program.Window.Draw(Text);
        }

        public void Destroy()
        {
            Text.DisplayedString = "";
        }
    }
}
