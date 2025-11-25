using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class Ball
    {
        public float X, Y;
        public float VX = 4, VY = -4;
        public int size = 10;

        public Ball(float x,float y)
        {
        X = x;
        Y = y;
        }

    }

}
