using System.Collections.Generic;
using GameOfLife.Domain.NeighbourHood;
using System.Linq;

namespace GameOfLife.Domain
{
    public class World
    {
        private List<List<Cel>> _cells;

        public World(List<List<Cel>> cells)
        {
            _cells = cells;
        }
        public void Tick()
        {
            _cells = _cells.Select((cellRow, rowNumber) => DetermineNextGeneration(cellRow, rowNumber)).ToList();
        }

        private List<Cel> DetermineNextGeneration(List<Cel> cellRow, int rowNumber)
        {
            return cellRow
            .Select((cell, columnNumber) => new NeighbourHoodFactory(_cells)
            .Create(new Location(rowNumber, columnNumber))
            .DetermineNewGeneration(cell))
            .ToList();
        }

        public List<List<Cel>> Cells
        {
            get
            {
                return _cells;
            }
        }
    }
}