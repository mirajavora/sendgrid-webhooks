using System;
using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Converters
{
    public class EpochToDateTimeConverter : JsonConverter
    {
        private static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                return;

            var date = (DateTime) value;
            var diff = date - EpochDate;

            var secondsSinceEpoch = (int) diff.TotalSeconds;
            serializer.Serialize(writer, secondsSinceEpoch);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var timestamp = Convert.ToDouble(reader.Value);
            return EpochDate.AddSeconds(timestamp);
        }
    }
}