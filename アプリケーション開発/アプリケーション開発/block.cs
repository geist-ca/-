using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class Block
    {
        public float X, Y;      // 初期値設定
        public int width = 50;
        public int height = 20;

        public bool IsDestroyed=false;
        public Block(float x,float y)
        {
        X = x;
        Y = y;      // ここまで
        }

        //ブロックを表示させるためのプログラミング
        public RectangleF Rect => new RectangleF(X, Y, width, height);

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, Rect);

        }
    }
}
