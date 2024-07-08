using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Bonus_64_Thu
    {

        public Physics_64_Thu physics_64_Thu;
        public Image img_64_Thu;
        public int type_64_Thu;

        public Bonus_64_Thu(PointF pos_64_Thu, int type_64_Thu)
        {
            switch (type_64_Thu)
            {
                case 1:
                    img_64_Thu = Properties.Resources.pruz;
                    physics_64_Thu = new Physics_64_Thu(pos_64_Thu, new Size(25, 25));
                    break;
                case 2:
                    img_64_Thu = Properties.Resources.raketa_on_panel;
                    physics_64_Thu = new Physics_64_Thu(pos_64_Thu, new Size(30, 30));
                    break;  
            }
            this.type_64_Thu = type_64_Thu;
        }

        public void DrawImg_64_Thu(Graphics img_64_Thu)
        {
            img_64_Thu.DrawImage(this.img_64_Thu, physics_64_Thu.transform_64_Thu.position_64_Thu.X, physics_64_Thu.transform_64_Thu.position_64_Thu.Y, physics_64_Thu.transform_64_Thu.size_64_Thu.Width, physics_64_Thu.transform_64_Thu.size_64_Thu.Height);
        }
    }
}
