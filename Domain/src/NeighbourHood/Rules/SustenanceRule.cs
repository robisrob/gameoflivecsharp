namespace GameOfLife.Domain.NeighbourHood
{
    internal partial class Neighbourhood
    {
        private class SustenanceRule : IRule
        {

            public bool Applies(Cel cel, int amountOfLivingNeigbors) => amountOfLivingNeigbors == 2;

            public Cel GetResult(Cel cel) =>  cel;
        }
    }
}