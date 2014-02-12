using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void TestBoardCreation()
        {
            var board = new Board(2, 2);
            Assert.That(board.Cells.Count, Is.EqualTo(4));
        }

        [Test]
        public void TestBoardCreationWithNegatives()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => new Board(-1, -1)));
            Assert.That(exception.Message, Is.EqualTo("Negative values are not acceptable"));
        }

        [Test]
        public void TestGetCell()
        {
            var board = new Board(2, 2);
            Assert.That(board.GetCellAt(1, 1),
                Is.EqualTo(new Cell { X = 1, Y = 1, IsAlive = false }));
        }

        [Test]
        public void TestGetCellThatDoesNotExist()
        {
            var board = new Board(2, 2);
            Assert.That(board.GetCellAt(4, 4), Is.EqualTo(null));
        }
    }
}
