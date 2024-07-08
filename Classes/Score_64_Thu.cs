using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Score_64_Thu
    {
        public static List<int> scores_64_Thu = new List<int>();
        private const string fileName_64_Thu = "High_Score.txt";

        public static void SaveHighScore_64_Thu(string playerName_64_Thu, int score_64_Thu)
        {
            string newLine_64_Thu;
            bool playerExists_64_Thu = false;

            if (!File.Exists(fileName_64_Thu))
            {
                using (StreamWriter streamWriter_64_Thu = File.CreateText(fileName_64_Thu))
                {

                }
            }

            string[] lines_64_Thu = File.ReadAllLines(fileName_64_Thu);
            List<string> playerSort_64_Thu = new List<string>();
            for (int i = 0; i < lines_64_Thu.Length; i++)
            {
                if (lines_64_Thu[i].Contains(playerName_64_Thu))
                {
                    playerSort_64_Thu.Add(lines_64_Thu[i]);
                }
            }

            int prevScore_64_Thu = 0;

            if(playerSort_64_Thu.Count > 1)
            {
                prevScore_64_Thu = PlayerHighestScore_64_Thu(playerSort_64_Thu);
            }

            for (int i = 0; i < lines_64_Thu.Length; i++)
            {
                if (lines_64_Thu[i].Contains(playerName_64_Thu))
                {
                    playerExists_64_Thu = true;
                    if (i < scores_64_Thu.Count && prevScore_64_Thu >= score_64_Thu)
                    {
                        lines_64_Thu[i] = null;
                        newLine_64_Thu = $"{playerName_64_Thu}: {prevScore_64_Thu}";
                        lines_64_Thu[i] = newLine_64_Thu;
                        break;
                    }
                    else
                    {
                        lines_64_Thu[i] = null;
                        newLine_64_Thu = $"{playerName_64_Thu}: {score_64_Thu}";
                        lines_64_Thu[i] = newLine_64_Thu;
                        break;
                    }
                }
            }

            if(!playerExists_64_Thu)
            {
                Array.Resize(ref lines_64_Thu, lines_64_Thu.Length + 1);
                lines_64_Thu[lines_64_Thu.Length - 1] = $"{playerName_64_Thu}: {score_64_Thu}";
            }

            File.WriteAllLines(fileName_64_Thu, lines_64_Thu);
        }

        public static int PlayerHighestScore_64_Thu(List<string> playerSort_64_Thu)
        {
            int n_64_Thu = playerSort_64_Thu.Count;
            List<int> s_64_Thu = new List<int>();

            for(int i = 0; i < n_64_Thu; i++)
            {
                s_64_Thu.Add(int.Parse(playerSort_64_Thu[i].Split(':')[1].Trim()));
            }

            for (int i = 1; i < n_64_Thu; i++)
            {
                int key_64_Thu = s_64_Thu[i];
                int j = i - 1;
                int temp = s_64_Thu[i];
                while (j >= 0 && s_64_Thu[j] < key_64_Thu)
                {
                    s_64_Thu[j + 1] = s_64_Thu[j];
                    j--;
                }
                s_64_Thu[j + 1] = temp;
            }

            int maxScore = s_64_Thu[0];
            return maxScore;
        }

        public static void ScoreSort_64_Thu()
        {
            string[] lines_64_Thu = File.ReadAllLines(fileName_64_Thu);
            int n_64_Thu = lines_64_Thu.Length;

            for (int i = 1; i < n_64_Thu; i++)
            {
                int key_64_Thu = int.Parse(lines_64_Thu[i].Split(':')[1].Trim());
                int j = i - 1;
                string temp = lines_64_Thu[i];
                while (j >= 0 && int.Parse(lines_64_Thu[j].Split(':')[1].Trim()) < key_64_Thu)
                {
                    lines_64_Thu[j + 1] = lines_64_Thu[j];
                    j--;
                }
                lines_64_Thu[j + 1] = temp;
            }

            File.WriteAllLines(fileName_64_Thu, lines_64_Thu);
        }
    }
}
