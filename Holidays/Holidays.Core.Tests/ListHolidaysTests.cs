using System.Linq;
using Holidays;
using NUnit.Framework;

namespace HolidaysTests
{
    [TestFixture]
    public class ListHolidaysTests
    {
        [Test]
        public void ShouldThereBe12HolidaysListed()
        {
            var holidays = NationalHolidays.From("br").OfYear(2016);

            Assert.That(holidays.Count, Is.EqualTo(12));
        }

        [Test]
        public void TheListMustBeAscendingOrdered()
        {
            var holidays = NationalHolidays.From("br").OfYear(2016);

            for (var i = 1; i < holidays.Count - 1; i++)
            {
                Assert.That(holidays.ElementAt(i).Value, Is.GreaterThan(holidays.ElementAt(i - 1).Value));
            }
        }

        [Test]
        public void ItDateTimeIsChristianHoliday()
        {
            var holiday = NationalHolidays.From("br").OfDateTime(new System.DateTime(2020, 12, 25));
            Assert.AreNotEqual(holiday.Value, System.DateTime.MinValue);
            Assert.IsFalse(string.IsNullOrEmpty(holiday.Key));
        }

        [Test]
        public void ItDateTimeIsHoliday()
        {
            var IsHoliday = NationalHolidays.From("br").OfDateTimeIsHoliday(new System.DateTime(2020, 12, 25));
            Assert.IsTrue(IsHoliday);
        }

        [Test]
        public void ItDateTimeIsNotHoliday()
        {
            var IsNotholiday = NationalHolidays.From("br").OfDateTimeIsNotHoliday(new System.DateTime(2020, 10, 10));
            Assert.IsTrue(IsNotholiday);
        }
    }
}
