using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetristana.Config;

namespace Tetristana.Game
{
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

        public virtual void renderShape(Form form) { }

        public void moveTetromino(Form form, MovingDirections movingDirection)
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
                    bool allowMovement = true;
                    foreach (Block block in Shape)
                    {
                        if (block.Right >= TetrisConfig.getFieldWidth()) allowMovement = false;
                    }
                    if (!allowMovement) return;
                    else
                    {
                        foreach (Block block in Shape)
                        {
                            block.moveBlock(movingDirection);
                        }
                    }
                    break;
                case MovingDirections.Down:
                    foreach (Block block in Shape)
                    {
                        if (block.Top + TetrisConfig.BlockSize < TetrisConfig.getFieldHeight())
                        {
                            block.Top += TetrisConfig.BlockSize;
                        }
                        else return;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
