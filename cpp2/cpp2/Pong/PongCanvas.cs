using System;

public class PongCanvas
{
    //the playing field

    public float Top { get; set; }
    public float Bottom { get; set; }
    public float Left { get; set; }
    public float Right { get; set; }
    public int Padding { get; set; }

    public PongCanvas()
	{
	}

    public PongCanvas(float top, float bottom, float left, float right, int padding)
    {
        this.Top = top;
        this.Bottom = bottom;
        this.Left = left;
        this.Right = right;
        this.Padding = padding;
    }
}
