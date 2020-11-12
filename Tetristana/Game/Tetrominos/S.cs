using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetristana.Config;

namespace Tetristana.Game.Tetrominos
{
    public class S : Tetromino
    {
        public S() : base(Config.Tetrominos.S)
        {
            BackgroundColor = TetrisConfig.TetrominoColors[Config.Tetrominos.S];
        }
    }
}