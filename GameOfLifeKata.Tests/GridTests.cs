using System;
using GameOfLifeKata.Core;
using NUnit.Framework;

namespace GameOfLifeKata.Tests
{
    [TestFixture]
    class GridTests
    {
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(new bool[100,100]);
        }

        [Test]
        public void EmptyGridShouldThrowAnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(new bool[0,0]));
        }

        [Test]
        public void OneByOneGridShouldThrowAnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(new bool[1, 1]));
        }

        [Test]
        public void TwoByTwoGridShouldInitializeToTwoByTwo()
        {
            var grid = new Grid(new bool[2, 2]);
            Assert.That(grid.Cells.GetLength(0), Is.EqualTo(2));
            Assert.That(grid.Cells.GetLength(1), Is.EqualTo(2));
        }

        [Test]
        public void GridShouldAllowResuscitation()
        {
            _grid.Resuscitate(1,1);
            Assert.That(_grid.Cells[1,1], Is.True);
        }

        [Test]
        public void GridShouldAllowDecimation()
        {
            _grid.Decimate(1, 1);
            Assert.That(_grid.Cells[1, 1], Is.False);
        }

        [Test]
        public void ClearingGridShouldDecimateAllCells()
        {
            _grid = new Grid(new [,]
                {
                    { true,  false, true,  false, true },
                    { false, true,  false, true,  false }
                });

            _grid.Clear();

            for(var x = 0; x < _grid.Cells.GetLength(0); x++)
                for (var y = 0; y < _grid.Cells.GetLength(1); y++)
                    Assert.That(_grid.Cells[x,y], Is.False);
        }
    }
}
