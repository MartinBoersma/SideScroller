using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideScroller
{
    public partial class lvl3 : Form
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

        int playerSpeed = 4;
        int backgroundSpeed = 8;

        int enemy1Speed = 5;
        int enemy2Speed = 5;
        int enemy3Speed = 5;

        int horizontalSpeed = 4;


        public lvl3()
        {
            InitializeComponent();
        }

        private void lvl3_Load(object sender, EventArgs e)
        {

        }

        private void intel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            extraScore.Text = "Score " + extra;
            player.Top += jumpSpeed;

            if (goLeft == true && player.Left > 60)
            {
                player.Left -= playerSpeed;
            }

            if (goRight == true && player.Left + (player.Width + 30) < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
            }

            if (goLeft == true && background.Left < 0)
            {
                background.Left += backgroundSpeed;
                MoveGameElements("forward");
            }

            if (goRight == true && background.Left > -1507)
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
                    gameComplete finishwsWindow = new gameComplete(); //level 3 has to have the name as lvl3_H, this means Level3_HARD

                    finishwsWindow.Show();

                    //missionwsComplete = mission with story, means that the player HAS collected the intel in the level
                }
                else
                {
                    gameComplete finishWindow = new gameComplete(); //this is the version without the collected intel from level 2, so it has to have an extra enemy

                    finishWindow.Show();
                    //this will show if the player has NOT collected the intel in the level
                }





                //MessageBox.Show("Mission Complete" + Environment.NewLine + "Click OK to replay this mission");
                //RestartGame();
            }



            if (player.Bounds.IntersectsWith(enemy2.Bounds))
            {
                GameTimer.Stop();
                MessageBox.Show("You were killed in action" + Environment.NewLine + "Click OK to replay this mission");
                RestartGame();
            }

            if (player.Bounds.IntersectsWith(enemy1.Bounds))
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

            enemy2.Left -= enemy2Speed;

            if (enemy2.Left < platformEnemy2.Left || enemy2.Left + enemy2.Width > platformEnemy2.Left + platformEnemy2.Width)
            {
                enemy2Speed = -enemy2Speed;
            }

            enemy1.Left -= enemy1Speed;

            if (enemy1.Left < platformEnemy1.Left || enemy1.Left + enemy1.Width > platformEnemy1.Left + platformEnemy1.Width)
            {
                enemy1Speed = -enemy1Speed;
            }


            //platform movement
            //horizontalPlatform.Left -= horizontalSpeed;

            //if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > 526)
            // {
            //    horizontalSpeed = -horizontalSpeed;
            // }

            //if (horizontalPlatform.Right < 0 || horizontalPlatform.Right + horizontalPlatform.Width > 240)
            //{
            //    horizontalSpeed = -horizontalSpeed;
            // }   



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
            lvl3 newWindow = new lvl3();
            newWindow.Show();
            this.Hide();

        }

        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "intel" ||
                    x is PictureBox && (string)x.Tag == "finish" || x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (direction == "back")
                    {
                        x.Left -= backgroundSpeed;
                    }
                    if (direction == "forward")
                    {
                        x.Left += backgroundSpeed;
                    }
                }
            }
        }

        private void background_Click(object sender, EventArgs e)
        {

        }
    }
}
