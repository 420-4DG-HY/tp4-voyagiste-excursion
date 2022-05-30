using CommonDataDTO;
using ExcursionDTO;
namespace ExcursionDAL
{
    public class FakeData
    {
        // TODO Vous devez ajouter quelques excursions, lieux et disponibilités 
        // Utilisez des GUID statiques (fake) pour les distinguer 
        // https://www.guidgenerator.com/online-guid-generator.aspx

        // TODO Simuler de la disponibilité. Attention, les disponibilités (Availability)
        // ne doivent pas être statiques puisqu'on doit voir 
        // la disponibilité changer après une réservation






        // TODO Vous devez ajouter quelques excursions, lieux et disponibilités 
        // Utilisez des GUID statiques (fake) pour les distinguer 
        // https://www.guidgenerator.com/online-guid-generator.aspx



        private static FakeData? Singleton;
        #region création des données de références
        internal static readonly ActivityType[] activityTypes =
        {
            new ActivityType(new Guid("d6a63fef-e780-4939-abbd-f8f23a23e8d1"), "Randonnée","Marche"),
            new ActivityType(new Guid("b5ee1d1e-2cb1-4543-9641-336d813fe517"), "Vélo","Vélo-ing"),
            new ActivityType(new Guid("23d7b010-4182-4309-84c6-793b7c9ab420"), "Kayak","Kayaking")
        };

        internal static readonly MeetingPoint[] meetingPoints =
        {
            new MeetingPoint(new Guid("05f2d7ef-530e-447d-bdf3-1088240bb6bf"),"Mi-Chemin",new Address(new Guid("40b40c62-099a-49d3-82b5-2036119a79d9"),new Country("Canada"),new Region("Froide"),new City(""), new PostalCode("H0H0H0"),"Autoroute"), "Mi-Chemin froid"),
            new MeetingPoint(new Guid("ab83f907-6888-4735-8920-c065b912c272"),"À l'hotel",new Address(new Guid("b0e1392a-b033-46b9-97e4-f48873291d0c"),new Country("USA"),new Region("Dangeureuse"),new City(""), new PostalCode("H0H0H0"),"Rue"), "À l'hotel dangeureux"),
            new MeetingPoint(new Guid("8658666d-7062-47aa-9c4d-6e6ce3f5cb40"),"Icitte",new Address(new Guid("6d49e5a4-a21a-4dfe-93ca-db3f7e8d239d"),new Country("Mexique"),new Region("Chaude"),new City(""), new PostalCode("H0H0H0"),"Boulevard"), "Icitte chaud")
        };

        internal static readonly Excursion[] excursion =
        {
            new Excursion(new Guid("f463c13a-7512-48b4-ac65-0a486fcdc53f"), meetingPoints[0], activityTypes[0]),
            new Excursion(new Guid("2e1124bf-f3a6-4736-a468-ecb8557c93e2"), meetingPoints[1], activityTypes[1]),
            new Excursion(new Guid("7a4dffb5-7b88-42ec-8db8-749946894c60"), meetingPoints[2], activityTypes[2])
        };

        #endregion

        #region données dynamiques : Celles vont changer avec les réservations
        internal List<ExcursionAvailability> excursionAvailabilities;
        internal List<ExcursionBooking> excursionBookings;
        internal List<BookingConfirmation> bookingConfirmations;
        internal List<BookingCancellation> bookingCancellations;
        #endregion


        private FakeData()
        {
            excursionAvailabilities = new List<ExcursionAvailability>();
            excursionAvailabilities.Add(new ExcursionAvailability(new Guid("56f93c48-0922-42d7-bddd-a3edd154685d"), excursion[0], excursion[0].ExcursionId, new DateTime(2022, 7, 12), new Guid("f332f5d3-1e74-4b4f-a9b0-902e23cdf011"))); 
            excursionAvailabilities.Add(new ExcursionAvailability(new Guid("aceff190-c2cb-47a7-b773-a150173eb89f"), excursion[1], excursion[1].ExcursionId, new DateTime(2022, 8, 12), new Guid("e8bd69c3-8b8b-4310-9ced-afe0fd709ea8")));        
            excursionAvailabilities.Add(new ExcursionAvailability(new Guid("10e9721a-2a9a-4d45-a86d-54dea2dce15b"), excursion[2], excursion[2].ExcursionId, new DateTime(2022, 9, 12), new Guid("95f3ac47-90c2-4d96-ab10-9256ef5dbacf")));

            excursionBookings = new List<ExcursionBooking>();
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