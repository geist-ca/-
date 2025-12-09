using System.Drawing;

public class Block
{
    public int X, Y;
    public int Width = 50;
    public int Height = 20;
    public bool IsDestroyed = false;

    public Block(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Rectangle Rect => new Rectangle(X, Y, Width, Height);

    public void Draw(Graphics g)
    {
        g.FillRectangle(Brushes.Orange, Rect);
        g.DrawRectangle(Pens.Black, Rect);
    }
}
