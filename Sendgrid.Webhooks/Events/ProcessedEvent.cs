using System;
using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Events
{
    public class ProcessedEvent : DeliveryEventBase
    {
        [JsonProperty("send_at"), JsonConverter(typeof(EpochToDateTimeConverter))]
        public DateTime SendAt { get; set; }
    }
}