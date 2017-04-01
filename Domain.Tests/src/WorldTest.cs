using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace GameOfLife.Domain
{
    public class WorldTest
    {
        [Fact]
        public void GivenWorld_WhenGetWorld_NewGenerationIsReturned()
        {
            var world = new World(new List<List<Cel>>
                {
                    new List<Cel>{Cel.Alive, Cel.Dead, Cel.Alive},
                    new List<Cel>{Cel.Dead, Cel.Alive, Cel.Dead},
                    new List<Cel>{Cel.Alive, Cel.Dead, Cel.Alive}
                });

            world.Tick();

            world.Cells[0].Should().Equal(Cel.Dead, Cel.Alive, Cel.Dead);
            world.Cells[1].Should().Equal(Cel.Alive, Cel.Dead, Cel.Alive);
            world.Cells[2].Should().Equal(Cel.Dead, Cel.Alive, Cel.Dead);
        }
    }
}
