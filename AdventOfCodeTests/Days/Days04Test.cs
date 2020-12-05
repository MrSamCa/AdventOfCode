using AdventOfCode.Common;
using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AdventOfCodeTests.Days
{
    [TestClass]
    public class Days04Test
    {
        private Mock<IInputGetter> _inputGetter;

        [TestInitialize]
        public void Initialise()
        {
            _inputGetter = new Mock<IInputGetter>();
        }

        [TestMethod]
        public void allworks()
        {
            List<string> lstInputs = new List<string>()
            {
                "byr:1920 iyr:2010 eyr:2020 hgt:150cm hcl:#000000 ecl:amb pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:193cm hcl:#ffffff ecl:blu pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:59in hcl:#ffffff ecl:brn pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:76in hcl:#ffffff ecl:gry pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:76in hcl:#ffffff ecl:grn pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:76in hcl:#ffffff ecl:hzl pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:76in hcl:#ffffff ecl:oth pid:012345678"
            };
            _inputGetter.Setup(x => x.GetAllLinesString(It.IsAny<string>())).Returns(lstInputs);

            var dayFour = new Day04(_inputGetter.Object);

            string result = dayFour.ExecutePartTwo();

            Assert.AreEqual($"There are 7 valid passports", result);
        }

        [TestMethod]
        public void allFails1()
        {
            List<string> lstInputs = new List<string>()
            {
                "byr:1919 iyr:2010 eyr:2020 hgt:150cm hcl:#000000 ecl:amb pid:012345678",
                "",
                "byr:1919 iyr:2009 eyr:2020 hgt:150cm hcl:#000000 ecl:amb pid:012345678",
                "",
                "byr:1919 iyr:2010 eyr:2019 hgt:150cm hcl:#000000 ecl:amb pid:012345678",
                "",
                "byr:1919 iyr:2010 eyr:2020 hgt:149cm hcl:#000000 ecl:amb pid:012345678",
                "",
                "byr:1919 iyr:2010 eyr:2020 hgt:150cm hcl:#0000000 ecl:amb pid:012345678",
                "",
                "byr:1919 iyr:2010 eyr:2020 hgt:150cm hcl:#000000 ecl:zzz pid:012345678",
                "",
                "byr:1919 iyr:2010 eyr:2020 hgt:150cm hcl:#000000 ecl:amb pid:12345678"
            };
            _inputGetter.Setup(x => x.GetAllLinesString(It.IsAny<string>())).Returns(lstInputs);

            var dayFour = new Day04(_inputGetter.Object);

            string result = dayFour.ExecutePartTwo();

            Assert.AreEqual($"There are 0 valid passports", result);
        }

        [TestMethod]
        public void AllFails2()
        {
            List<string> lstInputs = new List<string>()
            {
                "byr:2003 iyr:2020 eyr:2030 hgt:193cm hcl:#ffffff ecl:blu pid:012345678",
                "",
                "byr:2002 iyr:2021 eyr:2030 hgt:193cm hcl:#ffffff ecl:blu pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2031 hgt:193cm hcl:#ffffff ecl:blu pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:194cm hcl:#ffffff ecl:blu pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:193cm hcl:#fffffg ecl:blu pid:012345678",
                "",
                "byr:2002 iyr:2020 eyr:2030 hgt:193cm hcl:#ffffff ecl:blu pid:0123456789",
            };
            _inputGetter.Setup(x => x.GetAllLinesString(It.IsAny<string>())).Returns(lstInputs);

            var dayFour = new Day04(_inputGetter.Object);

            string result = dayFour.ExecutePartTwo();

            Assert.AreEqual($"There are 0 valid passports", result);
        }
    }
}
