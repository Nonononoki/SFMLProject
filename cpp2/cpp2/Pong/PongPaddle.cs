using gpp2;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class PongPaddle
{
    public float Height { get; set; }
    public float Width { get; set; }
    public float Speed { get; set; }
    public Vector2f Pos { get; set; }

    //limit movement range of Paddle
    public float MinHeight { get; set; }
    public float MaxHeight { get; set; }


    public PongPaddle()
    {
    }

    public PongPaddle(float width, float height, float speed, Vector2f pos)
    {
        this.Width = width;
        this.Height = height;
        this.Speed = speed;
        this.Pos = pos;
    }

    public void MoveUp(DeltaTime dt)
    {
        if (Pos.Y - Height / 2 > MinHeight)
            Pos = new Vector2f(Pos.X, Pos.Y - Speed * dt.Time);
    }

    public void MoveDown(DeltaTime dt)
    {
        if (Pos.Y + Height / 2 < MaxHeight)
            Pos = new Vector2f(Pos.X, Pos.Y + Speed * dt.Time);
    }
}

