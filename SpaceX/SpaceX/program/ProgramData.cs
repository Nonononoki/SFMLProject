using Newtonsoft.Json.Linq;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.program
{
    class ProgramData
    {
        public Vector2f WindowSize { set; get; }

        public int FadeStep { set; get; }
        public int FadeSpeed { set; get; }

        public ProgramData(String path)
        {
            //all int values are in percent, relative to canvas
            String addedPath = "../../../assets/json/" + path + ".json";
            JObject o = JObject.Parse(File.ReadAllText(@addedPath));

            WindowSize = new Vector2f(o.Value<int>("WindowWidth"), o.Value<int>("WindowHeight"));

            FadeStep = o.Value<int>("FadeStep");
            FadeSpeed = o.Value<int>("FadeSpeed");
        }
    }
}
