using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Holidays.Core {
    public class Locale {
        private JObject json;

        public string GetLocalizedStringFor(string key) {
            return json?.GetValue(key)?.Value<string>() ?? key;
        }

        public Locale(Type type, string country) {
            var assembly = Assembly.Load(new AssemblyName(GetType().Namespace));
            var localizableTypeManifestStream = assembly.GetManifestResourceStream($"{GetType().FullName}.{type.Name}-{country}.json");

            if (localizableTypeManifestStream == null) {
                localizableTypeManifestStream = assembly.GetManifestResourceStream($"{GetType().FullName}.{type.Name}.json");
                if (localizableTypeManifestStream == null) {
                    json = new JObject();
                    return;
                }
            }

            using (var jsonContentReader = new StreamReader(localizableTypeManifestStream, Encoding.UTF7)) {

                json = JObject.Parse(jsonContentReader.ReadToEnd());

            }

            localizableTypeManifestStream.Dispose();

        }
    }
}