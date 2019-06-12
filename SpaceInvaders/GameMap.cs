using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class GameMap : Form
    {
        bool goLeft = false;
        bool goRight = false;
        int speed = 1;
        int score = 0;
        bool isPressed;
        int totalEnemies = 10;
        int playerSpeed = 6;
        public GameMap(int score)
        {
            this.score = score;
            InitializeComponent();
        }

        private void GameMap_Load(object sender, EventArgs e)
        {
            
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                shootBullet();
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goRight)
            {
                player.Left += playerSpeed;
            }

            if (goLeft)
            {
                player.Left -= playerSpeed;
            }

            foreach(Control y in this.Controls)
            {
                if(y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 20; // bullet should move now
                    if(((PictureBox) y).Top < this.Height - 490)
                    {
                        this.Controls.Remove(y); // bullet is no longer on the map so.. delete it!
                    }
                }
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "invader")
                {
                    if(((PictureBox)x).Bottom > this.Height - 90)
                    {
                        gameOver();
                        break;
                    }
                    x.Top += speed;
                 
                }
            }

            foreach(Control i in this.Controls)
            {
                foreach(Control j in this.Controls)
                {
                    if(i is PictureBox && i.Tag == "invader")
                    {
                        if(j is PictureBox && j.Tag == "bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }

            scoreLabel.Text = "Score: " + score;
            if(score > totalEnemies - 1)
            {
                gameOver();
                MessageBox.Show("You Saved Earth!"); // fix this later pls!
            }
        }

        private void shootBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "bullet";
            bullet.Left = player.Left + player.Width / 2; // we want this in the middle
            bullet.Top = player.Top - 20; // we want the bullet over the player model (20 pixels above)
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text += " Game Over";
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
