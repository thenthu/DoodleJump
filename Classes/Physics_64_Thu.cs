using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJump.Classes
{
    public class Physics_64_Thu
    {
        public Transform_64_Thu transform_64_Thu;
        Player_64_Thu player_64_Thu;
        public float gravity_64_Thu;
        float a;
        public int bonusType_64_Thu;
        Sound_64_Thu sound_64_Thu = new Sound_64_Thu();
        public SoundPlayer soundPlayer_64_Thu = new SoundPlayer();

        public float dx_64_Thu;
        public bool usedBonus_64_Thu = false;

        public Physics_64_Thu(PointF position_64_Thu, Size size_64_Thu)
        {
            transform_64_Thu = new Transform_64_Thu(position_64_Thu, size_64_Thu);
            gravity_64_Thu = 0;
            a = 0.8f;
            dx_64_Thu = 0;
        }

        public void CalculatePhysics_64_Thu()
        {
            if (dx_64_Thu != 0)
            {
                transform_64_Thu.position_64_Thu.X += dx_64_Thu;
            }
            if (transform_64_Thu.position_64_Thu.Y < 800)
            {
                transform_64_Thu.position_64_Thu.Y += gravity_64_Thu;
                gravity_64_Thu += a;

                if (gravity_64_Thu > -35 && usedBonus_64_Thu)
                {
                    PlatformController_64_Thu.GenerateRandomPlatform_64_Thu();
                    PlatformController_64_Thu.startPlatformPosY_64_Thu = -200;
                    PlatformController_64_Thu.GenerateStartSequence_64_Thu();
                    PlatformController_64_Thu.startPlatformPosY_64_Thu = 0;
                    usedBonus_64_Thu = false;
                }

                Collide_64_Thu();
            }
        }

        public bool StandartCollidePlayerWithObjects_64_Thu(bool forMonsters_64_Thu, bool forBonuses_64_Thu)
        {
            if (forMonsters_64_Thu)
            {
                for (int i = 0; i < PlatformController_64_Thu.enemies_64_Thu.Count; i++)
                {
                    var enemy_64_Thu = PlatformController_64_Thu.enemies_64_Thu[i];
                    PointF delta_64_Thu = new PointF();
                    delta_64_Thu.X = (transform_64_Thu.position_64_Thu.X + transform_64_Thu.size_64_Thu.Width / 2) - (enemy_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.X + enemy_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2);
                    delta_64_Thu.Y = (transform_64_Thu.position_64_Thu.Y + transform_64_Thu.size_64_Thu.Height / 2) - (enemy_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y + enemy_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Height / 2);
                    if (Math.Abs(delta_64_Thu.X) <= transform_64_Thu.size_64_Thu.Width / 2 + enemy_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2)
                    {
                        if (Math.Abs(delta_64_Thu.Y) <= transform_64_Thu.size_64_Thu.Height / 2 + enemy_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Height / 2)
                        {
                            if (!usedBonus_64_Thu)
                                return true;
                        }
                    }
                }
            }
            if (forBonuses_64_Thu)
            {
                for (int i = 0; i < PlatformController_64_Thu.bonuses_64_Thu.Count; i++)
                {
                    var bonus_64_Thu = PlatformController_64_Thu.bonuses_64_Thu[i];
                    PointF delta_64_Thu = new PointF();
                    delta_64_Thu.X = (transform_64_Thu.position_64_Thu.X + transform_64_Thu.size_64_Thu.Width / 2) - (bonus_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.X + bonus_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2);
                    delta_64_Thu.Y = (transform_64_Thu.position_64_Thu.Y + transform_64_Thu.size_64_Thu.Height / 2) - (bonus_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y + bonus_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Height / 2);
                    if (Math.Abs(delta_64_Thu.X) <= transform_64_Thu.size_64_Thu.Width / 2 + bonus_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2)
                    {
                        if (Math.Abs(delta_64_Thu.Y) <= transform_64_Thu.size_64_Thu.Height / 2 + bonus_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Height / 2)
                        {
                            if (bonus_64_Thu.type_64_Thu == 1 && !usedBonus_64_Thu)
                            {
                                usedBonus_64_Thu = true;
                                soundPlayer_64_Thu = sound_64_Thu.ESound2_64_Thu;
                                soundPlayer_64_Thu.Play();
                                AddForce_64_Thu(-40);
                            }
                            if (bonus_64_Thu.type_64_Thu == 2 && !usedBonus_64_Thu)
                            {
                                usedBonus_64_Thu = true;
                                soundPlayer_64_Thu = sound_64_Thu.ESound3_64_Thu;
                                soundPlayer_64_Thu.Play();
                                AddForce_64_Thu(-80);
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool StandartCollide_64_Thu()
        {
            for (int i = 0; i < PlatformController_64_Thu.bullets_64_Thu.Count; i++)
            {
                var bullet_64_Thu = PlatformController_64_Thu.bullets_64_Thu[i];
                PointF delta_64_Thu = new PointF();
                delta_64_Thu.X = (transform_64_Thu.position_64_Thu.X + transform_64_Thu.size_64_Thu.Width / 2) - (bullet_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.X + bullet_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2);
                delta_64_Thu.Y = (transform_64_Thu.position_64_Thu.Y + transform_64_Thu.size_64_Thu.Height / 2) - (bullet_64_Thu.physics_64_Thu.transform_64_Thu.position_64_Thu.Y + bullet_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Height / 2);
                if (Math.Abs(delta_64_Thu.X) <= transform_64_Thu.size_64_Thu.Width / 2 + bullet_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Width / 2)
                {
                    if (Math.Abs(delta_64_Thu.Y) <= transform_64_Thu.size_64_Thu.Height / 2 + bullet_64_Thu.physics_64_Thu.transform_64_Thu.size_64_Thu.Height / 2)
                    {
                        PlatformController_64_Thu.score_64_Thu += 20;
                        PlatformController_64_Thu.RemoveBullet(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public void Collide_64_Thu()
        {
            for (int i = 0; i < PlatformController_64_Thu.platforms_64_Thu.Count; i++)
            {
                var platform_64_Thu = PlatformController_64_Thu.platforms_64_Thu[i];
                if (transform_64_Thu.position_64_Thu.X + transform_64_Thu.size_64_Thu.Width / 2 >= platform_64_Thu.transform_64_Thu.position_64_Thu.X && transform_64_Thu.position_64_Thu.X + transform_64_Thu.size_64_Thu.Width / 2 <= platform_64_Thu.transform_64_Thu.position_64_Thu.X + platform_64_Thu.transform_64_Thu.size_64_Thu.Width)
                {
                    if (transform_64_Thu.position_64_Thu.Y + transform_64_Thu.size_64_Thu.Height >= platform_64_Thu.transform_64_Thu.position_64_Thu.Y && transform_64_Thu.position_64_Thu.Y + transform_64_Thu.size_64_Thu.Height <= platform_64_Thu.transform_64_Thu.position_64_Thu.Y + platform_64_Thu.transform_64_Thu.size_64_Thu.Height)
                    {
                        if (gravity_64_Thu > 0)
                        {
                            AddForce_64_Thu();
                            soundPlayer_64_Thu = sound_64_Thu.ESound1_64_Thu;
                            soundPlayer_64_Thu.Play();
                            if (!platform_64_Thu.isTouchedByPlayer_64_Thu)
                            {
                                PlatformController_64_Thu.score_64_Thu += 20;
                                PlatformController_64_Thu.GenerateRandomPlatform_64_Thu();
                                platform_64_Thu.isTouchedByPlayer_64_Thu = true;
                            }
                        }
                    }
                }
            }
        }

        public void AddForce_64_Thu(int force = -18)
        {
            gravity_64_Thu = force;
        }
    }
}
