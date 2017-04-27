using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace GameOfLife.Domain.NeighbourHood
{
    public class NeighbourhoodFactoryTest
    {

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 3)]
        [InlineData(0, 2, 1)]
        [InlineData(1, 0, 3)]
        [InlineData(1, 1, 4)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 0, 1)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 2, 1)]
        public void GivenCertainLocation_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated(int rowNumber, int columnNumber, int amountOfLivingNeighbors)
        {
            NeighbourHoodFactory neighbourHoodFactory = new NeighbourHoodFactory(new List<List<Cel>>{
                new List<Cel>{Cel.Alive, Cel.Dead, Cel.Alive},
                new List<Cel>{Cel.Dead, Cel.Alive, Cel.Dead},
                new List<Cel>{Cel.Alive, Cel.Dead, Cel.Alive}
            }, new Location(rowNumber, columnNumber));

            var neighbourhood = neighbourHoodFactory.Create();


            neighbourhood.AmountOfLivingNeigbours.Should().Be(amountOfLivingNeighbors);
        }
    }
}