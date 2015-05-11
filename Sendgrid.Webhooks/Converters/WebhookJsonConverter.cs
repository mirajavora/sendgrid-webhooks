using System;
using Newtonsoft.Json;
using Sendgrid.Webhooks.Events;

namespace Sendgrid.Webhooks.Converters
{
    public class WebhookJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            
            return serializer.Deserialize<ProcessedEvent>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (WebhookEventBase);
        }
    }
}