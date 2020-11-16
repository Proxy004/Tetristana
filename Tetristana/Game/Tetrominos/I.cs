﻿using System;
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

        public override void RotateShape(Control.ControlCollection controls, RotationState currentRotationState)
        {
            Point oldLocation = new Point(Shape[0].Left, Shape[0].Top);
            if (currentRotationState == RotationState.Default || currentRotationState == RotationState.Down)
            {
                for (int i = 0; i < Shape.Length; i++)
                {
                    Shape[i].Top = oldLocation.X;
                    Shape[i].Left = oldLocation.Y * i;
                }
                this.RotationState = RotationState.Left;
            }
            else
            {
            }
        }
    }
}
