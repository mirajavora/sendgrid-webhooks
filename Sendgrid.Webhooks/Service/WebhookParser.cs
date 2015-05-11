using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;
using Sendgrid.Webhooks.Events;

namespace Sendgrid.Webhooks.Service
{
    public class WebhookParser
    {
        private JsonConverter[] converters; 

        public WebhookParser()
        {
            converters = new JsonConverter[] { new WebhookJsonConverter() };
        }

        public IList<WebhookEventBase> ParseEvents(String json)
        {
            return JsonConvert.DeserializeObject<IList<WebhookEventBase>>(json, converters);
        }
    }
}