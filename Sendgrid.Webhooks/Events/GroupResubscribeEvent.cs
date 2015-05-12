using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class GroupResubscribeEvent : EngagementEventBase
    {
        [JsonProperty("asm_group_id")]
        public int GroupId { get; set; }
    }
}