using System.Diagnostics;
using System.Linq.Expressions;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class BusTripService : CrudService<BusTripDto, BusTripInfo, BusTrip>, IBusTripService
    {
        public BusTripService(TourDbContext context, BusTripValidator validator) : base(context, validator)
        { }

        protected override Expression<Func<BusTrip, BusTripDto>> DtoMapper =>
            entity => new BusTripDto()
            {
                Id = entity.Id,
                RouteId = entity.RouteId,
                VehicleId = entity.VehicleId,
                Date = entity.Date,
                Price = entity.Price,
            };

        protected override Expression<Func<BusTrip, BusTripInfo>> SummaryMapper =>
            entity => new BusTripInfo()
            {
                Id = entity.Id,
                Date = entity.Date,
                Price = entity.Price,
                DepartureName = entity.Route.DepartureCity.Name,
                ArrivalName = entity.Route.ArrivalCity.Name,
                VehicleMakeName = entity.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehicleModelName = entity.Vehicle.VehicleDefinition.VehicleModel.Name,
                PlateNumber = entity.Vehicle.PlateNumber,
                SeatCount = entity.Vehicle.VehicleDefinition.SeatCount


                //SoldSeatNumbers=_dbContext.Tickets.
                //Where(x=>x.BusTripId==entity.Id).
                //Select(ss=>ss.SeatNumber).ToList()

            };

        public BusTripDetails? GetBusTripDetails(int id)
        {
            try
            {
                return _dbContext.BusTrips
                    .Where(x => x.Id == id)
                    .Select(x => new BusTripDetails()
                    {
                        BusTripId = x.Id,
                        ArrivalName = x.Route.ArrivalCity.Name,
                        DepartureName = x.Route.DepartureCity.Name,
                        PlateNumber = x.Vehicle.PlateNumber,
                        VehicleMakeName = x.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                        VehicleModelName = x.Vehicle.VehicleDefinition.VehicleModel.Name,
                        TicketPrice = x.Price,
                        SeatCount = x.Vehicle.VehicleDefinition.SeatCount,
                        Date = x.Date,
                        SoldSeatNumbers=_dbContext.Tickets.Where(t=>t.BusTripId ==id).Select(t=>t.SeatNumber).ToList()
                        

                        //SoldSeatNumbers = GetSoldSeatNumbers(x.Id).ToList()

                    }).SingleOrDefault();


            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public IEnumerable<int> GetSoldSeatNumbers(int busTripId)
        {
            var soldSeats = _dbContext.Tickets
            .Where(t => t.BusTripId == busTripId)
            .Select(t => t.SeatNumber)
            .ToList();

            return soldSeats;
        }

        public IEnumerable<BusTripInfo> GetTripsWithRouteId(int id)
        {
            try
            {
                return _dbContext.BusTrips
                    .Where(x => x.RouteId == id)
                    .Select(SummaryMapper).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripInfo>();

            }
        }

        protected override BusTrip MapToEntity(BusTripDto entity)
        {
            return new BusTrip()
            {
                Id = entity.Id,
                Date = entity.Date,
                Price = entity.Price,
                RouteId = entity.RouteId,
                VehicleId = entity.VehicleId,
            };
        }
    }
}
