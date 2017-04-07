using SFML.System;
using System;

public class Ball
{
    public float speed;
    public float radius { get; set; }
    public Vector2f pos { get; set; }
    public Vector2f mov { get; set; }

    private const float speedIncrease = 1.1f;
    private float minSpeed;

    public Ball(float speed)
	{
        this.speed = speed;
        minSpeed = speed;
	}

    //detect paddle collisions
    public void PaddleCollision(Paddle paddle, bool left)
    {
        //treat ball like a square

        //leftmost of Ball, not real points
        float leftPoint = pos.X - radius;
        //rightmost Point of Ball
        float rightPoint = pos.X + radius;
        //top Point of Ball
        float topPoint = pos.Y - radius;
        //bottom Point of Ball
        float bottomPoint = pos.Y + radius;

        //hit left paddle!
        if (left)
        {
            if (leftPoint < paddle.pos.X + paddle.width/2
                && bottomPoint > paddle.pos.Y - paddle.height/2
                && topPoint < paddle.pos.Y + paddle.height / 2)
            {
                ReflectPaddle();
            }
        }

        //hit right paddle!
        if (!left)
        {
            if (rightPoint > paddle.pos.X - paddle.width/2
                && bottomPoint > paddle.pos.Y - paddle.height/2
                && topPoint < paddle.pos.Y + paddle.height/2)
            {
                ReflectPaddle();
            }
        }
    }

    //colliding with canvas top and bottom
    public void CanvasTopBottomCollision(Canvas cv)
    {
        if (pos.Y + radius > cv.bottom + cv.padding || pos.Y - radius < cv.top - cv.padding)
        {
            ReflectCanvas();
        }
    }

    //colliding with canvas right
    public bool CanvasRightCollision(Canvas cv)
    {
        if (pos.X + radius > cv.right + cv.padding)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //colliding with canvas left
    public bool CanvasLeftCollision(Canvas cv)
    {
        if (pos.X - radius < cv.left - cv.padding)
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
        pos = new Vector2f(windowWidth / 2, windowHeight / 2);

        //new random mov vector
        Random random = new Random();
        int r = random.Next(0, 4);

        switch(r)
        {   
            case 0:
                mov = new Vector2f(1, 1); break;
            case 1:
                mov = new Vector2f(1, -1); break;
            case 2:
                mov = new Vector2f(-1, 1); break;
            case 3:
                mov = new Vector2f(-1, -1); break;
        }

        //reset speed
        speed = minSpeed;

    }

    private void ReflectPaddle()
    {
        mov = new Vector2f(-mov.X, mov.Y);

        //make it faster!
        speed = speed * speedIncrease;
    }

    private void ReflectCanvas()
    {
        mov = new Vector2f(mov.X, -mov.Y);
    }
}
