using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                PasswordInfos passwordInfos = ParseInput(passwordSecurity);

                int count = passwordInfos.Password.Count(x => x == passwordInfos.Char);

                if (count >= passwordInfos.Min && count <= passwordInfos.Max)
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
                PasswordInfos passwordInfos = ParseInput(passwordSecurity);

                char[] lstChars = passwordInfos.Password.ToCharArray();

                if (passwordInfos.Password[passwordInfos.Min - 1] == passwordInfos.Char ^ passwordInfos.Password[passwordInfos.Max - 1] == passwordInfos.Char)
                {
                    nbValidPasswords++;
                }
            }
            return $"There are {nbValidPasswords} valid passwords";
        }

        public PasswordInfos ParseInput(string input)
        {
            var match = new Regex(@"(\d*)-(\d*) (\w): (.*)").Match(input);

            return new PasswordInfos()
            {
                Password = match.Groups[4].Value,
                Char = char.Parse(match.Groups[3].Value),
                Max = int.Parse(match.Groups[2].Value),
                Min = int.Parse(match.Groups[1].Value)
            };
        }
    }

    public class PasswordInfos
    {
        public string Password { get; set; }
        public char Char { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
