namespace GameOfLife
{
    public class Neighbourhood
    {
        private int amountOfNeighbors;

        public Neighbourhood(int amountOfNeighbors)
        {
            this.amountOfNeighbors = amountOfNeighbors;
        }
        
        public int GetAmountOfLivingNeigbours()
        {
            return amountOfNeighbors;
        }
    }
}