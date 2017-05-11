using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutPaddle : GameObject
    {
        //limit movement range of Paddle
        public float LeftLimit { get; set; }
        public float RightLimit { get; set; }

        public BreakOutPaddle(float leftLimit, float rightLimit)
        {
            this.LeftLimit = leftLimit;
            this.RightLimit = rightLimit;
        }

        public void MoveLeft(DeltaTime dt, BreakOutBall ball, float ballPaddleDistance)
        {

            Direction = new Vector2(-1, 0);
            this.Move(dt.Time);

            //check if ball is sticky
            if (ball.Sticky)
            {
                Vector2 v = new Vector2(Sprite.Position.X, Sprite.Position.Y);
                 ball.SetPosition(v, ballPaddleDistance);
            }
               
        }

        public void MoveRight(DeltaTime dt, BreakOutBall ball, float ballPaddleDistance)
        {

            Direction = new Vector2(1, 0);
            this.Move(dt.Time);

            //check if ball is sticky
            if (ball.Sticky)
            {
                //ball.SetPosition(Position);
                Vector2 v = new Vector2(Sprite.Position.X, Sprite.Position.Y);
                ball.SetPosition(v, ballPaddleDistance);
            }
        }

        //reset paddle after losing
        public void Reset(Vector2 v)
        {
            Position = v;
            Body.Position = v;
            Sprite.Position = new Vector2f(v.X, v.Y);
        }


    }
}
