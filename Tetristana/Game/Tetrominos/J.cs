﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetristana.Config;

namespace Tetristana.Game.Tetrominos
{
    public class J : Tetromino
    {
        public J() : base(Config.Tetrominos.J)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.J];
        }

        public override void RenderShape(Control.ControlCollection controls)
        {
            for (int i = 0; i < Shape.Length; i++)
            {
                Shape[i] = new Block(BackgroundColor);
                Shape[i].Top = i * TetrisConfig.BlockSize;
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2;
                if (i == 3)
                {
                    Shape[i].Top = TetrisConfig.BlockSize * (i - 1);
                    Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 - TetrisConfig.BlockSize;
                }
                controls.Add(Shape[i]);
            }
        }
    }
}