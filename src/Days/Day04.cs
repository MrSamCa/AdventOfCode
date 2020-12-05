using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day04 : IDay
    {
        private readonly List<string> _lstInputs;

        public Day04(IInputGetter inputGetter)
        {
            _lstInputs = inputGetter.GetAllLinesString($"./Inputs/{GetType().Name}.txt").ToList();
        }

        public string ExecutePartOne()
        {
            List<List<KeyValuePair<string, string>>> lstAllPassports = GetAllPassports();

            int nbValidPassports = 0;

            foreach (var passport in lstAllPassports)
            {
                bool valid = true;
                if (!SearchKeyInList(passport, "byr") ||
                    !SearchKeyInList(passport, "iyr") ||
                    !SearchKeyInList(passport, "eyr") ||
                    !SearchKeyInList(passport, "hgt") ||
                    !SearchKeyInList(passport, "hcl") ||
                    !SearchKeyInList(passport, "ecl") ||
                    !SearchKeyInList(passport, "pid"))
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
            List<List<KeyValuePair<string, string>>> lstAllPassports = GetAllPassports();

            int nbValidPassports = 0;

            foreach (var passport in lstAllPassports)
            {
                bool valid = true;

                if (!SearchKeyInList(passport, "byr") ||
                    !SearchKeyInList(passport, "iyr") ||
                    !SearchKeyInList(passport, "eyr") ||
                    !SearchKeyInList(passport, "hgt") ||
                    !SearchKeyInList(passport, "hcl") ||
                    !SearchKeyInList(passport, "ecl") ||
                    !SearchKeyInList(passport, "pid"))
                {
                    valid = false;
                }
                if (valid)
                {
                    foreach (var item in passport)
                    {
                    
                        var value = item.Value;
                        switch (item.Key)
                        {
                            case "byr":
                                int birthYear = int.Parse(value);
                                if (value.Length == 4 && (birthYear < 1920 || birthYear > 2002))
                                {
                                    valid = false;
                                } 
                                break;
                            case "iyr":
                                int issueYear = int.Parse(value);
                                if (value.Length == 4 && (issueYear < 2010 || issueYear > 2020))
                                {
                                    valid = false;
                                }
                                break;
                            case "eyr":
                                int expYear = int.Parse(value);
                                if (value.Length == 4 && (expYear < 2020 || expYear > 2030))
                                {
                                    valid = false;
                                }
                                break;
                            case "hgt":
                                var matchIn = new Regex(@"(((\d*)+)[i][n])").Match(value);
                                var matchCm = new Regex(@"(((\d*)+)[c][m])").Match(value);

                                if ((!matchIn.Success || (matchIn.Success && (int.Parse(matchIn.Groups[2].Value) < 59 || int.Parse(matchIn.Groups[2].Value) > 76))) &&
                                    (!matchCm.Success || (matchCm.Success && (int.Parse(matchCm.Groups[2].Value) < 150 || int.Parse(matchCm.Groups[2].Value) > 193))))
                                {
                                    valid = false;
                                }

                                break;
                            case "hcl":
                                var matchHairColor = new Regex(@"[#][a-f0-9]{6}").Match(value);

                                if (!matchHairColor.Success)
                                {
                                    valid = false;
                                }

                                break;
                            case "ecl":
                                List<string> lstEyeColors = new List<string>()
                                {
                                    "amb",
                                    "blu",
                                    "brn",
                                    "gry",
                                    "grn",
                                    "hzl",
                                    "oth"
                                };

                                if (!lstEyeColors.Contains(value))
                                {
                                    valid = false;
                                }

                                break;
                            case "pid":
                                var matchPassId = new Regex(@"(\b[0-9]{9}$)").Match(value);

                                if (!matchPassId.Success)
                                {
                                    valid = false;
                                }

                                break;
                            default:
                                break;
                        }
                    }

                    if (valid)
                    {
                        nbValidPassports++;
                    }
                }
            }

            return $"There are {nbValidPassports} valid passports";
        }

        private List<List<KeyValuePair<string, string>>> GetAllPassports()
        {
            List<List<KeyValuePair<string, string>>> lstAllPassports = new List<List<KeyValuePair<string, string>>>()
            {
                new List<KeyValuePair<string, string>>()
            };
            int nbElements = 0;

            foreach (var line in _lstInputs)
            {
                if (line.Trim() == string.Empty)
                {
                    nbElements++;
                    lstAllPassports.Add(new List<KeyValuePair<string, string>>());
                }
                else
                {
                    string[] passportsInputs = line.Split(' ');
                    foreach (string passportinput in passportsInputs)
                    {
                        string[] splitPassport = passportinput.Split(':');

                        lstAllPassports[nbElements].Add(new KeyValuePair<string, string>(splitPassport[0], splitPassport[1]));
                    }
                }
            }
            return lstAllPassports;
        }

        private bool SearchKeyInList(List<KeyValuePair<string, string>> lstKeyValues, string key)
        {
            bool result = false;

            foreach (var keyValue in lstKeyValues)
            {
                if (keyValue.Key == key)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
