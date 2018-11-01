using System;
using NUnit.Framework;

namespace Holidays.Tests {
    [TestFixture]
    public class CarnivalCalculatorTests {

        [TestCase(2016, "2016/02/09")]
        [TestCase(2020, "2020/02/25")]
        [TestCase(2025, "2025/03/04")]
        [TestCase(2030, "2030/03/05")]
        public void WhenYearXThenCarnivalMustBeY(int year, string expectedDate) {
            var holidays = new ChristianHolidays(year);
            Assert.That(holidays.Carnival, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        
        
    }
}