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

        public string Build()
        {
            builder.Append("]");

            return builder.ToString();
        }

        private void AppendString(string item)
        {
            if (builder.Length != 0)
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
