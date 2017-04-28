using SFML.System;
using System;

public class PongBall
{
    public float Speed;
    public float Radius { get; set; }
    public Vector2f Pos { get; set; }
    public Vector2f Mov { get; set; }

    private const float speedIncrease = 1.1f;
    private float minSpeed;

    public PongBall(float speed)
	{
        this.Speed = speed;
        minSpeed = speed;
	}

    //detect paddle collisions
    public void PaddleCollision(PongPaddle paddle, bool left)
    {
        //treat ball like a square

        //leftmost of Ball, not real points
        float leftPoint = Pos.X - Radius;
        //rightmost Point of Ball
        float rightPoint = Pos.X + Radius;
        //top Point of Ball
        float topPoint = Pos.Y - Radius;
        //bottom Point of Ball
        float bottomPoint = Pos.Y + Radius;

        //hit left paddle!
        if (left)
        {
            if (leftPoint < paddle.Pos.X + paddle.Width/2
                && bottomPoint > paddle.Pos.Y - paddle.Height/2
                && topPoint < paddle.Pos.Y + paddle.Height / 2)
            {
                ReflectPaddle();
            }
        }

        //hit right paddle!
        if (!left)
        {
            if (rightPoint > paddle.Pos.X - paddle.Width/2
                && bottomPoint > paddle.Pos.Y - paddle.Height/2
                && topPoint < paddle.Pos.Y + paddle.Height/2)
            {
                ReflectPaddle();
            }
        }
    }

    //colliding with canvas top and bottom
    public void CanvasTopBottomCollision(PongCanvas cv)
    {
        if (Pos.Y + Radius > cv.Bottom + cv.Padding || Pos.Y - Radius < cv.Top - cv.Padding)
        {
            ReflectCanvas();
        }
    }

    //colliding with canvas right
    public bool CanvasRightCollision(PongCanvas cv)
    {
        if (Pos.X + Radius > cv.Right + cv.Padding)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //colliding with canvas left
    public bool CanvasLeftCollision(PongCanvas cv)
    {
        if (Pos.X - Radius < cv.Left - cv.Padding)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void Respawn(int windowWidth, int windowHeight)
    {
        Pos = new Vector2f(windowWidth / 2, windowHeight / 2);

        //new random mov vector
        Random random = new Random();
        int r = random.Next(0, 4);

        switch(r)
        {   
            case 0:
                Mov = new Vector2f(1, 1); break;
            case 1:
                Mov = new Vector2f(1, -1); break;
            case 2:
                Mov = new Vector2f(-1, 1); break;
            case 3:
                Mov = new Vector2f(-1, -1); break;
        }

        //reset speed
        Speed = minSpeed;

    }

    private void ReflectPaddle()
    {
        Mov = new Vector2f(-Mov.X, Mov.Y);

        //make it faster!
        Speed = Speed * speedIncrease;
    }

    private void ReflectCanvas()
    {
        Mov = new Vector2f(Mov.X, -Mov.Y);
    }
}
