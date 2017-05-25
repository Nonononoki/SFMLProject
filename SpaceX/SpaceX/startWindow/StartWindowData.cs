﻿using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using SpaceX.startWindow.logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.window
{
    class StartWindowData
    {
        public Vector2f BackgroundSize { set; get; }
        public Vector2f LogoSize { set; get; }
        public Vector2f StartSize { set; get; }

        public Vector2f BackgroundPosition { set; get; }
        public Vector2f LogoPosition { set; get; }
        public Vector2f StartPosition { set; get; }

        public Texture BackgroundTexture { set; get; }
        public Texture LogoTexture { set; get; }
        public Texture StartTexture { set; get; }

        RenderingComponent BackgroundRenderingComponent { set; get; }
        RenderingComponent LogoRenderingComponent { set; get; }
        RenderingComponent StartRenderingComponent { set; get; }

        public GameObject BackgroundObject { set; get; }
        public GameObject LogoObject { set; get; }
        public GameObject StartObject { set; get; }

        public String Enter { set; get; }
        public StartButtonLogic SBL { set; get; }


        public StartWindowData(RenderWindow Window, String path)
        {
            //all int values are in percent, relative to canvas
            String addedPath = "../../../assets/json/" + path + ".json";
            JObject o = JObject.Parse(File.ReadAllText(@addedPath));

            Enter = o.Value<String>("Enter");

            BackgroundSize = new Vector2f(o.Value<int>("BackGroundSizeX"), o.Value<int>("BackGroundSizeY"));
            LogoSize = new Vector2f(o.Value<int>("LogoSizeX"), o.Value<int>("LogoSizeY"));
            StartSize = new Vector2f(o.Value<int>("StartSizeX"), o.Value<int>("StartSizeY"));

            BackgroundPosition = new Vector2f(o.Value<int>("BackGroundPositionX"), o.Value<int>("BackGroundPositionY"));
            LogoPosition = new Vector2f(o.Value<int>("LogoPositionX"), o.Value<int>("LogoPositionY"));
            StartPosition = new Vector2f(o.Value<int>("StartPositionX"), o.Value<int>("StartPositionY"));

            //assign textures
            BackgroundTexture = new Texture(o.Value<String>("BackGroundTexture"));
            LogoTexture = new Texture(o.Value<String>("LogoTexture"));
            StartTexture = new Texture(o.Value<String>("StartTexture"));

            //create rendering components
            RenderingComponent BackgroundRenderingComponent = new RenderingComponent(BackgroundPosition, BackgroundTexture, BackgroundSize, Window, false);
            RenderingComponent LogoRenderingComponent = new RenderingComponent(LogoPosition, LogoTexture, LogoSize, Window, false);
            RenderingComponent StartRenderingComponent = new RenderingComponent(StartPosition, StartTexture, StartSize, Window, false);

            //set as gameobjects
            BackgroundObject = new GameObject();
            LogoObject = new GameObject();
            StartObject = new GameObject();

            //assign components to game objects
            BackgroundObject.AddComponent(BackgroundRenderingComponent);
            LogoObject.AddComponent(LogoRenderingComponent);
            StartObject.AddComponent(StartRenderingComponent);

            SBL = new StartButtonLogic(Enter, Window);
            StartObject.AddComponent(SBL);
        }
    }
}