using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Events
{
    public abstract class DeliveryEventBase : WebhookEventBase
    {
        [JsonProperty("smtp-id")]
        public string SmtpId { get; set; }

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