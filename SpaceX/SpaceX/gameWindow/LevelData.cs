using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
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
        public int AsteroidCount { set; get; }
        public List<int> AsteroidHealth { set; get; }
        public List<int> AsteroidSpeed { set; get; }
        public List<int> AsteroidMass { set; get; }
        public List<int> AsteroidSize { set; get; }
        public List<Vector2f> SpawnPosition { set; get; }
        public List<int> SpawnDelay { set; get; }
        public List<int> Points { set; get; }

        public LevelData(int level)
        {
            //Load data from json
            String path = "../../../assets/json/levels/Level" + level + ".json";
            JObject o = JObject.Parse(File.ReadAllText(path));

            AsteroidCount = o.Value<int>("AsteroidCount");

            //various attributes 
            AsteroidSize = o.Value<JToken>("Size").ToObject<List<int>>();
            AsteroidHealth = o.Value<JToken>("Health").ToObject<List<int>>();
            AsteroidMass = o.Value<JToken>("Mass").ToObject<List<int>>();
            AsteroidSpeed = o.Value<JToken>("Speed").ToObject<List<int>>();

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
