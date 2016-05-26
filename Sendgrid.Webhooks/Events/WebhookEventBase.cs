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

        [JsonProperty("event"), JsonConverter(typeof(StringEnumConverter))]
        public WebhookEventType EventType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("category"), JsonConverter(typeof(WebhookCategoryConverter))]
        public IList<string> Category { get; set; }

        [JsonProperty("timestamp"), JsonConverter(typeof(EpochToDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonConverter(typeof(JsonBoolConverter))]
        [JsonProperty("tls")]
        public bool TLSUsed { get; set; }

        [JsonConverter(typeof(JsonBoolConverter))]
        [JsonProperty("cert_err")]
        public bool CertificateError { get; set; }

        public IDictionary<string, string> UniqueParameters { get; set; }
    }
}
