using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class ClickEvent : EngagementEventBase
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_offset")]
        public UrlOffset UrlOffset { get; set; }
    }
}