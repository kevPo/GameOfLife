using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class RowIteratorTests
    {
        RowIterator iterator;
        List<String> rows;

        [SetUp]
        public void SetUp()
        {
            rows = new List<String> { "........",
                                      "....*...",
                                      "...**...",
                                      "........" };
        }

        private void BuildValidIterator()
        {
            iterator = new RowIterator(rows);
        }

        private void IterateToLast()
        {
            for (var count = 0; count < rows.Count(); count++)
                iterator.Next();
        }

        [Test]
        public void TestCreationWithEmptyList()
        {
            Exception exception = Assert.Throws<IteratorException>(new TestDelegate(() => new RowIterator(Enumerable.Empty<String>())));
            Assert.That(exception.Message, Is.EqualTo("Input list cannot be empty or null"));
        }

        [Test]
        public void TestCreationWithValidList()
        {
            BuildValidIterator();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[0])); 
        }

        [Test]
        public void TestNextMovesProperly()
        {
            BuildValidIterator();
            iterator.Next();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[1])); 
        }

        [Test]
        public void TestFirstGoesBackAfterNextHasBeenCalled()
        {
            BuildValidIterator();
            iterator.Next();
            iterator.First();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[0]));
        }

        [Test]
        public void TestIsDoneShouldReturnFalse()
        {
            BuildValidIterator();
            Assert.That(iterator.IsDone(), Is.EqualTo(false));
        }

        [Test]
        public void TestIsDoneShouldReturnTrue()
        {
            BuildValidIterator();
            IterateToLast();

            Assert.That(iterator.IsDone(), Is.EqualTo(true));
        }

        [Test]
        public void TestNextStopsIncrementingAfterIsDone()
        {
            BuildValidIterator();
            IterateToLast();
            iterator.Next();
            Assert.That(iterator.CurrentItem(), Is.EqualTo(rows[3]));
        }
    }
}
