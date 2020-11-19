using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetristana.Game;
using System.Media;
using System.IO;

namespace Tetristana.Config
{
    public enum Tetrominos
    {
        I, J, L, O, S, T, Z
    }

    public enum MovingDirections
    {
        Left, Right, Down
    }

    public enum RotationState
    {
        Default, Left, Right, Down
    }

    public static class TetrisConfig
    {
        public static int BlockSize { get; set; } = 35;
        public static int BlockCountWidth { get; set; } = 10;
        public static int BlockCountHeight { get; set; } = 24;
        public static int StatsBoxWidth { get; set; } = 200;
        public static Label ScoreLabel { get; set; }
        public static SoundPlayer MusicPlayer { get; set; } = new SoundPlayer();

        private static int _tmr_move_blocks_interval = 1000;

        public static Timer tmr_move_blocks = new Timer()
        {
            Interval = _tmr_move_blocks_interval,
            Enabled = false
        };

        public static Dictionary<Keys, string> ControlsInstructions = new Dictionary<Keys, string>
        {
            {Keys.Left, "Move tetromino to the left" },
            {Keys.Right, "Move tetromino to the right" },
            {Keys.Up, "Rotate tetromino clockwise" },
            {Keys.Down, "Drop tetromino softly" },
        };

        public static Dictionary<Tetrominos, System.Drawing.Color> TetrominoColors = new Dictionary<Tetrominos, Color>
        {
            {Tetrominos.I, Color.FromArgb(0, 240, 240) },
            {Tetrominos.J, Color.FromArgb(0, 0, 240) },
            {Tetrominos.L, Color.FromArgb(240, 160, 0) },
            {Tetrominos.O, Color.FromArgb(240, 240, 0) },
            {Tetrominos.S, Color.FromArgb(240, 0, 0) },
            {Tetrominos.T, Color.FromArgb(160, 0, 240) },
            {Tetrominos.Z, Color.FromArgb(0, 216, 0) },
        };

        public static void InitializeGame(Form form)
        {
            //init gui
            form.ClientSize = new System.Drawing.Size(BlockSize * BlockCountWidth + StatsBoxWidth, BlockSize * BlockCountHeight);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;

            //add background audio
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            MusicPlayer.SoundLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./../../assets/sound/tetris_audio.wav");



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
                AutoSize = true,
                Text = GetControlsInstructions(ControlsInstructions),
                Left = getFieldWidth() + BlockSize,
                Top = getStatsBoxHeight() / 3 * 2,
            };
            form.Controls.Add(controlsInstructions);

            //add score
            ScoreLabel = new Label()
            {
                AutoSize = true,
                Text = $"Score: {Tetromino.Score}",
                Top = getStatsBoxHeight() / 3,
                Left = getFieldWidth() + BlockSize
            };
            form.Controls.Add(ScoreLabel);
        } 

        public static Func<int> getFieldWidth = () => BlockCountWidth * BlockSize;
        public static Func<int> getFieldHeight = () => BlockCountHeight * BlockSize;

        public static Func<int> getStatsBoxWidth = () => StatsBoxWidth;
        public static Func<int> getStatsBoxHeight = () => BlockCountHeight * BlockSize;

        private static string GetControlsInstructions(Dictionary<Keys, string> instructions)
        {
            string result = "";
            foreach (KeyValuePair<Keys, string> ins in instructions)
            {
                result += $"{ins.Key}:  {ins.Value}\n";
            }
            return result;
        }
    }
}
