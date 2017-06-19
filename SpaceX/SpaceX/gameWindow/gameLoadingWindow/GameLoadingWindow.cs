using SpaceX.gameOverWindow;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.gameLoadingWindow
{
    class GameLoadingWindow : IWindow
    {
        public GameWindow GameWindow { set; get; }
        public GameLoadingWindowData GLWD { set; get; }

        public GameObject LoadingIcon { set; get; }
        public RenderingComponent RC { set; get; }
        public AnimationComponent AC { set; get; }

        public List<GameObject> MyGameObjects { set; get; }

        public GameLoadingWindow()
        {
            //Program.Windows.Add(this);
            Program.Windows.Insert(0, this);
        
            GLWD = new GameLoadingWindowData();

            MyGameObjects = new List<GameObject>();

            LoadingIcon = new GameObject();
            MyGameObjects.Add(LoadingIcon);
            RC = new RenderingComponent(GLWD.IconPosition, GLWD.IconTexture, GLWD.IconSize, false);
            AC = new AnimationComponent(GLWD.AnimationSprites, GLWD.AnimationSpeed, RC, null, true);

            LoadingIcon.AddComponent(RC);
            LoadingIcon.AddComponent(AC);

            AC.Start();
            
            //https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                GameWindow = new GameWindow();
                this.Remove();

            }).Start();
        }
    

        public void Update()
        {
            //draw sprites
            foreach (GameObject go in MyGameObjects.ToList<GameObject>())
            {
                go.Update();
            }
        }

        public void Remove()
        {
            Converter.RemoveAllComponents(this);
        }

        public List<GameObject> GameObjects()
        {
            return MyGameObjects;
        }


        public void Clear()
        {
            MyGameObjects.Clear();
            Program.Windows.Remove(this);
        }
    }
}
