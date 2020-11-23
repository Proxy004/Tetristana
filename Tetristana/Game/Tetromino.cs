using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetristana.Config;

namespace Tetristana.Game
{
    public delegate void EventTypeTetrominoDocked(Tetromino tetromino);
    public class Tetromino
    {
        private static int _score = 0;
        public static int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                TetrisConfig.ScoreLabel.Text = $"Score: {_score}";
            }
        }

        public static List<Tetromino> DockedTetrominos { get; set; } = new List<Tetromino>();
        public static Tetromino ActiveTetromino { get; set; }
        public Tetristana.Config.Tetrominos TetrominoType { get; set; }
        public Color BackgroundColor { get; set; }
        public Block[] Shape { get; set; } = new Block[4];
        public static Random random { get; set; } = new Random();
        public RotationState RotationState { get; set; } = RotationState.Default;
        public static Config.Tetrominos NextTetromino { get; set; }

        public Tetromino(Config.Tetrominos tetrominoType)
        {
            this.TetrominoType = tetrominoType;
        }

        public virtual void RenderShape(Control.ControlCollection controls) { }

        public void MoveTetromino(MovingDirections movingDirection)
        {
            switch (movingDirection)
            {
                case MovingDirections.Left:
                    bool allowMovementLeft = true;
                    foreach (Block block in Shape)
                    {
                        if (block.Left <= 0) allowMovementLeft = false;
                    }

                    if (!allowMovementLeft) return;
                    else
                    {
                        foreach (Block block in Shape)
                        {
                            block.moveBlock(movingDirection);
                        }
                    }

                    break;
                case MovingDirections.Right:
                    bool allowMovementRight = true;
                    foreach (Block block in Shape)
                    {
                        if (block.Right >= TetrisConfig.getFieldWidth()) allowMovementRight = false;
                    }

                    if (!allowMovementRight) return;
                    else
                    {
                        foreach (Block block in Shape)
                        {
                            block.moveBlock(movingDirection);
                        }
                    }
                    break;
                case MovingDirections.Down:
                    bool allowMovementDown = true;
                    foreach (Block block in Shape)
                    {
                        if (block.Bottom >= TetrisConfig.getFieldHeight()) allowMovementDown = false;
                    }

                    if (!allowMovementDown)
                    {
                        TetrominoDocked?.Invoke(this);
                        return;
                    }
                    else
                    {
                        foreach (Block block in Shape)
                        {
                            block.moveBlock(movingDirection);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void CheckCollisions(Control.ControlCollection controls)
        {
            List<Tetromino> copyOfTetrominos = new List<Tetromino>(Tetromino.DockedTetrominos);

            foreach (Block block in ActiveTetromino.Shape)
            {
                foreach (Tetromino tetromino in copyOfTetrominos)
                {
                    foreach (Block tetrominoBlock in tetromino.Shape)
                    {
                        block.SetBounds(block.Left, block.Top, block.Width, block.Height + 1);

                        if (block.Bounds.IntersectsWith(tetrominoBlock.Bounds))
                        {
                            TetrominoDocked?.Invoke(this);
                        }

                        block.SetBounds(block.Left, block.Top, block.Width, block.Height - 1);
                    }
                }
            }
        }

        public virtual void RotateTetromino(Control.ControlCollection controls, RotationState currentRotationState) { }

        public event EventTypeTetrominoDocked TetrominoDocked;
    }
}
