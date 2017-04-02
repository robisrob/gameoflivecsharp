using System.Collections.Generic;
using GameOfLife.Domain.NeighbourHood;

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
            var newCells = new List<List<Cel>>();

            for (int row = 0; row < _cells.Count; row++)
            {
                var newRow = new List<Cel>();
                for (int column = 0; column < _cells[row].Count; column++)
                {
                    newRow.Add(new NeighbourHoodFactory(_cells).Create(new Location(row, column)).DetermineNextStatus(_cells[row][column]));
                }
                newCells.Add(newRow);
            }
            _cells = newCells;
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