using Xunit;
using FluentAssertions;
using System;

namespace GameOfLife.Domain.NeighbourHood
{
public class NeighBourHoodTest {

    [Fact]
    public void GivenZeroLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(0).DetermineNextStatus(Cel.Dead).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenZeroLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(0).DetermineNextStatus(Cel.Alive).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenOneLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(1).DetermineNextStatus(Cel.Dead).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenOneLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(1).DetermineNextStatus(Cel.Alive).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenTwoLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(2).DetermineNextStatus(Cel.Dead).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenTwoLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsLiving() {
        new Neighbourhood(2).DetermineNextStatus(Cel.Alive).Should().Be(Cel.Alive);
    }

    [Fact]
    public void GivenThreeLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(3).DetermineNextStatus(Cel.Dead).Should().Be(Cel.Alive);
    }

    [Fact]
    public void GivenThreeLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(3).DetermineNextStatus(Cel.Alive).Should().Be(Cel.Alive);
    }

    [Fact]
    public void GivenFourLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(4).DetermineNextStatus(Cel.Dead).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenFourLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(4).DetermineNextStatus(Cel.Alive).Should().Be(Cel.Dead);
    }

    [Fact]

    public void GivenEightLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(8).DetermineNextStatus(Cel.Dead).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenEightLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new Neighbourhood(8).DetermineNextStatus(Cel.Alive).Should().Be(Cel.Dead);
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