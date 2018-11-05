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
        public Holidays FixedHolidays => holidays ?? (holidays = new Holidays());

        public string Country { get; set; }

        public IEnumerable<string> MoveableHolidays { get; set; }
        
        public IDictionary<string, DateTime> OfYear(int year) {
            var allHolidays = new Holidays();

            foreach (var moveableHolidaysStrategyDescription in MoveableHolidays) {
                var moveableHolidaysStrategyInstance = Activator.CreateInstance(Type.GetType(moveableHolidaysStrategyDescription)) as IMoveableHolidays;
                var moveableHolidays = moveableHolidaysStrategyInstance?
                                            .UseLocalizationFor(Country)
                                            .CalculateForYear(year)
                                            .Holidays;
                if(moveableHolidays == null || moveableHolidays.Count == 0)
                    continue;

                foreach (var moveableHoliday in moveableHolidays)
                {
                    allHolidays.Add(moveableHoliday);
                }
            }

            foreach (var fixedHoliday in FixedHolidays) {
                allHolidays.Add(fixedHoliday);
            }

            return allHolidays.ToDictionary(item => item.Description, item => item.ToDateOf(year));
        }

        public static NationalHolidays From(string country) {

#if NET45
            var assembly = typeof(NationalHolidays).GetTypeInfo().Assembly;
            var localizableTypeManifestStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Countries.{country}.json");

            using (var jsonContentReader = new StreamReader(localizableTypeManifestStream, Encoding.UTF7))
            {

                var nationalHolidays = JsonConvert.DeserializeObject<NationalHolidays>(jsonContentReader.ReadToEnd());
                if (nationalHolidays == null)
                    return new NationalHolidays();

                foreach (var nationalHoliday in nationalHolidays.FixedHolidays)
                {
                    nationalHoliday.Type = HolidayType.National;
                }

                return nationalHolidays;

            }
#else
            var assembly = typeof(NationalHolidays).Assembly;
            var localizableTypeManifestStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Countries.{country}.json");

            using (var jsonContentReader = new StreamReader(localizableTypeManifestStream, Encoding.UTF7))
            {

                var nationalHolidays = JsonConvert.DeserializeObject<NationalHolidays>(jsonContentReader.ReadToEnd());
                if (nationalHolidays == null)
                    return new NationalHolidays();

                foreach (var nationalHoliday in nationalHolidays.FixedHolidays)
                {
                    nationalHoliday.Type = HolidayType.National;
                }

                return nationalHolidays;

            }
#endif
        }

        public static NationalHolidays FromBrazil => From("br");
        
        public static NationalHolidays FromPortugal => From("pt");
        
    }
}