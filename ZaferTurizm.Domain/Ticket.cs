namespace ZaferTurizm.Domain
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int BusTripId { get; set; }
        public int PassengerId { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }

        public BusTrip BusTrip { get; set; }
        public Passenger Passenger { get; set; }
    }
}
