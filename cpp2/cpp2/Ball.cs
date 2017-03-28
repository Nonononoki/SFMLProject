using SFML.System;
using System;

public class Ball
{
    public float speed = 0.1f;
    public float radius { get; set; }
    public Vector2f pos { get; set; }
    public Vector2f mov { get; set; }

    public Ball()
	{
	}

    //detect paddle collisions
    public void PaddleCollision(FoePaddle fp, MyPaddle mp)
    {
        if(true)
        {
            reflectPaddle();
        }
    }

    //colliding with canvas top and bottom
    public void CanvasTopBottomCollision(Canvas cv)
    {
        if (pos.Y + radius > cv.bottom + cv.padding || pos.Y - radius < cv.top - cv.padding)
        {
            reflectCanvas();
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

    public void respawn(int windowWidth, int windowHeight)
    {
        pos = new Vector2f(windowWidth / 2, windowHeight / 2);

        //new random mov vector
        Random random = new Random();
        int r = random.Next(0, 4);

        switch(r)
        {   
            case 0:
                mov = new Vector2f(1, 1) * speed; break;
            case 1:
                mov = new Vector2f(1, -1) * speed; break;
            case 2:
                mov = new Vector2f(-1, 1) * speed; break;
            case 3:
                mov = new Vector2f(-1, -1) * speed; break;
        }


    }

    private void reflectPaddle()
    {

    }

    private void reflectCanvas()
    {
        mov = new Vector2f(mov.X, -mov.Y);
    }
}
