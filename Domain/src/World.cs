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
            => Cells = Cells.Select((cellRow, rowNumber) => DetermineNextGeneration(cellRow, rowNumber)).ToList();

        private List<Cel> DetermineNextGeneration(List<Cel> cellRow, int rowNumber)
        {
            return cellRow
            .Select((cell, columnNumber) => new NeighbourHoodFactory(Cells)
            .Create(new Location(rowNumber, columnNumber))
            .DetermineNewGeneration(cell))
            .ToList();
        }

        public List<List<Cel>> Cells {private set; get;}
    }
}