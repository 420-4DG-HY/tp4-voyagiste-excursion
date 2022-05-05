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
    public record CruiseBooking(Guid CruiseBookingGuid, Person person);
}