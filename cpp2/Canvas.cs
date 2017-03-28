using System;

public class Canvas
{
    //the playing field

    private float height { get; set; }
    private float width { get; set; }

    public Canvas()
	{
	}

    public Canvas(float height, float width)
    {
        this.height = height;
        this.width = width;
    }
}
