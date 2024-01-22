using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Holidays {
    public class Locale {
        private JObject json;

        public string GetLocalizedStringFor(string key) {
            return json?.GetValue(key)?.Value<string>() ?? key;
        }

        public Locale(JObject json) {
            this.json = json;
        }

        public static Locale LoadEmbeddedFor(Type type, string country) {
            var assembly = type.Assembly;
            var localizableTypeManifestStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{typeof(Locale).Name}.{type.Name}-{country}.json");

            if (localizableTypeManifestStream == null)
            {
                localizableTypeManifestStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{typeof(Locale).Name}.{type.Name}.json");
                if (localizableTypeManifestStream == null)
                {
                    var json = new JObject();
                    return new Locale(json);
                }
            }

            using (var jsonContentReader = new StreamReader(localizableTypeManifestStream, Encoding.UTF8))
            {
                var json = JObject.Parse(jsonContentReader.ReadToEnd());
                localizableTypeManifestStream.Dispose();
                return new Locale(json);
            }            

        }
    }
}
