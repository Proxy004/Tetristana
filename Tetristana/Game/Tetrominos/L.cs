using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetristana.Config;

namespace Tetristana.Game.Tetrominos
{
    public class L : Tetromino
    {
        public L() : base(Config.Tetrominos.L)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.L];
        }

        public override void RenderShape(Control.ControlCollection controls)
        {
            for (int i = 0; i < Shape.Length; i++)
            {
                Shape[i] = new Block(BackgroundColor);
                Shape[i].Top = (i - 2) * TetrisConfig.BlockSize - TetrisConfig.BlockSize;
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2;
                if (i == 3)
                {
                    Shape[i].Top = TetrisConfig.BlockSize * (i - 4);
                    Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 + TetrisConfig.BlockSize;
                }
                controls.Add(Shape[i]);
            }
        }

        public override void RotateTetromino(Control.ControlCollection controls, RotationState currentRotationState)
        {
            Point oldLocation = new Point(Shape[0].Left, Shape[0].Top);
            if (currentRotationState == RotationState.Default)
            {
                if (Shape[0].Left >= TetrisConfig.BlockSize)
                {
                    for (int i = 0; i < Shape.Length; i++)
                    {
                        Shape[i].Left = oldLocation.X + (i - 1) * TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y + TetrisConfig.BlockSize;
                        if (i == 3)
                        {
                            Shape[i].Left = oldLocation.X - TetrisConfig.BlockSize;
                            Shape[i].Top = oldLocation.Y + 2 * TetrisConfig.BlockSize;
                        }
                    }
                    this.RotationState = RotationState.Right;
                }
            }
            else if (currentRotationState == RotationState.Right)
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    Shape[i].Left = oldLocation.X + TetrisConfig.BlockSize;
                    Shape[i].Top = oldLocation.Y + (i - 1) * TetrisConfig.BlockSize;
                    if (i == 3)
                    {
                        Shape[i].Left = oldLocation.X;
                        Shape[i].Top = oldLocation.Y - TetrisConfig.BlockSize;
                    }
                }
                this.RotationState = RotationState.Down;
            }
            else if (currentRotationState == RotationState.Down)
            {
                if (Shape[0].Left + TetrisConfig.BlockSize < TetrisConfig.getFieldWidth())
                {
                    for (int i = 0; i < Shape.Length; i++)
                    {
                        Shape[i].Left = oldLocation.X + (i - 1) * TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y + TetrisConfig.BlockSize;
                        if (i == 3)
                        {
                            Shape[i].Left = oldLocation.X + TetrisConfig.BlockSize;
                            Shape[i].Top = oldLocation.Y;
                        }
                    }
                    this.RotationState = RotationState.Left;
                }
            }
            else
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    Shape[i].Top = oldLocation.Y + (i - 1) * TetrisConfig.BlockSize;
                    Shape[i].Left = oldLocation.X + TetrisConfig.BlockSize;
                    if (i == 3)
                    {
                        Shape[i].Left = oldLocation.X + 2 * TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y + TetrisConfig.BlockSize;
                    }
                }
                this.RotationState = RotationState.Default;
            }
        }
    }
}