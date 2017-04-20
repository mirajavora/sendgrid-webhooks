using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using Sendgrid.Webhooks.Converters;
using Sendgrid.Webhooks.Service;

namespace Sendgrid.Webhooks.Events
{
    public abstract class WebhookEventBase
    {
        public WebhookEventBase()
        {
            UniqueParameters = new Dictionary<string, string>();
        }

        [JsonProperty("sg_message_id")]
        public string SgMessageId { get; set; }

        [JsonProperty("sg_event_id")]
        public string SgEventId { get; set; }

        [JsonProperty("event"), JsonConverter(typeof(StringEnumConverter))]
        public WebhookEventType EventType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("category"), JsonConverter(typeof(WebhookCategoryConverter))]
        public IList<string> Category { get; set; }

        [JsonProperty("timestamp"), JsonConverter(typeof(EpochToDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        public IDictionary<string, string> UniqueParameters { get; set; }
    }
}
