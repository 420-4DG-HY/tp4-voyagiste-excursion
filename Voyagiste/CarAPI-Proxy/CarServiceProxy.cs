using Microsoft.Extensions.Logging;
using CarDTO;

namespace CarService
{
    public interface ICarService
    {
        public Task<IEnumerable<VehicleSize>> GetVehicleSizes();
    }

    public class CarServiceProxy : ICarService
    {
        private readonly ILogger _logger;

        public CarServiceProxy(ILogger<CarServiceProxy> logger)
        {
            _logger=logger;
        }

        public async Task<IEnumerable<VehicleSize>> GetVehicleSizes()
        {
            // TODO Appeler le CarAPI
            int itemCount=0;

            _logger.LogInformation("GetVehicleSizes() => "+ itemCount + " items");
            return new List<VehicleSize>();
        }
    }
}