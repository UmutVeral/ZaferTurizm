namespace ZaferTurizm.Domain
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public int VehicleDefinitionId { get; set; }
        public string PlateNumber { get; set; }

        public VehicleDefinition VehicleDefinition { get; set; }
    }
}
