using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Sendgrid.Webhooks.Converters;

namespace Sendgrid.Webhooks.Tests
{
    [TestFixture]
    public class EpochConverterTests
    {
        private EpochToDateTimeConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new EpochToDateTimeConverter();
        }

        [TestCase(typeof(DateTime), true)]
        [TestCase(typeof(string), false)]
        public void CanConvert_DateTime_Only(Type tested, bool expected)
        {
            var result = _converter.CanConvert(tested);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReadJson_Long_ConvertsToDate()
        {
            var reader = new JTokenReader(new JValue(123));
            reader.Read();
            var result = _converter.ReadJson(reader, typeof (long), null, new JsonSerializer());

            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 2, 3), result);
        }

        [Test]
        public void WriteJson_Date_ConvertsToEpoch()
        {
            var stringBuilder = new StringBuilder();
            _converter.WriteJson(new JsonTextWriter(new StringWriter(stringBuilder)), new DateTime(1980, 1, 1), new JsonSerializer());

            Assert.AreEqual("315532800", stringBuilder.ToString());
        }
    }
}