using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class DeferredEvent : DeliveryEventBase
    {
        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("attempt")]
        public string Attempts { get; set; }
    }
}