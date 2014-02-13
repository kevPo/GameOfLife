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
            board = new Board(4, 8, Enumerable.Empty<Cell>());
        }

        [Test]
        public void TestBoardCreation()
        {
            Assert.That(board.Cells.Count, Is.EqualTo(32));
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
