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
    public record Option(Guid optionId);
    public record CarOption(Guid optionId, Car car): Option(optionId);
    // public record ExcursionOption(Guid Guid, Excursion excursion) : Option(Guid);
    public record CruiseOption(Guid Guid, Cruise cruise) : Option(Guid);
    public record FlightOption(Guid Guid, Flight otherFlight) : Option(Guid);
    public record HotelOption(Guid Guid, Hotel otherHotel) : Option(Guid);
    public record Package(Guid packageId,string name, Flight outbound, Flight inbound, Hotel hotel, Option[] options);

    // Réservations
    public record OptionBooked(Guid optionBookingId);
    public record CarOptionBooking(Guid optionBookingId, CarBooking carBooking) : Option(optionBookingId);
    // public record ExcursionOptionBooking(Guid optionBookingId, ExcursionBooking excursionBooking) : Option(optionBookingId);
    // public record FlightOptionBooking(Guid optionBookingId, FlightBooking otherFlightBooking) : Option(optionBookingId);
    // public record HotelOptionBooking(Guid optionBookingId, HotelBooking otherHotelBooking) : Option(optionBookingId);
    // public record PackageBooking(Guid packageBookingId,Person person, FilgthBooking outboundBooking, FlightBooking inboundBooking,HotelBooking hotelBooking, OptionBooked[] optionsBooked)
}