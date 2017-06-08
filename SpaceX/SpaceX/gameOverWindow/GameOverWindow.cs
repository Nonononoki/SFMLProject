using SpaceX.gameWindow;
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
        public static int Index { set; get; }
        public GameOverHUD Hud { set; get; }
        public GameOverBackground GOBG { set; get; }
        public GameOverWindowData GOWD { set; get; }

        public GameOverWindow(int score)
        {
            GOWD = new GameOverWindowData();
            GameObject.DestroyAll();

            GOBG = new GameOverBackground(GOWD);
            Hud = new GameOverHUD(GOWD, score);

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

        public static void LoadNextWindow()
        {
            //Open next Window
            StartWindow SW = new StartWindow();
            Program.Windows.Add(SW);
            Program.Windows.RemoveAt(Index);
        }
    }
}
