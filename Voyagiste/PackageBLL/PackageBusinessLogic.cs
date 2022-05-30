using PackageDAL;
using PackageDTO;
using CommonDataDTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PackageBLL
{
    public interface IPackageBusinessLogic
    {
        public Package BookAsPackage(Booking[] bookings);
        public BookingConfirmation[] ConfirmPackage(Booking booking);
        public BookingCancellation[] CancelPackage(Booking booking);
    }

    public class PackageBusinessLogic : IPackageBusinessLogic
    {
        readonly ILogger<PackageBusinessLogic> _logger;
        IPackageDataAccess _DataAccess;
        public PackageBusinessLogic(IConfiguration configuration, ILogger<PackageBusinessLogic> Logger, IPackageDataAccess DataAccess)
        {
            _DataAccess = DataAccess;
            _logger = Logger;
        }

        public Package BookAsPackage(Booking[] bookings)
        {
            // Créer un nouveau forfait sur mesure
            throw new NotImplementedException();
        }

        public BookingCancellation[] CancelPackage(Booking booking)
        {
            // Traverser l'ensemble des réservations et les annuler
            // Annuler le forfait
            throw new NotImplementedException();
        }

        public BookingConfirmation[] ConfirmPackage(Booking booking)
        {
            // Ici normalement on devrait faire une transaction en 2 phases
            // Confirmer l'ensemble des bookings
            // Annuller les confirmations précédentes si une confirmation échoue
            throw new NotImplementedException();
        }
    }
}