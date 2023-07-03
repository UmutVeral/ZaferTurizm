using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class RouteData
    {
        public static readonly Route Data01_IzmirIstanbul = new Route()
        {
            Id = 1,
            DepartureCityId = CityData.Data06_Izmir.Id,
            ArrivalCityId = CityData.Data05_Istanbul.Id
        };

        public static readonly Route Data02_IstanbulAnkara = new Route()
        {
            Id = 2,
            DepartureCityId = CityData.Data05_Istanbul.Id,
            ArrivalCityId = CityData.Data02_Ankara.Id
        };

        public static readonly Route Data03_IstanbulAntalya = new Route()
        {
            Id = 3,
            DepartureCityId = CityData.Data05_Istanbul.Id,
            ArrivalCityId = CityData.Data03_Antalya.Id
        };

        public static readonly Route Data04_AnkaraIzmir = new Route()
        {
            Id = 4,
            DepartureCityId = CityData.Data02_Ankara.Id,
            ArrivalCityId = CityData.Data06_Izmir.Id
        };
    }
}
