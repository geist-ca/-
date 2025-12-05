using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class GameManeger
    {
        Ball ball;          // 定義設定
        Paddle paddle;
       Block block;
        List<Block> blocks=new List<Block>();
        int width, height;

        public GameManeger(int w, int h)
        {
        width = w;
        height = h;     // ここまで

            //ブロック生成
            ball = new Ball(150,300);
            paddle=new Paddle(w/2-50,h-40);

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    blocks.Add(new Block(10 + x * 60, 10 + y * 30));
                }
            }

        }

        public void MovePaddle(int mouseX) 
        {
        paddle.MoveTo(mouseX);
        }

        public void Update()
        {
            ball.Move();

            if (ball.X < 0 || ball.Right > width)
            {
                ball.VX *= -1;
            }

            if (ball.Y < 0)
            {
                ball.VY *= -1;
            }

            if (ball.Rect.IntersectsWith(paddle.Rect))
            {
                ball.VY = -Math.Abs(ball.VY);
            }

            foreach (var block in blocks)
            {
                if (!block.IsDestroyed && ball.Rect.IntersectsWith(paddle.Rect))
                {
                    block.IsDestroyed = true;
                    ball.VY *= -1;
                    break;
                }
            }
            if (ball.Y >height)
            {
            ball.Reset();
            }
        }

        public void Draw(Graphics g) 
        {
        ball.Draw(g);
        paddle.Draw(g);

            foreach(var block in blocks)
            {
                if (!block.IsDestroyed) 
                {
                block.Draw(g);
                }
            }
        }

    }
}
