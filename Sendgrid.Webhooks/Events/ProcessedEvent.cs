using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class ProcessedEvent : DeliveryEventBase
    {
        [JsonProperty("send_at")]
        public string SentAt { get; set; }
    }
}