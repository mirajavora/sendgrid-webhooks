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
        //these will be filtered out from the UniqueParams
        private static readonly string[] KnownProperties = {"event", "email", "category", "timestamp", "ip", "useragent", "type", 
                                                               "reason", "status", "url", "url_offset", "send_at"};

        private static readonly IDictionary<string, Type> TypeMapping = new Dictionary<string, Type>()
        {
            {"processed", typeof(ProcessedEvent)},
            {"bounce", typeof(BounceEvent)},
            {"click", typeof(ClickEvent)},
            {"deferred", typeof(DeferredEvent)},
            {"delivered", typeof(DeliveryEvent)},
            {"dropped", typeof(DroppedEvent)},
            {"open", typeof(OpenEvent)},
            {"spamreport", typeof(SpamReportEvent)},
            {"unsubscribe", typeof(UnsubscribeEvent)},
            {"group_resubscribe", typeof(GroupResubscribeEvent)},
            {"group_unsubscribe", typeof(GroupUnsubscribeEvent)}
        };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("The webhook JSON converter does not support write operations.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            //serialise based on the event type
            JToken eventName = null;
            jsonObject.TryGetValue("event", StringComparison.CurrentCultureIgnoreCase, out eventName);

            if (!TypeMapping.ContainsKey(eventName.ToString()))
                throw new NotImplementedException(string.Format("Event {0} is not implemented yet.", eventName));

            Type type = TypeMapping[eventName.ToString()];
            WebhookEventBase webhookItem = (WebhookEventBase)jsonObject.ToObject(type, serializer);

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
                if (KnownProperties.Contains(o.Key))
                    continue;

                webhookEvent.UniqueParameters.Add(o.Key, o.Value == null ? null : o.Value.ToString());
            }
        }
    }
}
