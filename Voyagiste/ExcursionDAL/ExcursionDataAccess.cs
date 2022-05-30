
using CommonDataDTO;
using ExcursionDTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExcursionDAL
{

    public interface IExcursionDataAccess
    {
        public MeetingPoint[] GetAvailableMeetingPoint();
        public MeetingPoint? GetMeetingPoint(Guid MeetingPointId);
        public Excursion? GetExcursion(Guid ExcursionId);
        public ExcursionAvailability[] GetExcursionAvailabilities(MeetingPoint model);
        public ExcursionAvailability[] GetExcursionAvailabilities(Excursion Excursion);
        public ExcursionAvailability AddExcursionAvailability(Excursion Excursion, DateTime BookedWhen, Person Traveler);
        public ExcursionBooking? GetExcursionBooking(Guid ExcursionBookingId);
        public ExcursionBooking[] GetExcursionBookings(Person Traveler);
        public ExcursionBooking[] GetExcursionBookings(Excursion Excursion);
        public ExcursionBooking Book(Excursion Excursion, DateTime From, Person Traveler);

        public BookingConfirmation ConfirmBooking(ExcursionBooking booking);
        public BookingConfirmation? GetBookingConfirmation(ExcursionBooking booking);

        public BookingCancellation CancelBooking(ExcursionBooking booking);
        public BookingCancellation? GetBookingCancellation(ExcursionBooking booking);
    }

    public class ExcursionDataAccess : IExcursionDataAccess
    {
        private IConfiguration _configuration;
        private ILogger _logger;

        public ExcursionDataAccess(IConfiguration configuration, ILogger<ExcursionDataAccess> logger)
        {
            _configuration = configuration; // Permet éventuellement de recevoir ici la connexion string pour la base de données
            _logger = logger;
        }

        /// <summary>
        /// Enregistre une réservation de voiture
        /// 
        /// Attention, les disponibilités ne sont pas gérés par le DAL
        /// </summary>
        public ExcursionBooking Book(Excursion Excursion, DateTime From, Person reservedTo)
        {
            var booking = new ExcursionBooking(new Guid(), Excursion, reservedTo, Excursion.ExcursionId, From, reservedTo.PersonId, new DateTime());
            FakeData.GetInstance().excursionBookings.Add(booking);
            return booking;
        }

        /// <summary>
        /// Enregistre une cancellation de voiture
        /// 
        /// Attention, la gestion du retrait de booking et les remises en disponibilités ne sont pas gérés par le DAL
        /// </summary>
        public BookingCancellation CancelBooking(ExcursionBooking booking)
        {
            BookingCancellation bc = new BookingCancellation(new Guid(), booking, new DateTime());
            FakeData.GetInstance().bookingCancellations.Add(bc);
            return bc;
        }

        public BookingConfirmation ConfirmBooking(ExcursionBooking booking)
        {
            BookingCancellation? bBancel = GetBookingCancellation(booking);
            if (bBancel != null)
            {
                string message = "Cannot confirm booking : \n" + booking + " \nBecause it has been cancelled by : \n" + bBancel;
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

        public ExcursionAvailability[] GetExcursionAvailabilities(MeetingPoint model)
        {
            return FakeData.GetInstance().excursionAvailabilities.Where(ca => ca.Excursion.MeetingPoint == model).ToArray();
        }

        public ExcursionBooking? GetExcursionBooking(Guid ExcursionBookingId)
        {
            return FakeData.GetInstance().excursionBookings.Where(cb => cb.ExcursionBookingId == ExcursionBookingId).FirstOrDefault();
        }

        public ExcursionBooking[] GetExcursionBookings(Excursion Excursion)
        {
            return FakeData.GetInstance().excursionBookings.Where(cb => cb.Excursion == Excursion).ToArray();
        }

        public MeetingPoint[] GetAvailableMeetingPoint()
        {
            return FakeData.excursion.Select(cm => cm.MeetingPoint).Distinct().ToArray();
        }

        public BookingConfirmation? GetBookingConfirmation(ExcursionBooking booking)
        {
            return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public BookingCancellation? GetBookingCancellation(ExcursionBooking booking)
        {
            return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public ExcursionBooking[] GetExcursionBookings(Person rentedTo)
        {
            return FakeData.GetInstance().excursionBookings.Where(cb => cb.Participant == rentedTo).ToArray();
        }

        public Excursion? GetExcursion(Guid ExcursionId)
        {
            return FakeData.excursion.Where(Excursion => Excursion.ExcursionId == ExcursionId).FirstOrDefault();
        }

        public ExcursionAvailability[] GetExcursionAvailabilities(Excursion Excursion)
        {
            return FakeData.GetInstance().excursionAvailabilities.Where(ca => ca.Excursion == Excursion).ToArray();
        }

        public ExcursionAvailability AddExcursionAvailability(Excursion Excursion, DateTime From, Person Traveler)
        {
            ExcursionAvailability ca = new ExcursionAvailability(new Guid(), Excursion, Excursion.ExcursionId, From, Traveler.PersonId);
            FakeData.GetInstance().excursionAvailabilities.Add(ca);
            return ca;
        }

        public MeetingPoint? GetMeetingPoint(Guid MeetingPointId)
        {
            return FakeData.meetingPoints.Where(cm => cm.MeetingPointId == MeetingPointId).FirstOrDefault();
        }
    }

}
