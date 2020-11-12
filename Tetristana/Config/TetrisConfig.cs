using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetristana
{
    public static class TetrisConfig
    {
        public static int BlockSize { get; set; } = 35;
        public static int BlockCountWidth { get; set; } = 10;
        public static int BlockCountHeight { get; set; } = 24;
        public static int StatsBoxWidth { get; set; } = 200;

        private static int _tmr_move_blocks_interval = 500;

        public static Timer tmr_move_blocks = new Timer() { 
            Interval = _tmr_move_blocks_interval,
        };

        public static object config = new { 
            Test = "test"
        };

        public static void InitializeGame(Form form)
        {
            //init gui
            form.ClientSize = new System.Drawing.Size(BlockSize * BlockCountWidth + StatsBoxWidth, BlockSize * BlockCountHeight);

            //add seperator 
            Panel seperator = new Panel()
            {
                Width = 1,
                Height = getFieldHeight(),
                BackColor = Color.Gray,
                Left = getFieldWidth()
            };
            form.Controls.Add(seperator);

            //set initial title
            form.Text = "Tetristana";

            //add controls instructions
            Label controlsInstructions = new Label()
            {
                Text = getControlsInstructions()
            };
        }

        static Func<int> getFieldWidth = () => BlockCountWidth * BlockSize;
        static Func<int> getFieldHeight = () => BlockCountHeight * BlockSize;


        static Func<string> getControlsInstructions = () => $"";
            

    }
}
