using System;

public class PongCanvas
{
    //the playing field

    public float top { get; set; }
    public float bottom { get; set; }
    public float left { get; set; }
    public float right { get; set; }
    public int padding { get; set; }

    public PongCanvas()
	{
	}

    public PongCanvas(float top, float bottom, float left, float right, int padding)
    {
        this.top = top;
        this.bottom = bottom;
        this.left = left;
        this.right = right;
        this.padding = padding;
    }
}
