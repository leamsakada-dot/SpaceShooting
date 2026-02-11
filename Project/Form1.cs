using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace FighterJetCam
{
    public partial class Form1 : Form
    {
     
        bool right, left, up, down, space;
        int score;
        PictureBox[] hearts;
        int lives = 3;
        bool isHit = false;
        int level = 1;
        int bossHealth = 10000;
        int bossSpeedX = 6;
        int bossSpeedY = 2;
        bool bossMoveRight = true;
        Timer bossBulletTimer;

        ProgressBar bossBar;
        bool bossActive = false;
        SoundPlayer shootSound = new SoundPlayer(Properties.Resources.pew1);
        WMPLib.WindowsMediaPlayer bossSoundPlayer = new WMPLib.WindowsMediaPlayer();
        WindowsMediaPlayer bossDeathPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();
        SoundPlayer playerDeathSound = new SoundPlayer(Properties.Resources.failwav);





        public Form1()
        {
            InitializeComponent();
            label2.Hide();
            label3.Hide();
            pictureBox3.Hide();
            CreateHearts();
            CreateBossBar();

        }
        void enemy_move()
        {
            Random rand = new Random();

            int speedturtle = 3;
            int speedShip = 2;
            int speedWillian = 5;

            if (level == 2)
            {
                speedturtle = 8;
                speedShip = 5;
                speedWillian = 6;
            }

            // MOVE ENEMIES
            alien.Top += speedturtle;
            ship.Top += speedShip;
            willian.Top += speedWillian;

            // RESET WHEN OUT OF SCREEN
            if (alien.Top > 700)
                alien.Location = new Point(rand.Next(0, 400),0);

            if (ship.Top > 700)
                ship.Location = new Point(rand.Next(0, 400),0);

            if (willian.Top > 700)
                willian.Location = new Point(rand.Next(0, 400), 0);
        }

        void CreateBossBar()
        {
            bossBar = new ProgressBar();
            bossBar.Width = 300;
            bossBar.Height = 20;
            bossBar.Left = 150;
            bossBar.Top = 10;
            bossBar.Maximum = 100;
            bossBar.Value = 100;
            bossBar.Visible = false;

            this.Controls.Add(bossBar);
            bossBar.BringToFront();
        }
        void BossMove()
        {
            if (!bossActive) return;

            // LEFT ↔ RIGHT zigzag
            if (bossMoveRight)
                alien.Left += bossSpeedX;
            else
                alien.Left -= bossSpeedX;

            if (alien.Left <= 10)
                bossMoveRight = true;

            if (alien.Left >= 350)
                bossMoveRight = false;

            // Slow vertical movement
            alien.Top += bossSpeedY;

            if (alien.Top > 200)
                alien.Top = 50;

            // 🔥 Enrage mode (harder when HP low)
            if (bossHealth < 5000)
                bossSpeedX = 10;

            if (bossHealth < 2000)
                bossSpeedX = 14;
        }
        void BossShoot()
        {
            if (!bossActive) return;

            PictureBox bullet = new PictureBox();
            bullet.SizeMode = PictureBoxSizeMode.AutoSize;
            bullet.Image = Properties.Resources.bullet_img; 
            bullet.BackColor = Color.Transparent;
            bullet.Tag = "bossBullet";

            // Position bullet at boss center
            bullet.Left = alien.Left + (alien.Width / 2) - (bullet.Width / 2);
            bullet.Top = alien.Top + alien.Height; // shoot downwards

            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        void MoveBossBullets()
       
        {
       
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control c = this.Controls[i];

                if (c is PictureBox bullet && bullet.Tag == "bossBullet")
                {
                    bullet.Top += 10; // move downwards

                    // Remove if out of screen
                    if (bullet.Top > 700)
                        this.Controls.Remove(bullet);

                    // Check collision with player
                    if (player.Bounds.IntersectsWith(bullet.Bounds) && !isHit)
                    {
                        isHit = true;
                        lives--;

                        if (lives >= 0 && lives < hearts.Length)
                            this.Controls.Remove(hearts[lives]);

                        player.Location = new Point(200, 500);

                        Timer hitTimer = new Timer();
                        hitTimer.Interval = 1000;
                        hitTimer.Tick += (s, e) =>
                        {
                            isHit = false;
                            hitTimer.Stop();
                        };
                        hitTimer.Start();

                        this.Controls.Remove(bullet);// remove bullet after hit

                        if (lives <= 0)
                        {
                            timer1.Stop();
                            label2.Show();
                            label2.BringToFront();
                        }
                    }
                }
            }
        }


        void Arrow_move()
            {
                if (right == true)
                {
                    if (player.Left < 420)
                    {
                        player.Left += 20;
                    }
                }
                if (left == true)
                {
                    if (player.Left > 10)
                    {
                        player.Left -= 20;
                    }
                }
                if (up == true)
                {
                    if (player.Top > 10)
                    {
                        player.Top -= 20;
                    }
                }
                if (down == true)
                {
                    if (player.Top < 600)
                    {
                        player.Top += 20;
                    }

                }
            }
            void add_bullet()
            {
                PictureBox bullet = new PictureBox();
                bullet.SizeMode = PictureBoxSizeMode.AutoSize;
                bullet.Image = Properties.Resources.bullet_img;
                bullet.BackColor = System.Drawing.Color.Transparent;
                bullet.Tag = "bullet";
                bullet.Left = player.Left + (player.Width / 2) - (bullet.Width / 2);
                bullet.Top = player.Top - bullet.Height;
                this.Controls.Add(bullet);
                bullet.BringToFront();

            }

            void bullet_move()
            {
            alien.Tag = "enemy";
            ship.Tag = "enemy";
            willian.Tag = "enemy";
            foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "bullet")
                    {
                        x.Top -= 15;
                        if (x.Top < -100)
                        {
                            this.Controls.Remove(x);
                        }
                    }
                }
            }
        void StartBossLevel()
        {
            bossSoundPlayer.URL = @"C:\Jetelement\bosslaugh.mp3";
            bossSoundPlayer.settings.setMode("loop", true); // loop it
            bossSoundPlayer.controls.play();

            level = 3;
            bossActive = true;

            ship.Visible = false;   // hide small enemy
            alien.Visible = true;
            willian.Visible = false; 

            alien.Image = Image.FromFile(@"C:\Jetelement\Alien2.gif");
            alien.Size = new Size(150, 150);
            alien.SizeMode = PictureBoxSizeMode.Zoom;
            alien.BackColor = Color.Transparent;
            alien.Top = 50;
            alien.Left = 150;

            bossHealth = 10000;
            bossBar.Maximum = 10000;
            bossBar.Value = bossHealth;
            bossBulletTimer = new Timer();
            bossBulletTimer.Interval = 1000; // 1 second
            bossBulletTimer.Tick += (s, e) =>
            {
                BossShoot();
            };
            bossBulletTimer.Start();

            bossBar.Visible = true;
           

        }

        void CheckLevel()
        {
            if (score >= 10 && level == 1)
                level = 2;

            if (score >= 50 && level == 2)
                StartBossLevel();
        }

        void star()
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "stars")
                    {
                        x.Top += 10;
                        if (x.Top > 400)
                        {
                            x.Top = 0;
                        }
                    }
                }
            }
        void game_result()
        {
                for (int i = this.Controls.Count - 1; i >= 0; i--)
                {
                    Control c = this.Controls[i];

                    if (c is PictureBox bullet && bullet.Tag == "bullet")
                    {
                        // 🔥 Boss collision only when boss is active
                        if (bossActive)
                        {
                            Rectangle bossHitBox = new Rectangle(
                                alien.Left + 20,
                                alien.Top + 20,
                                alien.Width - 40,
                                alien.Height - 40
                            );

                            if (bullet.Bounds.IntersectsWith(bossHitBox))
                            {
                                bossHealth -= 100;
                                if (bossHealth < 0) bossHealth = 0;

                                bossBar.Value = bossHealth;
                                this.Controls.Remove(bullet);

                                if (bossHealth <= 0)
                                {
                                    bossActive = false;
                                    bossBar.Visible = false;
                                    alien.Visible = false;
                                    bossSoundPlayer.controls.stop();
                                    backgroundMusic.controls.stop();    

                                if (bossBulletTimer != null)
                                    {
                                        bossBulletTimer.Stop();
                                        bossBulletTimer.Dispose();
                                    }

                                    timer1.Stop();
                                label3.Visible = true;  // show the label
                                label3.BringToFront();
                                pictureBox3.Visible = true; // show trophy
                                bossDeathPlayer.URL = @"C:\Jetelement\boss_death.mp3";
                                bossDeathPlayer.controls.play();  
                                bossDeathPlayer.settings.setMode("loop", true);


                            }
                        }
                        }
                        else
                        {
                            // 🔹 Normal enemies
                            foreach (Control e in this.Controls)
                            {
                                if (e is PictureBox enemy && enemy.Tag == "enemy")
                                {
                                    if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                                    {
                                        this.Controls.Remove(bullet);
                                        enemy.Top = -100;
                                        score++;
                                        label1.Text = "score: " + score;
                                        CheckLevel();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        

        // 🔻 PLAYER HIT
        void CheckPlayerHit()
        {
            // Check collision with enemies
            if ((player.Bounds.IntersectsWith(alien.Bounds) || player.Bounds.IntersectsWith(ship.Bounds)|| player.Bounds.IntersectsWith(willian.Bounds))&& !isHit)
            {
                isHit = true;
                lives--;

                // Remove one heart
                if (lives >= 0 && lives < hearts.Length)
                {
                    this.Controls.Remove(hearts[lives]);
                }

                // Reset player & enemies position
                player.Location = new Point(200, 500);
                alien.Top = -100;
                ship.Top = -300;

                // Start invincibility timer (1 second)
                Timer hitTimer = new Timer();
                hitTimer.Interval = 1000;
                hitTimer.Tick += (s, e) =>
                {
                    isHit = false;
                    hitTimer.Stop();
                    hitTimer.Dispose();
                };
                hitTimer.Start();

                // Game Over after 3 hits
                if (lives <= 0)
                {
                    timer1.Stop();
                    label2.Show();
                    label2.BringToFront();
                }
            }
        }
        
            void RestartGame()
        { 
                // Reset score
                score = 0;
                label1.Text = "Score: 0";

                // Hide game over text
                label2.Hide();

                // Reset player position
                player.Left = 200;
                player.Top = 500;

                // Reset enemies position
                alien.Top = -100;
                alien.Left = 50;

                ship.Top = -300;
                ship.Left = 250;

                // Remove all bullets
                for (int i = this.Controls.Count - 1; i >= 0; i--)
                {
                    if (this.Controls[i] is PictureBox &&
                        this.Controls[i].Tag == "bullet")
                    {
                        this.Controls.Remove(this.Controls[i]);
                    }
                }

                // Reset movement keys
                right = left = up = down = space = false;

                // Start game again
                timer1.Start();
                // Remove old hearts
                foreach (PictureBox h in hearts)
                {
                    this.Controls.Remove(h);
                }

                // Reset lives
                lives = 3;
                CreateHearts();
                isHit = false;
              

            }
            void CreateHearts()
            {
                hearts = new PictureBox[lives];

                for (int i = 0; i < lives; i++)
                {
                    hearts[i] = new PictureBox();
                    hearts[i].Image = Image.FromFile(@"C:\Jetelement\heart.gif");
                    hearts[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    hearts[i].BackColor = Color.Transparent ;
                    hearts[i].Size = new Size(25, 25);
                    hearts[i].Left = 10 + (i * 30);
                    hearts[i].Top = 10;
                    hearts[i].BackColor = Color.Transparent;

                    this.Controls.Add(hearts[i]);
                    hearts[i].BringToFront();
                }
            }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Arrow_move();
            bullet_move();
            star();
            if (bossActive)
                BossMove();
            else
                enemy_move();
            game_result();
            CheckPlayerHit();
            CheckLevel();
            if (bossActive)
            {
                BossMove();
                MoveBossBullets(); // 👈 move boss bullets
            }
            else
            {
                enemy_move();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void alien_Click(object sender, EventArgs e)
        {
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            willian.BackColor = Color.Transparent;
            alien.BackColor = Color.Transparent;
            ship.BackColor = Color.Transparent;
            player.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            backgroundMusic.URL = @"C:\Jetelement\Eye.mp3";
            backgroundMusic.settings.setMode("loop", true);
            backgroundMusic.settings.volume = 20;
            backgroundMusic.controls.play();


        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
                add_bullet();
                shootSound.Play();
            }
            if (e.KeyCode == Keys.Enter && !timer1.Enabled)
            {
                RestartGame();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Up)
            { 
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            { 
                down = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
          
        }
    }
}
