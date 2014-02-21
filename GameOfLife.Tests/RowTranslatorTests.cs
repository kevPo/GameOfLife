using System;
using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class RowTranslatorTests
    {
        private RowTranslator translator;

        [SetUp]
        public void SetUp()
        {
            translator = new RowTranslator('*', '.');
        }

        [Test]
        public void TestCorrectNumberOfCellsPopulated()
        {
            var cells = translator.Translate("....*..");
            Assert.That(cells.ToList().Count, Is.EqualTo(7));
        }

        [Test]
        public void TestCellIsGivenCorrectXAndYValue()
        {
            var cells = translator.Translate("..*.");
            var cell = cells.ToList()[0];
            Assert.That(cell.X, Is.EqualTo(0));
            Assert.That(cell.Y, Is.EqualTo(0));
        }

        [Test]
        public void TestCellsAreCorrectlySetToAlive()
        {
            var cells = translator.Translate(".**.");
            Assert.That(cells.Where(c => c.IsAlive).Count() , Is.EqualTo(2));
        }
    }
}
