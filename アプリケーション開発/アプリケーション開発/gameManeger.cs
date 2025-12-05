using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class GameManeger
    {
        Ball ball;          // 定義設定
        paddle paddle;
       Block block;
        List<Block> blocks=new List<Block>();
        int width, height;

        public GameManeger(int w, int h)
        {
        width = w;
        height = h;     // ここまで

            //ブロック生成
            ball = new Ball(150,300);
            paddle=new paddle(w/2-50,h-40);

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
        
        }
    }
}
