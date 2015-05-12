using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class BounceEvent : DeliveryEventBase
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("type")]
        public string BounceType { get; set; }
    }
}