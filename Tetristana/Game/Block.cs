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
    public class Block : Panel
    {
        public Block(Color backgroundColor)
        {
            this.BackColor = backgroundColor;
            this.Height = this.Width = TetrisConfig.BlockSize;
        }

        public Block(Color backgroundColor, int left, int top) : this(backgroundColor)
        {
            this.Left = left;
            this.Top = top;
        }

        public void MoveBlock(MovingDirections moveDirection)
        {
            if (moveDirection == MovingDirections.Left) this.Left -= TetrisConfig.BlockSize;
            if (moveDirection == MovingDirections.Right) this.Left += TetrisConfig.BlockSize;
            if (moveDirection == MovingDirections.Down) this.Top += TetrisConfig.BlockSize;
        }
    }
}
