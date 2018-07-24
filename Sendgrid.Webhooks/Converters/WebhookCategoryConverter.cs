using System;
using Newtonsoft.Json;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Service
{
    public class WebhookCategoryConverter : GenericListCreationJsonConverter<string>
    {
    }
}
