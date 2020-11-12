using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetristana.Config;

namespace Tetristana.Game
{
    public class Tetromino
    {
        public Tetristana.Config.Tetrominos TetrominoType { get; set; }

        public Tetromino(Tetristana.Config.Tetrominos tetromino)
        {
            this.TetrominoType = tetromino;
        }
    }
}
