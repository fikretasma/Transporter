using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Transporter.Core
{
    public static class ObjectExtensions
    {
        private static JsonSerializerSettings JsonSerializerSettings { get; } = new()
        {
            //ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            Converters = new List<JsonConverter> {new StringEnumConverter {CamelCaseText = true}}
        };

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
        }

        public static T ToObject<T>(this string serializedJson)
        {
            return JsonConvert.DeserializeObject<T>(serializedJson, JsonSerializerSettings);
        }
    }
}