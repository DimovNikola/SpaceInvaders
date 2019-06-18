using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class GameMap : Form
    {
        Form1 form = new Form1();

        bool goLeft = false;
        bool goRight = false;
        int speed = 1;
        int score = 0;
        bool isPressed;
        int totalEnemies = 14;
        int playerSpeed = 6;
        AccountDoc accDoc;
        Account account;
        private String FileName;

        public GameMap(Account selectedAcc, AccountDoc accDoc)
        {
            newDoc();
            this.accDoc = accDoc;
            account = selectedAcc;
            //this.accDoc.accounts.Remove(account);
            InitializeComponent();
        }

        public void newDoc()
        {
            accDoc = new AccountDoc();
            FileName = "Untitled";
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
                //MessageBox.Show("You Saved Earth!");  fix this later pls!
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

        public void saveFile()
        {
            if (FileName == "Untitled")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Accounts doc file (*.acc)|*.acc";
                saveFileDialog.Title = "Save accounts doc";
                saveFileDialog.FileName = FileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, accDoc);
                }
            }
        }

        private void gameOver()
        {
            timer1.Stop();
            accDoc.getAccount(account).score = score;           
            saveFile();
            label2.Visible = true;
            
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
