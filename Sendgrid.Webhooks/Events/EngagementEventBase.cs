using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public abstract class EngagementEventBase : WebhookEventBase
    {
        [JsonProperty("useragent")]
        public string UserAgent { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}