using System;
using Newtonsoft.Json;

namespace Holidays {
    public class Holiday : IComparable<Holiday> {
        public string Description { get; set; }
        [JsonProperty("M")]
        public int Month { get; set; }
        [JsonProperty("d")]
        public int Day { get; set; }
        public HolidayType? Type { get; set; }

        public DateTime ToDateOf(int year) {
            return new DateTime(year, Month, Day);
        }

        public int CompareTo(Holiday other) {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var monthComparison = Month.CompareTo(other.Month);
            if (monthComparison != 0) return monthComparison;
            var dayComparison = Day.CompareTo(other.Day);
            if (dayComparison != 0) return dayComparison;
            var descriptionComparison = string.Compare(Description, other.Description, StringComparison.Ordinal);
            if (descriptionComparison != 0) return descriptionComparison;
            return Nullable.Compare(Type, other.Type);
        }
    }
}