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
    public class BooleanConverterTests
    {
        private BooleanConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new BooleanConverter();
        }

        [TestCase(typeof(bool), true)]
        [TestCase(typeof(string), false)]
        public void CanConvert_Boolean_Only(Type tested, bool expected)
        {
            var result = _converter.CanConvert(tested);
            Assert.AreEqual(expected, result);
        }

        [TestCase("0", false)]
        [TestCase("1", true)]
        public void ReadJson_String_ConvertsToBoolean(String value, bool expected)
        {
            var reader = new JTokenReader(new JValue(value));
            reader.Read();
            var result = _converter.ReadJson(reader, typeof (String), null, new JsonSerializer());

            Assert.AreEqual(expected, result);
        }

        [TestCase("0", false)]
        [TestCase("1", true)]
        public void WriteJson_Bool_ConvertsToString(String expected, bool value)
        {
            var stringBuilder = new StringBuilder();
            _converter.WriteJson(new JsonTextWriter(new StringWriter(stringBuilder)), value, new JsonSerializer());

            Assert.AreEqual(expected, stringBuilder.ToString());
        }
    }
}