using System.Text.Json.Serialization;
using System.Text.Json;

namespace Domain.Helpers
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        public static string ToJson(this object obj) =>
            JsonSerializer.Serialize(obj, _options);
    }

}
