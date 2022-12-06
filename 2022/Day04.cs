using Core;

namespace _2022
{
    internal class Day04 : Day<int>
    {
        private string[] Pairs;
        public Day04() : base(2022, "day04")
        {
            Pairs = InputFile.Split(Environment.NewLine);
        }

        public override int PartOne()
        {
            var total = 0;
            foreach(var pair in Pairs)
            {
                var elfs = pair.Split(',');

                if (elfs[0].GetStartOfRange('-') <= elfs[1].GetStartOfRange('-') && elfs[0].GetEndOfRange('-') >= elfs[1].GetEndOfRange('-'))
                {
                    total++;
                }
                else if (elfs[1].GetStartOfRange('-') <= elfs[0].GetStartOfRange('-') && elfs[1].GetEndOfRange('-') >= elfs[0].GetEndOfRange('-'))
                {
                    total++;
                }
            }
            return total;
        }

        public override int PartTwo()
        {
            var total = 0;
            foreach (var pair in Pairs)
            {
                var elfs = pair.Split(',');
                var elf1 = Enumerable.Range(elfs[0].GetStartOfRange('-'), (elfs[0].GetEndOfRange('-') - elfs[0].GetStartOfRange('-') + 1));
                var elf2 = Enumerable.Range(elfs[1].GetStartOfRange('-'), (elfs[1].GetEndOfRange('-') - elfs[1].GetStartOfRange('-') + 1));

                if(elf1.Any(x => elf2.Contains(x)))
                {
                    total++;
                };  
            }
            return total;
        }
    }
}
