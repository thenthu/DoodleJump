using DoodleJump.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class MainMenu_64_Thu : Form
    {
        private int gravity_64_Thu = 0;
        private int force_64_Thu = 32;
        private bool isJumping_64_Thu = true;
        private static Sound_64_Thu sound_64_Thu = new Sound_64_Thu();

        public MainMenu_64_Thu()
        {
            InitializeComponent();
        }

        private void btn_start_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btn_start_64_Thu.Image = Properties.Resources.button_newgame_active;
        }

        private void btn_exit_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btn_exit_64_Thu.Image = Properties.Resources.button_exit_active;
        }

        private void btn_top10_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btn_top10_64_Thu.Image = Properties.Resources.button_top10_active;
        }

        private void btn_sound_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btn_sound_64_Thu.Image = Properties.Resources.sound_active;
        }

        private void btn_soundoff_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btn_soundoff_64_Thu.Image = Properties.Resources.soundoff_active;
        }

        private void btn_start_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btn_start_64_Thu.Image = Properties.Resources.button_newgame;
        }

        private void btn_exit_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btn_exit_64_Thu.Image = Properties.Resources.button_exit;
        }

        private void btn_top10_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btn_top10_64_Thu.Image = Properties.Resources.button_top10;
        }

        private void btn_sound_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btn_sound_64_Thu.Image = Properties.Resources.sound;
        }

        private void btn_soundoff_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btn_soundoff_64_Thu.Image = Properties.Resources.soundoff;
        }

        private void btn_start_64_Thu_Click(object sender, EventArgs e)
        {
            GameScreen_64_Thu gameScreen_64_Thu = new GameScreen_64_Thu();
            this.Hide();
            gameScreen_64_Thu.Show();
        }

        private void btn_exit_64_Thu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_top10_64_Thu_Click(object sender, EventArgs e)
        {
            Top10Screen_64_Thu top10 = new Top10Screen_64_Thu();
            this.Hide();
            top10.Show();
        }

        private void btn_soundoff_64_Thu_Click(object sender, EventArgs e)
        {
            btn_sound_64_Thu.Visible = true;
            btn_soundoff_64_Thu.Visible = false;
            sound_64_Thu.OffSound_64_Thu = false;
        }

        private void btn_sound_64_Thu_Click(object sender, EventArgs e)
        {
            btn_sound_64_Thu.Visible = false;
            btn_soundoff_64_Thu.Visible = true;
            sound_64_Thu.OffSound_64_Thu = true;
        }

        private void MainMenu_64_Thu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                HelpScreen_64_Thu helpScreen_64_Thu = new HelpScreen_64_Thu();
                this.Hide();
                helpScreen_64_Thu.Show();
            }
        }

        private void gameTimer_64_Thu_Tick(object sender, EventArgs e)
        {
            if (isJumping_64_Thu)
            {
                mainDoodle_64_Thu.Top -= force_64_Thu;
                force_64_Thu -= 4;
                
                if (force_64_Thu <= 0)
                {
                    isJumping_64_Thu = false;
                    force_64_Thu = 15;
                }
            }
            else
            {
                mainDoodle_64_Thu.Top += gravity_64_Thu;
                gravity_64_Thu += 10;
            }
            
            if (mainDoodle_64_Thu.Top + mainDoodle_64_Thu.Height >= staticBase_64_Thu.Top + 9)
            {
                sound_64_Thu.ESound1_64_Thu.Play();
                if (sound_64_Thu.OffSound_64_Thu || !this.Visible)
                {
                    sound_64_Thu.ESound1_64_Thu.Stop();
                }
                mainDoodle_64_Thu.Top = mainScreen_64_Thu.Height - staticBase_64_Thu.Top + 9;
                isJumping_64_Thu = true;
                gravity_64_Thu = 0; // Reset lại tốc độ rơi khi bắt đầu một lần nhảy mới
            }
        }
    }
}
