using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;
using Sendgrid.Webhooks.Events;

namespace Sendgrid.Webhooks.Service
{
    public class WebhookParser
    {
        private readonly JsonConverter[] _converters; 

        public WebhookParser()
        {
            _converters = new JsonConverter[] { new WebhookJsonConverter() };
        }

        public WebhookParser(JsonConverter[] converters)
        {
            if (converters == null) {
                throw new ArgumentNullException(nameof(converters));
            }
            
            _converters = converters;
        }

        public IList<WebhookEventBase> ParseEvents(String json)
        {
            return JsonConvert.DeserializeObject<IList<WebhookEventBase>>(json, _converters);
        }
    }
}
