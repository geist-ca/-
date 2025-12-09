using System;
using System.Collections.Generic;
using System.Drawing;

public class GameManager
{
    Ball ball;
    Paddle paddle;
    List<Block> blocks = new List<Block>();
    int width, height;

    public GameManager(int w, int h)
    {
        width = w;
        height = h;

        ball = new Ball(150, 300);
        paddle = new Paddle(w / 2 - 50, h - 40);

        // ブロック生成
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 8; x++)
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
        // ------- パドル衝突判定（最優先） -------
        if (ball.Rect.IntersectsWith(paddle.Rect))
        {
            ball.VY = -Math.Abs(ball.VY);
        }

        // ------- ブロック衝突判定（バグ修正済み） -------
        foreach (var block in blocks)
        {
            if (!block.IsDestroyed && ball.Rect.IntersectsWith(block.Rect))
            {
                block.IsDestroyed = true;
                ball.VY *= -1;
                break; // return 禁止（判定スキップ防止）
            }
        }

        // ------- ボール移動 -------
        ball.Move();

        // ------- 壁衝突 -------
        if (ball.X < 0 || ball.Right > width)
            ball.VX *= -1;

        if (ball.Y < 0)
            ball.VY *= -1;

        // 下に落ちたらリセット
        if (ball.Y > height)
            ball.Reset();
    }

    public void Draw(Graphics g)
    {
        ball.Draw(g);
        paddle.Draw(g);

        foreach (var block in blocks)
        {
            if (!block.IsDestroyed)
                block.Draw(g);
        }
    }
}
