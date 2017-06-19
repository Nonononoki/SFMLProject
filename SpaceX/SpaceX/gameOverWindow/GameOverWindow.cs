using SpaceX.gameWindow;
using SpaceX.gameWindow.background;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameOverWindow
{
    class GameOverWindow : IWindow
    {
        public GameOverHUD Hud { set; get; }
        public GameOverBackground GOBG { set; get; }
        public GameOverWindowData GOWD { set; get; }

        public List<GameObject> MyGameObjects { set; get; }

        public GameOverWindow(int score)
        {
            MyGameObjects = new List<GameObject>();

            GOWD = new GameOverWindowData();
            //GameObject.DestroyAll();

            //stop bgm
            //GameBackground.BGM.Sound.Stop();

            GOBG = new GameOverBackground(GOWD, this);
            Hud = new GameOverHUD(GOWD, score);

            MyGameObjects.Add(GOBG);
            MyGameObjects.Add(Hud);

            //assign window ID
            //Program.Windows.Add(this);
            Program.Windows.Insert(0, this);
        }

        public void Update()
        {
            //draw sprites
            foreach (GameObject go in GameObject._list.ToList<GameObject>())
            {
                go.Update();
            }
        }

        public void LoadNextWindow()
        {
            //Open next Window
            Remove();
            StartWindow SW = new StartWindow();
        }

        public List<GameObject> GameObjects()
        {
            return MyGameObjects;
        }

        public void Remove()
        {
            Converter.RemoveAllComponents(this);
        }

        public void Clear()
        {
            MyGameObjects.Clear();
            Program.Windows.Remove(this);
        }
    }
}
