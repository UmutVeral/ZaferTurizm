namespace ZaferTurizm.Domain
{
    public class VehicleDefinition : IEntity
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public bool HasToilet { get; set; }
        public bool HasWifi { get; set; }

        public VehicleModel VehicleModel { get; set; }
    }
}
