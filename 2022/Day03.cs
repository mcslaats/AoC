

using Core;

namespace _2022
{
    public class Day03 : Day<int>
    {

        private readonly IEnumerable<string> Rucksacks;
        private readonly char[] Priorities = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public Day03() : base(2022, "day03")
        {
            Rucksacks = InputLines;
        }

        public override int PartOne()
        {
            var total = 0;
            foreach (string sack in Rucksacks)
            {
                var halfway = sack.Length / 2;
                var compartment1 = sack[..halfway].ToCharArray();
                var compartment2 = sack.Substring(halfway, halfway).ToCharArray();

                var item = compartment1.First(item => compartment2.Any(x => x == item));
                total += (Array.IndexOf(Priorities, item) + 1);
            }
            return total;
        }

        public override int PartTwo()
        {
            var total = 0;

            for (int i = 0; i < Rucksacks.Count(); i+=3)
            {
                var sack1 = Rucksacks.ToArray()[i].ToCharArray();
                var sack2 = Rucksacks.ToArray()[i+1].ToCharArray();
                var sack3 = Rucksacks.ToArray()[i+2].ToCharArray();
                var item = sack1.First(item => sack2.Any(x => x == item) && sack3.Any(y => y == item));
                total += (Array.IndexOf(Priorities, item) + 1);
            }

            return total;
        }
    }
}
