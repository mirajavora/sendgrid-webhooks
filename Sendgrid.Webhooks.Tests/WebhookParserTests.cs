using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Parse_Click_Event()
        {
            var json = new JsonEventBuilder().AppendClick().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(ClickEvent));
            var bounceEvent = result[0] as ClickEvent;
            Assert.AreEqual("http://yourdomain.com/blog/news.html", bounceEvent.Url);
        }

        [Test]
        public void Parse_Deferred_Event()
        {
            var json = new JsonEventBuilder().AppendDeferred().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(DeferredEvent));
            var deferredEvent = result[0] as DeferredEvent;
            Assert.AreEqual("400 Try again", deferredEvent.Response);
            Assert.AreEqual("10", deferredEvent.Attempts);
        }

        [Test]
        public void Parse_Delivered_Event()
        {
            var json = new JsonEventBuilder().AppendDelivered().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(DeliveryEvent));;
        }

        [Test]
        public void Parse_Drop_Event()
        {
            var json = new JsonEventBuilder().AppendDrop().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(DroppedEvent));
            var dropEvent = result[0] as DroppedEvent;
            Assert.AreEqual("Bounced Address", dropEvent.Reason);
        }

        [Test]
        public void Parse_Open_Event()
        {
            var json = new JsonEventBuilder().AppendOpen().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(OpenEvent)); ;
        }


        [Test]
        public void Parse_Processed_Event()
        {
            var json = new JsonEventBuilder().AppendProcessed().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(ProcessedEvent));
        }

        [Test]
        public void Parse_SpamReport_Event()
        {
            var json = new JsonEventBuilder().AppendSpamReport().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(SpamReportEvent));
        }

        [Test]
        public void Parse_Unsubscribe_Event()
        {
            var json = new JsonEventBuilder().AppendUnsubscribe().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(UnsubscribeEvent));
        }

        [Test]
        public void Parse_Group_Resubscribe_Event()
        {
            var json = new JsonEventBuilder().AppendGroupResubscribe().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(GroupResubscribeEvent));
            var castEvent = result[0] as GroupResubscribeEvent;
            Assert.AreEqual(1, castEvent.GroupId);
        }

        [Test]
        public void Parse_Group_Unsubscribe_Event()
        {
            var json = new JsonEventBuilder().AppendGroupUnsubscribe().Build();
            var result = parser.ParseEvents(json);

            AssertCommonProperties(result, typeof(GroupUnsubscribeEvent));
            var castEvent = result[0] as GroupUnsubscribeEvent;
            Assert.AreEqual(1, castEvent.GroupId);
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

            //has correct timestamp
            Assert.AreEqual(new DateTime(2009, 08, 11, 0, 0, 0, DateTimeKind.Utc), webhookEvent.TimeStamp);
        }
    }
}