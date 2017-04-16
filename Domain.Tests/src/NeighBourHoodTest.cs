using Xunit;
using FluentAssertions;
using System;

namespace GameOfLife.Domain.NeighbourHood
{
public class NeighBourHoodTest {

    [Theory]
    [InlineData(0, Cel.Dead)]
    [InlineData(0, Cel.Alive)]
    [InlineData(1, Cel.Dead)]
    [InlineData(1, Cel.Alive)]

    public void GivenLessThenTwoLivingNeigbors_WhenDetermineNewGeneration_ThenNewCelIsDead_DueToUnderPopulation(int livingNeighbors, Cel currentCel) {
        new Neighbourhood(livingNeighbors).DetermineNextStatus(currentCel).Should().Be(Cel.Dead);
    }

    [Theory]
    [InlineData(Cel.Dead)]
    [InlineData(Cel.Alive)]
    public void GivenTwoLivingNeigbors_WhenDetermineNewGeneration_ThenNewCelIsTheSameAsOldCel_DueToSustenance(Cel currentCel) {
        new Neighbourhood(2).DetermineNextStatus(currentCel).Should().Be(currentCel);
    }

    [Theory]
    [InlineData(Cel.Dead)]
    [InlineData(Cel.Alive)]
    public void GivenThreeLivingNeigbors_WhenDetermineNewGeneration_ThenNewCelIsAlive_DueToReproduction(Cel currentCel) {
        new Neighbourhood(3).DetermineNextStatus(currentCel).Should().Be(Cel.Alive);
    }

    [Theory]
    [InlineData(4, Cel.Dead)]
    [InlineData(4, Cel.Alive)]
    [InlineData(5, Cel.Dead)]
    [InlineData(5, Cel.Alive)]
    [InlineData(6, Cel.Dead)]
    [InlineData(6, Cel.Alive)]
    [InlineData(7, Cel.Dead)]
    [InlineData(7, Cel.Alive)]
    [InlineData(8, Cel.Dead)]
    [InlineData(8, Cel.Alive)]
    public void GivenMoreThenThreeLivingNeighbors_WhenDetermineNewGeneration_ThenNewCelDead_DueToOverpopulation(int amountOfLivingNeighbors, Cel currentCel) {
        new Neighbourhood(amountOfLivingNeighbors).DetermineNextStatus(currentCel).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenMoreThanEightLivingNeigbors_WhenDetermineNextStatus_ThenExceptionIsThrown() {
        ((Action)(() => new Neighbourhood(9).DetermineNextStatus(Cel.Dead))).ShouldThrow<ArgumentException>().WithMessage("A cell has only 8 neighbors in total and therefore can't have 9 living neighbors");
    }

    [Fact]
    public void GivenLessThan0tLivingNeigbors_WhenDetermineNextStatus_ThenExceptionIsThrown() {
        ((Action)(() => new Neighbourhood(-1).DetermineNextStatus(Cel.Dead))).ShouldThrow<ArgumentException>().WithMessage("A cell can't have less than 0 living neighbors");
    }
}
}