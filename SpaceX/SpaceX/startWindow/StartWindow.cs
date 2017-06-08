using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.window
{
    class StartWindow : IWindow
    {
        public static int Index { set; get; }
        public StartWindowData SD;

        public StartWindow()
        {
            Program.Windows.Add(this);
            Index = Program.Windows.IndexOf(this);
            SD = new StartWindowData(this);
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
            Program.Windows.RemoveAt(Index);
            GameWindow GW = new GameWindow();
        }
    }
}
