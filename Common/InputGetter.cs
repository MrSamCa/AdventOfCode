using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Common
{
    public class InputGetter
    {
        public IEnumerable<string> GetAllLinesString(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            List<string> lstInput = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                lstInput.Add(line);
            }

            return lstInput;
        }


        public IEnumerable<int> GetAllLinesInt(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            List<int> lstInput = new List<int>();

            while ((line = reader.ReadLine()) != null)
            {
                lstInput.Add(int.Parse(line));
            }

            return lstInput;
        }
    }
}
