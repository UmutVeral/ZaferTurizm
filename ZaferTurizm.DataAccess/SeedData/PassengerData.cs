using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class PassengerData
    {
        public static readonly Passenger Data01_TsubasaOzora = new Passenger()
        {
            Id = 1,
            FirstName = "Tsubasa",
            LastName = "Ozora",
            IdentityNumber = "12345667874",
            Gender = Gender.Male
        };

        public static readonly Passenger Data02_SanaeOzora = new Passenger()
        {
            Id = 2,
            FirstName = "Sanae",
            LastName = "Ozora",
            IdentityNumber = "8764873564",
            Gender = Gender.Female
        };

        public static readonly Passenger Data03_TaroMisaki = new Passenger()
        {
            Id = 3,
            FirstName = "Taro",
            LastName = "Misaki",
            IdentityNumber = "3486384743",
            Gender = Gender.Male
        };
    }
}
