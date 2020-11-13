using System.Windows.Forms;
using Tetristana.Config;
using Tetristana.Game;

namespace Tetristana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TetrisConfig.InitializeGame(this);

            //init Tick methods
            TetrisConfig.tmr_move_blocks.Tick += Tmr_move_blocks_Tick;

            //I i = new I();
            //i.renderShape(this);

            //Z z = new Z();
            //z.renderShape(this);

            //O o = new O();
            //o.renderShape(this);

            //T t = new T();
            //t.renderShape(this);

            //S s = new S();
            //s.renderShape(this);

            //L l = new L();
            //l.renderShape(this);

            //J j = new J();
            //j.renderShape(this);
        }

        private void Tmr_move_blocks_Tick(object sender, System.EventArgs e)
        {
            Tetromino.activeTetromino.moveTetromino(this, MovingDirections.Down);
        }

        private void StartGame()
        {
            TetrisConfig.tmr_move_blocks.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //controls
            switch (e.KeyCode)
            {
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Down:
                    break;
                case Keys.Space:
                    StartGame();
                    break;
                default:
                    break;
            }
        }
    }
}
