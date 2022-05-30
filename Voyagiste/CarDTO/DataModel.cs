using CommonDataDTO;

namespace CarDTO
{
    public record VehicleSize(int sizeCode, string description); // sizeCode = OpenTravel id
    public record CarManufacturer(Guid CarManufacturerId, string manufacturer); // Use brand not company
    public record CarModel(Guid CarModelId, VehicleSize size, CarManufacturer manufacturer, string model, int year);
    public record CarSpecifications(Guid CarSpecificationsId, bool automatic, bool fourWheelDrive, bool electric, bool gas, bool diesel);
    public record CarRentalCompany(Guid CarRentalCompanyId, string company);
    public record Car(Guid CarId, CarRentalCompany from, CarModel model, CarSpecifications specs,string vehicleId);

    public record CarAvailability(Guid CarAvailabilityId,Car Car, DateTime From, DateTime To);
    public record CarBooking(Guid CarBookingId, Car Car, DateTime From, DateTime To, Person rentedTo, DateTime BookedWhen) :Booking(CarBookingId,rentedTo, BookedWhen); 

}