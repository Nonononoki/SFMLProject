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
        public BossFire BossFire { set; get; }
        public Stopwatch SW { set; get; }

        public BossFireLogic(int DestroyTime, BossFire BossFire)
        {
            this.DestroyTime = DestroyTime;
            this.BossFire = BossFire;
            SW = new Stopwatch();
        }

        public void Start()
        {
            SW.Start();
        }

        public void Destroy()
        {
            // throw new NotImplementedException();
            BossWindow.ToBeRemoved.Add(BossFire);
        }

        public void Update()
        {
            // throw new NotImplementedException();
            if (SW.ElapsedMilliseconds >= DestroyTime)
                Destroy();
        }
    }
}
