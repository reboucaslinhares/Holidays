using System;
using NUnit.Framework;

namespace Holidays.Tests {
    [TestFixture]
    public class EasterCalculatorTests {
        [TestCase(2016, "2016/03/27")]
        [TestCase(2020, "2020/04/12")]
        [TestCase(2025, "2025/04/20")]
        [TestCase(2030, "2030/04/21")]
        public void WhenYearXThenEasterMustBeY(int year, string expectedDate) {
            var holidays = new ChristianHolidays(year);
            Assert.That(holidays.Easter, Is.EqualTo(DateTime.Parse(expectedDate)));
        }
    }
}
