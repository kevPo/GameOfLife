using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class BoardFactoryTests
    {
        BoardFactory factory;
        String dimensions;
        String initialLayout;


        [SetUp]
        public void SetUp()
        {
            factory = new BoardFactory();
            dimensions = "4 8";
            initialLayout = "........\n" + 
                            "....*...\n" +
                            "...**...\n" +
                            "........\n";
        }

        [Test]
        public void TestBoardCreationWithEmptyDimensions()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => factory.GetBoard(String.Empty, String.Empty)));
            Assert.That(exception.Message, Is.EqualTo("Dimensions were not given in an acceptable format 'rows columns'"));
        }
    }
}
