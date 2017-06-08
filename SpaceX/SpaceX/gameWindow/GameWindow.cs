using SFML.Graphics;
using SpaceX.gameObject;
using SpaceX.gameOverWindow;
using SpaceX.gameWindow;
using SpaceX.gameWindow.asteroid;
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

        public GameWindow()
        {
            GameObject.DestroyAll();
            GameWindowData = new GameWindowData();
            Ship = new Ship(GameWindowData);
            HUD = new GameHUD(GameWindowData);

            LevelData = new LevelData(Level.Value);
            AsteroidPool = new AsteroidPool(LevelData,Ship);

            Ship.AddComponent(AsteroidPool);

            Program.Windows.Add(this);
            Index = Program.Windows.IndexOf(this);
        }

        public void Update()
        {
            //draw sprites
            foreach (GameObject go in GameObject._list.ToList<GameObject>())
            {
                go.Update();
            }
        }

        public static void LoadNextLevel()
        {
            Level.Value++;

            //check if last level reached
            if(Level.Value <= GameWindowData.MaxLevel)
            {
                Ship.RemoveComponent(AsteroidPool);
                LevelData = new LevelData(Level.Value);
                //Ship = new Ship(GameWindowData);
                AsteroidPool = new AsteroidPool(LevelData, Ship);
                Ship.AddComponent(AsteroidPool);
            }

            else
            {
                GameOver();
            }
        }

        public static void GameOver()
        {
            //Game Over!
            //Open next Window
            GameOverWindow GOW = new GameOverWindow(Score.Value);
            Program.Windows.Add(GOW);
            Program.Windows.RemoveAt(Index);
        }

    }
}
