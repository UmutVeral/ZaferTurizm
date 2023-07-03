using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }

        public string Description 
            => string.Concat(PlateNumber, " - ", VehicleMakeName, " ", VehicleModelName);
    }
}
