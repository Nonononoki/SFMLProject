using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class LevelData
    {
        public int AnimationSpeed { set; get; }
        public int AsteroidCount { set; get; }
        public int LevelDuration { set; get; }
        public int AsteroidDuration { set; get; }
        public List<int> AsteroidHealth { set; get; }
        public List<int> AsteroidSpeed { set; get; }
        public List<int> AsteroidMass { set; get; }
        public List<int> AsteroidSize { set; get; }
        public Texture AsteroidTexture { set; get; }

        public String ExplosionPath { set; get; }
        public int ExplosionCount { set; get; }
        public Sprite[] ExplosionSprites { set; get; }

        public String HitPath { set; get; }
        public int HitCount { set; get; }
        public Sprite[] HitSprites { set; get; }

        public List<Vector2f> SpawnPosition { set; get; }
        public List<int> SpawnDelay { set; get; }
        public List<int> Points { set; get; }

        public LevelData(int level)
        {
            //Load data from json
            String path = "../../../assets/json/levels/Level" + level + ".json";
            JObject o = JObject.Parse(File.ReadAllText(path));

            AnimationSpeed = o.Value<int>("AnimationSpeed");
            AsteroidCount = o.Value<int>("AsteroidCount");
            LevelDuration = o.Value<int>("LevelDuration");
            AsteroidDuration = o.Value<int>("AsteroidDuration");

            //various attributes 
            AsteroidSize = o.Value<JToken>("Size").ToObject<List<int>>();
            AsteroidHealth = o.Value<JToken>("Health").ToObject<List<int>>();
            AsteroidMass = o.Value<JToken>("Mass").ToObject<List<int>>();
            AsteroidSpeed = o.Value<JToken>("Speed").ToObject<List<int>>();

            AsteroidTexture = new Texture(o.Value<String>("Texture"));

            ExplosionPath = o.Value<String>("ExplosionPath");
            ExplosionCount = o.Value<int>("ExplosionCount");
            ExplosionSprites = new Sprite[ExplosionCount];
            for (int i = 0; i < ExplosionCount; i++)
            {
                ExplosionSprites[i] = new Sprite(new Texture(ExplosionPath + i + ".png"));
            }

            HitPath = o.Value<String>("HitPath");
            HitCount = o.Value<int>("HitCount");
            HitSprites = new Sprite[HitCount];
            for (int i = 0; i < HitCount; i++)
            {
                HitSprites[i] = new Sprite(new Texture(HitPath + i + ".png"));
            }

            SpawnDelay = o.Value<JToken>("SpawnDelay").ToObject<List<int>>();
            Points = o.Value<JToken>("Points").ToObject<List<int>>();

            List<int> SpawnPositionX = o.Value<JToken>("SpawnPositionX").ToObject<List<int>>();
            List<int> SpawnPositionY = o.Value<JToken>("SpawnPositionY").ToObject<List<int>>();
            SpawnPosition = new List<Vector2f>();
            for (int i = 0; i < AsteroidCount; i++)
            {
                SpawnPosition.Add(new Vector2f(SpawnPositionX.ElementAt(i), SpawnPositionY.ElementAt(i)));
            }
        }
    }
}
