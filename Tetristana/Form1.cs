using System;
using System.Windows.Forms;
using Tetristana.Config;
using Tetristana.Game;
using Tetristana.Game.Tetrominos;
using System.Linq;

namespace Tetristana
{
    public partial class Form1 : Form
    {
        private bool gameRunning = false;
        public Form1()
        {
            InitializeComponent();
            TetrisConfig.InitializeGame(this);

            //init Tick methods
            TetrisConfig.tmr_move_blocks.Tick += Tmr_move_blocks_Tick;
        }

        private void Tmr_move_blocks_Tick(object sender, System.EventArgs e)
        {
            Tetromino.activeTetromino.MoveTetromino(MovingDirections.Down);
            Tetromino.activeTetromino.CheckCollisions(this.Controls);
        }

        private void StartGame()
        {
            gameRunning = true;
            TetrisConfig.tmr_move_blocks.Start();
            RenderNewRandomTetromino();
        }

        private Tetromino GetTetromino(Tetrominos tetrominoType)
        {
            switch (tetrominoType)
            {
                case Tetrominos.I:
                    return new I();
                case Tetrominos.J:
                    return new J();
                case Tetrominos.L:
                    return new L();
                case Tetrominos.O:
                    return new O();
                case Tetrominos.S:
                    return new S();
                case Tetrominos.T:
                    return new T();
                case Tetrominos.Z:
                    return new Z();
                default:
                    return null;
            }
        }

        private void RenderNewRandomTetromino()
        {
            Tetrominos tetrominoType = (Tetrominos)Tetromino.random.Next(0, Enum.GetNames(typeof(Tetrominos)).Length);
            //int randomNextTetrominoNumnber = Tetromino.random.Next(0, Enum.GetNames(typeof(Tetrominos)).Length);

            Tetromino t = GetTetromino(tetrominoType);
            t.RenderShape(this.Controls);
            Tetromino.activeTetromino = t;

            Tetromino.activeTetromino.TetrominoDocked += ActiveTetromino_TetrominoDocked;
        }

        private void RenderNextTetromino(Tetromino tetromino)
        {
            tetromino.RenderShape(Controls);
        }

        //tetromino docked
        private void ActiveTetromino_TetrominoDocked(Tetromino tetromino)
        {
            Tetromino.Tetrominos.Add(Tetromino.activeTetromino);
            tetromino.TetrominoDocked -= ActiveTetromino_TetrominoDocked;
            RenderNewRandomTetromino();
        }

        //keyhandling
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //controls
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (gameRunning) Tetromino.activeTetromino.MoveTetromino(MovingDirections.Left);
                    Tetromino.activeTetromino.CheckCollisions(this.Controls);
                    break;
                case Keys.Right:
                    if (gameRunning) Tetromino.activeTetromino.MoveTetromino(MovingDirections.Right);
                    Tetromino.activeTetromino.CheckCollisions(this.Controls);
                    break;
                case Keys.Down:
                    if (gameRunning) Tetromino.activeTetromino.MoveTetromino(MovingDirections.Down);
                    Tetromino.activeTetromino.CheckCollisions(this.Controls);
                    break;
                case Keys.Up:
                    if (gameRunning) Tetromino.activeTetromino.RotateTetromino(this.Controls, Tetromino.activeTetromino.RotationState);
                    Tetromino.activeTetromino.CheckCollisions(this.Controls);
                    break;
                case Keys.Space:
                    if (!gameRunning) StartGame(); else TetrisConfig.tmr_move_blocks.Stop();
                    break;
                default:
                    break;
            }
        }
    }
}
