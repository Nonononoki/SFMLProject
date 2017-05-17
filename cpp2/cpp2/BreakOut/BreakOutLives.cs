using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutLives
    {
        public Text Text;
        public int Lives;

        private String myString = "Lives: ";

        public BreakOutLives(Vector2f Position, int Lives, Font font, Color fontColor, uint fontSize)
        {
            this.Lives = Lives;
            Text = new Text();
            Text.Font = font;
            Text.Color = fontColor;
            Text.CharacterSize = fontSize;
            Text.Position = Position;
        }

        public void UpdateLives(int Lives)
        {
            this.Lives = Lives;
            Text.DisplayedString = myString + Lives;
        }
    }
}
