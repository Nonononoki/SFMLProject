using SFML.Graphics;
using SpaceX.bossWindow;
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
        public StartWindowData SD;
        public List<GameObject> MyGameObjects;

        public StartWindow()
        {
            //Program.Windows.Add(this);
            Program.Windows.Insert(0, this);
            SD = new StartWindowData(this);
            MyGameObjects = SD.MyGameObjects;
        }
        
        public void Update()
        {
            //draw sprites
            foreach (GameObject go in MyGameObjects.ToList<GameObject>())
            {
                go.Update();
            }
        }

        public void LoadNextWindow()
        {
            Remove();
            //Open next Window with loading screen

            //GameLoadingWindow GLW = new GameLoadingWindow();

            //testing bossmap
            BossWindow BW = new BossWindow();

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
