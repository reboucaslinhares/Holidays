using System;
using Holidays.Moveable;
using NUnit.Framework;

namespace HolidaysTests {
    [TestFixture]
    public class CorpusChristiCalculatorTests {
        [TestCase(2016, "2016/05/26")]
        [TestCase(2020, "2020/06/11")]
        [TestCase(2025, "2025/06/19")]
        [TestCase(2030, "2030/06/20")]
        public void WhenYearXThenCorpusChristiMustBeY(int year, string expectedDate) {
            var holidays = new ChristianHolidays(year);
            Assert.That(holidays.CorpusChristi, Is.EqualTo(DateTime.Parse(expectedDate)));
        }
    }
}