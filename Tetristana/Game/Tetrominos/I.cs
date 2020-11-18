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
    public class I : Tetromino
    {
        public I() : base(Config.Tetrominos.I)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.I];
        }

        public override void RenderShape(Control.ControlCollection controls)
        {
            for (int i = 0; i < Shape.Length; i++)
            {
                Shape[i] = new Block(BackgroundColor);
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2;
                Shape[i].Top = i * TetrisConfig.BlockSize;
                controls.Add(Shape[i]);
            }
        }

        public override void RotateTetromino(Control.ControlCollection controls, RotationState currentRotationState)
        {
            Point oldLocation = new Point(Shape[0].Left, Shape[0].Top);
 
            if (currentRotationState == RotationState.Default)
            {
                if (Shape[0].Left + TetrisConfig.BlockSize * 3 < TetrisConfig.getFieldWidth())
                {
                    for (int i = 1; i < Shape.Length; i++)
                    {
                        Shape[i].Top = oldLocation.Y;
                        Shape[i].Left = oldLocation.X + i * TetrisConfig.BlockSize;
                    }
                    this.RotationState = RotationState.Left;
                }
            }
            else
            {
                for (int i = 1; i < Shape.Length; i++)
                {
                    Shape[i].Left = oldLocation.X;
                    Shape[i].Top = oldLocation.Y + i * TetrisConfig.BlockSize;
                }
                this.RotationState = RotationState.Default;
            }
        }
    }
}
