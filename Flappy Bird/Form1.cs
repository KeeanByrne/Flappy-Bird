using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 5;
        int score = 0;
        bool gameStarted = false;
        bool hasPassedPipes = false; // Flag to track if the user has passed the pipes
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (!gameStarted) // Check if the game has started
                return;

            flappyBird.Top += gravity;

            // Moves pipes across the screen
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            txtScore.Text = "Score: " + score.ToString();

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 420;
                pipeBottom.Top = ground.Top - pipeBottom.Height; // PipeBottom touches the ground
                hasPassedPipes = false; // Reset the flag when a new set of pipes appears
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 450;
                pipeTop.Top = 0; // PipeTop touches the top of the window
                hasPassedPipes = false; // Reset the flag when a new set of pipes appears
            }

            // Check if the user has passed the pipes
            if (!hasPassedPipes && flappyBird.Left > pipeBottom.Right)
            {
                score++;
                hasPassedPipes = true;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!gameStarted) // Check if the game has not started
                {
                    gameStarted = true; // Start the game
                    gameTimer.Start(); // Start the game timer
                }
                gravity = -10;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gravity = -15;
            gameTimer.Stop();
            txtScore.Text = "Game Over";
        }
    }
}