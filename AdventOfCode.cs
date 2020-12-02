using AdventOfCode.Common;
using AdventOfCode.Days;
using System;

namespace AdventOfCode
{
    public class AdventOfCode
    {
        public void Execute()
        {
            IDay dayToExecute = new Day02();

            Console.WriteLine(dayToExecute.ExecutePartOne());
            Console.WriteLine(dayToExecute.ExecutePartTwo());
            Console.ReadKey();
        }
    }
}
