using CommonDataDTO;

namespace TrainDTO
{
    public record Seat(Guid SeatId, string Name, SeatType SeatType); // Siège assigné, incluant le numéro de wagon
    public record SeatType(Guid SeatTypeId, string Name, string Description); // Allée, fenêtre, sortie de secours,...
    public record TrainOperator(Guid TrainOperatorId, string Name); // ViaRail, Amtrak, ...
    public record TrainLine(Guid TrainLineId, string Name, TrainOperator Operator, TrainStation[] Stations);// Une station peut être partagée entre plusieurs ligne (connexions)
    public record TrainStation(Guid TrainStationId, string Name, Address Address); 

    // Permet de construire l'horaire des trains pour une journée/trajet donné
    // Chaque départ de chaque jour doit avoir son entrée
    public record TrainSchedule(Guid TrainScheduleId, string Name, TrainLine Line, TrainStation StartStation, TrainStation EndStation, DateTime[] StationDepartureTimes );
    public record TrainAvailability(Guid TrainAvailabilityId, TrainSchedule Schedule, Seat Seat);
    public record TrainBooking(Guid TrainBookingId, Person Passenger, TrainAvailability Availability, DateTime BookedWhen) :Booking(TrainBookingId,Passenger,BookedWhen);
}