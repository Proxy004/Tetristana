using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetristana.Game
{
    public class Block : Panel
    {
        public Block(Color backgroundColor, int size)
        {
            this.BackColor = backgroundColor;
            this.Height = this.Width = size;
        }

        public void moveBlock()
        {
            //move block
        }
    }
}
