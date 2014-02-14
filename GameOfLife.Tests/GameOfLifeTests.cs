using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        GameOfLife game;

        [SetUp]
        public void SetUp()
        {
            var rawData = "4 8\n" +
                          "........\n" +
                          "....*...\n" +
                          "...**...\n" +
                          "........";
            var inputTranslator = new InputTranslator();
            var boardFactory = new BoardFactory(new RowTranslator());
            game = new GameOfLife(rawData, inputTranslator, boardFactory);
        }


        [Test]
        public void TestThatBoardIsCreated()
        {
            
        }
    }
}
