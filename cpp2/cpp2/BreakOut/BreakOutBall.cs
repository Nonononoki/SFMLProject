using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutBall : GameObject
    {
        //vector of direction
        public Vector2f Direction { set; get; }

        //Speed of ball
        public float Speed { set; get; }

        //list of gameobject  ball is currently colliding with
        public List<GameObject> Touch { set; get; }
    }
}
