using System;
using NUnit.Framework;

namespace BrazilianHolidays.Tests {
    [TestFixture]
    public class AddingCustomHolidaysTests {
        [Test]
        public void WhenAddACustomHolidayListShouldBeIncreased() {
            var holidays = new Holidays(2016);

            holidays.AddCustom(new DateTime(2016, 9, 6));

            Assert.That(holidays.List.Count, Is.EqualTo(13));
        }

        [Test]
        public void WhenCustomHolidayAlreadyIsOnTheListShouldNotBeAdded() {
            var holidays = new Holidays(2016);

            holidays.AddCustom(new DateTime(2016, 1, 1));

            Assert.That(holidays.List.Count, Is.EqualTo(12));
        }

        [Test]
        public void WhenAddACustomHolidayListShouldBeKeepOrdered() {
            var holidays = new Holidays(2016);

            holidays.AddCustom(new DateTime(2016, 9, 6));

            var dates = holidays.List;

            for (var i = 1; i < dates.Count - 1; i++) {
                Assert.That(dates[i], Is.GreaterThan(dates[i - 1]));
            }
        }
    }
}
