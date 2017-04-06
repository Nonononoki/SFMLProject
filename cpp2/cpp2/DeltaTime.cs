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
        public float time { get; set; }
        Stopwatch sw;

        public DeltaTime()
        {
            time = 0; 
            sw = new Stopwatch();
        }

        public void Start()
        {
            sw.Start();
        }
        public void Stop()
        {
            time = sw.ElapsedTicks / (float) Stopwatch.Frequency;
            sw.Restart();
        }
        
    }
}
