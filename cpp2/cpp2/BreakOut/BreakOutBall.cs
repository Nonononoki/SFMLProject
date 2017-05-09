using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using SFML.Graphics;
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
        //move ball with paddle when starting
        public bool Sticky { set; get; }

        public BreakOutBall()
        {
            Sticky = true;
            Direction = new Vector2(0, 0);              
        }

        //launch ball from paddle
        public void Launch()
        {
            Sticky = false;

            //new random Direction Vector
            Random random = new Random();
            int r = random.Next(0, 2);

            switch (r)
            {
                case 0:
                    Direction = new Vector2(1, -1); break;
                case 1:
                    Direction = new Vector2(-1, -1); break;
            }
        }

        
        private new bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            this.Shape.FillColor = Color.Yellow;
            return true;
        }
    }
}
