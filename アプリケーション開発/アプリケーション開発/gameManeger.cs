using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace アプリケーション開発
{
    public class gameManeger
    {
        Ball ball;
        paddle paddle;
       block block;
        List<block> blocks=new List<block>();
        int width, height;

        public gameManeger(int w, int h)
        {
        width = w;
        height = h;

            ball = new Ball(150,300);
            paddle=new paddle(w/2-50,h-40);

        }

    }
}
