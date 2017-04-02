namespace GameOfLife.Domain.NeighbourHood
{
    public partial class Neighbourhood
    {
        private interface IRule
        {
            bool Applies(Cel cel, int amountOfLivingNeigbors);

            Cel GetResult(Cel cel);
        }
    }
}