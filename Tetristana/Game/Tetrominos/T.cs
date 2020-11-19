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
    public class T : Tetromino
    {
        public T() : base(Config.Tetrominos.T)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.T];
        }

        public override void RenderShape(Control.ControlCollection controls)
        {
            int renderCount = 0;
            for (int i = 0; i < Shape.Length; i++)
            {
                Shape[i] = new Block(BackgroundColor);
                Shape[i].Top = 0;
                if (i >= 1)
                {
                    Shape[i].Top = TetrisConfig.BlockSize;
                }
                if (i == 1) { renderCount -= 2; }
                renderCount++;
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 + renderCount * TetrisConfig.BlockSize - TetrisConfig.BlockSize;
                controls.Add(Shape[i]);
            }
        }

        public override void RotateTetromino(Control.ControlCollection controls, RotationState currentRotationState)
        {
            Point oldLocation = new Point(Shape[0].Left, Shape[0].Top);
            if (currentRotationState == RotationState.Default)
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    if (i == 0)
                    {
                        Shape[i].Left = oldLocation.X + TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y + TetrisConfig.BlockSize;
                    }
                    else
                    {
                        Shape[i].Left = oldLocation.X;
                        Shape[i].Top = oldLocation.Y + (i - 1) * TetrisConfig.BlockSize;
                    }
                }
                this.RotationState = RotationState.Right;
            }
            else if (currentRotationState == RotationState.Right)
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    if (i == 0)
                    {
                        Shape[i].Left = oldLocation.X - TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y + TetrisConfig.BlockSize;
                    }
                    else
                    {
                        Shape[i].Left = oldLocation.X + (i - 3) * TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y;
                    }
                }
                this.RotationState = RotationState.Down;
            }
            else if (currentRotationState == RotationState.Down)
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    if (i == 0)
                    {
                        Shape[i].Left = oldLocation.X - TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y - TetrisConfig.BlockSize;
                    }
                    else
                    {
                        Shape[i].Left = oldLocation.X;
                        Shape[i].Top = oldLocation.Y + (i - 3) * TetrisConfig.BlockSize;
                    }
                }
                this.RotationState = RotationState.Left;
            }
            else
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    if (i == 0)
                    {
                        Shape[i].Left = oldLocation.X + TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y - TetrisConfig.BlockSize;
                    }
                    else
                    {
                        Shape[i].Left = oldLocation.X + (i - 1) * TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y;
                    }
                }
                this.RotationState = RotationState.Default;
            }
        }
    }
}
