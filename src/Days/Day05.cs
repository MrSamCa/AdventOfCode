using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day05 : IDay
    {
        private readonly List<char[]> _lstInputs;

        public Day05(IInputGetter inputGetter)
        {
            _lstInputs = inputGetter.GetAllLinesCharArray($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            return $"Highest id : {ObtainListId().Last()}";
        }

        public string ExecutePartTwo()
        {
            List<decimal> lstId = ObtainListId();
            decimal result = 0;
            for (decimal value = lstId.First(); value < lstId.Last(); value++)
            {
                if (lstId.Contains(value - 1) && lstId.Contains(value + 1) && !lstId.Contains(value))
                {
                    result = value;
                }
            }

            return $"My seat id : {result}";
        }

        private List<decimal> ObtainListId()
        {
            List<decimal> lstId = new List<decimal>();

            foreach (var lstChars in _lstInputs)
            {
                decimal maxRow = 127;
                decimal minRow = 0;
                decimal maxCol = 7;
                decimal minCol = 0;

                decimal finalRow = 0;
                decimal finalCol = 0;

                for (int i = 0; i < lstChars.Length; i++)
                {
                    if (i == 6)
                    {
                        if (lstChars[i] == 'F')
                        {
                            finalRow = minRow;
                        }
                        else if (lstChars[i] == 'B')
                        {
                            finalRow = maxRow;
                        }
                    }
                    else if (i == 9)
                    {
                        if (lstChars[i] == 'R')
                        {
                            finalCol = maxCol;
                        }
                        else if (lstChars[i] == 'L')
                        {
                            finalCol = minCol;
                        }
                    }
                    else
                    {
                        if (lstChars[i] == 'F')
                        {
                            maxRow -= Math.Round((maxRow - minRow) / 2);
                        }
                        else if (lstChars[i] == 'B')
                        {
                            minRow += Math.Round((maxRow - minRow) / 2);
                        }
                        else if (lstChars[i] == 'L')
                        {
                            maxCol -= Math.Round((maxCol - minCol) / 2);
                        }
                        else if (lstChars[i] == 'R')
                        {
                            minCol += Math.Round((maxCol - minCol) / 2);
                        }
                    }
                }
                lstId.Add(finalRow * 8 + finalCol);
            }
            lstId.Sort();
            return lstId;
        }
    }
}
