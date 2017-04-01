using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace GameOfLife
{
    public class GameOfLifeControllerTest
    {
        [Fact]
        public void GivenWorld_WhenGetWorld_NewGenerationIsReturned()
        {
            var newWorld = new GameOfLifeController().GetWorld(
                new List<List<bool>>
                {
                    new List<bool>{true, false, true},
                    new List<bool>{false, true, false},
                    new List<bool>{true, false, true},
                });

            newWorld[0].Should().Equal(false, true, false);
            newWorld[1].Should().Equal(true, false, true);
            newWorld[2].Should().Equal(false, true, false);
        }
    }
}
