using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace marketplace.Utilities.DataUtils
{
    public class DocumentUtils
    {
        public static List<T> ConvertJsonToObjectByJsonFile<T>(IFormFile file)
        {
            var stream = file.OpenReadStream();
            var result = new List<T>();
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                result = JsonSerializer.Deserialize<List<T>>(json);
            }
            return result;
        }
    }
}