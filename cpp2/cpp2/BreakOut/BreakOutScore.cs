using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutScore
    {
        public Text Text;
        public int Score;

        private String myString = "Score: ";

        public BreakOutScore(Vector2f Position, int Score, Font font, Color fontColor, uint fontSize)
        {
            this.Score = Score;
            Text = new Text();
            Text.Font = font;
            Text.Color = fontColor;
            Text.CharacterSize = fontSize;
            Text.Position = Position;
        }

        public void UpdateScore()
        {
            Text.DisplayedString = myString + Score;
        }
    }
}
