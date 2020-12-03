using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day01 : IDay
    {
        private readonly List<int> _lstExpenses;

        public Day01()
        {
            _lstExpenses = InputGetter.GetAllLinesInt($"./Inputs/{GetType().Name}.txt").ToList();
        }
        
        public string ExecutePartOne()
        {
            //int result = 0;
            //int pos = 0;

            //while (result == 0 && pos <= _lstExpenses.Count)
            //{
            //    int searchedValue = 2020 - _lstExpenses[pos];
            //    if (_lstExpenses.Contains(searchedValue))
            //    {
            //        result = searchedValue * _lstExpenses[pos];
            //    }

            //    pos++;
            //}

            var result = (
                    from x in _lstExpenses
                    from y in _lstExpenses
                    where x + y == 2020
                    select x * y
                ).First();

            return $"Day 1 part 1 result : {result}";
        }

        public string ExecutePartTwo()
        {
            //int result = 0;
            //int posFirst = 0;
            //int maxValue = 2020;

            //while (result == 0 && posFirst < _lstExpenses.Count)
            //{
            //    int posSecond = 0;
            //    while (result == 0 && posSecond < _lstExpenses.Count)
            //    {
            //        if (posFirst != posSecond && maxValue - _lstExpenses[posFirst] - _lstExpenses[posSecond] > 0)
            //        {
            //            int posThird = 0;
            //            while (result == 0 && posThird < _lstExpenses.Count)
            //            {
            //                if (posFirst != posThird && posSecond != posThird && maxValue - _lstExpenses[posFirst] - _lstExpenses[posSecond] - _lstExpenses[posThird] == 0)
            //                {
            //                    result = _lstExpenses[posFirst] * _lstExpenses[posSecond] * _lstExpenses[posThird];
            //                }
            //                posThird++;
            //            }
            //        }
            //        posSecond++;
            //    }
            //    posFirst++;
            //}

            var result = (
                    from x in _lstExpenses
                    from y in _lstExpenses
                    from z in _lstExpenses
                    where x + y + z == 2020
                    select x * y * z
                ).First();

            return $"Day 1 part 2 result : {result}";
        }
    }
}
