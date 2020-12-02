using System;
using AdventOfCode.Days;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            IDay dayToExecute = new Day03();

            Console.WriteLine(dayToExecute.ExecutePartOne());
            Console.WriteLine(dayToExecute.ExecutePartTwo());
            Console.ReadKey();
        }
    }
}
