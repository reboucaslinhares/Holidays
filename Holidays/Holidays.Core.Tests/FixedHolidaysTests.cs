using System;
using Holidays;
using NUnit.Framework;

namespace HolidaysTests {
    [TestFixture]
    public class FixedHolidaysTests {
        [TestCase(2016, "2016/01/01")]
        [TestCase(2020, "2020/01/01")]
        [TestCase(2025, "2025/01/01")]
        [TestCase(2030, "2030/01/01")]
        public void NewYearsDayShouldBeAlwaysJanuaryFirst(int year, string expectedDate) {
            var holidays = NationalHolidays.From("br").OfYear(year);

            Assert.That(holidays["Confraternização Universal"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/04/21")]
        [TestCase(2020, "2020/04/21")]
        [TestCase(2025, "2025/04/21")]
        [TestCase(2030, "2030/04/21")]
        public void TiradentesDayShouldBeAlwaysApril21(int year, string expectedDate) {
            var holidays = NationalHolidays.FromBrazil.OfYear(year);

            Assert.That(holidays["Tiradentes"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/05/01")]
        [TestCase(2020, "2020/05/01")]
        [TestCase(2025, "2025/05/01")]
        [TestCase(2030, "2030/05/01")]
        public void WorkersDayShouldBeAlwaysMayFirst(int year, string expectedDate) {
            var holidays = NationalHolidays.FromPortugal.OfYear(year);

            Assert.That(holidays["Dia do Trabalhador"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/09/07")]
        [TestCase(2020, "2020/09/07")]
        [TestCase(2025, "2025/09/07")]
        [TestCase(2030, "2030/09/07")]
        public void IndependenceDayShouldBeAlwaysSeptember7(int year, string expectedDate) {
            var holidays = NationalHolidays.From("br").OfYear(year);

                Assert.That(holidays["Dia da Independência"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/10/12")]
        [TestCase(2020, "2020/10/12")]
        [TestCase(2025, "2025/10/12")]
        [TestCase(2030, "2030/10/12")]
        public void PatronessDayShouldBeAlwaysOctober12(int year, string expectedDate) {
            var holidays = NationalHolidays.From("br").OfYear(year);

            Assert.That(holidays["Dia de Nossa Senhora Aparecida"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/11/02")]
        [TestCase(2020, "2020/11/02")]
        [TestCase(2025, "2025/11/02")]
        [TestCase(2030, "2030/11/02")]
        public void AllSoulsDayShouldBeAlwaysNovember2(int year, string expectedDate) {
            var holidays = NationalHolidays.From("br").OfYear(year);

            Assert.That(holidays["Dia de Finados"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/11/15")]
        [TestCase(2020, "2020/11/15")]
        [TestCase(2025, "2025/11/15")]
        [TestCase(2030, "2030/11/15")]
        public void ProclamationOfTheRepublicDayShouldBeAlwaysNovember15(int year, string expectedDate) {
            var holidays = NationalHolidays.From("br").OfYear(year);

            Assert.That(holidays["Dia da Proclamação da República"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }

        [TestCase(2016, "2016/12/25")]
        [TestCase(2020, "2020/12/25")]
        [TestCase(2025, "2025/12/25")]
        [TestCase(2030, "2030/12/25")]
        public void ChristmasDayShouldBeAlwaysDecember25(int year, string expectedDate) {
            var holidays = NationalHolidays.From("br").OfYear(year);

            Assert.That(holidays["Natal"], Is.EqualTo(DateTime.Parse(expectedDate)));
        }
    }
}
