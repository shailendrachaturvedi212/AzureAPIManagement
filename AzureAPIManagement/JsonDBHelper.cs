using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureAPIManagement
{
    public class JsonDBHelper
    {
       private string _jsonFile = "Catalogue.json";

            public JsonDBHelper()
            {
                if (!File.Exists(_jsonFile))
                {
                    File.WriteAllText(_jsonFile, JsonSerializer.Serialize(new List<Device>()));
                }
            }

            public void SaveToDB(List<Device> catalogue)
            {
                var json = JsonSerializer.Serialize(catalogue);
                File.WriteAllText(_jsonFile, json);
            }

            public List<Device> LoadFromDB()
            {
                if (!File.Exists(_jsonFile))
                    return new List<Device>();

                List<Device> catalogue =
                    JsonSerializer.Deserialize<List<Device>>(File.ReadAllText(_jsonFile));

                return catalogue;
            }
    }
}
