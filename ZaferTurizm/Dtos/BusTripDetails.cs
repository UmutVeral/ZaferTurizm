using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class BusTripDetails
    {
        public int BusTripId { get; set; }
        public int SeatCount { get; set; }
        public DateTime Date { get; set; }
        public decimal TicketPrice { get; set; }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string PlateNumber { get; set; }

        public string BusTripName => $"{Date.ToString("dd.MM.yyyy HH:mm")} / {DepartureName} -> {ArrivalName}";
        public string VehicleInfo => $"{VehicleMakeName} {VehicleModelName} / {PlateNumber}";

        public IEnumerable<int> SoldSeatNumbers { get; set; }
    }
}
