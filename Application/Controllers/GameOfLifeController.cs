using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GameOfLife.Domain;
using System.Linq;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class GameOfLifeController : Controller
    {
        [HttpPost]
        public List<List<bool>> GetWorld([FromBody]List<List<bool>> currentWorld)
        {
            var world = new World(TransformWorldToWorldOfCells(currentWorld));
            world.Tick();
            return TransformWorldToWorldOfBool(world.Cells);       }

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
