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
        public Vector2 MoveForce { get; set; }

        public BreakOutPaddle(float leftLimit, float rightLimit)
        {
            this.LeftLimit = leftLimit;
            this.RightLimit = rightLimit;
        }

        public void MoveLeft(DeltaTime dt)
        {           
            //limit left movement
            if (Body.Position.Y + Size.X / 2 < LeftLimit)
                Body.ApplyForce(-MoveForce * dt.Time);
        }

        public void MoveRight(DeltaTime dt)
        {
            //limit right movement
            if (Body.Position.Y - Size.X / 2 > RightLimit)
                Body.ApplyForce(MoveForce * dt.Time);
        }


    }
}
