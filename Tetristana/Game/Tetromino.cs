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

        public Tetromino(Tetristana.Config.Tetrominos tetrominoType)
        {
            this.TetrominoType = tetrominoType;
        }

        public virtual void renderShape(Form form) { }

        public virtual void moveTetromino(Form form, MovingDirections movingDirection)
        {
            foreach (Block block in Shape)
            {
                switch (movingDirection)
                {
                    case MovingDirections.Left:
                        if (block.Left > 0)
                        {
                            block.moveBlock(movingDirection);
                        }
                        break;
                    case MovingDirections.Right:
                        if (block.Right < TetrisConfig.getFieldWidth())
                        {
                            block.moveBlock(movingDirection);
                        }
                        break;
                    case MovingDirections.Down:
                        if (block.Top + TetrisConfig.BlockSize < TetrisConfig.getFieldHeight())
                        {
                            block.Top += TetrisConfig.BlockSize;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
