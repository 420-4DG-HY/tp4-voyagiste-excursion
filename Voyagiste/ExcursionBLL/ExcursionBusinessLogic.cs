using Microsoft.Extensions.Logging;
using CommonDataDTO;
using ExcursionDTO;
using ExcursionDAL;

//using CruiseDTO;

namespace ExcursionBLL
{
    public interface IExcursionBusinessLogic
    {
        public MeetingPoint[] GetAvailableMeetingPoint();
        public ExcursionAvailability[] GetExcursionAvailabilities(MeetingPoint MeetingPoint);
        public ExcursionBooking? GetExcursionBooking(Guid ExcursionBookingId);
        public MeetingPoint? GetMeetingPoint(Guid MeetingPointId);
        public Excursion? GetExcursion(Guid ExcursionId);
        public ExcursionBooking Book(Guid ExcursionId, DateTime From, Person rentedTo);

        public BookingConfirmation ConfirmBooking(ExcursionBooking ExcursionBooking);
        public BookingConfirmation? GetBookingConfirmation(ExcursionBooking ExcursionBooking);

        public BookingCancellation CancelBooking(ExcursionBooking ExcursionBooking);
        public BookingCancellation? GetBookingCancellation(ExcursionBooking ExcursionBooking);
    }
    public class ExcursionBusinessLogic : IExcursionBusinessLogic
    {
        readonly ILogger<ExcursionBusinessLogic> _logger;
        readonly IExcursionDataAccess _dal;

        public ExcursionBusinessLogic(IExcursionDataAccess DataAccess, ILogger<ExcursionBusinessLogic> Logger)
        {
            _dal = DataAccess;
            _logger = Logger;
        }

        public ExcursionBooking Book(Guid ExcursionId, DateTime From, Person rentedTo)
        {
            Excursion? Excursion = _dal.GetExcursion(ExcursionId);
            if (Excursion == null)
            {
                string message = "Invalid Excursion GUID : " + ExcursionId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            return _dal.Book(Excursion, From, rentedTo);
        }

        public BookingCancellation CancelBooking(ExcursionBooking cb)
        {
            // Libère la plage horaire de cette réservation
            _dal.AddExcursionAvailability(cb.Excursion, cb.BookedWhen, cb.traveler);
            CleanupAvailabilities(cb.Excursion);

            return _dal.CancelBooking(cb);
        }

        void CleanupAvailabilities(Excursion Excursion)
        {
            // ici on devrait éventuellement fusionner les disponibilités adjacentes
            // Une forme de défragmentation du calendrier après une annulation ou un retour prématuré de véhicule...

            ExcursionAvailability[]? availabilities = _dal.GetExcursionAvailabilities(Excursion);

            // On identifie les disponibilités adjacentes 
            // On les supprime et crée une nouvelle disponibilité qui les remplace
        }

        #region Les autres méthodes sont simplement des délégations au DAL
        public BookingConfirmation ConfirmBooking(ExcursionBooking cb)
        {
            return _dal.ConfirmBooking(cb);
        }

        public MeetingPoint[] GetAvailableMeetingPoint()
        {
            return _dal.GetAvailableMeetingPoint();
        }

        public BookingCancellation? GetBookingCancellation(ExcursionBooking ExcursionBooking)
        {
            return _dal.GetBookingCancellation(ExcursionBooking);
        }

        public BookingConfirmation? GetBookingConfirmation(ExcursionBooking ExcursionBooking)
        {
            return _dal.GetBookingConfirmation(ExcursionBooking);
        }

        public ExcursionAvailability[] GetExcursionAvailabilities(MeetingPoint meetingPoint)
        {
            return _dal.GetExcursionAvailabilities(meetingPoint);
        }

        public ExcursionBooking? GetExcursionBooking(Guid ExcursionBookingId)
        {
            return _dal.GetExcursionBooking(ExcursionBookingId);
        }

        public ExcursionBooking[] GetExcursionBookings(Excursion Excursion)
        {
            return _dal.GetExcursionBookings(Excursion);
        }

        public Excursion? GetExcursion(Guid ExcursionId)
        {
            return _dal.GetExcursion(ExcursionId);
        }

        public MeetingPoint? GetMeetingPoint(Guid MeetingPointId)
        {
            return _dal.GetMeetingPoint(MeetingPointId);
        }
        #endregion
    }
}