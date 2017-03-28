using System;

public class Ball
{
    private float radius { get; set; }
    private Vector2D pos { get; set; }
    private Vector2D mov { get; set; }

    public Ball()
	{
	}

    //detect collisions
    public bool PaddleCollision(FoePaddle fp, MyPaddle mp)
    {
        if()
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //colliding with canvas top and bottom
    public bool CanvasTopBottomCollision(Canvas cv)
    {
        if ()
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //colliding with canvas left and right
    public bool CanvasLeftRightCollision(Canvas cv)
    {
        if ()
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
