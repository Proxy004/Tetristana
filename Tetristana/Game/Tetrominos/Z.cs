using System;
using System.Collections.Generic;
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

        public override void RenderShape(Form form)
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
                if (i == 2) { renderCount--; }
                Shape[i].Left = TetrisConfig.BlockSize * TetrisConfig.BlockCountWidth / 2 + renderCount * TetrisConfig.BlockSize - TetrisConfig.BlockSize * 2;
                form.Controls.Add(Shape[i]);
            }
        }
    }
}
