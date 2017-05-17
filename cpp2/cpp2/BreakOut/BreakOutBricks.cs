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
        private int score = 100; //get score from breaking block
        public int hp;
        public static List<BreakOutBricks> _bricks;

        //store reference of pattern 
        private BreakOutPattern pattern;

        public BreakOutBricks(int hp, BreakOutPattern pattern)
        {
            this.hp = hp;
            this.pattern = pattern;
            if (_bricks == null) _bricks = new List<BreakOutBricks>();
        }

        //Set position for single brick
        public void Spawn()
        {
            Body.BodyType = BodyType.Static;
            Fixture.OnCollision += OnCollision;
            _bricks.Add(this);
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            hp--;

            if(hp == 0)
            {
                //destroy block when blockHP reaches 0
                _bricks.Remove(this);
                this.Destroy();

                //increase score
                pattern.score.Score += score;
                pattern.score.UpdateScore();

                //check if every brick has been destroyed
                if (!_bricks.Any())
                {
                    pattern.currentLevel++;
                    pattern.LoadPattern(pattern.currentLevel);
                }

            }

            return true;
        }
    }
}
