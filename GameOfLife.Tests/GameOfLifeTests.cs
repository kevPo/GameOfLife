using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {

        private GameOfLife BuildGame(String rawData)
        {
            var inputTranslator = new InputTranslator();
            var criteria = new GameCriteria
            {
                CellIterator = new CellIterator(),
                GameRules = new DefaultGameRules(),
                AliveValue = '*',
                DeadValue = '.'
            };
            var boardFactory = new BoardFactory(new RowTranslator(criteria.AliveValue, criteria.DeadValue));
            
            return new GameOfLife(rawData, criteria, inputTranslator, boardFactory);
        }


        [Test]
        public void TestThatBoardIsCreated()
        {
            var rawData = "4 8\n" +
                          "........\n" +
                          "....*...\n" +
                          "...**...\n" +
                          "........";
            var game = BuildGame(rawData);

            var expected = "........\n" +
                           "....*...\n" +
                           "...**...\n" +
                           "........\n";
            Assert.That(game.ViewGameBoard(), Is.EqualTo(expected));
        }

        [Test]
        public void TestBlockGeneration()
        {
            var rawData = "4 8\n" +
                          "........\n" +
                          "....*...\n" +
                          "...**...\n" +
                          "........";
            var game = BuildGame(rawData);

            var nextGeneration = "........\n" +
                                 "...**...\n" +
                                 "...**...\n" +
                                 "........\n";
            Assert.That(game.NextGeneration(), Is.EqualTo(nextGeneration));
        }

        [Test]
        public void TestBeehiveGeneration()
        {
            var rawData = "5 6\n" +
                          "......\n" +
                          "..**..\n" +
                          ".*..*.\n" +
                          "..**..\n" +
                          "......";
            var game = BuildGame(rawData);

            var nextGeneration = "......\n" +
                                 "..**..\n" +
                                 ".*..*.\n" +
                                 "..**..\n" +
                                 "......\n";
            Assert.That(game.NextGeneration(), Is.EqualTo(nextGeneration));
        }

        [Test]
        public void TestBlinkerGeneration()
        {
            var rawData = "5 5\n" +
                          ".....\n" +
                          "..*..\n" +
                          "..*..\n" +
                          "..*..\n" +
                          ".....";
            var game = BuildGame(rawData);

            var nextGeneration = ".....\n" +
                                 ".....\n" +
                                 ".***.\n" +
                                 ".....\n" +
                                 ".....\n";
            Assert.That(game.NextGeneration(), Is.EqualTo(nextGeneration));
        }

        [Test]
        public void TestToadGeneration()
        {
            var rawData = "6 6\n" +
                          "......\n" +
                          "......\n" +
                          "..***.\n" +
                          ".***..\n" +
                          "......\n" +
                          "......";
            var game = BuildGame(rawData);

            var nextGeneration = "......\n" +
                                 "...*..\n" +
                                 ".*..*.\n" +
                                 ".*..*.\n" +
                                 "..*...\n" +
                                 "......\n";
            
            Assert.That(game.NextGeneration(), Is.EqualTo(nextGeneration));
        }
    }
}
