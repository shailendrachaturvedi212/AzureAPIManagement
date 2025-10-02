using AzureAPIManagement;
using Microsoft.AspNetCore.Mvc;

namespace DeviceCatalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceCatalogueController : ControllerBase
    {
        private List<Device> catalogue = new();

        private JsonDBHelper jsonDBHelper = new();

        private readonly ILogger<DeviceCatalogueController> _logger;

        public DeviceCatalogueController(ILogger<DeviceCatalogueController> logger)
        {
            _logger = logger;

            // load the catalogue from the json database each time the API is called
            catalogue = jsonDBHelper.LoadFromDB();
        }

        [HttpGet(Name = "GetCatalogue")]
        public IEnumerable<Device> GetCatalogue()
        {
            return catalogue;
        }

        [HttpGet("{deviceId}", Name = "GetDevice")]
        public Device GetDevice(int deviceId)
        {
            var device = catalogue.SingleOrDefault(c => c.Id == deviceId);

            // save changed back to the json database
            jsonDBHelper.SaveToDB(catalogue);

            return device ?? new Device();
        }

        [HttpPost(Name = "AddDevice")]
        public Device AddDevice(Device device)
        {
            if (device == null)
                return new Device();

            int newId = catalogue.Any() ? catalogue.Max(c => c.Id) + 1 : 1;
            device.Id = newId;

            catalogue.Add(device);

            // save changes back to the json database
            jsonDBHelper.SaveToDB(catalogue);

            return device;
        }

        [HttpPut("{deviceId}/{newPrice}", Name = "UpdatePrice")]
        public Device UpdatePrice(int deviceId, double newPrice)
        {
            var device = catalogue.SingleOrDefault(c => c.Id == deviceId);
            if (device == null)
                return new Device();

            device.Price = newPrice;

            // save changes back to the json database
            jsonDBHelper.SaveToDB(catalogue);

            return device;
        }

        [HttpDelete("{deviceId}", Name = "DeleteDevice")]
        public void DeleteDevice(int deviceId)
        {
            var device = catalogue.SingleOrDefault(c => c.Id == deviceId);
            if (device != null)
            {
                catalogue.Remove(device);
            }

            // save changes back to the json database
            jsonDBHelper.SaveToDB(catalogue);
        }
    }
}