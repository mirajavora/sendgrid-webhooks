using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;
using System;

namespace Sendgrid.Webhooks.Events
{
    public class ProcessedEvent : DeliveryEventBase
    {
        [JsonProperty("send_at"), JsonConverter(typeof(EpochToDateTimeConverter))]
        public DateTime SentAt { get; set; }
    }
}