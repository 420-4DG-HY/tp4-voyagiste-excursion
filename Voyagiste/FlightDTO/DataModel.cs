using CommonDataDTO;
namespace FlightDTO
{

    public record Airport(string IATACode, string AirportName, Address AirportAddress);
    public record AirLine(Guid AireLineId, string AirLineName);
    public record Flight(Guid FlightId, AirLine AirLine, string FlightNumber, Airport DepartureAirport, DateTime DepartureDate, Airport ArrivalAiport, DateTime ArrivalDate);

    public record FlightBooking(Guid FlightBookingId, Flight Flight, Person Passenger, DateTime BookedWhen) : Booking(FlightBookingId, Passenger,BookedWhen);

}
