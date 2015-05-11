using Newtonsoft.Json;
using System.Collections.Generic;
using Sendgrid.Webhooks.Service;

namespace Sendgrid.Webhooks.Events
{
    public abstract class WebhookEventBase
    {
        [JsonProperty("event")]
        public WebhookEventType EventType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("category"), JsonConverter(typeof(WebhookCategoryConverter))]
        public IList<string> Category { get; set; }
    }
}