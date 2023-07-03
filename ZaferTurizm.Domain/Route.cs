﻿namespace ZaferTurizm.Domain
{
    public class Route : IEntity
    {
        public int Id { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }

        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }
    }
}
