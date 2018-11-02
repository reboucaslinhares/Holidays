using System.Linq;
using Holidays;
using Holidays.Core;
using NUnit.Framework;

namespace HolidaysCoreTests {
    [TestFixture]
    public class ListHolidaysTests {
        [Test]
        public void ShouldThereBe12HolidaysListed() {
            var holidays = NationalHolidays.From("br").OfYear(2016);

            Assert.That(holidays.Count, Is.EqualTo(12));
        }

        [Test]
        public void TheListMustBeAscendingOrdered() {
            var holidays = NationalHolidays.From("br").OfYear(2016);

            for (var i = 1; i < holidays.Count - 1; i++) {
                Assert.That(holidays.ElementAt(i).Value, Is.GreaterThan(holidays.ElementAt(i - 1).Value));
            }
        }
    }
}
