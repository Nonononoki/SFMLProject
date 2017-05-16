using FarseerPhysics;
using FarseerPhysics.Common;
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
        //List of body IDs ball currently touching
        public List<int> CollisionBodyID = new List<int>();

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

            Move();
        }

        //reset ball after losing
        public void Reset(Vector2 v)
        {
            Sticky = true;
            Direction = new Vector2(0, 0);
            Position = v;
            Body.LinearVelocity = new Vector2(0, 0);
        }

        public void EnableCollision()
        {
            Fixture.OnCollision += OnCollision;
            Fixture.OnSeparation += OnSeparation;
        }

        private void OnSeparation(Fixture fixtureA, Fixture fixtureB)
        {
            int bodyid = fixtureB.Body.BodyId;
            CollisionBodyID.Remove(bodyid);
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            if(!IsTouching(fixtureB))
            {
                /* Get contact point
                 * https://gamedev.stackexchange.com/questions/72658/how-can-i-determine-the-contact-point-of-a-collision
                 */
                Vector2 normal;
                FixedArray2<Vector2> worldPoints;
                contact.GetWorldManifold(out normal, out worldPoints);

                if (contact.Manifold.PointCount >= 1)
                {
                    Vector2 contactPoint = worldPoints[0];
                    Direction = Vector2.Reflect(Direction, normal);

                    //Reflect with new Direction
                    Move();

                    //save id so it wont collide again with same object
                    int bodyid = fixtureB.Body.BodyId;
                    CollisionBodyID.Add(bodyid);
                }
            }
            return true;
        }

        //check if ball is touching the same body of the fixture
        private bool IsTouching(Fixture f)
        {
            foreach(int i in CollisionBodyID)
            {
                if (i == f.Body.BodyId) return true;
            }
            return false;
        }
             

        //move ball with when paddle is sticky
        public void SetPosition(Vector2 v, float ballPaddleDistance)
        {
            
            Position = new Vector2(v.X, v.Y - ballPaddleDistance);
            //Body.Position = Position;
            Body.Position = ConvertUnits.ToSimUnits(Position);
            Sprite.Position = new Vector2f(Position.X, Position.Y);
            
        }
    }
}
