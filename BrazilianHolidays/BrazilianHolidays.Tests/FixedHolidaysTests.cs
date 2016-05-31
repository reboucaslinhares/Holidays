using System;
using NUnit.Framework;

namespace BrazilianHolidays.Tests {
    [TestFixture]
    public class FixedHolidaysTests {
        [TestCase(2016, "2016/01/01")]
        [TestCase(2020, "2020/01/01")]
        [TestCase(2025, "2025/01/01")]
        [TestCase(2030, "2030/01/01")]
        public void NewYearsDayShouldBeAlwaysJanuaryFirst(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.NewYearsDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/04/21")]
        [TestCase(2020, "2020/04/21")]
        [TestCase(2025, "2025/04/21")]
        [TestCase(2030, "2030/04/21")]
        public void TiradentesDayShouldBeAlwaysApril21(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.Tiradentes, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/05/01")]
        [TestCase(2020, "2020/05/01")]
        [TestCase(2025, "2025/05/01")]
        [TestCase(2030, "2030/05/01")]
        public void WorkersDayShouldBeAlwaysMayFirst(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.WorkersDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/09/07")]
        [TestCase(2020, "2020/09/07")]
        [TestCase(2025, "2025/09/07")]
        [TestCase(2030, "2030/09/07")]
        public void IndependenceDayShouldBeAlwaysSeptember7(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.IndependenceDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/10/12")]
        [TestCase(2020, "2020/10/12")]
        [TestCase(2025, "2025/10/12")]
        [TestCase(2030, "2030/10/12")]
        public void PatronessDayShouldBeAlwaysOctober12(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.PatronessDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/11/02")]
        [TestCase(2020, "2020/11/02")]
        [TestCase(2025, "2025/11/02")]
        [TestCase(2030, "2030/11/02")]
        public void AllSoulsDayShouldBeAlwaysNovember2(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.AllSoulsDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/11/15")]
        [TestCase(2020, "2020/11/15")]
        [TestCase(2025, "2025/11/15")]
        [TestCase(2030, "2030/11/15")]
        public void ProclamationOfTheRepublicDayShouldBeAlwaysNovember15(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.ProclamationOfTheRepublicDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/12/25")]
        [TestCase(2020, "2020/12/25")]
        [TestCase(2025, "2025/12/25")]
        [TestCase(2030, "2030/12/25")]
        public void ChristmasDayShouldBeAlwaysDecember25(int year, string expectedDate) {
            var holidays = new Holidays(year);

            Assert.That(holidays.ChristmasDay, Is.EqualTo(DateTime.Parse(expectedDate)));
        }
    }
}
