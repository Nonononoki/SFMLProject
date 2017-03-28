using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Paddle
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
}

