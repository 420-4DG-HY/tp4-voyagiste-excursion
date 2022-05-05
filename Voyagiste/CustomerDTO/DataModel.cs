using CommonDataDTO;
using CarDTO;
using CruiseDTO;
using CustomerDTO;
using ExcursionDTO;
using FlightDTO;
using HotelDTO;
using TrainDTO;
using PackageDTO;

namespace CustomerDTO
{
    public record Currency(string name, string code);
    public record Price(Currency currency, float price);
    public record Customer(Guid CustomerId, Person Person, Order[] orders);
    public record Product(Guid ProductId, Booking Booking, Price Price);
    public record Order(Guid orderId, Product[] Products, Person Client); // Manque notions d'état et suivi des paiements
}