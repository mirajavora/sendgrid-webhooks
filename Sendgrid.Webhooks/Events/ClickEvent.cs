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

    public class UrlOffset
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}