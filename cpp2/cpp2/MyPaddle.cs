using SFML.System;
using System;

public class MyPaddle
{
    public float height { get; set; }
    public float width { get; set; }
    public float maxSpeed { get; set; }
    public Vector2f pos { get; set; }


    public MyPaddle()
	{
	}

    public MyPaddle(float width, float height, float maxSpeed, Vector2f pos)
    {
        this.width = width;
        this.height = height;
        this.maxSpeed = maxSpeed;
        this.pos = pos;
    }
}
