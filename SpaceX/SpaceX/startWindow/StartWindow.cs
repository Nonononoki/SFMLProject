using SFML.Graphics;
using SpaceX.gameWindow.gameLoadingWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.window
{
    class StartWindow : IWindow
    {
        public int Index { set; get; }
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
            foreach (GameObject go in SD.MyGameobjects.ToList<GameObject>())
            {
                go.Update();
            }
        }

        public void LoadNextWindow()
        {
            DeleteMe();
            //Open next Window with loading screen
            GameLoadingWindow GLW = new GameLoadingWindow();
            //GameWindow GW = new GameWindow();
        }

        public void DeleteMe()
        {
            Program.Windows.RemoveAt(Index);
            Converter.RemoveAllComponents(SD.MyGameobjects);
            SD.MyGameobjects.Clear();
        }
    }
}
