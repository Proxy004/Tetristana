using System;
using System.Collections.Generic;
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
                if(i == 1) { renderCount -= 2; }
                renderCount++;
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 + renderCount * TetrisConfig.BlockSize - TetrisConfig.BlockSize;
                controls.Add(Shape[i]);
            }
        }
    }
}
