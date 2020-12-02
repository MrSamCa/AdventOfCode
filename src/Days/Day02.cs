using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day02 : IDay
    {
        private readonly List<string> _lstPasswords;

        public Day02()
        {
            _lstPasswords = InputGetter.GetAllLinesString($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            int nbValidPasswords = 0;

            foreach (string passwordSecurity in _lstPasswords)
            {
                string[] splitPasswordSecurity = passwordSecurity.Split(':');
                string[] splitSecurity1 = splitPasswordSecurity[0].Split(' ');
                string[] splitSecurity2 = splitSecurity1[0].Split('-');
                string password = splitPasswordSecurity[1];
                int minCount = int.Parse(splitSecurity2[0]);
                int maxCount = int.Parse(splitSecurity2[1]);
                string stringToFind = splitSecurity1[1];

                int count = password.Count(x => x == stringToFind.ToCharArray()[0]);

                if (count >= minCount && count <= maxCount)
                {
                    nbValidPasswords++;
                }

            }
            return $"There are {nbValidPasswords} valid passwords";
        }

        public string ExecutePartTwo()
        {
            int nbValidPasswords = 0;

            foreach (string passwordSecurity in _lstPasswords)
            {
                string[] splitPasswordSecurity = passwordSecurity.Split(':');
                string[] splitSecurity1 = splitPasswordSecurity[0].Split(' ');
                string[] splitSecurity2 = splitSecurity1[0].Split('-');
                string password = splitPasswordSecurity[1].Trim();
                int firstPos = int.Parse(splitSecurity2[0]);
                int secondPos = int.Parse(splitSecurity2[1]);
                char charToFind = splitSecurity1[1].ToCharArray()[0];

                char[] lstChars = password.ToCharArray();

                int nbPresence = 0;

                if (lstChars.Length >= firstPos - 1)
                {
                    if (firstPos - 1 >= 0 && lstChars[firstPos - 1] == charToFind)
                    {
                        nbPresence++;
                    }
                }

                if (lstChars.Length >= secondPos - 1)
                {
                    if (secondPos - 1 >= 0 && lstChars[secondPos - 1] == charToFind)
                    {
                        nbPresence++;
                    }
                }

                if (nbPresence == 1)
                {
                    nbValidPasswords++;
                }

            }
            return $"There are {nbValidPasswords} valid passwords";
        }
    }
}
