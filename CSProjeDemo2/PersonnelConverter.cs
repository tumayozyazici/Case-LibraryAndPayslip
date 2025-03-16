using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class PersonnelConverter : JsonConverter<Personnel>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Personnel);
        }

        public override Personnel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                string? type = root.GetProperty("Title").GetString();

                if (type == "Manager")
                {
                    return JsonSerializer.Deserialize<Manager>(root.GetRawText(), options);
                }
                else if (type == "Officer")
                {
                    return JsonSerializer.Deserialize<Officer>(root.GetRawText(), options);
                }
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, Personnel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
