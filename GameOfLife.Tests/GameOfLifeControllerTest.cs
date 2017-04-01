using System;
using Xunit;
using GameOfLife;

namespace GameOfLife.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GameOfLifeControllerTest()
        {
            new GameOfLifeController().GetWorld(null);
        }
    }
}
