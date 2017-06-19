using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    interface IWindow
    {
        List<GameObject> GameObjects();
        void Update();
        void Remove();
        void Clear();
    }
}
