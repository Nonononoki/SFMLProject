﻿using FarseerPhysics.Common;
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
using static SFML.Window.Keyboard;

namespace SpaceX.window
{
    class GameWindowData
    {
        //BackgroundData
        public Vector2f BackgroundSize { set; get; }
        public Vector2f BackgroundPosition { set; get; }
        public Texture BackgroundTexture { set; get; }

        public String BackGroundAnimationSpritesPath { set; get; }
        public int BackGroundAnimationSpritesCount { set; get; }
        public Sprite[] BackgroundAnimation { set; get; }
        public int BackGroundSpeed { set; get; }

        //Ship Data
        public Vector2 MyShipPosition { set; get; }
        public Vector2 MyShipSize { set; get; }
        public Vertices MyShipVertices { set; get; }
        public Texture MyShipTexture { set; get; }
        public int MyShipHealth { set; get; }
        public int MyShipSpeed { set; get; }
        public int MyShipMass { set; get; }

        //Bullet Data
        public Vector2 MyBulletPosition { set; get; }
        public Vector2 MyBulletSize { set; get; }
        public Vertices MyBulletVertices { set; get; }
        public Texture MyBulletTexture { set; get; }
        public int MyBulletDelay { set; get; }
        public int MyBulletSpeed { set; get; }
        public int MyBulletMass { set; get; }
        public int MyBulletMax { set; get; }
        public int MyBulletDuration { set; get; }

        //hud and fonts
        public Vector2f HealthPosition { set; get; }
        public int HealthValue { set; get; }
        public Vector2f ScorePosition { set; get; }
        public Vector2f LevelPosition { set; get; }

        public Color TextColor { set; get; }
        public Font Font { set; get; }
        public uint FontSize { set; get; }

        public int MaxLevel { set; get; }

        //Sound
        public String AsteroidDestroyPath { set; get; }
        public String AsteroidHitPath { set; get; }
        public String ShipHitPath { set; get; }
        public String LaserSpawnPath { set; get; }
        public String LevelUpPath { set; get; }
        public String BackgroundBGM { set; get; }

        //Control  buttons
        public Key Up { set; get; }
        public Key Down { set; get; }
        public Key Left { set; get; }
        public Key Right { set; get; }


        public GameWindowData()
        {
            //Load data from json
            String path = "../../../assets/json/GameWindowData.json";
            JObject o = JObject.Parse(File.ReadAllText(path));

            //background
            BackgroundSize = new Vector2f(o.Value<int>("BackGroundSizeX"), o.Value<int>("BackGroundSizeY"));
            BackgroundPosition = new Vector2f(o.Value<int>("BackGroundPositionX"), o.Value<int>("BackGroundPositionY"));
            BackgroundTexture = new Texture(o.Value<String>("BackGroundTexture"));
            BackGroundAnimationSpritesPath = o.Value<String>("BackGroundAnimationSpritesPath");
            BackGroundAnimationSpritesCount = o.Value<int>("BackGroundAnimationSpritesCount");
            BackGroundSpeed = o.Value<int>("BackGroundSpeed");

            
            BackgroundAnimation = new Sprite[BackGroundAnimationSpritesCount];
            //assign Sprites from path
            for (int i = 0; i < BackGroundAnimationSpritesCount; i++)
            {
                BackgroundAnimation[i] = new Sprite(new Texture(BackGroundAnimationSpritesPath + i + ".png"));
            }
            

            //ship
            MyShipPosition = new Vector2(o.Value<int>("MyShipPositionX"), o.Value<int>("MyShipPositionY"));
            MyShipSize = new Vector2(o.Value<int>("MyShipSizeX"), o.Value<int>("MyShipSizeY"));
            MyShipVertices = PhysicsComponent.RechtangleVertices(MyShipSize); //create rechtangular hitbox, could be optimized to fit sprite
            MyShipTexture = new Texture(o.Value<String>("MyShipTexture"));
            MyShipHealth = o.Value<int>("MyShipHealth");
            MyShipSpeed = o.Value<int>("MyShipSpeed");

            //bullet
            MyBulletPosition = new Vector2(o.Value<int>("MyBulletPositionX"), o.Value<int>("MyBulletPositionY"));
            MyBulletSize = new Vector2(o.Value<int>("MyBulletSizeX"), o.Value<int>("MyBulletSizeY"));
            MyBulletVertices = PhysicsComponent.RechtangleVertices(MyBulletSize); //create rechtangular hitbox, could be optimized to fit sprite
            MyBulletTexture = new Texture(o.Value<String>("MyBulletTexture"));
            MyBulletDelay = o.Value<int>("MyBulletDelay");
            MyBulletSpeed = o.Value<int>("MyBulletSpeed");
            MyBulletMass = o.Value<int>("MyBulletMass");
            MyBulletMax = o.Value<int>("MyBulletMax");
            MyBulletDuration = o.Value<int>("MyBulletDuration");

            //hud
            HealthValue = o.Value<int>("HealthValue");
            HealthPosition = new Vector2f(o.Value<int>("HealthPositionX"), o.Value<int>("HealthPositionY"));
            ScorePosition = new Vector2f(o.Value<int>("ScorePositionX"), o.Value<int>("ScorePositionY"));
            LevelPosition = new Vector2f(o.Value<int>("LevelPositionX"), o.Value<int>("LevelPositionY"));

            TextColor = new Color((byte)o.Value<int>("FontColorR"),
                                  (byte)o.Value<int>("FontColorG"),
                                  (byte)o.Value<int>("FontColorB"),
                                  (byte)o.Value<int>("FontColorA"));
            Font = new Font(o.Value<String>("Font"));
            FontSize = (uint)o.Value<int>("FontSize");

            MaxLevel = o.Value<int>("MaxLevel");

            //sound
            AsteroidDestroyPath = o.Value<String>("AsteroidDestroySFX");
            AsteroidHitPath = o.Value<String>("AsteroidHitSFX");
            ShipHitPath = o.Value<String>("ShipHitSFX");
            LaserSpawnPath = o.Value<String>("LaserSpawnSFX");
            LevelUpPath = o.Value<String>("LevelUpSFX");


            BackgroundBGM = o.Value<String>("BackGroundBGM");

            //PlayerControl Strings
            String path2 = "../../../assets/json/Control.json";
            JObject o2 = JObject.Parse(File.ReadAllText(path2));

            Up = Converter.StringKey(o2.Value<String>("Up"));
            Down = Converter.StringKey(o2.Value<String>("Down"));
            Left = Converter.StringKey(o2.Value<String>("Left"));
            Right = Converter.StringKey(o2.Value<String>("Right"));

        }
    }
}
