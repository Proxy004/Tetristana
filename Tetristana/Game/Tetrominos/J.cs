using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetristana.Config;

namespace Tetristana.Game.Tetrominos
{
    public class J : Tetromino
    {
        public J() : base(Config.Tetrominos.J)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.J];
        }
    }
}