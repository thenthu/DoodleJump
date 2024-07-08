using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Platform_64_Thu
    {
        Image img_64_Thu;
        public Transform_64_Thu transform_64_Thu;
        public int sizeX_64_Thu;
        public int sizeY_64_Thu;
        public bool isTouchedByPlayer_64_Thu;

        public Platform_64_Thu(PointF pos_64_Thu)
        {
            img_64_Thu = Properties.Resources.static_panel;
            sizeX_64_Thu = 83;
            sizeY_64_Thu = 17;
            transform_64_Thu = new Transform_64_Thu(pos_64_Thu, new Size(sizeX_64_Thu, sizeY_64_Thu));
            isTouchedByPlayer_64_Thu = false;
        }

        public void DrawImg_64_Thu(Graphics img_64_Thu)
        {
            img_64_Thu.DrawImage(this.img_64_Thu, transform_64_Thu.position_64_Thu.X, transform_64_Thu.position_64_Thu.Y, transform_64_Thu.size_64_Thu.Width, transform_64_Thu.size_64_Thu.Height);
        }

    }
}
