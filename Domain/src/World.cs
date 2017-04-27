using System.Collections.Generic;
using GameOfLife.Domain.NeighbourHood;
using System.Linq;

namespace GameOfLife.Domain
{
    public class World
    {
        public World(List<List<Cel>> cells)
        {
            Cells = cells;
        }
        public void Tick()
            => Cells = Cells.Select(DetermineNextGeneration).ToList();

        private List<Cel> DetermineNextGeneration(List<Cel> cellRow, int rowNumber)
        {
            return cellRow
            .Select((cell, columnNumber) => new NeighbourHoodFactory(Cells, new Location(rowNumber, columnNumber))
            .Create()
            .DetermineNewGeneration(cell))
            .ToList();
        }

        public List<List<Cel>> Cells {private set; get;}
    }
}