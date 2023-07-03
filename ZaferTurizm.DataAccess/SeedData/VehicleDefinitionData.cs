using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class VehicleDefinitionData
    {
        /// <summary>
        /// Mercedes Travego 2020
        /// </summary>
        public readonly static VehicleDefinition Data01_MercedesTravego2020 = new VehicleDefinition()
        {
            Id = 1,
            VehicleModelId = VehicleModelData.Data01_MercedesTravego.Id,
            Year = 2020,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true
        };

        /// <summary>
        /// Mercedes Travego 2021
        /// </summary>
        public static readonly VehicleDefinition Data02_MercedesTravego2021 = new VehicleDefinition()
        {
            Id = 2,
            VehicleModelId = VehicleModelData.Data01_MercedesTravego.Id,
            Year = 2021,
            SeatCount = 48,
            HasToilet = false,
            HasWifi = true
        };

        public static readonly VehicleDefinition Data03_ManFortuna2019 = new VehicleDefinition()
        {
            Id = 3,
            VehicleModelId = VehicleModelData.Data05_ManFortuna.Id,
            Year = 2019,
            SeatCount = 52,
            HasToilet = false,
            HasWifi = false
        };
    }
}
