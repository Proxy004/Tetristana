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
        public static List<Tetromino> Tetrominos = new List<Tetromino>();
        public static Tetromino activeTetromino;
        public Tetristana.Config.Tetrominos TetrominoType { get; set; }
        public Color BackgroundColor { get; set; }
        public Block[] Shape = new Block[4];
        public static Random random = new Random();

        public Tetromino(Tetristana.Config.Tetrominos tetrominoType)
        {
            this.TetrominoType = tetrominoType;
        }

        public virtual void RenderShape(Form form) { }

        public void MoveTetromino(Form form, MovingDirections movingDirection)
        {
            switch (movingDirection)
            {
                case MovingDirections.Left:
                    foreach (Block block in Shape)
                    {
                        if (block.Left > 0)
                        {
                            block.moveBlock(movingDirection);
                        }
                        else return;
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

        public void CheckCollisions()
        {
            foreach (Block block in activeTetromino.Shape)
            {
                foreach (Tetromino tetromino in Tetromino.Tetrominos)
                {
                    foreach (Block tetrominoBlock in tetromino.Shape)
                    {
                        if (block.Bounds.IntersectsWith(tetrominoBlock.Bounds))
                        {
                            TetrominoDocked?.Invoke(this);
                        }
                    }
                }
            }
        }

        public event EventTypeTetrominoDocked TetrominoDocked;
    }
}
