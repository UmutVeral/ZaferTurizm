using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class VehicleModelData
    {
        /// <summary>
        /// Mercedes Travego
        /// </summary>
        public static readonly VehicleModel Data01_MercedesTravego = new VehicleModel() { Id = 1, VehicleMakeId = 1, Name = "Travego" };

        /// <summary>
        /// Mercedes 403
        /// </summary>
        public static readonly VehicleModel Data02_Mercedes403 = new VehicleModel() { Id = 2, VehicleMakeId = 1, Name = "403" };

        /// <summary>
        /// Mercedes Tourismo
        /// </summary>
        public static readonly VehicleModel Data03_MercedesTourismo = new VehicleModel() { Id = 3, VehicleMakeId = 1, Name = "Tourismo" };

        /// <summary>
        /// MAN Lions
        /// </summary>
        public static readonly VehicleModel Data04_ManLions = new VehicleModel() { Id = 4, VehicleMakeId = 2, Name = "Lions" };

        /// <summary>
        /// MAN Fortuna
        /// </summary>
        public static readonly VehicleModel Data05_ManFortuna = new VehicleModel() { Id = 5, VehicleMakeId = 2, Name = "Fortuna" };

        /// <summary>
        /// MAN SL
        /// </summary>
        public static readonly VehicleModel Data06_ManSl = new VehicleModel() { Id = 6, VehicleMakeId = 2, Name = "SL" };
    }
};