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

        public void MoveLeft(DeltaTime dt, BreakOutBall ball)
        {
            //limit left movement
            if (Sprite.Position.X - Size.X / 2 > LeftLimit)
            {
                Direction = new Vector2(-1, 0);
                this.Move(dt.Time);

                //check if ball is sticky
                if (ball.Sticky)
                {
                    ball.Position = new Vector2(Position.X, ball.Position.Y);
                }
            }    
        }

        public void MoveRight(DeltaTime dt, BreakOutBall ball)
        {
            //limit right movement
            if (Sprite.Position.X + Size.X / 2 < RightLimit)
            {
                Direction = new Vector2(1, 0);
                this.Move(dt.Time);

                //check if ball is sticky
                if (ball.Sticky)
                {
                    ball.Position = new Vector2(Position.X, ball.Position.Y);
                }
            }   
        }


    }
}
