using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public abstract class WebhookEventBase
    {
        [JsonProperty("event")]
        public WebhookEventType EventType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}