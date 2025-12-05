using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace アプリケーション開発
{
    public partial class Form1 : Form
    {
        GameManeger game;
        private Panel GamePanel;
        private Timer GameTimer;
        public Form1()
        {
            InitializeComponent();

            GamePanel = new Panel();
            GamePanel.Location = new Point(10, 10);      // 位置
            GamePanel.Size = new Size(400, 300);         // サイズ
            GamePanel.BackColor = Color.Black;           // 背景色
            this.Controls.Add(GamePanel);
            DoubleBuffered = true;

            game=new GameManeger(GamePanel.Width,GamePanel.Height);
            GameTimer.Interval = 16;
            GameTimer.Start();
        }
        private void GameTimer_Tick(object sender, EventArgs e) 
        {
            game.Update();
            GamePanel.Invalidate();
        }

        private void Game_Panel(object sender, PaintEventArgs e) 
        {
            game.Draw(e.graphics);
        }
    }
}
