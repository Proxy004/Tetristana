using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetristana.Game;
using Tetristana.Config;
using Tetristana.Game.Tetrominos;

namespace Tetristana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TetrisConfig.InitializeGame(this);

            //I i = new I();
            //i.renderShape(this);

            //Z z = new Z();
            //z.renderShape(this);

            //O o = new O();
            //o.renderShape(this);

            T t = new T();
            t.renderShape(this);
        }
    }
}
