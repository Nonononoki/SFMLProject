using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SpaceX.component;
using SpaceX.gameObject;
using SpaceX.gameOverWindow;
using SpaceX.gameWindow;
using SpaceX.gameWindow.asteroid;
using SpaceX.gameWindow.background;
using SpaceX.gameWindow.hud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.window
{
    class GameWindow : IWindow
    {
        public static World World { set; get; }
        public static GameWindowData GameWindowData { set; get; }
        public static LevelData LevelData { set; get; }
        public static Ship Ship { set; get; }
        public GameHUD HUD { set; get; }
        public static AsteroidPool AsteroidPool { set; get; }
        public GameBackground GBG { set; get; }
        public static AudioComponent LevelUpSFX {set;get;}

        public static List<GameObject> ToBeRemoved { set; get; }
        public static List<ICollidingComponent> CollisionList { set; get; }
        public static bool IsOver = false;

        public static List<GameObject> MyGameObjects { set; get; }

        public GameWindow()
        {
            //GameObject.DestroyAll();

            World = new World(new Vector2(0, 0));

            //static data first
            GameWindowData = new GameWindowData();

            //list of window gameobjects
            MyGameObjects = new List<GameObject>();

            LevelData = new LevelData(1);        
            LevelUpSFX = new AudioComponent(GameWindowData.LevelUpPath, false);

            //load gameobjects
            GBG = new GameBackground(GameWindowData);
            HUD = new GameHUD(GameWindowData);
            Ship = new Ship(GameWindowData);

            //add to list
            MyGameObjects.Add(GBG);
            MyGameObjects.Add(HUD);
            MyGameObjects.Add(Ship);

            //spawn asteroids
            AsteroidPool = new AsteroidPool(LevelData, GameWindowData, Ship);
            Ship.AddComponent(AsteroidPool);

            //remove to be deleted gameobjects
            ToBeRemoved = new List<GameObject>();
            CollisionList = new List<ICollidingComponent>();

            //add to windows
            //Program.Windows.Add(this);
            Program.Windows.Insert(0, this);
        }

        public void Update()
        {
            //farseer steps
            if(World != null)
                World.Step(DeltaTime.Time);

            //draw sprites
            foreach (GameObject go in MyGameObjects.ToList<GameObject>())
            {
                go.Update();
            }

            //collide before destruction
            foreach (ICollidingComponent cc in CollisionList.ToList<ICollidingComponent>())
            {
                CollisionList.Remove(cc);
                cc.CollisionHandling();
            }

            //delete GameObjects
            foreach (GameObject go in ToBeRemoved.ToList<GameObject>())
            {
                ToBeRemoved.Remove(go);
                go.Destroy();
            }

            if (IsOver)
            {
                Remove();
                GameOverWindow GOW = new GameOverWindow(Score.Value);

                World = null;
                IsOver = false;
            }
        }

        public static void LoadNextLevel()
        {
            LevelUpSFX.Sound.Play();
            Level.Value++;

            //check if last level reached
            if(Level.Value <= GameWindowData.MaxLevel)
            {
                Ship.RemoveComponent(AsteroidPool);
                LevelData = new LevelData(Level.Value);
                //Ship = new Ship(GameWindowData);
                AsteroidPool = new AsteroidPool(LevelData, GameWindowData, Ship);
                Ship.AddComponent(AsteroidPool);
            }

            else
            {
                GameOver();
            }
        }

        public static void GameOver()
        {
            IsOver = true;
        }

        public List<GameObject> GameObjects()
        {
            return MyGameObjects;
        }

        public void Remove()
        {
            World = null;
            Converter.RemoveAllComponents(this);
        }

        public void Clear()
        {
            MyGameObjects.Clear();
            Program.Windows.Remove(this);
        }

    }
}
