using CarDTO;

using CommonDataDTO;

namespace CarDAL
{
    /// <summary>
    /// Singleton pour simuler une base de données contenant les 
    /// données de références et les transactions
    /// </summary>
    internal class FakeData
    {
        private static FakeData? Singleton;

        #region création des données de références
        // Ces données proviennent du fichier Excel OpenTravel
        internal static readonly VehicleSize[] vehicleSizes =
        {
            new VehicleSize(1,"Mini"),
            new VehicleSize(2,"Subcompact"),
            new VehicleSize(3,"Economy"),
            new VehicleSize(4,"Compact"),
            new VehicleSize(5,"Midsize"),
            new VehicleSize(6,"Intermediate"),
            new VehicleSize(7,"Standard"),
            new VehicleSize(8,"Fullsize"),
            new VehicleSize(9,"Luxury"),
            new VehicleSize(10,"Premium"),
            new VehicleSize(11,"Minivan"),
            new VehicleSize(12,"12 passenger van"),
            new VehicleSize(13,"Moving van"),
            new VehicleSize(14,"15 passenger van"),
            new VehicleSize(15,"Cargo van"),
            new VehicleSize(16,"12 foot truck"),
            new VehicleSize(17,"20 foot truck"),
            new VehicleSize(18,"24 foot truck"),
            new VehicleSize(19,"26 foot truck"),
            new VehicleSize(20,"Moped"),
            new VehicleSize(21,"Stretch"),
            new VehicleSize(22,"Regular"),
            new VehicleSize(23,"Unique"),
            new VehicleSize(24,"Exotic"),
            new VehicleSize(25,"Small/medium truck"),
            new VehicleSize(26,"Large truck"),
            new VehicleSize(27,"Small SUV "),
            new VehicleSize(28,"Medium SUV"),
            new VehicleSize(29,"Large SUV"),
            new VehicleSize(30,"Exotic SUV"),
            new VehicleSize(31,"Four wheel drive"),
            new VehicleSize(32,"Special"),
            new VehicleSize(33,"Mini elite"),
            new VehicleSize(34,"Economy elite"),
            new VehicleSize(35,"Compact elite"),
            new VehicleSize(36,"Intermediate elite"),
            new VehicleSize(37,"Standard elite"),
            new VehicleSize(38,"Fullsize elite"),
            new VehicleSize(39,"Premium elite"),
            new VehicleSize(40,"Luxury elite"),
            new VehicleSize(41,"Oversize"),
            new VehicleSize(42,"50 passenger coach")
        };

        // Ces données sont arbitraires
        // On utilise des GUID statiques pour faciliter les tests
        // Générés à partir de https://www.guidgenerator.com/online-guid-generator.aspx
        internal static readonly CarManufacturer[] carManufacturers =
        {
            new CarManufacturer(new Guid("7d72e9b6-7edf-4233-a079-243ecd1a0da1"),"Toyota"),
            new CarManufacturer(new Guid("39bd208e-30b8-4309-a536-aa600ab36353"),"Ford"),
            new CarManufacturer(new Guid("daa25b46-a468-4a17-a775-6d993d07e2c0"),"BMW"),
        };

        internal static readonly CarModel[] carModels =
        {
            new CarModel(new Guid("9cbe9c4c-b50b-445b-bbde-f9a16c91dcd4"),vehicleSizes[6],carManufacturers[0],"Prius",2022),
            new CarModel(new Guid("2753a5b4-0849-47e0-bb16-898077042c19"),vehicleSizes[24],carManufacturers[1],"F-150",2021),
            new CarModel(new Guid("1d96ed7a-5040-47eb-bba4-bde6d696a856"),vehicleSizes[29],carManufacturers[2],"X5 Le Mans Concept",2022)
        };

        internal static readonly CarSpecifications[] carSpecifications = {
            new CarSpecifications(new Guid("4e3090b5-2421-4651-84c5-65e28c67b61d"),true,false,true,true,false),
            new CarSpecifications(new Guid("987f029a-01f9-45be-8ab9-ee0ffe22463c"),false,true,false,false,true),
            new CarSpecifications(new Guid("5e0aa1ac-4e9c-4a3c-b670-9b29dd5f1a42"),true,true,false,true,false)
        };
        internal static readonly CarRentalCompany[] carRentalCompanies = {
            new CarRentalCompany(new Guid("a65ed087-0193-49f8-b384-b9ab28a00fba"),"Budget"),
            new CarRentalCompany(new Guid("4efbd2a5-e367-4061-b919-c41283813e7e"),"Avis")
        };

        internal static readonly Car[] car = {
            new Car(new Guid("4293f4da-f7c8-4998-aa41-f0c05aab2cfb"),carRentalCompanies[0],carModels[0], carSpecifications[0],"BTP-01"),
            new Car(new Guid("54cf1439-a515-413e-a839-ae16717433d9"),carRentalCompanies[0],carModels[1], carSpecifications[1],"BFF-01"),
            new Car(new Guid("bea09eb2-dca6-4ad2-be61-28f341b5d424"),carRentalCompanies[1],carModels[2], carSpecifications[2],"ABX-01")
        };

        #endregion

        #region données dynamiques : Celles vont changer avec les réservations
        internal List<CarAvailability> carAvailabilities;
        internal List<CarBooking> carBookings;
        internal List<BookingConfirmation> bookingConfirmations;
        internal List<BookingCancellation> bookingCancellations;
        #endregion

        private FakeData()
        {
            carAvailabilities = new List<CarAvailability>();
            carAvailabilities.Add(new CarAvailability(new Guid("56f93c48-0922-42d7-bddd-a3edd154685d"),car[0],new DateTime(2022,2,12), new DateTime(2022, 7, 1)));
            carAvailabilities.Add(new CarAvailability(new Guid("aceff190-c2cb-47a7-b773-a150173eb89f"), car[1], new DateTime(2022, 2, 12), new DateTime(2022, 7, 1)));
            carAvailabilities.Add(new CarAvailability(new Guid("10e9721a-2a9a-4d45-a86d-54dea2dce15b"), car[2], new DateTime(2022, 2, 12), new DateTime(2022, 7, 1)));
            
            carBookings = new List<CarBooking>();
            bookingConfirmations = new List<BookingConfirmation>();
            bookingCancellations = new List<BookingCancellation>();
        }


        internal static FakeData GetInstance()
        {
            if (Singleton == null) Singleton = new FakeData();
            return Singleton;
        }

    }
}