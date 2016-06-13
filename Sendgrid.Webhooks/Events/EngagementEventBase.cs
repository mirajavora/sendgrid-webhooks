using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Events
{
    public abstract class EngagementEventBase : WebhookEventBase
    {
        [JsonProperty("useragent")]
        public string UserAgent { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonConverter(typeof(BooleanConverter))]
        [JsonProperty("tls")]
        public bool Tls { get; set; }

        [JsonConverter(typeof(BooleanConverter))]
        [JsonProperty("cert_err")]
        public bool CertificateError { get; set; }
    }
}