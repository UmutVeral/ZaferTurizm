using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class CityData
    {
        public static readonly City Data01_Adana = new City() { Id = 1, Name = "Adana" };
        public static readonly City Data02_Ankara = new City() { Id = 6, Name = "Ankara" };
        public static readonly City Data03_Antalya = new City() { Id = 7, Name = "Antalya" };
        public static readonly City Data04_Bursa = new City() { Id = 16, Name = "Bursa" };
        public static readonly City Data05_Istanbul = new City() { Id = 34, Name = "İstanbul" };
        public static readonly City Data06_Izmir = new City() { Id = 35, Name = "İzmir" };
    }
}
