using System;
using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class BoardFactoryTests
    {
        BoardFactory factory;
        String dimensions;
        Board board;

        [SetUp]
        public void SetUp()
        {
            factory = new BoardFactory(new RowTranslator());
            dimensions = "4 8";
            var initialLayout = new []{ "........", 
                                        "....*...",
                                        "...**...",
                                        "........" };
            board = factory.GetBoard(dimensions, initialLayout);
        }

        [Test]
        public void TestBoardCreationWithEmptyDimensions()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => factory.GetBoard(String.Empty, Enumerable.Empty<String>())));
            Assert.That(exception.Message, Is.EqualTo("Dimensions were not given in an acceptable format 'rows columns'"));
        }

        [Test]
        public void TestBoardCreationWithEmptyLayout()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => factory.GetBoard(dimensions, Enumerable.Empty<String>())));
            Assert.That(exception.Message, Is.EqualTo("Layout was undefined"));
        }

        [Test]
        public void TestGetBoardReturnsFormattedBoard()
        {
            Assert.That(board.Cells.Count, Is.EqualTo(32));
        }

        [Test]
        public void TestCellsAreCorrectlySetAlive()
        {
            var aliveCell = board.Cells.FirstOrDefault(c => c.Y == 2 && c.X == 3);
            Assert.That(aliveCell.IsAlive, Is.EqualTo(true));
        }

        [Test]
        public void TestCellsAreCorrectlyNotAlive()
        {
            var deadCell = board.Cells.FirstOrDefault(c => c.Y == 0 && c.X == 0);
            Assert.That(deadCell.IsAlive, Is.EqualTo(false));
        }

    }
}
