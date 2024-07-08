using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Enemy_64_Thu : Player_64_Thu
    {
        public Enemy_64_Thu(PointF pos_64_Thu, int type_64_Thu)
        {
            switch (type_64_Thu)
            {
                case 1:
                    img_64_Thu = Properties.Resources.monster_1;
                    physics_64_Thu = new Physics_64_Thu(pos_64_Thu, new Size(40, 40));
                    break;
                case 2:
                    img_64_Thu = Properties.Resources.monster_2;
                    physics_64_Thu = new Physics_64_Thu(pos_64_Thu, new Size(70, 50));
                    break;
                case 3:
                    img_64_Thu = Properties.Resources.monster_3right;
                    physics_64_Thu = new Physics_64_Thu(pos_64_Thu, new Size(70, 60));
                    break;

            }

        }
    }
}
