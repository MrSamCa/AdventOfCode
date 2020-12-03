using AdventOfCode.Common;
using AdventOfCode.Days;
using System;

namespace AdventOfCode
{
    public class AdventOfCode
    {
        public void Execute()
        {
            IDay dayToExecute = new Day03();

            Console.WriteLine(dayToExecute.ExecutePartOne());
            Console.WriteLine(dayToExecute.ExecutePartTwo());
            Console.ReadKey();
        }
    }
}
