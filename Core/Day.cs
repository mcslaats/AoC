using System.Collections.Generic;

namespace Core
{
    public abstract class Day<T>
    {
        protected string InputFile;
        protected IEnumerable<string> InputLines;

        public Day(int year, string fileName)
        {
            InputFile = System.IO.File.ReadAllText($@"C:\Users\carlijn\AoC\AoC\{year}\PuzzleInputs\{fileName}.txt");
            InputLines = System.IO.File.ReadLines($@"C:\Users\carlijn\AoC\AoC\{year}\PuzzleInputs\{fileName}.txt");
        }

        public abstract T PartOne();

        public abstract T PartTwo();
    }
}
