using CommonDataDTO;

namespace CruiseDTO
{
    public record CruiseLine(Guid CruiseLineGuid, string name);
    public record Port(Guid PortGuid, string portName, Address portAddress);
    public record Ship(Guid ShipGuid, string name, Port homePort, CruiseLine? cruiseLine);
    public record Deck(Guid DeckGuid, Ship ship, string name);
    public record CabinType(Guid CabinTypeGuid, string name);
    public record Cabin(Guid CabinGuid, Deck deck, CabinType cabinType, string name);
    public record Cruise(Guid CruiseGuid,Ship ship, Deck deck, CabinType cabinType, Port departurePort, DateTime departureTime, Port arrivalPort, DateTime arrivalTime);

    // CruiseAvailability est instancié pour chaque cabine disponible
    // L'enregistrement CruiseAvailability est effacé quand la cabine esr réservée
    public record CruiseAvailability(Guid CruiseAvailabilityGuid, Cruise Cruise, Cabin Cabin);
    public record CruiseBooking(Guid CruiseBookingGuid, Person Person, Cruise Cruise, Cabin Cabin, DateTime BookedWhen) :Booking(CruiseBookingGuid,Person, BookedWhen);
}