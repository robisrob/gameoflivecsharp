namespace GameOfLife.Domain.NeighbourHood
{
    public partial class Neighbourhood
    {
        private class SustenanceRule : IRule
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
    }
}