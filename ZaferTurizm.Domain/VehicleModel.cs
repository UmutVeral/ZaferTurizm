namespace ZaferTurizm.Domain
{
    public class VehicleModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VehicleMakeId { get; set; }

        // Navigation Property
        public VehicleMake VehicleMake { get; set; }
    }
}
