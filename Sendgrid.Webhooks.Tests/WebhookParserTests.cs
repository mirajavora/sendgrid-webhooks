using NUnit.Framework;
using Sendgrid.Webhooks.Service;

namespace Sendgrid.Webhooks.Tests
{
    [TestFixture]
    public class WebhookParserTests
    {
        private WebhookParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new WebhookParser();
        }

        [Test]
        public void Parse_Processed_Event()
        {
            var json = new JsonEventBuilder().AppendProcessed().Build();
            var result = parser.ParseEvents(json);

            Assert.IsNotNull(result);
        }
    }
}