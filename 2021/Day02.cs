using Core;

namespace _2021
{
    public class Day02 : Day<int>
    {

        public Day02() : base(2021, "day02") { 
            
        }
        public override int PartOne()
        {
            int depth = 0;
            int horizontal = 0;

            foreach(string line in InputLines)
            {
                if(line.Contains("up")){
                    depth -= int.Parse(line.Split(" ")[1]);
                }
                if(line.Contains("down"))
                {
                    depth += int.Parse(line.Split(" ")[1]);
                }
                if(line.Contains("forward"))
                {
                    horizontal += int.Parse(line.Split(" ")[1]);
                }
            }

            return depth * horizontal;
        }

        public override int PartTwo()
        {
            int depth = 0;
            int horizontal = 0;
            int aim = 0;

            foreach (string line in InputLines)
            {
                if (line.Contains("up"))
                {
                    aim -= int.Parse(line.Split(" ")[1]);
                }
                if (line.Contains("down"))
                {
                    aim += int.Parse(line.Split(" ")[1]);
                }
                if (line.Contains("forward"))
                {
                    int x = int.Parse(line.Split(" ")[1]);
                    horizontal += x;
                    depth += (aim * x);
                }
            }

            return depth * horizontal;
        }
    }
}
