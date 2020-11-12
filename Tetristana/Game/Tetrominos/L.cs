using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetristana.Config;

namespace Tetristana.Game.Tetrominos
{
    public class L : Tetromino
    {
        public L() : base(Config.Tetrominos.L)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.L];
        }
    }
}