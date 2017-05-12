using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutBricks : GameObject
    {

        public int hp;
        public int maxLevel;
        public static List<BreakOutBricks> _bricks;
        private static BreakOutPattern _pattern;


        public BreakOutBricks(int hp, int maxLevel)
        {
            this.hp = hp;
            this.maxLevel = maxLevel;
            if (_bricks == null) _bricks = new List<BreakOutBricks>();
            if (_pattern == null) _pattern = new BreakOutPattern(maxLevel);
        }

        //Set position for single brick
        public void Spawn(Vector2 pos)
        {
            this.Position = pos;
            Body.Position = pos;
            Sprite.Position = new Vector2f(pos.X, pos.Y);
            Fixture.OnCollision += OnCollision;
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            hp--;

            if(hp == 0)
            {
                //destroy block when blockHP reaches 0
                _bricks.Remove(this);

                //check if every brick has been destroyed
                if (!_bricks.Any())
                {

                }

            }

            return true;
        }
    }
}
