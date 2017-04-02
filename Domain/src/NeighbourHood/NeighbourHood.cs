using System.Collections.Generic;
using System.Linq;
using System;

namespace GameOfLife.Domain.NeighbourHood
{
    internal partial class Neighbourhood
    {
        private readonly IEnumerable<IRule> rules;

        private int _amountOfLivingNeighbors;

        public Neighbourhood(int amountOfLivingNeighbors)
        {
            ValidateAmountOfLivingNeigbors(amountOfLivingNeighbors);
            _amountOfLivingNeighbors = amountOfLivingNeighbors;
            rules = new List<IRule>{new OverPopulationRule(), new UnderPopulationRule(), new SustenanceRule(), new ReproductionRule()};
        }
        
        public int GetAmountOfLivingNeigbours()
        {
            return _amountOfLivingNeighbors;
        }

        public Cel DetermineNextStatus(Cel cel)
        {
            return rules.Where(rule => rule.Applies(cel, _amountOfLivingNeighbors)).First().GetResult(cel);
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