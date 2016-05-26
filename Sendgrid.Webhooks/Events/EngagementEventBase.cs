using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Events
{
    public abstract class EngagementEventBase : WebhookEventBase
    {
        [JsonProperty("useragent")]
        public string UserAgent { get; set; }                
    }
}