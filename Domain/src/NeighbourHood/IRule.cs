namespace GameOfLife.Domain.NeighbourHood
{
    internal partial class Neighbourhood
    {
        private interface IRule
        {
            bool Applies(Cel cel, int amountOfLivingNeigbors);

            Cel GetResult(Cel cel);
        }
    }
}