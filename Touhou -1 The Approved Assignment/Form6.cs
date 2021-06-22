using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using WMPLib;

namespace Touhou__1_The_Approved_Assignment
{
    public partial class Form6 : Form
    {
        WindowsMediaPlayer play = new WindowsMediaPlayer();
        bool shot = false;
        int score = 0;
        int speed = 11;
        Random rand = new Random();
        int playerSpeed = 10;

        public Form6()
        {
            InitializeComponent();
            play.URL = "stage3.mp3";
        }

        private void gameTick(object sender, EventArgs e)
        {
            pillar1.Left -= speed;
            pillar2.Left -= speed;
            pillar3.Left -= speed;
            pillar4.Left -= speed;
            pillar5.Left -= speed;
            pillar6.Left -= speed;
            pillar7.Left -= speed;
            enemy.Left -= speed;
            label1.Text = "Score: " + score;

            if (pillar1.Left < -150)
            {
                pillar1.Left = 800;
            }

            if (pillar2.Left < -150)
            {
                pillar2.Left = 900;
            }

            if (pillar3.Left < -150)
            {
                pillar3.Left = 1000;
            }

            if (pillar4.Left < -150)
            {
                pillar4.Left = 1100;
            }

            if (pillar5.Left < -150)
            {
                pillar5.Left = 1200;
            }

            if (pillar6.Left < -150)
            {
                pillar6.Left = 1500;
            }

            if (pillar7.Left < -150)
            {
                pillar7.Left = 1700;
            }

            if (C1.Bounds.IntersectsWith(enemy.Bounds) || C1.Bounds.IntersectsWith(pillar1.Bounds) || C1.Bounds.IntersectsWith(pillar2.Bounds) || C1.Bounds.IntersectsWith(pillar3.Bounds) || C1.Bounds.IntersectsWith(pillar4.Bounds) || C1.Bounds.IntersectsWith(pillar5.Bounds) || C1.Bounds.IntersectsWith(pillar6.Bounds) || C1.Bounds.IntersectsWith(pillar7.Bounds) || C2.Bounds.IntersectsWith(enemy.Bounds) || C2.Bounds.IntersectsWith(pillar1.Bounds) || C2.Bounds.IntersectsWith(pillar2.Bounds) || C2.Bounds.IntersectsWith(pillar3.Bounds) || C2.Bounds.IntersectsWith(pillar4.Bounds) || C2.Bounds.IntersectsWith(pillar5.Bounds) || C2.Bounds.IntersectsWith(pillar6.Bounds) || C2.Bounds.IntersectsWith(pillar7.Bounds) || C3.Bounds.IntersectsWith(enemy.Bounds) || C3.Bounds.IntersectsWith(pillar1.Bounds) || C3.Bounds.IntersectsWith(pillar2.Bounds) || C3.Bounds.IntersectsWith(pillar3.Bounds) || C3.Bounds.IntersectsWith(pillar4.Bounds) || C3.Bounds.IntersectsWith(pillar5.Bounds) || C3.Bounds.IntersectsWith(pillar6.Bounds) || C3.Bounds.IntersectsWith(pillar7.Bounds))
            {
                play.URL = "DEAD.mp3";
                gameTimer.Stop();
                MessageBox.Show("You are dead. You killed: " + score + " enemies");
                play.controls.stop();
                Form6 f6 = new Form6();
                this.Hide();
                f6.FormClosed += (s, args) => this.Close();
                f6.Show();
                f6.Focus();
                play.controls.stop();
            }

            if (enemy.Left < -5)
            {
                score--;
                enemy.Left = 1000;
                enemy.Top = rand.Next(5, 330) - enemy.Height;
            }

            if (score == 15)
            {
                gameTimer.Stop();
                MessageBox.Show("Congratulations! You defeated Rin and recovered your cheese!");
                    Form7 f7 = new Form7();
                    this.Hide();
                    f7.FormClosed += (s, args) => this.Close();
                    f7.Show();
                    f7.Focus();
                    play.controls.stop();
            }

            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && X.Tag == "bullet")
                {
                    X.Left += 15;

                    if (X.Left > 900)
                    {
                        this.Controls.Remove(X);
                        X.Dispose();
                    }
                    if (X.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        score += 1;
                        this.Controls.Remove(X);
                        X.Dispose();
                        enemy.Left = 1000;
                        enemy.Top = rand.Next(5, 330) - enemy.Height;
                    }
                }
            }
        }       

        private void keyisdown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    timer2.Enabled = true;
                    C1.Top -= playerSpeed;
                    C2.Top -= playerSpeed;
                    C3.Top -= playerSpeed;
                    break;

                case Keys.Down:
                    timer2.Enabled = true;
                    C1.Top += playerSpeed;
                    C2.Top += playerSpeed;
                    C3.Top += playerSpeed;
                    break;
            }

            if (e.KeyCode == Keys.Z && shot == false)
            {
                makeBullet();
                shot = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            timer2.Enabled = false;

            if (shot == true)
            {
                shot = false;
            }
        }

        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();

            bullet.BackColor = System.Drawing.Color.DarkOrange;
            bullet.Height = 5;
            bullet.Width = 10;
            bullet.Left = C1.Left + C1.Width;
            bullet.Left = C2.Left + C2.Width;
            bullet.Left = C3.Left + C3.Width;
            bullet.Top = C1.Top + C1.Height / 2;
            bullet.Top = C2.Top + C2.Height / 2;
            bullet.Top = C3.Top + C3.Height / 2;
            bullet.Tag = "bullet";
            this.Controls.Add(bullet);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (C1.Visible == true)
            {
                C1.Visible = false;
                C2.Visible = true;
            }
            else
            {
                if (C2.Visible == true)
                {
                    C2.Visible = false;
                    C3.Visible = true;
                }
                else
                {
                    C3.Visible = false;
                    C1.Visible = true;
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            play.controls.play();
        }
    }
}
