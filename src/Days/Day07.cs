﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day07 : IDay
    {
        private readonly List<string> _lstInputs;

        public Day07(IInputGetter inputGetter)
        {
            _lstInputs = inputGetter.GetAllLinesString($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            foreach (var bagRule in _lstInputs)
            {
                string[] splitBagRule = bagRule.Split("bags contain");

            }
            return string.Empty;
        }

        public string ExecutePartTwo()
        {
            return string.Empty;
        }
    }
}
