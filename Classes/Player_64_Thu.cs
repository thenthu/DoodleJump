using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Player_64_Thu
    {
        public Physics_64_Thu physics_64_Thu;
        public Image img_64_Thu;

        public Player_64_Thu()
        {
            img_64_Thu = Properties.Resources.doodle_right;
            physics_64_Thu = new Physics_64_Thu(new PointF(100, 350), new Size(60, 60));
        }

        public void DrawImg_64_Thu(Graphics img_64_Thu)
        {
            img_64_Thu.DrawImage(this.img_64_Thu, physics_64_Thu.transform_64_Thu.position_64_Thu.X, physics_64_Thu.transform_64_Thu.position_64_Thu.Y, physics_64_Thu.transform_64_Thu.size_64_Thu.Width, physics_64_Thu.transform_64_Thu.size_64_Thu.Height);
        }
    }
}
