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
        public bool gameRunning = false;
        public Form1()
        {
            InitializeComponent();
            TetrisConfig.InitializeGame(this);

            //init Tick methods
            TetrisConfig.tmr_move_blocks.Tick += Tmr_move_blocks_Tick;

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
            gameRunning = true;
            TetrisConfig.tmr_move_blocks.Start();
            RenderRandomTetromino();
        }

        private void RenderRandomTetromino()
        {
            //string randomTetromino = ((Tetrominos)Tetromino.random.Next(Enum.GetNames(typeof(Tetrominos)).Length)).ToString();
            //object tetromino = Activator.CreateInstance(Type.GetType(randomTetromino));
            //Tetromino.activeTetromino = (Tetromino)tetromino;

            int randomTetrominoNumber = Tetromino.random.Next(0, Enum.GetNames(typeof(Tetrominos)).Length);

            switch (Math.Round(Convert.ToDouble(randomTetrominoNumber), 0))
            {
                case 0:
                    I i = new I();
                    i.renderShape(this);
                    Tetromino.activeTetromino = i;
                    break;
                case 1:
                    J j = new J();
                    j.renderShape(this);
                    Tetromino.activeTetromino = j;
                    break;
                case 2:
                    L l = new L();
                    l.renderShape(this);
                    Tetromino.activeTetromino = l;
                    break;
                case 3:
                    O o = new O();
                    o.renderShape(this);
                    Tetromino.activeTetromino = o;
                    break;
                case 4:
                    S s = new S();
                    s.renderShape(this);
                    Tetromino.activeTetromino = s;
                    break;
                case 5:
                    T t = new T();
                    t.renderShape(this);
                    Tetromino.activeTetromino = t;
                    break;
                case 6:
                    Z z = new Z();
                    z.renderShape(this);
                    Tetromino.activeTetromino = z;
                    break;
                default:
                    break;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //controls
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (gameRunning) Tetromino.activeTetromino.moveTetromino(this, MovingDirections.Left);
                    break;
                case Keys.Right:
                    if (gameRunning) Tetromino.activeTetromino.moveTetromino(this, MovingDirections.Right);
                    break;
                case Keys.Down:
                    if (gameRunning) Tetromino.activeTetromino.moveTetromino(this, MovingDirections.Down);
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
