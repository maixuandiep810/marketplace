using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace marketplace.Utilities.DataUtils
{
    public static class HttpUtils
    {
        public static StringContent GetJsonStringContent<T>(T dataObject, Encoding encoding, string mediaType)
        {
            var json = JsonSerializer.Serialize(dataObject);
            var httpContent = new StringContent(json, encoding, mediaType);
            return httpContent;
        }

        public static StringContent GetApplicationJsonUTF8<T>(T dataObject)
        {
            return GetJsonStringContent<T>(dataObject, Encoding.UTF8, "application/json");
        }
    }
}