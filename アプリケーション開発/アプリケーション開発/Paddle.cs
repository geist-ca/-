using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace アプリケーション開発
{
    public class paddle
    {
        public float X, Y;      //初期値設定
        public int width = 100;
        public int height = 15;

        public paddle(float x, float y)
        {
            X = x;
            Y = y;          //ここまで
        }
        public void MoveTo(float mouseX)
        {
            X = mouseX - width / 2;
        }

        public void Draw(Graphics g, Block block)
        {
            g.FillRectangle(Brushes.Blue, block.Rect);
        }
    }
}

