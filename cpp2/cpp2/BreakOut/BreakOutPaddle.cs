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
        public float Speed { get; set; }

        public BreakOutPaddle(float leftLimit, float rightLimit)
        {
            this.LeftLimit = leftLimit;
            this.RightLimit = rightLimit;
        }

        public void MoveLeft(DeltaTime dt)
        {
            //limit left movement
            if (Sprite.Position.X - Size.X / 2 > LeftLimit)
            {
                Vector2 v = new Vector2(-Speed * dt.Time, 0);
                this.Move(v);
            }
        }

        public void MoveRight(DeltaTime dt)
        {
            //limit right movement
            if (Sprite.Position.X + Size.X / 2 < RightLimit)
            {
                Vector2 v = new Vector2(Speed * dt.Time, 0);
                this.Move(v);
            }
        }


    }
}
