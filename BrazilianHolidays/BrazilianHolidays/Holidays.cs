using System;

namespace BrazilianHolidays {
    public class Holidays {
        public DateTime Easter { get; }

        public DateTime Carnival {
            get {
                return Easter.AddDays(-47);
            }
        }

        public DateTime GoodFriday {
            get {
                return Easter.AddDays(-2);
            }
        }

        public DateTime CorpusChristi {
            get {
                return Easter.AddDays(60);
            }
        }

        public Holidays(int year) {
            Easter = CalculateEasterHolidayFor(year);
        }

        private DateTime CalculateEasterHolidayFor(int year) {
            var x = 24;
            var y = 5;

            var a = year%19;
            var b = year%4;
            var c = year%7;

            var d = (19*a + x)%30;
            var e = (2*b + 4*c + 6*d + y)%7;

            int day;
            int month;

            if (d + e > 9) {
                day = d + e - 9;
                month = 4;
            }
            else {
                day = d + e + 22;
                month = 3;
            }
            return DateTime.Parse($"{year},{month},{day}");
        }        

    }
}
