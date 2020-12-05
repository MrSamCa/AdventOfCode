using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class DayModel : IDay
    {
        private readonly List<string> _lstInputs;

        public DayModel(IInputGetter inputGetter)
        {
            _lstInputs = inputGetter.GetAllLinesString($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            return string.Empty;
        }

        public string ExecutePartTwo()
        {
            return string.Empty;
        }
    }
}
