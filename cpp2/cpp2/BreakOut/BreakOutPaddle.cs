using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BrickBreak
{
    class BreakOutPaddle
    {
        public Body body;

        //limit movement range of Paddle
        public float LeftLimit { get; set; }
        public float RightLimit { get; set; }
        public float MoveForce { get; set; }
        public Vector2 Size { get; set; }

        public BreakOutPaddle(Body body, float leftLimit, float rightLimit)
        {
            this.body = body;
            this.LeftLimit = leftLimit;
            this.RightLimit = rightLimit;
            MoveForce = 10f;
        }

        public void MoveLeft(DeltaTime dt)
        {           
            //limit left movement
            if (body.Position.Y + Size.X / 2 < LeftLimit)
                body.ApplyForce(new Vector2(-MoveForce * dt.Time, 0));
        }

        public void MoveRight(DeltaTime dt)
        {
            //limit right movement
            if (body.Position.Y - Size.X / 2 > RightLimit)
                body.ApplyForce(new Vector2(MoveForce * dt.Time, 0));
        }


    }
}
