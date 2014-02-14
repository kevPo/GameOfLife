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
            var criteria = new GameCriteria { 
                CellIterator = new CellIterator(),
                GameRules = new DefaultGameRules(),
                AliveValue = '*',
                DeadValue = '.'
            };
            var boardFactory = new BoardFactory(new RowTranslator(criteria.AliveValue, criteria.DeadValue));
            game = new GameOfLife(rawData, criteria, inputTranslator, boardFactory);
        }


        [Test]
        public void TestThatBoardIsCreated()
        {
            var expected = "........\n" +
                           "....*...\n" +
                           "...**...\n" +
                           "........\n";
            Assert.That(game.ViewGameBoard(), Is.EqualTo(expected));
        }

        [Test]
        public void TestBlockGeneration()
        {
            var nextGeneration = "........\n" +
                                 "...**...\n" +
                                 "...**...\n" +
                                 "........\n";
            Assert.That(game.NextGeneration(), Is.EqualTo(nextGeneration));
        }
    }
}
