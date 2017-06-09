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
        public static int Index { set; get; }
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

        public GameWindow()
        {
            GameObject.DestroyAll();

            //static data first
            GameWindowData = new GameWindowData();

            //assign window id
            Program.Windows.Add(this);
            Index = Program.Windows.IndexOf(this);
            LevelData = new LevelData(1);        
            LevelUpSFX = new AudioComponent(GameWindowData.LevelUpPath, false);

            //load gameobjects
            GBG = new GameBackground(GameWindowData);
            HUD = new GameHUD(GameWindowData);
            Ship = new Ship(GameWindowData);

            //spawn asteroids
            AsteroidPool = new AsteroidPool(LevelData, GameWindowData, Ship);
            Ship.AddComponent(AsteroidPool);

            //remove to be deleted gameobjects
            ToBeRemoved = new List<GameObject>();
            CollisionList = new List<ICollidingComponent>();
        }

        public void Update()
        {
            //draw sprites
            foreach (GameObject go in GameObject._list.ToList<GameObject>())
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
                //Game Over!
                //Open next Window
                Program.Windows.RemoveAt(Index);
                GameOverWindow GOW = new GameOverWindow(Score.Value);
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

    }
}
