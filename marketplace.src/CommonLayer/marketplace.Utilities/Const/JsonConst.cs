using System.Text.Json;

namespace marketplace.Utilities.Const
{
    public class JsonConst
    {
        public static JsonSerializerOptions JSON_SERIALIZER_OPTIONS = new JsonSerializerOptions { IgnoreNullValues = false, PropertyNameCaseInsensitive = true };
    }
}