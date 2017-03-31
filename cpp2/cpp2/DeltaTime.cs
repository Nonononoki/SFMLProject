using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2
{
    public class DeltaTime
    {
        public long time { get; set; }
        Stopwatch sw;

        public DeltaTime()
        {
            time = 5; //average tick rate
            sw = new Stopwatch();
        }

        public void Start()
        {
            sw.Start();
        }
        public void Stop()
        {
            sw.Stop();
            time = sw.ElapsedTicks / Stopwatch.Frequency;
        }
        
    }
}
