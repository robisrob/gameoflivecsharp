using System.Collections.Generic;
using System.Linq;
using System;

namespace GameOfLife.Domain
{
    public class CelDeterminator
    {
        private interface Rule
        {
            bool Applies(Cel cel, int amountOfLivingNeigbors);

            Cel GetResult(Cel cel);
        }

        private class UnderPopulation : Rule
        {

            public bool Applies(Cel cel, int amountOfLivingNeigbors)
            {
                return amountOfLivingNeigbors < 2;
            }

            public Cel GetResult(Cel cel)
            {
                return Cel.Dead;
            }
        }

        private class OverPopulation : Rule
        {

            public bool Applies(Cel cel, int amountOfLivingNeigbors)
            {
                return amountOfLivingNeigbors > 3;
            }

            public Cel GetResult(Cel cel)
            {
                return Cel.Dead;
            }
        }

        private class Sustenance : Rule
        {

            public bool Applies(Cel cel, int amountOfLivingNeigbors)
            {
                return amountOfLivingNeigbors == 2;
            }

            public Cel GetResult(Cel cel)
            {
                return cel;
            }
        }

        private class Reproduction : Rule
        {

            public bool Applies(Cel cel, int amountOfLivingNeigbors)
            {
                return amountOfLivingNeigbors == 3;
            }

            public Cel GetResult(Cel cel)
            {
                return Cel.Alive;
            }
        }

        private IEnumerable<Rule> rules = new List<Rule> { new UnderPopulation(), new OverPopulation(), new Reproduction(), new Sustenance() };

        public Cel DetermineNextStatus(Cel cel, int amountOfLivingNeighbors)
        {
            ValidateAmountOfLivingNeigbors(amountOfLivingNeighbors);
            return rules.Where(rule => rule.Applies(cel, amountOfLivingNeighbors)).First().GetResult(cel);
        }

        private void ValidateAmountOfLivingNeigbors(int amountOfLivingNeighbors)
        {
            ValidateAmountOfLivingNeigborsNotGreaterThenEight(amountOfLivingNeighbors);
            ValidateAmountOfLivingNeigborsNotSmallerThenZero(amountOfLivingNeighbors);
        }

        private void ValidateAmountOfLivingNeigborsNotGreaterThenEight(int amountOfLivingNeighbors)
        {
            if (amountOfLivingNeighbors < 0)
            {
                throw new ArgumentException("A cell can't have less than 0 living neighbors");
            }
        }

        private void ValidateAmountOfLivingNeigborsNotSmallerThenZero(int amountOfLivingNeighbors)
        {
            if (amountOfLivingNeighbors > 8)
            {
                throw new ArgumentException("A cell has only 8 neighbors in total and therefore can't have " + amountOfLivingNeighbors + " living neighbors");
            }
        }
    }
}