using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class UrlOffset
    {
        [JsonProperty("index")]
        public int Index { get; set; }
 
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}