using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
            var type = typeof(ChristianHolidays);
            var assembly = Assembly.Load(new AssemblyName(type.Namespace));
            var localizableTypeManifestStream = assembly.GetManifestResourceStream($"{type.Namespace}.Countries.{country}.json");

            using (var jsonContentReader = new StreamReader(localizableTypeManifestStream, Encoding.UTF7))
            {

                var nationalHolidays = JsonConvert.DeserializeObject<NationalHolidays>(jsonContentReader.ReadToEnd());
                if (nationalHolidays == null)
                    return new NationalHolidays();

                foreach (var nationalHoliday in nationalHolidays.Holidays)
                {
                    nationalHoliday.Type = HolidayType.National;
                }

                return nationalHolidays;

            }           
        }
    }
}