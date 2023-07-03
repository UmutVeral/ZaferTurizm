namespace ZaferTurizm.Dtos
{
    public class VehicleDefinitionSummary
    {
        public int Id { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public bool HasToilet { get; set; }
        public string HasToiletString
        {
            get
            {
                return HasToilet ? "Var" : "Yok";
            }
        }
        public bool HasWifi { get; set; }

        // Arrow Function ile readonly property yazma
        public string HasWifiString => HasWifi ? "Var" : "Yok";
    }
}
