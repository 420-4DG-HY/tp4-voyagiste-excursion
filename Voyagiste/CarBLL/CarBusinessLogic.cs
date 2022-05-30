using CommonDataDTO;
using CarDTO;
using CarDAL;

using Microsoft.Extensions.Logging;
using CruiseDTO;

namespace CarBLL
{
    public interface ICarBusinessLogic
    {
        public CarModel[] GetAvailableCarModels();
        public CarAvailability[] GetCarAvailabilities(CarModel carModel);
        public CarBooking? GetCarBooking(Guid CarBookingId);
        public CarModel? GetCarModel(Guid CarModelId);
        public Car? GetCar(Guid CarId);
        public CarBooking Book(Guid CarId, DateTime From, DateTime To, Person rentedTo);

        public BookingConfirmation ConfirmBooking(CarBooking carBooking);
        public BookingConfirmation? GetBookingConfirmation(CarBooking carBooking);

        public BookingCancellation CancelBooking(CarBooking carBooking);
        public BookingCancellation? GetBookingCancellation(CarBooking carBooking);
    }
    public class CarBusinessLogic : ICarBusinessLogic
    {
        readonly ILogger<CarBusinessLogic> _logger;
        readonly ICarDataAccess _dal;

        public CarBusinessLogic(ICarDataAccess DataAccess, ILogger<CarBusinessLogic> Logger)
        {
            _dal = DataAccess;
            _logger = Logger;
        }

    public CarBooking Book(Guid CarId, DateTime From, DateTime To, Person rentedTo)
        {
            Car? car = _dal.GetCar(CarId);
            if (car == null)
            {
                string message = "Invalid Car GUID : " + CarId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            return _dal.Book(car, From, To, rentedTo);
        }

        public BookingCancellation CancelBooking(CarBooking cb)
        {
            // Libère la plage horaire de cette réservation
            _dal.AddCarAvailability(cb.Car, cb.From, cb.To);
            CleanupAvailabilities(cb.Car);
            
            return _dal.CancelBooking(cb);
        }

        void CleanupAvailabilities(Car car)
        {
            // ici on devrait éventuellement fusionner les disponibilités adjacentes
            // Une forme de défragmentation du calendrier après une annulation ou un retour prématuré de véhicule...

            CarAvailability[]? availabilities = _dal.GetCarAvailabilities(car);

            // On identifie les disponibilités adjacentes 
            // On les supprime et crée une nouvelle disponibilité qui les remplace
        }

        #region Les autres méthodes sont simplement des délégations au DAL
        public BookingConfirmation ConfirmBooking(CarBooking cb)
        {
            return _dal.ConfirmBooking(cb);
        }

        public CarModel[] GetAvailableCarModels()
        {
            return _dal.GetAvailableCarModels();
        }

        public BookingCancellation? GetBookingCancellation(CarBooking carBooking)
        {
            return _dal.GetBookingCancellation(carBooking);
        }

        public BookingConfirmation? GetBookingConfirmation(CarBooking carBooking)
        {
            return _dal.GetBookingConfirmation(carBooking);
        }

        public CarAvailability[] GetCarAvailabilities(CarModel model)
        {
            return _dal.GetCarAvailabilities(model);
        }

        public CarBooking? GetCarBooking(Guid CarBookingId)
        {
            return _dal.GetCarBooking(CarBookingId);
        }

        public CarBooking[] GetCarBookings(Car car)
        {
            return _dal.GetCarBookings(car);
        }

        public Car? GetCar(Guid CarId)
        {
            return _dal.GetCar(CarId);
        }

        public CarModel? GetCarModel(Guid CarModelId)
        {
            return _dal.GetCarModel(CarModelId);
        }
        #endregion
    }
}