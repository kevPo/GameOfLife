using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class DefaultGameRulesTests
    {
        private IGameRules rules;

        [SetUp]
        public void SetUp()
        {
            rules = new DefaultGameRules();
        }

        [Test]
        public void TestCellAliveUnderPopulation()
        {
            Assert.That(rules.IsLifeGrantedFor(true, 1), Is.EqualTo(false));
        }

        [Test]
        public void TestCellAliveOverPopulation()
        {
            Assert.That(rules.IsLifeGrantedFor(true, 7), Is.EqualTo(false));
        }

        [Test]
        public void TestAliveStaysAlive()
        {
            Assert.That(rules.IsLifeGrantedFor(true, 2), Is.EqualTo(true));
        }

        [Test]
        public void TestDeadBecomesAlive()
        {
            Assert.That(rules.IsLifeGrantedFor(false, 3), Is.EqualTo(true));
        }

        [Test]
        public void TestDeadStaysDead()
        {
            Assert.That(rules.IsLifeGrantedFor(false, 2), Is.EqualTo(false));
        }
    }
}
