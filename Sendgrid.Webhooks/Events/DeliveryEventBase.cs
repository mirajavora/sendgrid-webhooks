using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public abstract class DeliveryEventBase : WebhookEventBase
    {
        [JsonProperty("smtp-id")]
        public string SmtpId { get; set; }
    }
}