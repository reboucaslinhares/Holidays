using System;
using NUnit.Framework;

namespace BrazilianHolidays.Tests {
    [TestFixture]
    public class GoodFridayCalculatorTests {

        [TestCase(2016, "2016/03/25")]
        [TestCase(2020, "2020/04/10")]
        [TestCase(2025, "2025/04/18")]
        [TestCase(2030, "2030/04/19")]
        public void WhenYearXThenGoodFridayMustBeY(int year, string expectedDate) {
            var holidays = new Holidays(year);
            Assert.That(holidays.GoodFriday, Is.EqualTo(DateTime.Parse(expectedDate)));
        }
        
    }
}