using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Holidays {
    [JsonArray(false)]
    public class Holidays : ICollection<Holiday> {
        
        private SortedSet<Holiday> items;

        public Holidays()
        {
            items = new SortedSet<Holiday>();
        }
        
        public void AddCustom(string description, DateTime date)
        {
            items.Add(new Holiday{Description = description, Month = date.Month, Day = date.Day, Type = HolidayType.Custom});
        }

        public void AddRange(params Holiday[] holidays)
        {
            foreach (var holiday in holidays.Where(h => h != null)) {
                Add(holiday);
            }
        }
        
        public void Add(Holiday holiday) {
            if(holiday == null)
                return;
            
            if (holiday.Month <= 0 || holiday.Day <= 0)
                throw new ArgumentException("Holiday's day and month must be valid");

            items.Add(holiday);
        }

        public void Clear() {
            items.Clear();
        }

        public bool Contains(Holiday item) {
            return items.Contains(item);
        }

        public void CopyTo(Holiday[] array, int arrayIndex) {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Holiday item) {
            return items.Remove(item);
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public IEnumerator<Holiday> GetEnumerator() {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
