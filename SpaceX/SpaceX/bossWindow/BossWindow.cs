﻿using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SpaceX.component;
using SpaceX.gameOverWindow;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class BossWindow : IWindow
    {
        public static World World { set; get; }
        public AudioComponent BGM { set; get; }
        public BossWindowData BWD { set; get; }
        public Boss Boss { set; get; }
        public BossHero Hero { set; get; }

        public static BossArena Arena { set; get; }
        public static List<GameObject> MyGameObjects { set; get; }
        public static List<GameObject> ToBeRemoved { set; get; }
        public static List<CollidingComponent> CollisionList { set; get; }

        public static bool IsOver;
        public int Score { set; get; }

        public BossWindow(int score)
        {
            BWD = new BossWindowData();

            this.Score = score;

            MyGameObjects = new List<GameObject>();
            World = new World(new Vector2(0, 0));
            CollisionList = new List<CollidingComponent>();
            ToBeRemoved = new List<GameObject>();

            IsOver = false;

            Arena = new BossArena(BWD);
            MyGameObjects.Add(Arena);

            Hero = new BossHero(BWD);
            MyGameObjects.Add(Hero);

            Boss = new Boss(BWD, Hero);
            MyGameObjects.Add(Boss);

            BGM = new AudioComponent(BWD.BGM, true);
            BGM.Sound.Play();

            //add to windows "stack"
            Program.Windows.Insert(0, this);
        }
        public List<GameObject> GameObjects()
        {
            return MyGameObjects;
        }

        public void Update()
        {
            //farseer steps
            if (World != null)
                World.Step(DeltaTime.Time);

            Arena.Draw();

            //draw sprites
            foreach (GameObject go in MyGameObjects.ToList<GameObject>())
            {
                go.Update();
            }

            //collide before destruction
            foreach (CollidingComponent cc in CollisionList.ToList<CollidingComponent>())
            {
                CollisionList.Remove(cc);
                cc.CollisionHandling();
            }

            //delete GameObjects
            foreach (GameObject go in ToBeRemoved.ToList<GameObject>())
            {
                ToBeRemoved.Remove(go);
                go.Destroy();
                MyGameObjects.Remove(go);
            }

            if (IsOver)
            {
                Remove();              
                //LoadNextWindow();
            }
        }

        public void Remove()
        {
            Converter.RemoveAllComponents(this);
        }

        public void Clear()
        {
            CalculateScore();

            BGM.Sound.Stop();
            Arena.Destroy();
            Arena = null;

            MyGameObjects.Clear();
            World.Enabled = false;
            Program.Windows.Remove(this);

            LoadNextWindow();
        }

        private int CalculateScore()
        {
            return Hero.Health * Score;
        }

        public void LoadNextWindow()
        {
            //get to gameOverWindow if won
            if(Hero.Health > 0)
            {
                GameOverWindow GOW = new GameOverWindow(CalculateScore());
            }
            //return ToBeRemoved main window if skipped
            else
            {
                StartWindow SW = new StartWindow();
            }
        }
    }
}
