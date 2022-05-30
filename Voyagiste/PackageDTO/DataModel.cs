using CommonDataDTO;
using CarDTO;
using CruiseDTO;
using ExcursionDTO;
using FlightDTO;
using HotelDTO;
using TrainDTO;

namespace PackageDTO
{
    // Produits
    public record Option(Guid OptionId);
    public record CarOption(Guid OptionId, Car Car): Option(OptionId);
    // public record ExcursionOption(Guid Guid, Excursion excursion) : Option(Guid);
    public record CruiseOption(Guid Guid, Cruise Cruise) : Option(Guid);
    public record FlightOption(Guid Guid, Flight OtherFlight) : Option(Guid);
    public record HotelOption(Guid Guid, Hotel OtherHotel) : Option(Guid);
    public record Package(Guid PackageId,string Name, Flight Outbound, Flight Inbound, Hotel hotel, Option[] Options);

    // Réservations
    public record OptionBooked(Guid OptionBookingId);
    public record CarOptionBooking(Guid OptionBookingId, CarBooking CarBooking) : Option(OptionBookingId);
    // public record ExcursionOptionBooking(Guid optionBookingId, ExcursionBooking excursionBooking) : Option(optionBookingId);
    // public record FlightOptionBooking(Guid optionBookingId, FlightBooking otherFlightBooking) : Option(optionBookingId);
    // public record HotelOptionBooking(Guid optionBookingId, HotelBooking otherHotelBooking) : Option(optionBookingId);
    public record PackageBooking(Guid PackageBookingId,Person Person, FlightBooking OutboundBooking, FlightBooking InboundBooking,HotelBooking HotelBooking, OptionBooked[] OptionsBooked,DateTime BookedWhen) :Booking(PackageBookingId,Person,BookedWhen);
}