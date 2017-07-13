using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class TimedDestructionComponent : ILogicComponent
    {
        public int DestroyTime { set; get; }
        public GameObject GameObject { set; get; }
        public Stopwatch SW { set; get; }

        public TimedDestructionComponent(int DestroyTime, GameObject GameObject)
        {
            this.DestroyTime = DestroyTime;
            this.GameObject = GameObject;
            SW = new Stopwatch();
        }

        public void Start()
        {
            SW.Start();
        }

        public void Destroy()
        {
            // throw new NotImplementedException();
            BossWindow.ToBeRemoved.Add(GameObject);
        }

        public void Update()
        {
            // throw new NotImplementedException();
            if (SW.ElapsedMilliseconds >= DestroyTime)
                Destroy();
        }
    }
}
