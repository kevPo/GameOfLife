using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class InputTranslatorTests
    {
        private InputTranslator translator;
        private String data;

        [SetUp]
        public void SetUp()
        {
            translator = new InputTranslator();
            data = "3 3\n" +
                   "...\n" +
                   "...\n" +
                   "...";
        }

        [Test]
        public void TestTranslateEmptyInput()
        {
            Exception exception = Assert.Throws<TranslationException>(
                new TestDelegate(() => translator.Translate(String.Empty)));
            Assert.That(exception.Message, Is.EqualTo("Invalid game input"));
        }

        [Test]
        public void TestDimensionsAreCorrectlyTranslated()
        {
            var gameData = translator.Translate(data);
            Assert.That(gameData.Dimensions, Is.EqualTo("3 3"));
        }

        [Test]
        public void TestRowsAreCorrectlyTranslated()
        {
            var gameData = translator.Translate(data);
            Assert.That(gameData.Rows.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestRowIsParsedCorrectly()
        {
            var gameData = translator.Translate(data);
            Assert.That(gameData.Rows[0], Is.EqualTo("..."));
        }
    }
}
