using System.Collections.Generic;

namespace GameOfLife
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
                    newRow.Add(new CelDeterminator().DetermineNextStatus(_cells[row][column], new NeighbourHoodFactory(_cells).create(new Location(row, column)).GetAmountOfLivingNeigbours()));
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