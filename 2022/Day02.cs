

using Core;

namespace _2022
{
    public class Day02 : Day<int>
    {
        private IEnumerable<string> Rounds;
        public Day02() : base(2022, "day02")
        {
            Rounds = InputLines;
        }

        public override int PartOne()
        {
            var score = 0;

            foreach (var round in Rounds)
            {
                var hands = round.Split(' ');
                var opponent = hands[0];
                var me = hands[1];

                switch (me)
                {
                    case "X":
                        score += 1;
                        break;
                    case "Y":
                        score += 2;
                        break;
                    case "Z":
                        score += 3;
                        break;
                    default:
                        break;
                }

                if(round == "A Y" || round == "B Z" || round == "C X") 
                {
                    // win
                    score += 6;
                }
                else if(round == "A X" || round == "B Y" || round == "C Z")
                {
                    // draw
                    score += 3;
                }

            }
            
            return score;
        }

        public override int PartTwo()
        {
            var score = 0;

            foreach (var round in Rounds)
            {
                var hands = round.Split(' ');
                var opponent = hands[0];
                var me = hands[1];

                switch (me)
                {
                    case "X":
                        // lose
                        switch (opponent)
                        {
                            case "A":
                                score += 3;
                                break; 
                            case "B":
                                score += 1;
                                break;
                            case "C":
                                score += 2;
                                break;
                            default: break;
                        }   
                        break;
                    case "Y":
                        // draw
                        score += 3;
                        switch (opponent)
                        {
                            case "A":
                                score += 1;
                                break;
                            case "B":
                                score += 2;
                                break;
                            case "C":
                                score += 3;
                                break;
                            default: break;
                        }
                        break;
                    case "Z":
                        // win
                        score += 6;
                        switch (opponent)
                        {
                            case "A":
                                score += 2;
                                break;
                            case "B":
                                score += 3;
                                break;
                            case "C":
                                score += 1;
                                break;
                            default: break;
                        }
                        break;
                    default:
                        break;
                }

            }

            return score;
        }
    }
}
