using System.Linq.Expressions;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class RouteService : CrudService<RouteDto, RouteSummary, Route>, IRouteService
    {
        public RouteService(TourDbContext context, GenericValidator<Route> validator)
            : base(context, validator)
        { }

        protected override Expression<Func<Route, RouteDto>> DtoMapper =>
            entity => new RouteDto
            {
                Id = entity.Id,
                ArrivalId = entity.ArrivalCityId,
                DepartuteId = entity.DepartureCityId
            };

        protected override Expression<Func<Route, RouteSummary>> SummaryMapper =>
            entity => new RouteSummary()
            {
                Id = entity.Id,
                ArrivalName = entity.ArrivalCity.Name,
                DepartureName = entity.DepartureCity.Name
            };

        protected override Route MapToEntity(RouteDto entity)
        {
            return new Route()
            {
                Id = entity.Id,
                ArrivalCityId = entity.ArrivalId,
                DepartureCityId = entity.DepartuteId
            };
        }
    }
}
