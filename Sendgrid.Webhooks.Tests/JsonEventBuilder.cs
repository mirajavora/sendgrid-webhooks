using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sendgrid.Webhooks.Tests
{
    public class JsonEventBuilder
    {
        private StringBuilder builder;
        private String baseDirectory;

        public JsonEventBuilder()
        {
            builder = new StringBuilder("[");
            baseDirectory = Path.Combine(GetAssemblyDirectory().Parent.FullName, "Events");
        }

        public JsonEventBuilder AppendProcessed()
        {
            AppendString(ReadContent("processed.json"));
            return this;
        }

        public JsonEventBuilder AppendBounce()
        {
            AppendString(ReadContent("bounce.json"));
            return this;
        }

        public JsonEventBuilder AppendBounceNull()
        {
            AppendString(ReadContent("bounce-null.json"));
            return this;
        }

        public JsonEventBuilder AppendClick()
        {
            AppendString(ReadContent("click.json"));
            return this;
        }

        public JsonEventBuilder AppendDeferred()
        {
            AppendString(ReadContent("deferred.json"));
            return this;
        }

        public JsonEventBuilder AppendDelivered()
        {
            AppendString(ReadContent("delivered.json"));
            return this;
        }

        public JsonEventBuilder AppendDrop()
        {
            AppendString(ReadContent("drop.json"));
            return this;
        }

        public JsonEventBuilder AppendGroupResubscribe()
        {
            AppendString(ReadContent("group_resubscribe.json"));
            return this;
        }

        public JsonEventBuilder AppendGroupUnsubscribe()
        {
            AppendString(ReadContent("group_unsubscribe.json"));
            return this;
        }

        public JsonEventBuilder AppendOpen()
        {
            AppendString(ReadContent("open.json"));
            return this;
        }

        public JsonEventBuilder AppendSpamReport()
        {
            AppendString(ReadContent("spamreport.json"));
            return this;
        }

        public JsonEventBuilder AppendUnsubscribe()
        {
            AppendString(ReadContent("unsubscribe.json"));
            return this;
        }

        public string Build()
        {
            builder.Append("]");

            return builder.ToString();
        }

        private void AppendString(string item)
        {
            if (builder.Length > 1)
                builder.Append(",");

            builder.Append(item);
        }

        private String ReadContent(string filename)
        {
            var path = Path.Combine(baseDirectory, filename);
            return File.ReadAllText(path);
        }

        //move out to helper
        private static DirectoryInfo GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return new DirectoryInfo(path);
        }
    }
}
