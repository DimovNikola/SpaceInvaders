using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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
        int totalEnemies = 0;
        int playerSpeed = 6;
        AccountDoc accDoc;
        Account account;
        private String FileName;
        private SoundPlayer soundPlayer;
        private SoundPlayer soundPlayer1;
        
        

        public GameMap(Account selectedAcc, AccountDoc accDoc)
        {
          
            newDoc();
            
            soundPlayer = new SoundPlayer("audio.wav");
            soundPlayer1 = new SoundPlayer("gameOverAudio.wav");
            soundPlayer.Play();
            this.accDoc = accDoc;
            account = selectedAcc;
           
            
            InitializeComponent();
        }

        public void newDoc()
        {
            accDoc = new AccountDoc();
            FileName = "Untitled";
        }

        private void GameMap_Load(object sender, EventArgs e)
        {
            generateNewWave();
            this.timer1.Start();
        }

        List<Control> enemies = new List<Control>();

        private void fillList()
        {
            if (enemies.Count > 0) enemies.Clear();

            for (int x = 1; x <= 4; x++)
            {
                int xPos = (x-1) * 150 +50;
                int yPos = 0;

                if (x % 2 == 0)
                {
                    for (int y = 1; y <= 4; y++)
                    {
                        yPos = (y-1) * 60 ;
                        generateEnemy(xPos, yPos);
                    }
                } else
                {
                    for (int y = 1; y <= 5; y++)
                    {
                        yPos = (y - 1) * 60 + 10;
                        generateEnemy(xPos, yPos);
                    }
                }
            }
        }

        private void generateEnemy(int x, int y)
        {
            PictureBox pb = new PictureBox();

            pb.Location = new Point(x, y);
            pb.Tag = "invader";
            pb.Name = "pb" + enemies.Count;
            pb.Image = global::SpaceInvaders.Properties.Resources.alien;

            pb.Anchor = System.Windows.Forms.AnchorStyles.None;
            pb.Size = new System.Drawing.Size(50, 50);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.TabIndex = 5;
            pb.TabStop = false;

            enemies.Add(pb);
        }

        private void generateNewWave()
        {
            fillList();
            foreach (Control x in enemies)
            {
                this.Controls.Add(x);
                totalEnemies += 1;
            }
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

            updateEnemiesPosition();

            scoreLabel.Text = "Score: " + score;
            if(score > totalEnemies - 1)
            {
                generateNewWave();
            }
        }

        private void updateEnemiesPosition()
        {
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 20; 
                    if (((PictureBox)y).Top < this.Height - 490)
                    {
                        this.Controls.Remove(y); 
                    }
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "invader") {
                    if (((PictureBox)x).Bottom > this.Height - 90)

                    {
                        soundPlayer.Stop();
                        gameOver();
                        break;
                    }
                    x.Top += speed;
                }
            }

            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "invader" && j is PictureBox && j.Tag == "bullet")
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

        private void shootBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "bullet";
            bullet.Left = player.Left + player.Width / 2; 
            bullet.Top = player.Top - 20; 
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
            
            soundPlayer1.Play();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
