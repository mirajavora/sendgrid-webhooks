using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class GroupUnsubscribeEvent : EngagementEventBase
    {
        [JsonProperty("asm_group_id")]
        public string GroupId { get; set; }
    }
}