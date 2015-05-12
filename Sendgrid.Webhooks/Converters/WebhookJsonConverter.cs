using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sendgrid.Webhooks.Events;

namespace Sendgrid.Webhooks.Converters
{
    public class WebhookJsonConverter : JsonConverter
    {
        private static readonly string[] KnownProperties = {"event", "email", "category", "timestamp", "ip", "useragent"};

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var webhookItem = jsonObject.ToObject<ProcessedEvent>(serializer);

            AddUnmappedPropertiesAsUnique(webhookItem, jsonObject);

            return webhookItem;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (WebhookEventBase);
        }

        private void AddUnmappedPropertiesAsUnique(WebhookEventBase webhookEvent, JObject jObject)
        {
            var dict = jObject.ToObject<Dictionary<string, object>>();

            foreach (var o in dict)
            {
                if(KnownProperties.Contains(o.Key))
                    continue;

                webhookEvent.UniqueParameters.Add(o.Key, o.Value.ToString());
            }
        }
    }
}