using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Converters
{
    public abstract class GenericListCreationJsonConverter<T> : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<List<T>>(reader);
            }
            else
            {
                T t = serializer.Deserialize<T>(reader);
                return new List<T>(new[] {t});
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}