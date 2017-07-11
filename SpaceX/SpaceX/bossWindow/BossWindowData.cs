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
        public String BGM { set; get; }

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
        public int BossFireDestroyTime { set; get; }
        public Texture BossFireTexture { set; get; }
        public String BossFireSpawnSFX { set; get; }

        public Vector2f BossHPBarPosition { set; get; }
        public Vector2f BossHPBarSize { set; get; }
        public Color BossHPBarColor { set; get; }

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
        public int HeroBulletDestroyTime { set; get; }
        public String HeroBulletSpawnSFX { set; get; }

        public Vector2f HeroHPBarPosition { set; get; }
        public Vector2f HeroHPBarSize { set; get; }
        public Color HeroHPBarColor { set; get; }

        public Map Map { set; get; }

        public Sprite[] BossIdleAni { set; get; }
        public int BossAniCount { set; get; }
        public int BossAniSpeed { set; get; }

        public Sprite HeroUp { set; get; }
        public Sprite HeroDown { set; get; }
        public Sprite HeroLeft { set; get; }
        public Sprite HeroRight { set; get; }
        public Sprite[] HeroUpAni { set; get; }
        public Sprite[] HeroDownAni { set; get; }
        public Sprite[] HeroLeftAni { set; get; }
        public Sprite[] HeroRightAni { set; get; }
        public int HeroAniCount { set; get; }
        public int HeroAniSpeed { set; get; }

        public Font Font { set; get; }
        public uint FontSize { set; get; }
        public Color FontColor { set; get; }

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

            BossHPBarPosition = new Vector2f(o.Value<int>("BossHPBarPositionX"), o.Value<int>("BossHPBarPositionY"));
            BossHPBarSize = new Vector2f(o.Value<int>("BossHPBarSizeX"), o.Value<int>("BossHPBarSizeY"));
            BossHPBarColor = Color.Red; //too lazy to read RGBA from json

            HeroHPBarPosition = new Vector2f(o.Value<int>("HeroHPBarPositionX"), o.Value<int>("HeroHPBarPositionY"));
            HeroHPBarSize = new Vector2f(o.Value<int>("HeroHPBarSizeX"), o.Value<int>("HeroHPBarSizeY"));
            HeroHPBarColor = Color.Green; //too lazy to read RGBA from json

            BGM = o.Value<String>("BGM");
            FontSize = (uint)o.Value<int>("FontSize");
            FontColor = Color.White; //too lazy to json RGBA
            Font = new Font(o.Value<String>("Font"));
            
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
            BossFireDestroyTime = o.Value<int>("BossFireDestroyTime");
            BossFireSpawnSFX = o.Value<String>("BossFireSpawnSFX");

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
            HeroBulletDestroyTime = o.Value<int>("HeroBulletDestroyTime");
            HeroBulletSpawnSFX = o.Value<String>("HeroBulletSpawnSFX");

            Map = new Map(o.Value<String>("MapPath"), Program.Window.DefaultView);

            BossAniCount = o.Value<int>("BossAniCount");
            BossAniSpeed = o.Value<int>("BossAniSpeed");
            BossIdleAni = new Sprite[BossAniCount];
            for (int i = 0; i < BossIdleAni.Length; i++)
                BossIdleAni[i] = new Sprite(new Texture(o.Value<String>("BossIdleAni") + i + ".png"));


            HeroAniCount = o.Value<int>("HeroAniCount");
            HeroAniSpeed = o.Value<int>("HeroAniSpeed");

            HeroUp = new Sprite(new Texture(o.Value<String>("HeroUpTexture")));
            HeroDown = new Sprite(new Texture(o.Value<String>("HeroDownTexture")));
            HeroLeft = new Sprite(new Texture(o.Value<String>("HeroLeftTexture")));
            HeroRight = new Sprite(new Texture(o.Value<String>("HeroRightTexture")));

            HeroUpAni = new Sprite[HeroAniCount];
            for (int i = 0; i < HeroUpAni.Length; i++)
                HeroUpAni[i] = new Sprite(new Texture(o.Value<String>("HeroUpAni") + i + ".png"));

            HeroDownAni = new Sprite[HeroAniCount];
            for (int i = 0; i < HeroDownAni.Length; i++)
                HeroDownAni[i] = new Sprite(new Texture(o.Value<String>("HeroDownAni") + i + ".png"));

            HeroLeftAni = new Sprite[HeroAniCount];
            for (int i = 0; i < HeroLeftAni.Length; i++)
                HeroLeftAni[i] = new Sprite(new Texture(o.Value<String>("HeroLeftAni") + i + ".png"));

            HeroRightAni = new Sprite[HeroAniCount];
            for (int i = 0; i < HeroRightAni.Length; i++)
                HeroRightAni[i] = new Sprite(new Texture(o.Value<String>("HeroRightAni") + i + ".png"));

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
