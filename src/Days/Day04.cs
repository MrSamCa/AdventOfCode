using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day04 : IDay
    {
        private readonly List<string> _lstInputs;

        public Day04()
        {
            _lstInputs = InputGetter.GetAllLinesString($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            List<Dictionary<string, string>> lstAllPassports = GetAllPassports();

            int nbValidPassports = 0;

            foreach (var passport in lstAllPassports)
            {
                bool valid = true;
                if (!passport.ContainsKey("byr") ||
                    !passport.ContainsKey("iyr") ||
                    !passport.ContainsKey("eyr") ||
                    !passport.ContainsKey("hgt") ||
                    !passport.ContainsKey("hcl") ||
                    !passport.ContainsKey("ecl") ||
                    !passport.ContainsKey("pid"))
                {
                    valid = false;
                }
                if (valid)
                {
                    nbValidPassports++;
                }
            }

            return $"There are {nbValidPassports} valid passports";
        }

        public string ExecutePartTwo()
        {
            List<Dictionary<string, string>> lstAllPassports = GetAllPassports();

            int nbValidPassports = 0;

            foreach (var passport in lstAllPassports)
            {
                bool valid = true;
                foreach (var item in passport)
                {
                    switch (item.Key)
                    {
                        case "byr":
                        case "iyr":
                        case "eyr":
                        case "hgt":
                        case "hcl":
                        case "ecl":
                        case "pid":

                        default:
                            break;
                    }
                }

                if (!passport.ContainsKey("byr") ||
                    !passport.ContainsKey("iyr") ||
                    !passport.ContainsKey("eyr") ||
                    !passport.ContainsKey("hgt") ||
                    !passport.ContainsKey("hcl") ||
                    !passport.ContainsKey("ecl") ||
                    !passport.ContainsKey("pid"))
                {
                    valid = false;
                }
                if (valid)
                {
                    nbValidPassports++;
                }
            }

            return $"There are {nbValidPassports} valid passports";
        }

        private List<Dictionary<string, string>> GetAllPassports()
        {
            List<Dictionary<string, string>> lstAllPassports = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
            };
            int nbElements = 0;

            foreach (var line in _lstInputs)
            {
                if (line.Trim() == string.Empty)
                {
                    nbElements++;
                    lstAllPassports.Add(new Dictionary<string, string>());
                }
                else
                {
                    string[] passportsInputs = line.Split(' ');
                    foreach (string passportinput in passportsInputs)
                    {
                        string[] splitPassport = passportinput.Split(':');
                        var test = new Dictionary<string, string>();

                        lstAllPassports[nbElements].Add(splitPassport[0], splitPassport[1]);
                    }
                }
            }
            return lstAllPassports;
        }
    }
}
