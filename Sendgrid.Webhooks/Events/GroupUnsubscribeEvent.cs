using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class GroupUnsubscribeEvent : EngagementEventBase
    {
        [JsonProperty("asm_group_id")]
        public int GroupId { get; set; }
    }
}