using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class block
    {
        public float X, Y;
        public int width = 50;
        public int height = 20;

        public block(float x,float y)
        {
        X = x;
        Y = y;
        }

        public RectangleF Rect => new RectangleF(X, Y, width, height);

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, Rect);

        }
    }
}
