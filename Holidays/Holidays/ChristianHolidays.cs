using System;

namespace Holidays {
    public class ChristianHolidays {
        private Holidays holidays;
        private Locale locale;

        public DateTime Easter { get; private set; }
        
        public DateTime Carnival => Easter.AddDays(-47);

        public DateTime GoodFriday => Easter.AddDays(-2);

        public DateTime CorpusChristi => Easter.AddDays(60);

        public DateTime ChristmasDay { get; }

        public Holidays Holidays => holidays??(holidays = new Holidays());

        public ChristianHolidays(int year) {
            CalculateForYear(year);
        }

        public ChristianHolidays() {
        }

        public ChristianHolidays CalculateForYear(int year) {
            Easter = CalculateEasterHolidayFor(year);

            var easter = new Holiday {
                Day = Easter.Day,
                Month = Easter.Month,
                Type = HolidayType.Custom,
                Description = locale?.GetLocalizedStringFor(nameof(Easter))
            };

            var carnival = new Holiday {
                Day = Carnival.Day,
                Month = Carnival.Month,
                Type = HolidayType.Custom,
                Description = locale?.GetLocalizedStringFor(nameof(Carnival))
            };

            var goodFriday = new Holiday {
                Day = GoodFriday.Day,
                Month = GoodFriday.Month,
                Type = HolidayType.Custom,
                Description = locale?.GetLocalizedStringFor(nameof(GoodFriday))
            };

            var corpusChristi = new Holiday {
                Day = CorpusChristi.Day,
                Month = CorpusChristi.Month,
                Type = HolidayType.Custom,
                Description = locale?.GetLocalizedStringFor(nameof(CorpusChristi))
            };

            var christmasDay = new Holiday {
                Day = 25,
                Month = 12,
                Type = HolidayType.Custom,
                Description = locale?.GetLocalizedStringFor(nameof(ChristmasDay))
            };

            Holidays.Add(easter, carnival, goodFriday, corpusChristi, christmasDay);
            return this;
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

        public ChristianHolidays UseLocalizationFor(string country) {
            locale = new Locale(GetType(), country);
            return this;
        }
    }
}