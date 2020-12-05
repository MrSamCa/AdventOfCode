using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Common
{
    public interface IInputGetter
    {
        IEnumerable<string> GetAllLinesString(string path);
        IEnumerable<char[]> GetAllLinesCharArray(string path);
        IEnumerable<int> GetAllLinesInt(string path);
    }
}
