using Core;

namespace _2022
{
    internal class Day06 : Day<int>
    {
        public Day06() : base(2022, "day06")
        {
        }

        public override int PartOne()
        {
            var index = 4;
            
            foreach(var window in InputFile.SlidingWindow(4))
            {
                if(window.Distinct().Count() == 4)
                {
                    return index;
                }
                index++;
            }
            return index;
        }

        public override int PartTwo()
        {
            var index = 14;

            foreach (var window in InputFile.SlidingWindow(14))
            {
                if (window.Distinct().Count() == 14)
                {
                    return index;
                }
                index++;
            }
            return index;
        }
    }
}
