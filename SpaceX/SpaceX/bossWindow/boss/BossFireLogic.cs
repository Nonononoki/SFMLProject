using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.boss
{
    class BossFireLogic : ILogicComponent
    {
        public int DestroyTime { set; get; }
        public Stopwatch SW { set; get; }

        public void Destroy()
        {
           // throw new NotImplementedException();
        }

        public void Update()
        {
           // throw new NotImplementedException();
        }
    }
}
