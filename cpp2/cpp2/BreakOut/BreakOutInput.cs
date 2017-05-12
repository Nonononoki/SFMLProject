﻿using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutInput
    {
        public void KeyboardInPut(BreakOutPaddle paddle, BreakOutBall ball, float ballPaddleDistance)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                paddle.MoveLeft(ball, ballPaddleDistance);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                paddle.MoveRight(ball, ballPaddleDistance);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                if (ball.Sticky) ball.Launch();
            }
        }
    }
}
