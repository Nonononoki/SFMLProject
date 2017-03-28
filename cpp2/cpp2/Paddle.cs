using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Paddle
{
    public float height { get; set; }
    public float width { get; set; }
    public float speed { get; set; }
    public Vector2f pos { get; set; }

    public Paddle()
    {
    }

    public Paddle(float width, float height, float speed, Vector2f pos)
    {
        this.width = width;
        this.height = height;
        this.speed = speed;
        this.pos = pos;
    }

    public void moveUp()
    {
        pos = new Vector2f(pos.X, pos.Y - speed);
    }

    public void moveDown()
    {
        pos = new Vector2f(pos.X, pos.Y + speed);
    }
}

