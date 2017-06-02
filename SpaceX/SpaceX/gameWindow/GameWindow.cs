using SFML.Graphics;
using SpaceX.gameObject;
using SpaceX.gameWindow;
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
        public GameWindowData GameWindowData { set; get; }
        public LevelData LevelData { set; get; }
        public Ship Ship { set; get; }
        public static BulletPool BulletPool { set; get; }
        public HUD HUD { set; get; }
        public GameWindow()
        {
            GameWindowData = new GameWindowData();
            Ship = new Ship(GameWindowData);
            BulletPool = new BulletPool(GameWindowData, Ship);
            HUD = new HUD(GameWindowData);
            LevelData = new LevelData(Level.Value);
        }

        public void Update()
        {
            //draw sprites
            foreach (GameObject go in GameObject._list)
            {
                go.Update();
            }

        }
    }
}
