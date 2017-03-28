using SFML.System;
using System;

public class MyPaddle : Paddle
{
    public MyPaddle()
	{
	}

    public MyPaddle(float width, float height, float speed, Vector2f pos) : base(width, height, speed, pos)
    { 
    }
}
