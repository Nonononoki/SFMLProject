using FarseerPhysics;
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

        public void MoveLeft(BreakOutBall ball, float ballPaddleDistance)
        {

            if (Position.X - Size.X / 2 > LeftLimit)
            {
                Direction = new Vector2(-1, 0);
                //this.Move();
                //dont apply force, just set position
                Vector2 newPos = Position + Direction * Speed;
                SetPosition(newPos);

                //check if ball is sticky
                if (ball.Sticky)
                {
                    Vector2 v = new Vector2(Sprite.Position.X, Sprite.Position.Y);
                    ball.SetPosition(v, ballPaddleDistance);
                }
            }

        }

        public void MoveRight(BreakOutBall ball, float ballPaddleDistance)
        {
            if (Position.X + Size.X / 2 < RightLimit)
            {
                Direction = new Vector2(1, 0);
                //this.Move();
                //dont apply force, just set position
                Vector2 newPos = Position + Direction * Speed;
                SetPosition(newPos);

                //check if ball is sticky
                if (ball.Sticky)
                {
                    Vector2 v = new Vector2(Sprite.Position.X, Sprite.Position.Y);
                    ball.SetPosition(v, ballPaddleDistance);
                }
            }
        }

        //reset paddle after losing
        public void Reset()
        {
            SetPosition(DefaultPosition);
        }
    }
}
