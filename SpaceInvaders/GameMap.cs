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
        int speed = 5;
        int score = 0;
        bool isPressed;
        int totalEnemies = 8;
        int playerSpeed = 6;
        public GameMap()
        {
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
        }
    }
}
