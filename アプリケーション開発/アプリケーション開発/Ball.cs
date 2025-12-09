using System.Drawing;

public class Ball
{
    public int X, Y;
    public int VX = 4;
    public int VY = -4;
    public int Size = 10;

    public Ball(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Rectangle Rect => new Rectangle(X, Y, Size, Size);
    public int Right => X + Size;
    public int Bottom => Y + Size;

    public void Move()
    {
        X += VX;
        Y += VY;
    }

    public void Reset()
    {
        X = 150;
        Y = 300;
        VX = 4;
        VY = -4;
    }

    public void Draw(Graphics g)
    {
        g.FillEllipse(Brushes.White, Rect);
    }
}
