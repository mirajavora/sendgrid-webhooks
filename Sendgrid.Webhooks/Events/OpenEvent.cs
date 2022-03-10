using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Events
{
    public class OpenEvent : EngagementEventBase
    {
        [JsonConverter(typeof(BooleanConverter))]
        [JsonProperty("sg_machine_open")]
        public bool SgMachineOpen { get; set; } = false;
    }
}