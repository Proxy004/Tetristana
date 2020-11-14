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
            Tetromino.activeTetromino.MoveTetromino(this, MovingDirections.Down);
            Tetromino.activeTetromino.CheckCollisions();
        }

        private void StartGame()
        {
            gameRunning = true;
            TetrisConfig.tmr_move_blocks.Start();
            RenderNewRandomTetromino();
        } 

        private void RenderNewRandomTetromino()
        {
            //string randomTetromino = ((Tetrominos)Tetromino.random.Next(Enum.GetNames(typeof(Tetrominos)).Length)).ToString();
            //object tetromino = Activator.CreateInstance(Type.GetType(randomTetromino));
            //Tetromino.activeTetromino = (Tetromino)tetromino;

            int randomTetrominoNumber = Tetromino.random.Next(0, Enum.GetNames(typeof(Tetrominos)).Length);

            switch (Math.Round(Convert.ToDouble(randomTetrominoNumber), 0))
            {
                case 0:
                    I i = new I();
                    i.RenderShape(this);
                    Tetromino.activeTetromino = i;
                    break;
                case 1:
                    J j = new J();
                    j.RenderShape(this);
                    Tetromino.activeTetromino = j;
                    break;
                case 2:
                    L l = new L();
                    l.RenderShape(this);
                    Tetromino.activeTetromino = l;
                    break;
                case 3:
                    O o = new O();
                    o.RenderShape(this);
                    Tetromino.activeTetromino = o;
                    break;
                case 4:
                    S s = new S();
                    s.RenderShape(this);
                    Tetromino.activeTetromino = s;
                    break;
                case 5:
                    T t = new T();
                    t.RenderShape(this);
                    Tetromino.activeTetromino = t;
                    break;
                case 6:
                    Z z = new Z();
                    z.RenderShape(this);
                    Tetromino.activeTetromino = z;
                    break;
                default:
                    break;
            }
            Tetromino.activeTetromino.TetrominoDocked += ActiveTetromino_TetrominoDocked;
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
                    if (gameRunning) Tetromino.activeTetromino.MoveTetromino(this, MovingDirections.Left);
                    break;
                case Keys.Right:
                    if (gameRunning) Tetromino.activeTetromino.MoveTetromino(this, MovingDirections.Right);
                    break;
                case Keys.Down:
                    if (gameRunning) Tetromino.activeTetromino.MoveTetromino(this, MovingDirections.Down);
                    break;
                case Keys.Space:
                    if (!gameRunning) StartGame();
                    break;
                default:
                    break;
            }
        }
    }
}
