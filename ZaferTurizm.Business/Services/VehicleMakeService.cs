using System.Linq.Expressions;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class VehicleMakeService : CrudService<VehicleMakeDto, VehicleMakeSummary, VehicleMake>, IVehicleMakeService
    {
        public VehicleMakeService(TourDbContext dbContext, GenericValidator<VehicleMake> validator)
            : base(dbContext, validator)
        { }

        protected override Expression<Func<VehicleMake, VehicleMakeDto>> DtoMapper =>
            entity => new VehicleMakeDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        protected override Expression<Func<VehicleMake, VehicleMakeSummary>> SummaryMapper =>
            entity => new VehicleMakeSummary()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        protected override VehicleMake MapToEntity(VehicleMakeDto dto)
        {
            return new VehicleMake()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
