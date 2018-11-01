using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace BrazilianHolidays {
    public class Holidays {
        [JsonProperty("Items")]
        private SortedSet<Holiday> items;
        public IReadOnlyList<Holiday> List => items.ToList().AsReadOnly();

        public void AddCustom(string description, DateTime date)
        {
            items.Add(new Holiday{Description = description, Month = date.Month, Day = date.Day, Type = HolidayType.Custom});
        }

        public void Add(params Holiday[] holidays)
        {
            foreach (var holiday in holidays.Where(h => h != null)) {
                if (holiday.Month <= 0 || holiday.Day <= 0)
                    throw new ArgumentException("Holiday's day and month must be valid");

                items.Add(holiday);
            }
        }

        public Holiday Get(byte month, byte day, HolidayType type) {
            return List.Single(holiday => holiday.Month == month && holiday.Day == day && holiday.Type == type);
        }

        public Holidays() {
            items = new SortedSet<Holiday>();
        }
    }
}
