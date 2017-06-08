using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Keyboard;

namespace SpaceX.gameOverWindow
{
    class GameOverWindowData
    {

        public Color TextColor { set; get; }
        public Font Font { set; get; }
        public uint FontSize { set; get; }
        public Vector2f ScorePosition { set; get; }

        public Vector2f BackgroundSize { set; get; }
        public Vector2f BackgroundPosition { set; get; }
        public Texture BackgroundTexture { set; get; }

        public Key Enter { set; get; }

        public GameOverWindowData()
        {
            //Load data from json
            String path = "../../../assets/json/GameOverWindowData.json";
            JObject o = JObject.Parse(File.ReadAllText(path));

            ScorePosition = new Vector2f(o.Value<int>("ScorePositionX"), o.Value<int>("ScorePositionY"));

            TextColor = new Color((byte)o.Value<int>("FontColorR"),
                                  (byte)o.Value<int>("FontColorG"),
                                  (byte)o.Value<int>("FontColorB"),
                                  (byte)o.Value<int>("FontColorA"));
            Font = new Font(o.Value<String>("Font"));
            FontSize = (uint)o.Value<int>("FontSize");

            BackgroundSize = new Vector2f(o.Value<int>("BackGroundSizeX"), o.Value<int>("BackGroundSizeY"));
            BackgroundPosition = new Vector2f(o.Value<int>("BackGroundPositionX"), o.Value<int>("BackGroundPositionY"));
            BackgroundTexture = new Texture(o.Value<String>("BackGroundTexture"));

            Enter = Converter.StringKey(o.Value<String>("Enter"));
        }
    }
}
