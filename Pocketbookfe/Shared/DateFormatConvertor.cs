using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pocketbookfe.Shared
{
    public class DateFormatConverter : JsonConverter<DateTime>
    {
        private readonly string Format;
        public DateFormatConverter(string format)
        {
            Format = format;
        }
        public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
        {
            writer.WriteStringValue(date.ToString(Format));
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }
    }
}
