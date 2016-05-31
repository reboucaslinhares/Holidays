using NUnit.Framework;

namespace BrazilianHolidays.Tests {
    [TestFixture]
    public class ListHolidaysTests {
        [Test]
        public void ShouldThereBe12HolidaysListed() {
            var holidays = new Holidays(2016);

            var dates = holidays.List;

            Assert.That(dates.Count, Is.EqualTo(12));
        }

        [Test]
        public void TheListMustBeAscendingOrdered() {
            var holidays = new Holidays(2016);

            var dates = holidays.List;

            for (var i = 1; i < dates.Count - 1; i++) {
                Assert.That(dates[i], Is.GreaterThan(dates[i - 1]));
            }
        }
    }
}
