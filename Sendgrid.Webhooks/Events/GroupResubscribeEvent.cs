using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public class GroupResubscribeEvent : EngagementEventBase
    {
        [JsonProperty("asm_group_id")]
        public string GroupId { get; set; }
    }
}