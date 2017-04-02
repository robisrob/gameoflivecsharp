namespace GameOfLife.Domain.NeighbourHood
{
    public partial class Neighbourhood
    {
        private class ReproductionRule : IRule
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
    }
}