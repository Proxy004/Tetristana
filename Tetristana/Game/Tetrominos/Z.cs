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
    public class Z : Tetromino
    {
        public Z() : base(Config.Tetrominos.Z)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.Z];
        }


        public override void RenderShape(Control.ControlCollection controls)
        {
            int renderCount = 0;
            for (int i = 0; i < Shape.Length; i++)
            {
                Shape[i] = new Block(BackgroundColor);
                Shape[i].Top = -2 * TetrisConfig.BlockSize;
                if (i >= 2)
                {
                    Shape[i].Top = -TetrisConfig.BlockSize;
                }
                renderCount++;
                if (i == 2) { renderCount--; }
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 + renderCount * TetrisConfig.BlockSize - TetrisConfig.BlockSize * 2;
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
                    for (int i = 1; i < Shape.Length; i++)
                    {
                        Shape[i].Top = oldLocation.Y + i * TetrisConfig.BlockSize;
                        if (i >= 2) Shape[i].Top = oldLocation.Y + (i - 1) * TetrisConfig.BlockSize;
                        Shape[i].Left = oldLocation.X;
                        if (i >= 2) Shape[i].Left = oldLocation.X - TetrisConfig.BlockSize;
                    }
                    this.RotationState = RotationState.Left;
                }
            }
            else
            {
                if (Shape[0].Left + TetrisConfig.BlockSize * 3 <= TetrisConfig.getFieldWidth())
                {
                    for (int i = 1; i < Shape.Length; i++)
                    {
                        Shape[i].Left = oldLocation.X + i * TetrisConfig.BlockSize;
                        if (i >= 2) Shape[i].Left = oldLocation.X + (i - 1) * TetrisConfig.BlockSize;
                        Shape[i].Top = oldLocation.Y;
                        if (i >= 2) Shape[i].Top = oldLocation.Y + TetrisConfig.BlockSize;
                    }
                    this.RotationState = RotationState.Default;
                }
            }
        }
    }
}

