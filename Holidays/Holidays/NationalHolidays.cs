﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Holidays.Properties;
using Newtonsoft.Json;

namespace Holidays {
    public class NationalHolidays {
        [JsonProperty("Holidays")]
        private Holidays holidays;

        [JsonIgnore]
        public Holidays Holidays {
            get => holidays ?? (holidays = new Holidays());
        }

        public string Country { get; set; }

        public bool IsChristian { get; set; }
        
        public IDictionary<string, DateTime> OfYear(int year) {
            var holidaysOfYear = new Holidays();

            if (IsChristian)
            {
                var christianHolidays = new ChristianHolidays()
                    .UseLocalizationFor(Country)
                    .CalculateForYear(year)
                    .Holidays;

                foreach (var christianHoliday in christianHolidays) {
                    holidaysOfYear.Add(christianHoliday);
                }
            }

            foreach (var nationalHoliday in Holidays) {
                holidaysOfYear.Add(nationalHoliday);
            }

            return holidaysOfYear.ToDictionary(item => item.Description, item => item.ToDateOf(year));
        }

        public static NationalHolidays From(string country) {
            var countryNationalHolidaysBlob = (byte[])Resources.ResourceManager.GetObject(country);
    
            var countryNationalHolidays = Encoding.Default.GetString(countryNationalHolidaysBlob);
            var nationalHolidays = JsonConvert.DeserializeObject<NationalHolidays>(countryNationalHolidays);
            if (nationalHolidays == null)
                return new NationalHolidays();

            foreach (var nationalHoliday in nationalHolidays.Holidays) {
                nationalHoliday.Type = HolidayType.National;
            }

            return nationalHolidays;
        
        
        }
    }
}