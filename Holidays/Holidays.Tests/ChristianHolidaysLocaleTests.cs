using Holidays;
using NUnit.Framework;

namespace HolidaysTests {
    [TestFixture]
    public class ChristianHolidaysLocaleTests
    {
        [TestCase("br", "Carnival", "Carnaval")]
        [TestCase("br", "ChristmasDay", "Natal")]
        [TestCase("br", "CorpusChristi", "Corpus Christi")]
        [TestCase("br", "GoodFriday", "Sexta-feira Santa")]
        [TestCase("br", "Easter", "P�scoa")]
        public void WhenLocaleIsBrThenDescriptionsMustBeAsExpected(string country, string inputText, string expectedText)
        {
            var locale = new Locale(typeof(ChristianHolidays), country);

            Assert.That(locale.GetLocalizedStringFor(inputText), Is.EqualTo(expectedText));
        }

        [TestCase("pt", "Carnival", "Carnaval")]
        [TestCase("pt", "ChristmasDay", "Natal")]
        [TestCase("pt", "CorpusChristi", "Corpo de Deus")]
        [TestCase("pt", "GoodFriday", "Sexta-feira Santa")]
        [TestCase("pt", "Easter", "P�scoa")]
        public void WhenLocaleIsPtThenDescriptionsMustBeAsExpected(string country, string inputText, string expectedText)
        {
            var locale = new Locale(typeof(ChristianHolidays), country);
            Assert.That(locale.GetLocalizedStringFor(inputText), Is.EqualTo(expectedText));
        }
    }
}