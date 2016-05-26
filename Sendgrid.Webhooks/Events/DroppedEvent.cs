using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class DroppedEvent : DeliveryEventBase
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string DropStatus { get; set; }
    }
}