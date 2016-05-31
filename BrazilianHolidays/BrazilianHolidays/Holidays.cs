using System;

namespace BrazilianHolidays {
    public class Holidays {
        public DateTime Easter { get; }
        public DateTime NewYearsDay { get; }
        public DateTime TiradentesDay { get; }
        public DateTime WorkersDay { get; }
        public DateTime IndependenceDay { get; }
        public DateTime PatronessDay { get; }
        public DateTime AllSoulsDay { get; }
        public DateTime ProclamationOfTheRepublicDay { get; }
        public DateTime ChristmasDay { get; }

        public DateTime Carnival => Easter.AddDays(-47);

        public DateTime GoodFriday => Easter.AddDays(-2);

        public DateTime CorpusChristi => Easter.AddDays(60);

        public Holidays(int year) {
            Easter = CalculateEasterHolidayFor(year);
            NewYearsDay = new DateTime(year, 1, 1);
            TiradentesDay = new DateTime(year, 4, 21);
            WorkersDay = new DateTime(year, 5, 1);
            IndependenceDay = new DateTime(year, 9, 7);
            PatronessDay = new DateTime(year, 10, 12);
            AllSoulsDay = new DateTime(year, 11, 2);
            ProclamationOfTheRepublicDay = new DateTime(year, 11, 15);
            ChristmasDay = new DateTime(year, 12, 25);
        }

        private DateTime CalculateEasterHolidayFor(int year) {
            const int x = 24;
            const int y = 5;

            var a = year % 19;
            var b = year % 4;
            var c = year % 7;

            var d = (19 * a + x) % 30;
            var e = (2 * b + 4 * c + 6 * d + y) % 7;

            int day;
            int month;

            if (d + e > 9) {
                day = d + e - 9;
                month = 4;
            } else {
                day = d + e + 22;
                month = 3;
            }

            return DateTime.Parse($"{year},{month},{day}");
        }
    }
}
