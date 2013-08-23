using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeKata.Core;
using NUnit.Framework;

namespace GameOfLifeKata.Tests
{
    [TestFixture]
    internal class GameTests
    {
        private Grid _expected;
        private GameOfLife _game;

        [SetUp]
        public void SetUp()
        {
            _game = new GameOfLife();
        }

        [Test]
        public void CellsWithFewerThanTwoNeighboursAreDecimated()
        {
            var testGrid = new Grid(new [,]
                {
                    {false, false, false},
                    {false, true,  false},
                    {false, false, true }
                });

            _expected = new Grid(new [,]
                {
                    {false, false, false},
                    {false, false, false},
                    {false, false, false}
                });

            Assert.AreEqual(_expected.Cells, _game.Play(testGrid).Cells);
        }

        [Test]
        public void CellsWithTwoNeighboursThatAreAliveStayAlive()
        {
            var testGrid = new Grid(new[,]
                {
                    {true,  false, false},
                    {false, true,  false},
                    {false, false, true }
                });

            _expected = new Grid(new[,]
                {
                    {false, false, false},
                    {false, true,  false},
                    {false, false, false}
                });

            Assert.AreEqual(_expected.Cells, _game.Play(testGrid).Cells);
        }

        [Test]
        public void CellsWithThreeNeighborsStayAliveIfAliveOrComeAliveIfDead()
        {
            var testGrid = new Grid(new[,]
                {
                    {true,  false, false},
                    {false, true,  false},
                    {false, true,  true }
                });

            _expected = new Grid(new[,]
                {
                    {false, false, false},
                    {true,  true,  true},
                    {false, true,  true}
                });

            Assert.AreEqual(_expected.Cells, _game.Play(testGrid).Cells);
        }

        [Test]
        public void CellsWithFourOrMoreNeighborsDie()
        {
            var testGrid = new Grid(new[,]
                {
                    {false, false, false},
                    {true,  true,  true},
                    {false, true,  true}
                });

            _expected = new Grid(new[,]
                {
                    {false, true,  false},
                    {true,  false, true},
                    {true,  false, true}
                });

            Assert.AreEqual(_expected.Cells, _game.Play(testGrid).Cells);
        }
    }
}