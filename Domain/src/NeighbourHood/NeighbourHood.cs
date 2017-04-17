using System.Collections.Generic;
using System.Linq;
using System;

namespace GameOfLife.Domain.NeighbourHood
{
    internal partial class Neighbourhood
    {
        private readonly IEnumerable<IRule> rules;


        public Neighbourhood(int amountOfLivingNeighbors)
        {
            ValidateAmountOfLivingNeigbors(amountOfLivingNeighbors);
            AmountOfLivingNeigbours = amountOfLivingNeighbors;
            rules = new List<IRule> { new OverPopulationRule(), new UnderPopulationRule(), new SustenanceRule(), new ReproductionRule() };
        }

        public int AmountOfLivingNeigbours {get; }

        public Cel DetermineNewGeneration(Cel cel) 
            => rules.Where(rule => rule.Applies(cel, AmountOfLivingNeigbours)).First().GetResult(cel);

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