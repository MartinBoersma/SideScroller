using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//background By Zeyu Ren 任泽宇, from opengameart.org

namespace SideScroller
{
    public partial class Form1 : Form
    {

        public static List<string> Inventory = new List<string>();


        bool goLeft = false;
        bool goRight = false;
        bool jumping = false;
        //bool hasKey = false;

        int jumpSpeed = 10;
        int force = 8;
        int score = 0;
        int extra = 0;

        int playerSpeed = 5;
        int backgroundSpeed = 8;

        int enemy1Speed = 5;
        int enemy2Speed = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void background_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }



        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            extraScore.Text = "Score " + extra;
            player.Top += jumpSpeed;

            if(goLeft == true && player.Left > 60)
            {
                player.Left -= playerSpeed;
            }
            if(goRight == true && player.Left + (player.Width + 30) < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
            }

            if (goLeft == true && background.Left < 0)
            {
                background.Left += backgroundSpeed;
                MoveGameElements("forward");
            }

            if (goRight == true && background.Left > -1568)
            {
                background.Left -= backgroundSpeed;
                MoveGameElements("back");
            }

            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        jumpSpeed = 0;
                    }

                    x.BringToFront();
                }

                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        Inventory.Add("coin");

                        x.Visible = false;
                        score += 1;                        
                    }
                }

                if (player.Bounds.IntersectsWith(intel.Bounds) && intel.Visible == true)
                {
                    Inventory.Add("intel");

                    intel.Visible = false;
                    extra += 1;
                }
            }

            
            if (player.Bounds.IntersectsWith(finish.Bounds))
            {
                GameTimer.Stop();

                if (Inventory.Contains("intel"))
                {
                    missionwsComplete finishwsWindow = new missionwsComplete();

                    finishwsWindow.Show();
                    
                }
                else
                {
                    missionComplete finishWindow = new missionComplete();

                    finishWindow.Show();
                    
                }


                
                
                
                //MessageBox.Show("Mission Complete" + Environment.NewLine + "Click OK to replay this mission");
                //RestartGame();
            }

                if (player.Bounds.IntersectsWith(enemy1.Bounds))
                {
                    GameTimer.Stop();
                    MessageBox.Show("You were killed in action" + Environment.NewLine + "Click OK to replay this mission");
                    RestartGame();
                }

                if (player.Bounds.IntersectsWith(enemy2.Bounds))
                {
                GameTimer.Stop();
                MessageBox.Show("You were killed in action" + Environment.NewLine + "Click OK to replay this mission");
                RestartGame();
                }


            if (player.Top + player.Height > this.ClientSize.Height)
            {
                GameTimer.Stop();
                MessageBox.Show("Killed In Action" + Environment.NewLine + "Click OK to replay this mission");
                RestartGame();
            }

            //enemy movement
            enemy1.Left -= enemy1Speed;

            if(enemy1.Left < pictureBoxEnemy.Left || enemy1.Left + enemy1.Width > pictureBoxEnemy.Left + pictureBoxEnemy.Width)
            {
                enemy1Speed = -enemy1Speed;
            }

            enemy2.Left -= enemy1Speed;

            if (enemy2.Left < pictureBoxEnemy.Left || enemy2.Left + enemy2.Width > pictureBoxEnemy.Left + pictureBoxEnemy.Width)
            {
                enemy2Speed = -enemy2Speed;
            }







        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }



        private void CloseGame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RestartGame()
        {
            Form1 newWindow = new Form1();
            newWindow.Show();
            this.Hide();

        }

        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "intel" || 
                    x is PictureBox && (string)x.Tag == "finish" || x is PictureBox && (string)x.Tag == "enemy" )
                    {
                        if(direction == "back")
                        {
                        x.Left -= backgroundSpeed;
                        }
                        if(direction == "forward")
                        {
                        x.Left += backgroundSpeed;
                        }
                    }
            }





        }

        private void pictureBox2_Click_1(object sender, EventArgs e)  //this is the enemy that was copied from the player
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e) //new enemy withour copying
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void intel_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
