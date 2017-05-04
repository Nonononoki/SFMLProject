using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutCanvas
    {
        //the playing field
        public float Top { get; set; }
        public float Bottom { get; set; }
        public float Left { get; set; }
        public float Right { get; set; }

        public BreakOutCanvas(float top, float bottom, float left, float right)
        {
            this.Top = top;
            this.Bottom = bottom;
            this.Left = left;
            this.Right = right;
        }
    }
}
