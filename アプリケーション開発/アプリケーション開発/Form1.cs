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

            this.ClientSize = new Size(800, 600);
            this.DoubleBuffered = true;

            // パネル作成
            GamePanel = new DoubleBufferedPanel();
            GamePanel.Location = new Point(10, 10);
            GamePanel.Size = new Size(700, 500);
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

        private void ClampGamePanel() 
        {
        int maxX=this.ClientSize.Width-GamePanel.Width;
        int maxY=this.ClientSize.Height-GamePanel.Height;

            int x = GamePanel.Left;
            int y = GamePanel.Top;

            if (x > 0) x = 0;
            if(y> 0) y = 0;
            if(x < maxX) x = maxX;
            if(y < maxY) y = maxY;

            GamePanel.Location= new Point(x, y);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
        ClampGamePanel();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
            GamePanel.Invalidate();

            if (game.state == GamePlayState.Message) 
            {
            GameTimer.Stop();
                var yesno = MessageBox.Show("続けますか?",game.MessageText,  MessageBoxButtons.YesNo);
                    if(yesno== DialogResult.Yes)
                {
                    game.ResetStege();
                    GameTimer.Start();
                }
                else 
                {
                 Application.Exit();
                }

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
