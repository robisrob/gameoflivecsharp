using Xunit;
using FluentAssertions;
using GameOfLife;
using System;

namespace GameOfLife
{
public class CelDeterminatorTest {

    [Fact]
    public void GivenZeroLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Dead, 0).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenZeroLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Alive, 0).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenOneLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Dead, 1).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenOneLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Alive, 1).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenTwoLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Dead, 2).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenTwoLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsLiving() {
        new CelDeterminator().DetermineNextStatus(Cel.Alive, 2).Should().Be(Cel.Alive);
    }

    [Fact]
    public void GivenThreeLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Dead, 3).Should().Be(Cel.Alive);
    }

    [Fact]
    public void GivenThreeLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Alive, 3).Should().Be(Cel.Alive);
    }

    [Fact]
    public void GivenFourLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Dead, 4).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenFourLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Alive, 4).Should().Be(Cel.Dead);
    }

    [Fact]

    public void GivenEightLivingNeighborAndCelIsDead_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Dead, 8).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenEightLivingNeighborAndCelIsLiving_WhenDetermineNextStatus_ThenNextStatusIsDead() {
        new CelDeterminator().DetermineNextStatus(Cel.Alive, 8).Should().Be(Cel.Dead);
    }

    [Fact]
    public void GivenMoreThanEightLivingNeigbors_WhenDetermineNextStatus_ThenExceptionIsThrown() {
        ((Action)(() => new CelDeterminator().DetermineNextStatus(Cel.Dead, 9))).ShouldThrow<ArgumentException>().WithMessage("A cell has only 8 neighbors in total and therefore can't have 9 living neighbors");
    }

    [Fact]
    public void GivenLessThan0tLivingNeigbors_WhenDetermineNextStatus_ThenExceptionIsThrown() {
        ((Action)(() => new CelDeterminator().DetermineNextStatus(Cel.Dead, -1))).ShouldThrow<ArgumentException>().WithMessage("A cell can't have less than 0 living neighbors");
    }
}
}