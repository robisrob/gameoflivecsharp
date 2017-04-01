using System.Collections.Generic;
using System.Linq;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class GameOfLifeController
    {
        public List<List<bool>> GetWorld(List<List<bool>> currentWorld)
        {
            var world = new World(TransformWorldToWorldOfCells(currentWorld));
            world.Tick();
            return TransformWorldToWorldOfBool(world.Cells);
        }

        private List<List<Cel>> TransformWorldToWorldOfCells(List<List<bool>> currentWorld)
        {
            return currentWorld.Select(row => row.Select(b => b ? Cel.Alive : Cel.Dead).ToList()).ToList();
        }

        private List<List<bool>> TransformWorldToWorldOfBool(List<List<Cel>> currentWorld)
        {
            return currentWorld.Select(row => row.Select(cel => cel == Cel.Alive ? true : false).ToList()).ToList();
        }
    }
}
