using SpaceX.gameOverWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.hero
{
    class HeroDirections
    {
        public enum Direction { Up, Down, Left, Right };
        public AnimationComponent AC { set; get; }
        public Direction Value { set; get; }
    }
}
