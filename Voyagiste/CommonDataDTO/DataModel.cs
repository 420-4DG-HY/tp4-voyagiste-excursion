namespace CommonDataDTO
{
    public record Country(string countryName); // Devrait éventuellement avoir un code ISO correspondant et supporter multilinguisme...
    public record City(string cityName);
    public record Region(string regionName);
    public record PostalCode(string postalCode);
    public record CountryCode(string countryCode);
    public record Address(Guid AddressId, Country country, Region region, City city, PostalCode postalCode, string streetAddress);

    public record Passport(Guid PassportId, Country country, string passportNumber, DateTime expiration);

    public record Title(string title); // M., Mme, Dr, ... Devrait être multilingue, mais on garde ça simple :-)
    public record BirthDate(DateTime birthDate); // Éventuellement changer le setter pour arrondir et fournir les méthodes pour l'âge
    public record Person(Guid PersonId, Title? title, string firstName, string? middleName, string lastName, BirthDate? birthDate, Passport? passport);


    // La notion d'agent est absente pour simplifier le modèle
    public abstract record Booking(Guid BookingId, Person traveler, DateTime BookedWhen); // On doit typer la réservation (booking) pour l'utiliser
    public record BookingConfirmation(Guid BookingConfirmationId, Booking Booking, DateTime ConfirmedWhen);
    public record BookingCancellation(Guid BookingCancellationId, Booking Booking, DateTime CancelledWhen);

}