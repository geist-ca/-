using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class Ball
    {
        public float X, Y;              //初期値設定
        public float VX = 4, VY = -4;
        public int size = 10;

        public Ball(float x,float y)
        {
        X = x;
        Y = y;
        }
        //ここまで
        public RectangleF Rect => new RectangleF(X, Y, size, size);

        public float Right => X + size;

        public void Move() 
        {
            X += VX;
            Y += VY;
        }
        public void Draw(Graphics g) 
        {
            g.FillEllipse(Brushes.Red, Rect);
        
        }
        public void Reset() 
        {
            X = 150;
            Y = 300;
            VX = 4;
            VY = 4;
        }
    }



}
