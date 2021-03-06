using CommonDataDTO;
namespace HotelDTO
{

    public record Room(Guid RoomId, Hotel Hotel, string RoomName);
    public record Hotel(Guid HotelId, Address HotelAddress);
    public record HotelBooking(Guid HotelBookingId, Room Room, Person Guest, DateTime BookedWhen) : Booking(HotelBookingId, Guest,BookedWhen);

}
