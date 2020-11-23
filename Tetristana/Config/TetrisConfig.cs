using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static PictureBox LogoBox { get; set; }
        public static PictureBox Tristana { get; set; }
        public static Panel MuteMusic { get; set; }
        public static Panel Information { get; set; }
        public static Panel nextTetromino { get; set; }
        public static bool MusicPlaying { get; set; } = true;

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
            MusicPlayer.SoundLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./../../assets/sound/tetris_audio.wav");

            TetrisConfig.nextTetromino = new Panel()
            {
                BackgroundImageLayout = ImageLayout.Center,
                Size = new Size(100, 100),
                Top = getStatsBoxHeight() / 10 * 3,
                Left = getFieldWidth() + getStatsBoxWidth() / 2 - 50,
            };

            form.Controls.Add(nextTetromino);

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

            //add score
            ScoreLabel = new Label()
            {
                AutoSize = true,
                Font = new Font("Open Sans", 20, FontStyle.Bold),
                Text = $"Score: {Tetromino.Score}",
                Top = getStatsBoxHeight() / 10 * 6,
                Left = getFieldWidth() + getStatsBoxWidth() / 2 - 60,
            };
            form.Controls.Add(ScoreLabel);

            //add tetristana logo
            LogoBox = new PictureBox()
            {
                Image = Image.FromFile(@"./../../assets/pictures/tetristana.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(200, 150),
                Top = 20,
                Left = getFieldWidth() + getStatsBoxWidth() / 2 - 100,
            };
            form.Controls.Add(LogoBox);

            //add Tristana
            Tristana = new PictureBox()
            {
                Image = Image.FromFile(@"./../../assets/pictures/tristana.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(220, 200),
                Top = getStatsBoxHeight() - 188,
                Left = getFieldWidth() + getStatsBoxWidth() / 2 - 90,
            };
            form.Controls.Add(Tristana);

            MuteMusic = new Panel()
            {
                BackgroundImage = Image.FromFile(@"./../../assets/pictures/unmute_1.png"),
                Size = new Size(40, 40),
                BackgroundImageLayout = ImageLayout.Stretch,
                Top = getStatsBoxHeight() / 10 * 7,
                Left = getFieldWidth() + getStatsBoxWidth() / 2 + 20,
            };

            MuteMusic.Click += MuteMusic_click;
            MuteMusic.TabStop = false;
            form.Controls.Add(MuteMusic);

            Information = new Panel()
            {
                BackgroundImage = Image.FromFile(@"./../../assets/pictures/information.png"),
                Size = new Size(40, 40),
                BackgroundImageLayout = ImageLayout.Stretch,
                Top = getStatsBoxHeight() / 10 * 7,
                Left = getFieldWidth() + getStatsBoxWidth() / 2 - 60,
            };

            Information.Click += Information_click;
            Information.TabStop = false;
            form.Controls.Add(Information);
        }

        public static void Information_click(object sender, System.EventArgs e)
        {
            Form1.PauseGame();
            MessageBox.Show(GetControlsInstructions(ControlsInstructions), "Controls", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Form1.GameStarted)
            {
                Form1.ContinueGame();
            }
        }


        public static void MuteMusic_click(object sender, System.EventArgs e)
        {
            if (MusicPlaying)
            {
                MusicPlayer.Stop();
                MusicPlaying = false;
                MuteMusic.BackgroundImage = Image.FromFile(@"./../../assets/pictures/mute_1.png");
            }
            else
            {
                MusicPlayer.Play();
                MusicPlaying = true;
                MuteMusic.BackgroundImage = Image.FromFile(@"./../../assets/pictures/unmute_1.png");
            }
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
