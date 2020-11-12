using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetristana.Config;

namespace Tetristana.Game
{
    public class Tetromino
    {
        public Tetristana.Config.Tetrominos TetrominoType { get; set; }
        public Color BackgroundColor { get; set; }
        public Block[] Shape = new Block[4];

        public Tetromino(Tetristana.Config.Tetrominos tetrominoType)
        {
            this.TetrominoType = tetrominoType;
        }

        public virtual void renderShape(Form form) { }
    }
}
