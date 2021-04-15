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
        public partial class lvl2 : Form
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

            public lvl2()
            {
                InitializeComponent();
            }

            private void background_Click(object sender, EventArgs e)
            {

            }

            private void lvl2_Load(object sender, EventArgs e)
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
                        mission2Complete finishwsWindow = new mission2Complete(); 

                        finishwsWindow.Show();

                    }
                    else
                    {
                        mission2Complete_HARD finishWindow = new mission2Complete_HARD(); 

                        finishWindow.Show();

                    }     

                }

                

                if (player.Bounds.IntersectsWith(enemy2.Bounds))
                {
                    GameTimer.Stop();
                    MessageBox.Show("You were killed in action" + Environment.NewLine + "Click OK to replay this mission");
                    RestartGame();
                }

                if (player.Bounds.IntersectsWith(enemy3.Bounds))
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

                enemy3.Left -= enemy3Speed;

                if (enemy3.Left < platformEnemy3.Left || enemy3.Left + enemy3.Width > platformEnemy3.Left + platformEnemy3.Width)
                {
                    enemy3Speed = -enemy3Speed;
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
                lvl2 newWindow = new lvl2();
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

            private void pictureBox2_Click_1(object sender, EventArgs e)  //this is the enemy that was copied from the player
            {

            }

            private void pictureBox12_Click(object sender, EventArgs e)
            {

            }

            private void player_Click(object sender, EventArgs e)
            {

            }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void finish_Click(object sender, EventArgs e)
        {

        }

        private void enemy2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
    }