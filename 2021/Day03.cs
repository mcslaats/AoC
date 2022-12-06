using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2021
{
    public class Day03 : Day<int>
    {
        private IEnumerable<string> Binaries;
        public Day03() : base(2021, "day03") {
            Binaries = InputLines;       
        }
        public override int PartOne()
        {
            string gamma = "";
            string epsilon= "";

            for(int i= 0; i < 12; i++)
            {
                gamma += Binaries.GetMostAccuringAtIndex(i, 1, "1", "0", null);
                epsilon += Binaries.GetLeastAccuringAtIndex(i, 1, "1", "0", null);
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        public override int PartTwo()
        {
            var leftoverBinariesOxygen = Binaries;
            var leftoverBinariesCo2 = Binaries;

            for(int i = 0; i < 12; i++)
            {
                if (leftoverBinariesOxygen.Count() > 1)
                {
                    string mostOccuring = Binaries.GetMostAccuringAtIndex(i, 1, "1", "0", "1");
                    leftoverBinariesOxygen = leftoverBinariesOxygen.Where(binary => binary.Substring(i, 1) == mostOccuring).ToList();
                }
                if (leftoverBinariesCo2.Count() > 1)
                {
                    string leastOccuring = Binaries.GetLeastAccuringAtIndex(i, 1, "1", "0", "0");
                    leftoverBinariesCo2 = leftoverBinariesCo2.Where(binary => binary.Substring(i, 1) == leastOccuring).ToList();
                }
            }
            string oxygen = leftoverBinariesOxygen.First();
            string co2 = leftoverBinariesCo2.First();

            return Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2);
        }
    }
}
