namespace ZaferTurizm.Domain
{
    public class BusTrip : IEntity
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public Route Route { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
