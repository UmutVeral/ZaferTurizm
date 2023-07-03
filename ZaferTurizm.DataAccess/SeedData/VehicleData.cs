using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class VehicleData
    {
        public static readonly Vehicle Data01_34ABC123 = new Vehicle()
        {
            Id = 1,
            PlateNumber = "34 ABC 123",
            VehicleDefinitionId = VehicleDefinitionData.Data01_MercedesTravego2020.Id
        };

        public static readonly Vehicle Data02_34CDE654 = new Vehicle()
        {
            Id = 2,
            PlateNumber = "34 CDE 654",
            VehicleDefinitionId = VehicleDefinitionData.Data01_MercedesTravego2020.Id
        };

        public static readonly Vehicle Data03_34QWE345 = new Vehicle()
        {
            Id = 3,
            PlateNumber = "34 QWE 345",
            VehicleDefinitionId = VehicleDefinitionData.Data02_MercedesTravego2021.Id
        };

        public static readonly Vehicle Data04_34ZXC987 = new Vehicle()
        {
            Id = 4,
            PlateNumber = "34 ZXC 987",
            VehicleDefinitionId = VehicleDefinitionData.Data03_ManFortuna2019.Id
        };
    }
}
