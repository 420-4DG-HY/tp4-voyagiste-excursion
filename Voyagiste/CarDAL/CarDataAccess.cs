using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CarDTO;

using CommonDataDTO;

namespace CarDAL
{
    public interface ICarDataAccess
    {
        public CarModel[] GetAvailableCarModels();
        public CarModel? GetCarModel(Guid CarModelId);
        public Car? GetCar(Guid CarId);
        public CarAvailability[] GetCarAvailabilities(CarModel model);
        public CarAvailability[] GetCarAvailabilities(Car car);
        public CarAvailability AddCarAvailability(Car car, DateTime From, DateTime To);
        public CarBooking? GetCarBooking(Guid CarBookingId);
        public CarBooking[] GetCarBookings(Person rentedTo);
        public CarBooking[] GetCarBookings(Car car);
        public CarBooking Book(Car Car, DateTime From, DateTime To, Person rentedTo);

        public BookingConfirmation ConfirmBooking(CarBooking booking);
        public BookingConfirmation? GetBookingConfirmation(CarBooking booking);

        public BookingCancellation CancelBooking(CarBooking booking);
        public BookingCancellation? GetBookingCancellation(CarBooking booking);
    }

    public class CarDataAccess : ICarDataAccess
    {
        private IConfiguration _configuration;
        private ILogger _logger;

        public CarDataAccess(IConfiguration configuration, ILogger<CarDataAccess> logger)
        {
            _configuration = configuration; // Permet éventuellement de recevoir ici la connexion string pour la base de données
            _logger = logger;
        }

        /// <summary>
        /// Enregistre une réservation de voiture
        /// 
        /// Attention, les disponibilités ne sont pas gérés par le DAL
        /// </summary>
        public CarBooking Book(Car Car, DateTime From, DateTime To, Person rentedTo)
        {
            var booking = new CarBooking(new Guid(), Car, From, To, rentedTo, new DateTime());
            FakeData.GetInstance().carBookings.Add(booking);    
            return booking;
        }

        /// <summary>
        /// Enregistre une cancellation de voiture
        /// 
        /// Attention, la gestion du retrait de booking et les remises en disponibilités ne sont pas gérés par le DAL
        /// </summary>
        public BookingCancellation CancelBooking(CarBooking booking)
        {
            BookingCancellation bc = new BookingCancellation(new Guid(), booking , new DateTime());
            FakeData.GetInstance().bookingCancellations.Add(bc);
            return bc;
        }

        public BookingConfirmation ConfirmBooking(CarBooking booking)
        {
            BookingCancellation? bBancel = GetBookingCancellation(booking);
            if (bBancel != null)
            {
                string message = "Cannot confirm booking : \n" + booking +" \nBecause it has been cancelled by : \n" + bBancel;
                _logger.LogError(message);
                throw new Exception(message);
            }
            else
            {
                BookingConfirmation bc = new BookingConfirmation(new Guid(), booking, new DateTime());
                FakeData.GetInstance().bookingConfirmations.Add(bc);
                return bc;
            }
        }

        public CarAvailability[] GetCarAvailabilities(CarModel model)
        {
            return FakeData.GetInstance().carAvailabilities.Where(ca => ca.Car.model == model).ToArray();
        }

        public CarBooking? GetCarBooking(Guid CarBookingId)
        {
            return FakeData.GetInstance().carBookings.Where(cb => cb.CarBookingId == CarBookingId).FirstOrDefault();
        }

        public CarBooking[] GetCarBookings(Car car)
        {
            return FakeData.GetInstance().carBookings.Where(cb => cb.Car == car).ToArray();
        }

        public CarModel[] GetAvailableCarModels()
        {
            return FakeData.car.Select(cm => cm.model).Distinct().ToArray();
        }

        public BookingConfirmation? GetBookingConfirmation(CarBooking booking)
        {
            return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public BookingCancellation? GetBookingCancellation(CarBooking booking)
        {
            return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public CarBooking[] GetCarBookings(Person rentedTo)
        {
            return FakeData.GetInstance().carBookings.Where(cb => cb.rentedTo == rentedTo).ToArray();
        }

        public Car? GetCar(Guid CarId)
        {
            return FakeData.car.Where(car => car.CarId == CarId).FirstOrDefault();
        }

        public CarAvailability[] GetCarAvailabilities(Car car)
        {
            return FakeData.GetInstance().carAvailabilities.Where(ca => ca.Car == car).ToArray();
        }

        public CarAvailability AddCarAvailability(Car car, DateTime From, DateTime To)
        {
            CarAvailability ca = new CarAvailability(new Guid(), car, From, To);
            FakeData.GetInstance().carAvailabilities.Add(ca);
            return ca;
        }

        public CarModel? GetCarModel(Guid CarModelId)
        {
            return FakeData.carModels.Where(cm=>cm.CarModelId == CarModelId).FirstOrDefault();
        }
    }
}
