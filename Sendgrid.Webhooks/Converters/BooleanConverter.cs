using Newtonsoft.Json;
using System;

namespace Sendgrid.Webhooks.Converters
{
    public class BooleanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var booleanValue = (Boolean) value;
            writer.WriteValue(booleanValue ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return !reader.Value.Equals("0");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Boolean);
        }
    }
}