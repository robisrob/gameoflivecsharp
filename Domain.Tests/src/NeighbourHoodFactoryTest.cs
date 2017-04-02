using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace GameOfLife.Domain.NeighbourHood
{
    public class NeighbourhoodFactoryTest
    {

        private NeighbourHoodFactory neighbourHoodFactory;

        public NeighbourhoodFactoryTest()
        {
            neighbourHoodFactory = new NeighbourHoodFactory(new List<List<Cel>>{
                new List<Cel>{Cel.Alive, Cel.Dead, Cel.Alive},
                new List<Cel>{Cel.Dead, Cel.Alive, Cel.Dead},
                new List<Cel>{Cel.Alive, Cel.Dead, Cel.Alive}
            });
        }

        [Fact]
        public void GivenLocation00_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(0, 0)).GetAmountOfLivingNeigbours().Should().Be(1);
        }

        [Fact]
        public void GivenLocation01_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(0, 1)).GetAmountOfLivingNeigbours().Should().Be(3);
        }

        [Fact]
        public void GivenLocation02_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(0, 2)).GetAmountOfLivingNeigbours().Should().Be(1);
        }

        [Fact]
        public void GivenLocation10_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(1, 0)).GetAmountOfLivingNeigbours().Should().Be(3);
        }

        [Fact]
        public void GivenLocation11_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(1, 1)).GetAmountOfLivingNeigbours().Should().Be(4);
        }

        [Fact]
        public void GivenLocation12_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(1, 2)).GetAmountOfLivingNeigbours().Should().Be(3);
        }

        [Fact]
        public void GivenLocation20_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(2, 0)).GetAmountOfLivingNeigbours().Should().Be(1);
        }

        [Fact]
        public void GivenLocation21_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(2, 1)).GetAmountOfLivingNeigbours().Should().Be(3);
        }

        [Fact]
        public void GivenLocation22_whenCreatingNeighbourhood_NeigbourhoodWithCorrectAmountOfLivingNeigborsIsCreated()
        {
            neighbourHoodFactory.Create(new Location(2, 2)).GetAmountOfLivingNeigbours().Should().Be(1);
        }
    }
}