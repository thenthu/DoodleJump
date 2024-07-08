using System.Drawing;

namespace DoodleJump.Classes
{
    public class Bullet_64_Thu
    {
        public Physics_64_Thu physics_64_Thu;
        public Image img_64_Thu;

        public Bullet_64_Thu(PointF pos_64_Thu)
        {
            img_64_Thu = Properties.Resources.shot;
            physics_64_Thu = new Physics_64_Thu(pos_64_Thu, new Size(15, 15));
        }

        public void MoveUp_64_Thu()
        {
            physics_64_Thu.transform_64_Thu.position_64_Thu.Y -= 15;
        }

        public void DrawImg_64_Thu(Graphics img_64_Thu)
        {
            img_64_Thu.DrawImage(this.img_64_Thu, physics_64_Thu.transform_64_Thu.position_64_Thu.X, physics_64_Thu.transform_64_Thu.position_64_Thu.Y, physics_64_Thu.transform_64_Thu.size_64_Thu.Width, physics_64_Thu.transform_64_Thu.size_64_Thu.Height);
        }
    }
}
