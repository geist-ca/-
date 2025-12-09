using System.Drawing;

public class Paddle
{
    public int X, Y;
    public int Width = 100;
    public int Height = 15;

    public Paddle(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Rectangle Rect => new Rectangle(X, Y, Width, Height);

    public void MoveTo(int mouseX)
    {
        X = mouseX - Width / 2;
    }

    public void Draw(Graphics g)
    {
        g.FillRectangle(Brushes.LightBlue, Rect);
    }
}
