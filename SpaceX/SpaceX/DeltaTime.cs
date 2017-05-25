using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    public class DeltaTime
    {
        public float Time { get; set; }
        Stopwatch sw;

        public DeltaTime()
        {
            Time = 0;
            sw = new Stopwatch();
        }

        public void Start()
        {
            sw.Start();
        }
        public void Stop()
        {
            Time = sw.ElapsedTicks / (float)Stopwatch.Frequency;
            sw.Restart();
        }

    }
}
