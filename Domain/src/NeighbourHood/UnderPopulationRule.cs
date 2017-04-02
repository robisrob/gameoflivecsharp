namespace GameOfLife.Domain.NeighbourHood
{
    public partial class Neighbourhood
    {
        private class UnderPopulationRule : IRule
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
    }
}