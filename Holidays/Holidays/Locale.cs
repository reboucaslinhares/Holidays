using System;
using System.Text;
using Holidays.Properties;
using Newtonsoft.Json.Linq;

namespace Holidays {
    public class Locale {
        private JObject json;
        public string GetLocalizedStringFor(string key) {
            return json?.GetValue(key)?.Value<string>() ?? key;
        }

        public Locale(Type type, string country) {
            var localizableType = (byte[])Resources.ResourceManager.GetObject($"{type.Name}_{country}");
            if (localizableType == null) {
                localizableType = (byte[])Resources.ResourceManager.GetObject($"{type.Name}");
                if (localizableType == null)
                    localizableType = new byte[0];
            }
            json = JObject.Parse(Encoding.ASCII.GetString(localizableType));
        }
    }
}
