using System;
using System.Drawing;
using System.Windows.Forms;

namespace アプリケーション開発
{
    public partial class Form1 : Form
    {
        GameManager game;
        DoubleBufferedPanel GamePanel;
        Timer GameTimer;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            // パネル作成
            GamePanel = new DoubleBufferedPanel();
            GamePanel.Location = new Point(10, 10);
            GamePanel.Size = new Size(600, 400);
            GamePanel.BackColor = Color.Black;

            GamePanel.Paint += GamePanel_Paint;
            GamePanel.MouseMove += GamePanel_MouseMove;

            this.Controls.Add(GamePanel);

            // ゲーム管理
            game = new GameManager(GamePanel.Width, GamePanel.Height);

            // タイマー
            GameTimer = new Timer();
            GameTimer.Interval = 16; // 60FPS
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
            GamePanel.Invalidate();

            if (game.state == GamePlayState.Message) 
            {
            GameTimer.Stop();
                MessageBox.Show(game.MessageText);
                game.ResetStege();
                GameTimer.Start();
            }
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            game.MovePaddle(e.X);

            Point p=game.GetPaddleCenter();

            Point scrrenPos = GamePanel.PointToScreen(p);
            Cursor.Position = scrrenPos;
        }
    }
}
