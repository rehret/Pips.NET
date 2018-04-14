using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pips.Models
{
    public class D20
    {
        public int NumDice { get; set; }

        public int NumSides { get; set; }

        public D20(string d20string)
        {
            var matches = new Regex(@"^(\d+)d(\d+)$").Match(d20string);
            if (!matches.Success)
            {
                throw new Exception("Invalid d20 syntax");
            }

            var numDice = int.Parse(matches.Groups[1].Value);
            var numSides = int.Parse(matches.Groups[2].Value);

            if (numDice < 1 || numSides < 1)
            {
                throw new Exception("Number of dice and number of sides must both be positive integers");
            }

            NumDice = numDice;
            NumSides = numSides;
        }

        public D20(int numDice, int numSides)
        {
            if (numDice < 1 || numSides < 1)
            {
                throw new Exception("Number of dice and number of sides must both be positive integers");
            }

            NumDice = numDice;
            NumSides = numSides;
        }

        public IEnumerable<int> Rolls 
        {
            get
            {
                var rolls = new List<int>();
                var rollGenerator = new Random();

                for (var i = 0; i < NumDice; i++)
                {
                    rolls.Add(rollGenerator.Next(1, NumSides + 1));
                }

                return rolls;
            }
        }
    }
}
