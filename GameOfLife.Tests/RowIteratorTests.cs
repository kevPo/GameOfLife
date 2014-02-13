using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class RowIteratorTests
    {
        IIterator<String> iterator;
        List<String> rows;

        [SetUp]
        public void SetUp()
        {
            rows = new List<String> { "........",
                                      "....*...",
                                      "...**...",
                                      "........" };
            iterator = new RowIterator();
            iterator.Initialize(rows);
        }

        private void IterateToLast()
        {
            for (var count = 0; count < rows.Count(); count++)
                iterator.Next();
        }

        [Test]
        public void TestCreationWithEmptyList()
        {
            var rowIterator = new RowIterator();
            Exception exception = Assert.Throws<IteratorException>(new TestDelegate(() => rowIterator.Initialize(Enumerable.Empty<String>())));
            Assert.That(exception.Message, Is.EqualTo("Input list cannot be empty or null"));
        }

        [Test]
        public void TestCreationWithValidList()
        {
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[0])); 
        }

        [Test]
        public void TestNextMovesProperly()
        {
            iterator.Next();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[1])); 
        }

        [Test]
        public void TestFirstGoesBackAfterNextHasBeenCalled()
        {
            iterator.Next();
            iterator.First();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[0]));
        }

        [Test]
        public void TestIsDoneShouldReturnFalse()
        {
            Assert.That(iterator.IsDone(), Is.EqualTo(false));
        }

        [Test]
        public void TestIsDoneShouldReturnTrue()
        {
            IterateToLast();

            Assert.That(iterator.IsDone(), Is.EqualTo(true));
        }

        [Test]
        public void TestNextStopsIncrementingAfterIsDone()
        {
            IterateToLast();
            iterator.Next();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[3]));
        }
    }
}
