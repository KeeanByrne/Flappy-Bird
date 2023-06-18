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

        int pipeSpeed = 10;
        int gravity = 10;
        int score = 0;







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

            flappyBird.Top += gravity;

            //Moves pipes across the screen
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            txtScore.Text = score.ToString();


            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 600;
                score++;
            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 650;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {

            }

        }

        private void keyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            {
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

        }
    }
}
