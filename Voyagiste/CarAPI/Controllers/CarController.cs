using Microsoft.AspNetCore.Mvc;
using CarBLL;
using CarDTO;
using CommonDataDTO;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        readonly ILogger<CarController> _logger;
        readonly ICarBusinessLogic _bll;

        public CarController(ICarBusinessLogic BusinessLogic, ILogger<CarController> Logger)
        {
            _bll = BusinessLogic;
            _logger = Logger;
        }

        [HttpGet("GetAvailableCarModels")]
        public CarModel[] GetAvailableCarModels()
        {
            return _bll.GetAvailableCarModels();
        }

        [HttpGet("CarAvailabilities/{CarModelGuid}")]
        public CarAvailability[] GetCarAvailabilities(Guid CarModelGuid)
        {
            if (CarModelGuid != null)
            {
                CarModel? cm = _bll.GetCarModel(CarModelGuid);
                if (cm != null)
                {
                    return _bll.GetCarAvailabilities(cm);
                }
            }

            // Aucun résultat
            return new List<CarAvailability>().ToArray();
        }

        [HttpGet("Car/{CarId}")]
        public Car? GetCar(Guid CarId)
        {
            var car = _bll.GetCar(CarId);
            return car;
        }

        [HttpPost("Book")]
        public CarBooking Book(Guid CarId, DateTime From, DateTime To, Person rentedTo)
        {
            return _bll.Book(CarId, From, To, rentedTo);
        }
    }
}