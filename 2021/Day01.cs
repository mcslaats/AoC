using Core;
using System.Collections.Generic;
using System.Linq;

namespace _2021
{
    public class Day01 : Day<int>
    {
        private IEnumerable<int> Measurements;

        public Day01() : base(2021, "day01")
        {
            Measurements = InputLines.Select(measurement => int.Parse(measurement));
        }

        public override int PartOne()
        {
            return Measurements
                .SlidingWindow(2)
                .Count(window => window.Last() > window.First());
        }

        public override int PartTwo()
        {
            int? prevSum = null;
            int count = 0;
            foreach(var window in Measurements.SlidingWindow(3))
            {
                int sum = window.Aggregate(0, (curr, next) => curr + next);

                if (!prevSum.HasValue)
                {
                    prevSum = sum;
                }
                else if(sum > prevSum)
                {
                    count++;
                }
                prevSum = sum;
            }
            
            return count;
        }
    }
}
