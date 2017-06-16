using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.gameLoadingWindow
{
    class GameLoadingWindowData
    {
        public Vector2f IconPosition { set; get; }
        public Texture IconTexture { set; get; }
        public String IconTexturePath { set; get; }
        public Vector2f IconSize { set; get; }

        public String AnimationSpritesPath { set; get; }
        public Sprite[] AnimationSprites { set; get; }
        public int AnimationSpritesCount { set; get; }
        public int AnimationSpeed { set; get; }

        public GameLoadingWindowData()
        {
            //Load data from json
            String path = "../../../assets/json/GameWindowLoadingData.json";
            JObject o = JObject.Parse(File.ReadAllText(path));

            IconSize = new Vector2f(o.Value<int>("IconSizeX"), o.Value<int>("IconSizeY"));
            IconPosition = new Vector2f(o.Value<int>("IconPositionX"), o.Value<int>("IconPositionY"));
            IconTexturePath = o.Value<String>("IconTexturePath");
            IconTexture = new Texture(IconTexturePath);

            AnimationSpritesPath = o.Value<String>("AnimationSpritesPath");
            AnimationSpritesCount = o.Value<int>("AnimationSpritesCount");
            AnimationSpeed = o.Value<int>("AnimationSpeed");

            AnimationSprites = new Sprite[AnimationSpritesCount];
            for(int i = 0; i < AnimationSpritesCount; i++)
            {
                AnimationSprites[i] = new Sprite(new Texture(AnimationSpritesPath + i + ".png"));
            }
        }
    }
}
