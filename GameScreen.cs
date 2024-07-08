using DoodleJump.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class GameScreen_64_Thu : Form
    {
        Player_64_Thu player_64_Thu;
        Timer timer1_64_Thu;
        bool isDoodleRight_64_Thu = true;
        private String playerName_64_Thu;
        public static int highScore_64_Thu;
        private int score_64_Thu;
        private static Sound_64_Thu sound_64_Thu = new Sound_64_Thu();

        public GameScreen_64_Thu()
        {
            InitializeComponent();
            Init();
            timer1_64_Thu = new Timer();
            timer1_64_Thu.Interval = 15;
            timer1_64_Thu.Tick += new EventHandler(Update);
            timer1_64_Thu.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.Paint += new PaintEventHandler(OnRepaint_64_Thu);
        }

        public void Init()
        {
            PlatformController_64_Thu.platforms_64_Thu = new List<Platform_64_Thu>();
            PlatformController_64_Thu.AddPlatform_64_Thu(new PointF(100, 400));
            PlatformController_64_Thu.startPlatformPosY_64_Thu = 400;
            PlatformController_64_Thu.score_64_Thu = 0;
            PlatformController_64_Thu.GenerateStartSequence_64_Thu();
            PlatformController_64_Thu.bullets_64_Thu.Clear();
            PlatformController_64_Thu.bonuses_64_Thu.Clear();
            PlatformController_64_Thu.enemies_64_Thu.Clear();
            player_64_Thu = new Player_64_Thu();
        }

        private void btnReturn_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btnReturn_64_Thu.Image = Properties.Resources.button_return_active;
        }

        private void btnReturn_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btnReturn_64_Thu.Image = Properties.Resources.button_return;
        }

        private void btnReturn_64_Thu_Click(object sender, EventArgs e)
        {
            Score_64_Thu.SaveHighScore_64_Thu(playerName_64_Thu, highScore_64_Thu);
            MainMenu_64_Thu mainMenu_64_Thu = new MainMenu_64_Thu();
            this.Hide();
            mainMenu_64_Thu.Show();
        }

        private void btnSoundOff_64_Thu_Click(object sender, EventArgs e)
        {
            btnSoundOff_64_Thu.Visible = false;
            btnSound_64_Thu.Visible = true;
            sound_64_Thu.OffSound_64_Thu = false;
        }

        private void btnSoundOff_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btnSoundOff_64_Thu.Image = Properties.Resources.soundoff_active;
        }

        private void btnSoundOff_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btnSoundOff_64_Thu.Image = Properties.Resources.soundoff;
        }

        private void btnSound_64_Thu_Click(object sender, EventArgs e)
        {
            btnSound_64_Thu.Visible = false;
            btnSoundOff_64_Thu.Visible = true;
            sound_64_Thu.OffSound_64_Thu = true;
        }

        private void btnSound_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btnSound_64_Thu.Image = Properties.Resources.sound_active;
        }

        private void btnSound_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btnSound_64_Thu.Image = Properties.Resources.sound;
        }

        private void txtName_64_Thu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtName_64_Thu.Text))
                {
                    e.SuppressKeyPress = true;
                    lblWarning_64_Thu.Text = "Please enter your name!";
                }
                else
                {
                    e.SuppressKeyPress = true;
                    playerName_64_Thu = txtName_64_Thu.Text;
                    panelName_64_Thu.Visible = false;
                    panelName_64_Thu.Enabled = false;
                }
            }
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player_64_Thu.physics_64_Thu.dx_64_Thu = 0;
            if (isDoodleRight_64_Thu)
            {
                player_64_Thu.img_64_Thu = Properties.Resources.doodle_right;
            }
            else
            {
                player_64_Thu.img_64_Thu = Properties.Resources.doodle_left;
            }
            switch (e.KeyCode.ToString())
            {
                case "Space":
                    e.SuppressKeyPress = true;
                    PlatformController_64_Thu.CreateBullet_64_Thu(new PointF(player_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.X + player_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2, player_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y));
                    break;
            }
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player_64_Thu.img_64_Thu = Properties.Resources.doodle_right;
                    isDoodleRight_64_Thu = true;
                    player_64_Thu.physics_64_Thu.dx_64_Thu = 10;
                    break;
                case "Left":
                    player_64_Thu.img_64_Thu = Properties.Resources.doodle_left;
                    isDoodleRight_64_Thu = false;
                    player_64_Thu.physics_64_Thu.dx_64_Thu = -10;
                    break;
                case "Space":
                    e.SuppressKeyPress = true;
                    player_64_Thu.img_64_Thu = Properties.Resources.doodle_pow;
                    sound_64_Thu.ESound4_64_Thu.Play();
                    break;
                case "R":
                    Score_64_Thu.SaveHighScore_64_Thu(playerName_64_Thu, highScore_64_Thu);
                    e.SuppressKeyPress = true;
                    this.Init();
                    break;
            }
        }


        private void Update(object sender, EventArgs e)
        {
            lblScore_64_Thu.Text = "Score: " + PlatformController_64_Thu.score_64_Thu.ToString();
            highScore_64_Thu = PlatformController_64_Thu.score_64_Thu;
            GameSound_64_Thu();

            if ((player_64_Thu.physics_64_Thu.gravity_64_Thu > 30) || player_64_Thu.physics_64_Thu.StandartCollidePlayerWithObjects_64_Thu(true, false))
            {
                Score_64_Thu.SaveHighScore_64_Thu(playerName_64_Thu, highScore_64_Thu);
                Init();
            }

            player_64_Thu.physics_64_Thu.StandartCollidePlayerWithObjects_64_Thu(false, true);

            if (PlatformController_64_Thu.bullets_64_Thu.Count > 0)
            {
                for (int i = 0; i < PlatformController_64_Thu.bullets_64_Thu.Count; i++)
                {
                    if (Math.Abs(PlatformController_64_Thu.bullets_64_Thu[i].physics_64_Thu.transform_64_Thu.position_64_Thu.Y - player_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y) > 500)
                    {
                        PlatformController_64_Thu.RemoveBullet(i);
                        continue;
                    }
                    PlatformController_64_Thu.bullets_64_Thu[i].MoveUp_64_Thu();
                }
            }
            if (PlatformController_64_Thu.enemies_64_Thu.Count > 0)
            {
                for (int i = 0; i < PlatformController_64_Thu.enemies_64_Thu.Count; i++)
                {
                    if (PlatformController_64_Thu.enemies_64_Thu[i].physics_64_Thu.StandartCollide_64_Thu())
                    {
                        PlatformController_64_Thu.RemoveEnemy(i);
                        break;
                    }
                }
            }

            player_64_Thu.physics_64_Thu.CalculatePhysics_64_Thu();
            FollowPlayer_64_Thu();

            Invalidate();
        }

        public void FollowPlayer_64_Thu()
        {
            int offset = 400 - (int)player_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y;
            player_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y += offset;
            for (int i = 0; i < PlatformController_64_Thu.platforms_64_Thu.Count; i++)
            {
                var platform = PlatformController_64_Thu.platforms_64_Thu[i];
                platform.transform_64_Thu.position_64_Thu.Y += offset;
            }
            for (int i = 0; i < PlatformController_64_Thu.bullets_64_Thu.Count; i++)
            {
                var bullet = PlatformController_64_Thu.bullets_64_Thu[i];
                bullet.physics_64_Thu.transform_64_Thu.position_64_Thu.Y += offset;
            }
            for (int i = 0; i < PlatformController_64_Thu.enemies_64_Thu.Count; i++)
            {
                var enemy = PlatformController_64_Thu.enemies_64_Thu[i];
                enemy.physics_64_Thu.transform_64_Thu.position_64_Thu.Y += offset;
            }
            for (int i = 0; i < PlatformController_64_Thu.bonuses_64_Thu.Count; i++)
            {
                var bonus = PlatformController_64_Thu.bonuses_64_Thu[i];
                bonus.physics_64_Thu.transform_64_Thu.position_64_Thu.Y += offset;
            }
        }

        private void OnRepaint_64_Thu(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (PlatformController_64_Thu.platforms_64_Thu.Count > 0)
            {
                for (int i = 0; i < PlatformController_64_Thu.platforms_64_Thu.Count; i++)
                    PlatformController_64_Thu.platforms_64_Thu[i].DrawImg_64_Thu(g);
            }
            if (PlatformController_64_Thu.bullets_64_Thu.Count > 0)
            {
                for (int i = 0; i < PlatformController_64_Thu.bullets_64_Thu.Count; i++)
                    PlatformController_64_Thu.bullets_64_Thu[i].DrawImg_64_Thu(g);
            }
            if (PlatformController_64_Thu.enemies_64_Thu.Count > 0)
            {
                for (int i = 0; i < PlatformController_64_Thu.enemies_64_Thu.Count; i++)
                    PlatformController_64_Thu.enemies_64_Thu[i].DrawImg_64_Thu(g);
            }
            if (PlatformController_64_Thu.bonuses_64_Thu.Count > 0)
            {
                for (int i = 0; i < PlatformController_64_Thu.bonuses_64_Thu.Count; i++)
                    PlatformController_64_Thu.bonuses_64_Thu[i].DrawImg_64_Thu(g);
            }
            player_64_Thu.DrawImg_64_Thu(g);
        }

        private void GameSound_64_Thu()
        {
            if(sound_64_Thu.OffSound_64_Thu || this.Visible == false || panelName_64_Thu.Visible == true)
            {
                player_64_Thu.physics_64_Thu.soundPlayer_64_Thu.Stop();
            }
        }
    }
}
