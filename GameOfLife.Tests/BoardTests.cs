using System;
using System.Linq;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private Board board;

        [SetUp]
        public void SetUp()
        {
            var cells = new[] { 
                new Cell { X =  0, Y = 0, Value = '.', IsAlive = false },
                new Cell { X =  0, Y = 1, Value = '.', IsAlive = false },
                new Cell { X =  0, Y = 2, Value = '.', IsAlive = false },
                new Cell { X =  1, Y = 0, Value = '.', IsAlive = false },
                new Cell { X =  1, Y = 1, Value = '.', IsAlive = false },
                new Cell { X =  1, Y = 2, Value = '.', IsAlive = false },
                new Cell { X =  2, Y = 0, Value = '.', IsAlive = false },
                new Cell { X =  2, Y = 1, Value = '.', IsAlive = false },
                new Cell { X =  2, Y = 2, Value = '.', IsAlive = false },
            };
            board = new Board(3, 3, cells);
        }

        [Test]
        public void TestBoardCreation()
        {
            var emptyBoard = new Board(0, 0, Enumerable.Empty<Cell>());
            Assert.That(emptyBoard.Cells.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestBoardCreationWithNegatives()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => new Board(-1, -1, Enumerable.Empty<Cell>())));
            Assert.That(exception.Message, Is.EqualTo("Negative values are not acceptable"));
        }

        [Test]
        public void TestGetCell()
        {
            Assert.That(board.GetCellAt(1, 1),
                Is.EqualTo(new Cell { X = 1, Y = 1, IsAlive = false }));
        }

        [Test]
        public void TestGetCellThatDoesNotExist()
        {
            Assert.That(board.GetCellAt(4, 9), Is.EqualTo(null));
        }

        [Test]
        public void TestGiveLifeToCell()
        {
            board.SetLifeFor(2, 2, true);
            Assert.That(board.GetCellAt(2, 2).IsAlive, Is.EqualTo(true));
        }

        [Test]
        public void TestTakeLifeFromCell()
        {
            board.SetLifeFor(2, 2, true);
            board.SetLifeFor(2, 2, false);
            Assert.That(board.GetCellAt(2, 2).IsAlive, Is.EqualTo(false));
        }
    }
}
