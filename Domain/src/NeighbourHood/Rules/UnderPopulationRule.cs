namespace GameOfLife.Domain.NeighbourHood
{
    internal partial class Neighbourhood
    {
        private class UnderPopulationRule : IRule
        {
            public bool Applies(Cel cel, int amountOfLivingNeigbors) => amountOfLivingNeigbors < 2;

            public Cel GetResult(Cel cel) => Cel.Dead;
        }
    }
}