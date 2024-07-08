using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class HelpScreen_64_Thu : Form
    {
        public HelpScreen_64_Thu()
        {
            InitializeComponent();
        }

        private void btnReturn_64_Thu_Click(object sender, EventArgs e)
        {
            MainMenu_64_Thu mainMenu_64_Thu = new MainMenu_64_Thu();
            this.Hide();
            mainMenu_64_Thu.Show();
        }

        private void btnReturn_64_Thu_MouseHover(object sender, EventArgs e)
        {
            btnReturn_64_Thu.Image = Properties.Resources.button_return_active;
        }

        private void btnReturn_64_Thu_MouseLeave(object sender, EventArgs e)
        {
            btnReturn_64_Thu.Image = Properties.Resources.button_return;
        }
    }
}
