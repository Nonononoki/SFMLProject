using gpp2;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class PongPaddle
{
    public float height { get; set; }
    public float width { get; set; }
    public float speed { get; set; }
    public Vector2f pos { get; set; }

    //limit movement range of Paddle
    public float minHeight { get; set; }
    public float maxHeight { get; set; }


    public PongPaddle()
    {
    }

    public PongPaddle(float width, float height, float speed, Vector2f pos)
    {
        this.width = width;
        this.height = height;
        this.speed = speed;
        this.pos = pos;
    }

    public void MoveUp(DeltaTime dt)
    {
        if (pos.Y - height / 2 > minHeight)
            pos = new Vector2f(pos.X, pos.Y - speed * dt.time);
    }

    public void MoveDown(DeltaTime dt)
    {
        if (pos.Y + height / 2 < maxHeight)
            pos = new Vector2f(pos.X, pos.Y + speed * dt.time);
    }
}

