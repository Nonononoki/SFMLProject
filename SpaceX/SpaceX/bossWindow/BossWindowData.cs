using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiled.SFML;
using static SFML.Window.Keyboard;

namespace SpaceX.bossWindow
{
    class BossWindowData
    {
        public Vector2f BossPosition { set; get; }
        public Vector2f BossSize { set; get; }
        public Texture BossTexture { set; get; }
        public int BossSpeed { set; get; }
        public int BossHealth { set; get; }
        public int BossMass { set; get; }
        public int BossFireCooldown { set; get; }
        public String BossHitPath { set; get; }

        public Vector2f BossFireSize { set; get; }
        public int BossFireSpeed { set; get; }
        public int BossFireMass { set; get; }
        public Texture BossFireTexture { set; get; }

        public Vector2f HeroPosition { set; get; }
        public Vector2f HeroSize { set; get; }
        public Texture  HeroTexture { set; get; }
        public int HeroSpeed { set; get; }
        public int HeroMass { set; get; }
        public int HeroInvCooldown { set; get; }
        public int HeroFireCooldown { set; get; }
        public String HeroHitPath { set; get; }

        public Vector2f HeroBulletSize { set; get; }
        public Texture HeroBulletTexture { set; get; }
        public int HeroBulletSpeed { set; get; }
        public int HeroBulletMass { set; get; }

        public Map Map { set; get; }

        public Key Up { set; get; }
        public Key Down { set; get; }
        public Key Left { set; get; }
        public Key Right { set; get; }
        public Key Shoot { set; get; }


        public BossWindowData()
        {
            //Load data from json
            String path = "../../../assets/json/BossWindowData.json";
            JObject o = JObject.Parse(File.ReadAllText(path));

            BossSize = new Vector2f(o.Value<int>("BossSizeX"), o.Value<int>("BossSizeY"));
            BossPosition = new Vector2f(o.Value<int>("BossPositionX"), o.Value<int>("BossPositionY"));
            BossTexture = new Texture(o.Value<String>("BossTexture"));
            BossSpeed = o.Value<int>("BossSpeed");
            BossMass = o.Value<int>("BossMass");
            BossHealth = o.Value<int>("BossHealth");
            BossFireCooldown = o.Value<int>("BossFireCooldown");
            BossHitPath = o.Value<String>("BossHitPath");

            BossFireSize = new Vector2f(o.Value<int>("BossFireSizeX"), o.Value<int>("BossFireSizeY"));
            BossFireTexture = new Texture(o.Value<String>("BossFireTexture"));
            BossFireSpeed = o.Value<int>("BossFireSpeed");
            BossFireMass = o.Value<int>("BossFireMass");

            HeroSize = new Vector2f(o.Value<int>("HeroSizeX"), o.Value<int>("HeroSizeY"));
            HeroPosition = new Vector2f(o.Value<int>("HeroPositionX"), o.Value<int>("HeroPositionY"));
            HeroTexture = new Texture(o.Value<String>("HeroTexture"));
            HeroSpeed = o.Value<int>("HeroSpeed");
            HeroMass = o.Value<int>("HeroMass");
            HeroInvCooldown = o.Value<int>("HeroInvCooldown");
            HeroFireCooldown = o.Value<int>("HeroFireCooldown");
            HeroHitPath = o.Value<String>("HeroHitPath");

            HeroBulletSize = new Vector2f(o.Value<int>("HeroBulletSizeX"), o.Value<int>("HeroBulletSizeY"));
            HeroBulletTexture = new Texture(o.Value<String>("HeroBulletTexture"));
            HeroBulletSpeed = o.Value<int>("HeroBulletSpeed");
            HeroBulletMass = o.Value<int>("HeroBulletMass");

            Map = new Map(o.Value<String>("MapPath"), Program.Window.DefaultView);



            //Load Controllers
            //Load data from json
            String path2 = "../../../assets/json/Control.json";
            JObject o2 = JObject.Parse(File.ReadAllText(path2));

            Up = Converter.StringKey(o2.Value<String>("Up"));
            Down = Converter.StringKey(o2.Value<String>("Down"));
            Left = Converter.StringKey(o2.Value<String>("Left"));
            Right = Converter.StringKey(o2.Value<String>("Right"));
            Shoot = Converter.StringKey(o2.Value<String>("Shoot"));

        }


    }
}
