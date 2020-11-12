using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetristana.Config;

namespace Tetristana.Game.Tetrominos
{
    public class O : Tetromino
    {
        public O() : base(Config.Tetrominos.O)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.O];
        }

        public override void renderShape(System.Windows.Forms.Form form)
        {
            int renderCount = 0;
            for (int i = 0; i < Shape.Length; i++)
            {
                Shape[i] = new Block(BackgroundColor);
                Shape[i].Top = 0;
                if (i >= 2)
                {
                    Shape[i].Top = TetrisConfig.BlockSize;
                }
                renderCount++;
                if (i == 2) { renderCount -= 2; }
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 + renderCount * TetrisConfig.BlockSize - TetrisConfig.BlockSize;
                form.Controls.Add(Shape[i]);
            }
        }
    }
}