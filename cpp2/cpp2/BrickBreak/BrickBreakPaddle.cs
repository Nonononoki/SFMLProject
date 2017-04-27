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
    class BrickBreakPaddle
    {
        public Body body;

        //limit movement range of Paddle
        public float leftLimit { get; set; }
        public float rightLimit { get; set; }
        public float moveForce { get; set; }
        public Vector2 size { get; set; }

        public BrickBreakPaddle(Body body, float leftLimit, float rightLimit)
        {
            this.body = body;
            this.leftLimit = leftLimit;
            this.rightLimit = rightLimit;
            moveForce = 10f;
        }

        public void MoveLeft(DeltaTime dt)
        {           
            //limit left movement
            if (body.Position.Y + size.X / 2 < leftLimit)
                body.ApplyForce(new Vector2(-moveForce * dt.time, 0));
        }

        public void MoveRight(DeltaTime dt)
        {
            //limit right movement
            if (body.Position.Y - size.X / 2 > rightLimit)
                body.ApplyForce(new Vector2(moveForce * dt.time, 0));
        }


    }
}
