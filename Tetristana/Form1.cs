﻿using System;
using System.Windows.Forms;
using Tetristana.Config;
using Tetristana.Game;
using Tetristana.Game.Tetrominos;
using System.Linq;
using System.IO;
using System.Windows;

namespace Tetristana
{
    public partial class Form1 : Form
    {
        public static bool GameStarted { get; set; } = false;
        public static bool GameRunning { get; set; } = false;

        public Form1()
        {
            InitializeComponent();
            TetrisConfig.InitializeGame(this);

            //init Tick methods
            TetrisConfig.tmr_move_blocks.Tick += Tmr_move_blocks_Tick;
        }

        private void Tmr_move_blocks_Tick(object sender, System.EventArgs e)
        {
            Tetromino.ActiveTetromino.MoveTetromino(MovingDirections.Down);
            Tetromino.ActiveTetromino.CheckCollisions(this.Controls);
        }

        private void HandleToggleSpaceKey()
        {
            if (!GameStarted)
            {
                GameStarted = true;
                GameRunning = true;
                TetrisConfig.tmr_move_blocks.Start();
                RenderNewRandomTetromino();
                if (TetrisConfig.MusicPlaying)
                {
                    TetrisConfig.MusicPlayer.PlayLooping();
                }  
            }
            else
            {
                if (GameRunning)
                {
                    PauseGame();
                }
                else
                {
                    ContinueGame();
                }
            }
        }

        public static void PauseGame()
        {
            GameRunning = false;
            TetrisConfig.tmr_move_blocks.Stop();
            TetrisConfig.MusicPlayer.Stop();
        }


        public static void ContinueGame()
        {
            GameRunning = true; 
            
            TetrisConfig.tmr_move_blocks.Start();

            if (TetrisConfig.MusicPlaying == false)
            { }
            else
            {
                TetrisConfig.tmr_move_blocks.Start();
                TetrisConfig.MusicPlayer.PlayLooping();
            }
        }

        private Tetromino GetTetromino(Tetrominos tetrominoType)
        {
            switch (tetrominoType)
            {
                case Tetrominos.I:
                    return new I();
                case Tetrominos.J:
                    return new J();
                case Tetrominos.L:
                    return new L();
                case Tetrominos.O:
                    return new O();
                case Tetrominos.S:
                    return new S();
                case Tetrominos.T:
                    return new T();
                case Tetrominos.Z:
                    return new Z();
                default:
                    return null;
            }
        }

        private void RenderNewRandomTetromino()
        {
            Tetrominos tetrominoType = (Tetrominos)Tetromino.random.Next(0, Enum.GetNames(typeof(Tetrominos)).Length);
            Tetromino t = GetTetromino(tetrominoType);
            RenderNextTetromino(t);

            DeclareNextTetromino();
        }

        private void DeclareNextTetromino()
        {
            Tetromino.NextTetromino = (Tetrominos)Tetromino.random.Next(0, Enum.GetNames(typeof(Tetrominos)).Length);
        }

        private void RenderNextTetromino(Tetromino tetromino)
        {
            tetromino.RenderShape(Controls);
            Tetromino.ActiveTetromino = tetromino;
            tetromino.TetrominoDocked += ActiveTetromino_TetrominoDocked;
            DeclareNextTetromino();
        }

        //tetromino docked
        private void ActiveTetromino_TetrominoDocked(Tetromino tetromino)
        {
            Tetromino.DockedTetrominos.Add(Tetromino.ActiveTetromino);
            Tetromino.Score++;
            tetromino.TetrominoDocked -= ActiveTetromino_TetrominoDocked;
            RenderNextTetromino(GetTetromino(Tetromino.NextTetromino));
        }

        //keyhandling
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //controls
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (GameRunning) Tetromino.ActiveTetromino.MoveTetromino(MovingDirections.Left);
                    break;
                case Keys.Right:
                    if (GameRunning) Tetromino.ActiveTetromino.MoveTetromino(MovingDirections.Right);
                    break;
                case Keys.Down:
                    if (GameRunning) Tetromino.ActiveTetromino.MoveTetromino(MovingDirections.Down);
                    break;
                case Keys.Up:
                    if (GameRunning) Tetromino.ActiveTetromino.RotateTetromino(this.Controls, Tetromino.ActiveTetromino.RotationState);
                    break;
                case Keys.Space:
                    HandleToggleSpaceKey();
                    break;
                default:
                    break;
            }

            if (Tetromino.ActiveTetromino != null) Tetromino.ActiveTetromino.CheckCollisions(this.Controls);
        }

       
    }
}
