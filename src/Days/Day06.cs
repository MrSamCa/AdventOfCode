using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day06 : IDay
    {
        private readonly List<char[]> _lstInputs;

        public Day06(IInputGetter inputGetter)
        {
            _lstInputs = inputGetter.GetAllLinesCharArray($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            List<char> lstYesAnswers = new List<char>();
            List<int> lstNbAnswers = new List<int>();

            foreach (var personAnswers in _lstInputs)
            {
                if (personAnswers.Length == 0)
                {
                    lstNbAnswers.Add(lstYesAnswers.Count);
                    lstYesAnswers = new List<char>();
                }
                else
                {
                    foreach (var answer in personAnswers)
                    {
                        if (!lstYesAnswers.Contains(answer))
                        {
                            lstYesAnswers.Add(answer);
                        }
                    }
                }
            }

            lstNbAnswers.Add(lstYesAnswers.Count);

            return $"Day 6 part 1 answer : {lstNbAnswers.Sum()}";
        }

        public string ExecutePartTwo()
        {
            List<char[]> lstAnswers = new List<char[]>();
            List<int> lstNbAnswers = new List<int>();

            foreach (var personAnswers in _lstInputs)
            {
                if (personAnswers.Length == 0)
                {
                    lstNbAnswers.Add(CalculateNbAnswers(lstAnswers));
                    lstAnswers = new List<char[]>();
                }
                else
                {
                    lstAnswers.Add(personAnswers);
                }
            }

            lstNbAnswers.Add(CalculateNbAnswers(lstAnswers));

            return $"Day 6 part 1 answer : {lstNbAnswers.Sum()}";
        }

        private int CalculateNbAnswers(List<char[]> lstAnswers)
        {
            int nbAnswers = 0;
            foreach (var item in lstAnswers[0])
            {
                if (lstAnswers.All(x => x.Contains(item)))
                {
                    nbAnswers++;
                }
            }

            return nbAnswers;
        }
    }
}
