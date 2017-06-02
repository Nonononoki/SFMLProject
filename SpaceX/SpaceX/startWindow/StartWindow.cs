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
        public StartWindowData SD;

        public StartWindow()
        {
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
    }
}
