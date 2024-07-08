using DoodleJump.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class Top10Screen_64_Thu : Form
    {
        private const string fileName_64_Thu = "High_Score.txt";

        public Top10Screen_64_Thu()
        {
            InitializeComponent();
        }

        private void Top10Screen_64_Thu_Load(object sender, EventArgs e)
        {
            if (File.Exists(fileName_64_Thu))
            {
                Score_64_Thu.ScoreSort_64_Thu();

                List<string> lines_64_Thu = File.ReadAllLines(fileName_64_Thu).ToList();
                int displayCount_64_Thu = Math.Min(10, lines_64_Thu.Count);

                for (int i = 0; i < displayCount_64_Thu; i++)
                {
                    string labelName_64_Thu = "top" + (i + 1) + "Name_64_Thu";
                    Label lblTop_64_Thu = Controls.Find(labelName_64_Thu, true).FirstOrDefault() as Label;

                    if (lblTop_64_Thu != null)
                    {
                        lblTop_64_Thu.Text = lines_64_Thu[i];
                    }
                }
            }
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
            MainMenu_64_Thu mainMenu_64_Thu = new MainMenu_64_Thu();
            this.Hide();
            mainMenu_64_Thu.Show();
        }
    }
}
