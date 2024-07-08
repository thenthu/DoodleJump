using System;
using System.Collections.Generic;
using System.Drawing;

namespace DoodleJump.Classes
{
    public static class PlatformController_64_Thu
    {
        public static List<Platform_64_Thu> platforms_64_Thu;
        public static List<Bullet_64_Thu> bullets_64_Thu = new List<Bullet_64_Thu>();
        public static List<Enemy_64_Thu> enemies_64_Thu = new List<Enemy_64_Thu>();
        public static List<Bonus_64_Thu> bonuses_64_Thu = new List<Bonus_64_Thu>();
        public static int startPlatformPosY_64_Thu = 400;
        public static int score_64_Thu = 0;

        public static void AddPlatform_64_Thu(PointF position_64_Thu)
        {
            Platform_64_Thu platform_64_Thu = new Platform_64_Thu(position_64_Thu);
            platforms_64_Thu.Add(platform_64_Thu);
        }

        public static void CreateBullet_64_Thu(PointF pos_64_Thu)
        {
            var bullet_64_Thu = new Bullet_64_Thu(pos_64_Thu);
            bullets_64_Thu.Add(bullet_64_Thu);
        }

        public static void GenerateStartSequence_64_Thu()
        {
            Random rand_64_Thu = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x_64_Thu = rand_64_Thu.Next(0, 370);
                int y_64_Thu = rand_64_Thu.Next(50, 60);
                startPlatformPosY_64_Thu -= y_64_Thu;
                PointF position_64_Thu = new PointF(x_64_Thu, startPlatformPosY_64_Thu);
                Platform_64_Thu platform_64_Thu = new Platform_64_Thu(position_64_Thu);
                platforms_64_Thu.Add(platform_64_Thu);
            }
        }

        public static void GenerateRandomPlatform_64_Thu()
        {
            ClearPlatforms_64_Thu();

            Random rand_64_Thu = new Random();

            // Tạo biến tạm để lưu trữ giá trị Y của platform trước đó
            int prevPlatformY = startPlatformPosY_64_Thu;

            // Tạo platform ngẫu nhiên
            int numPlatforms_64_Thu = rand_64_Thu.Next(1, 5); // Số lượng platform được tạo ngẫu nhiên từ 1 đến 4
            for (int i = 0; i < numPlatforms_64_Thu; i++)
            {
                int y_64_Thu = prevPlatformY - rand_64_Thu.Next(50, 60); // Tạo ngẫu nhiên vị trí Y cho platform
                PointF position_64_Thu = new PointF(rand_64_Thu.Next(0, 370), y_64_Thu);
                Platform_64_Thu platform_64_Thu = new Platform_64_Thu(position_64_Thu);
                platforms_64_Thu.Add(platform_64_Thu);

                // Cập nhật giá trị Y của platform trước đó
                prevPlatformY = y_64_Thu;

                int chance_64_Thu = rand_64_Thu.Next(1, 10);
                if (chance_64_Thu == 1)
                {
                    if (rand_64_Thu.Next(2) == 0)
                    {
                        CreateEnemy_64_Thu(platform_64_Thu);
                    }
                    else
                    {
                        CreateBonus_64_Thu(platform_64_Thu);
                    }
                }
            }
        }

        public static void CreateBonus_64_Thu(Platform_64_Thu platform)
        {
            Random r = new Random();
            var bonusType = r.Next(1, 3);

            switch (bonusType)
            {
                case 1:
                    var bonus = new Bonus_64_Thu(new PointF(platform.transform_64_Thu.position_64_Thu.X + (platform.sizeX_64_Thu / 2) - 17, platform.transform_64_Thu.position_64_Thu.Y - 25), bonusType);
                    bonuses_64_Thu.Add(bonus);
                    break;
                case 2:
                    bonus = new Bonus_64_Thu(new PointF(platform.transform_64_Thu.position_64_Thu.X + (platform.sizeX_64_Thu / 2) - 15, platform.transform_64_Thu.position_64_Thu.Y - 30), bonusType);
                    bonuses_64_Thu.Add(bonus);
                    break;
            }
        }

        public static void CreateEnemy_64_Thu(Platform_64_Thu platform)
        {
            Random r = new Random();
            var enemyType = r.Next(1, 4);

            switch (enemyType)
            {
                case 1:
                    var enemy = new Enemy_64_Thu(new PointF(platform.transform_64_Thu.position_64_Thu.X + (platform.sizeX_64_Thu / 2) - 30, platform.transform_64_Thu.position_64_Thu.Y - 40), enemyType);
                    enemies_64_Thu.Add(enemy);
                    break;
                case 2:
                    enemy = new Enemy_64_Thu(new PointF(platform.transform_64_Thu.position_64_Thu.X + (platform.sizeX_64_Thu / 2) - 35, platform.transform_64_Thu.position_64_Thu.Y - 50), enemyType);
                    enemies_64_Thu.Add(enemy);
                    break;
                case 3:
                    enemy = new Enemy_64_Thu(new PointF(platform.transform_64_Thu.position_64_Thu.X + (platform.sizeX_64_Thu / 2) - 35, platform.transform_64_Thu.position_64_Thu.Y - 60), enemyType);
                    enemies_64_Thu.Add(enemy);
                    break;

            }
        }

        public static void RemoveEnemy(int i)
        {
            enemies_64_Thu.RemoveAt(i);
        }

        public static void RemoveBullet(int i)
        {
            bullets_64_Thu.RemoveAt(i);
        }

        public static void ClearPlatforms_64_Thu()
        {
            for (int i = 0; i < platforms_64_Thu.Count; i++)
            {
                if (platforms_64_Thu[i].transform_64_Thu.position_64_Thu.Y >= 700)
                    platforms_64_Thu.RemoveAt(i);
            }
            for (int i = 0; i < bonuses_64_Thu.Count; i++)
            {
                if (bonuses_64_Thu[i].physics_64_Thu.transform_64_Thu.position_64_Thu.Y >= 700)
                    bonuses_64_Thu.RemoveAt(i);
            }

            for (int i = 0; i < enemies_64_Thu.Count; i++)
            {
                if (enemies_64_Thu[i].physics_64_Thu.transform_64_Thu.position_64_Thu.Y >= 700)
                    enemies_64_Thu.RemoveAt(i);
            }
        }
    }
}
