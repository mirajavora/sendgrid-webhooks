using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;
using Sendgrid.Webhooks.Events;

namespace Sendgrid.Webhooks.Service
{
    public class WebhookParser
    {
        private readonly IEnumerable<JsonConverter>_converters; 

        public WebhookParser()
        {
            _converters = new List<JsonConverter>{ new WebhookJsonConverter() };
        }

        public WebhookParser(IEnumerable<JsonConverter>converters)
        {
            _converters = converters;
        }

        public IList<WebhookEventBase> ParseEvents(String json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<WebhookEventBase>>(json, _converters);
        }
    }
}
