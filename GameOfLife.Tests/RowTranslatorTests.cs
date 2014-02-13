using System;
using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class RowTranslatorTests
    {
        RowTranslator translator;

        [SetUp]
        public void SetUp()
        {
            translator = new RowTranslator();
        }

        [Test]
        public void TestCorrectNumberOfCellsPopulated()
        {
            var cells = translator.Translate(0, "....*..");
            Assert.That(cells.Count, Is.EqualTo(7));
        }

        [Test]
        public void TestCellIsGivenCorrectXAndYValue()
        {
            var cells = translator.Translate(3, "..*.");
            var cell = cells[0];
            Assert.That(cell.X, Is.EqualTo(0));
            Assert.That(cell.Y, Is.EqualTo(3));
        }

        [Test]
        public void TestCellsAreCorrectlySetToAlive()
        {
            var cells = translator.Translate(0, ".**.");
            Assert.That(cells.Where(c => c.IsAlive).Count() , Is.EqualTo(2));
        }
    }
}
