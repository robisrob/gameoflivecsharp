using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameOfLife.Application;


namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class GameOfLifeController : Controller
    {
        [HttpPost]
        public List<List<bool>> GetWorld([FromBody]List<List<bool>> currentWorld)
        {
            var a = new List<List<bool>> {new List<bool>{true, false}};
            return new GameOfLife.Application.GameOfLifeController().GetWorld(currentWorld);
       }
    }
}
