using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using NUnit.Framework;
using Sendgrid.Webhooks.Events;
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
        public void Parse_Bounce_Event()
        {
            var json = new JsonEventBuilder().AppendBounce().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(BounceEvent));
            var bounceEvent = result[0] as BounceEvent;
            Assert.AreEqual("500 No Such User", bounceEvent.Reason);
            Assert.AreEqual("bounce", bounceEvent.BounceType);
        }

        [Test]
        public void Parse_Processed_Event()
        {
            var json = new JsonEventBuilder().AppendProcessed().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(ProcessedEvent));
        }

        private void AssertCommonProperties(IList<WebhookEventBase> result, Type expectedType)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            var webhookEvent = result.FirstOrDefault();
            Assert.IsNotNull(webhookEvent);
            Assert.IsTrue(webhookEvent.GetType() == expectedType, "Expected type of: {0}", expectedType);

            //has unique keys
            Assert.IsTrue(webhookEvent.UniqueParameters.ContainsKey("unique_arg_key"));
            Assert.AreEqual("unique_arg_value", webhookEvent.UniqueParameters["unique_arg_key"]);

            //has categories
            Assert.IsNotNull(webhookEvent.Category);
            Assert.AreEqual(2, webhookEvent.Category.Count);
            CollectionAssert.AreEquivalent(webhookEvent.Category, new[] {"category1", "category2"});
        }
    }
}