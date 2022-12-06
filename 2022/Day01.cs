

using Core;

namespace _2022
{
    public class Day01 : Day<int>
    {
        private readonly string[] Elfs;
        private readonly IEnumerable<int> Calories;
        public Day01() : base(2022, "day01")
        {
            Elfs = InputFile.Split(Environment.NewLine + Environment.NewLine); 
            Calories = Elfs.Select(x => x.Split(Environment.NewLine).Sum(y => int.Parse(y)));
        }

        public override int PartOne()
        {
            return Calories.Max();
        }

        public override int PartTwo()
        {
            return Calories.OrderByDescending(x => x).Take(3).Sum();
        }
    }
}
