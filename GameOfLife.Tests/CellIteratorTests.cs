using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellIteratorTests
    {
        private CellIterator cellIterator;
        private List<Cell> cells;

        [SetUp]
        public void SetUp()
        {
            cells = new List<Cell> { 
                new Cell { Y = 0, X = 0, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 1, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 2, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 3, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 4, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 5, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 6, Value = '.', IsAlive = false },
                new Cell { Y = 0, X = 7, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 0, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 1, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 2, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 3, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 4, Value = '*', IsAlive = true },
                new Cell { Y = 1, X = 5, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 6, Value = '.', IsAlive = false },
                new Cell { Y = 1, X = 7, Value = '.', IsAlive = false },
                new Cell { Y = 2, X = 0, Value = '.', IsAlive = false },
                new Cell { Y = 2, X = 1, Value = '.', IsAlive = false },
                new Cell { Y = 2, X = 2, Value = '.', IsAlive = false },
                new Cell { Y = 2, X = 3, Value = '*', IsAlive = true },
                new Cell { Y = 2, X = 4, Value = '*', IsAlive = true },
                new Cell { Y = 2, X = 5, Value = '.', IsAlive = false },
                new Cell { Y = 2, X = 6, Value = '.', IsAlive = false },
                new Cell { Y = 2, X = 7, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 0, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 1, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 2, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 3, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 4, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 5, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 6, Value = '.', IsAlive = false },
                new Cell { Y = 3, X = 7, Value = '.', IsAlive = false }
            };
            cellIterator = new CellIterator();
            cellIterator.Initialize(cells);
        }

        private void InitializeAndMove(Cell homeCell, Int32 moves)
        {
            cellIterator.SetHomeCell(homeCell);
            cellIterator.First();

            for (var i = 0; i < moves; i++)
                cellIterator.Next();
        }

        [Test]
        public void TestIteratorInitialization()
        {
            var expectedCell = cells.FirstOrDefault(c => c.Y == 0 && c.X == 2);
            cellIterator.SetHomeCell(cells.FirstOrDefault(c => c.Y == 1 && c.X == 3));
            cellIterator.First();
            Assert.That(cellIterator.CurrentItem(), Is.EqualTo(expectedCell));
        }

        [Test]
        public void TestNextAfterFirst()
        {
            var expectedCell = cells.FirstOrDefault(c => c.Y == 0 && c.X == 3);
            InitializeAndMove(cells.FirstOrDefault(c => c.Y == 1 && c.X == 3), 1);
            Assert.That(cellIterator.CurrentItem(), Is.EqualTo(expectedCell));
        }

        [Test]
        public void TestNextGoingToNextRow()
        {
            var expectedCell = cells.FirstOrDefault(c => c.Y == 1 && c.X == 2);
            InitializeAndMove(cells.FirstOrDefault(c => c.Y == 1 && c.X == 3), 3);
            Assert.That(cellIterator.CurrentItem(), Is.EqualTo(expectedCell));
        }

        [Test]
        public void TestThatHomeCellIsSkipped()
        {
            var expectedCell = cells.FirstOrDefault(c => c.Y == 1 && c.X == 4);
            InitializeAndMove(cells.FirstOrDefault(c => c.Y == 1 && c.X == 3), 4);
            Assert.That(cellIterator.CurrentItem(), Is.EqualTo(expectedCell));
        }

        [Test]
        public void TestThatDoneIsCorrectlySet()
        {
            InitializeAndMove(cells.FirstOrDefault(c => c.Y == 1 && c.X == 3), 8);
            Assert.That(cellIterator.IsDone(), Is.EqualTo(true));
        }
    }
}
