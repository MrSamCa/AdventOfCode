using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day03 : IDay
    {
        private readonly List<char[]> _lstInputs;

        public Day03(IInputGetter inputGetter)
        {
            _lstInputs = inputGetter.GetAllLinesCharArray($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            int column = 3;
            int line = 1;
            int nbTrees = 0;

            while(line < _lstInputs.Count)
            {
                if (column >= _lstInputs[line].Length)
                {
                    column -= _lstInputs[line].Length;
                }

                if (_lstInputs[line][column] == '#')
                {
                    nbTrees++;
                }

                column += 3;
                line++;
            }

            return $"Day 3 part 1 result : {nbTrees}";
        }

        public string ExecutePartTwo()
        {
            int moveOneOne = SlideTobogan(1, 1);
            int moveThreeOne = SlideTobogan(3, 1);
            int moveFiveOne = SlideTobogan(5, 1);
            int moveSevenOne = SlideTobogan(7, 1);
            int moveOneTwo = SlideTobogan(1, 2);

            Console.WriteLine($"moveOneOne : {moveOneOne}");
            Console.WriteLine($"moveThreeOne : {moveThreeOne}");
            Console.WriteLine($"moveFiveOne : {moveFiveOne}");
            Console.WriteLine($"moveSevenOne : {moveSevenOne}");
            Console.WriteLine($"moveOneTwo : {moveOneTwo}");

            return $"Day 3 part 2 result : {moveOneOne * moveThreeOne * moveFiveOne * moveSevenOne * moveOneTwo}";
        }

        private int SlideTobogan(int moveRight, int moveDown)
        {
            int column = moveRight;
            int line = moveDown;
            int nbTrees = 0;

            while (line < _lstInputs.Count)
            {
                if (column >= _lstInputs[line].Length)
                {
                    column -= _lstInputs[line].Length;
                }

                if (_lstInputs[line][column] == '#')
                {
                    nbTrees++;
                }

                column += moveRight;
                line += moveDown;
            }

            return nbTrees;
        }
    }
}
