using System.Linq.Expressions;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class VehicleDefinitionService : CrudService<VehicleDefinitionDto, VehicleDefinitionSummary, VehicleDefinition>, IVehicleDefinitionService
    {
        public VehicleDefinitionService(TourDbContext dbContext, GenericValidator<VehicleDefinition> validator)
            : base(dbContext, validator)
        { }

        protected override Expression<Func<VehicleDefinition, VehicleDefinitionDto>> DtoMapper =>
            entity => new VehicleDefinitionDto()
            {
                Id = entity.Id,
                Year = entity.Year,
                SeatCount = entity.SeatCount,
                VehicleModelId = entity.VehicleModelId,
                VehicleMakeId = entity.VehicleModel.VehicleMakeId,
                HasWifi = entity.HasWifi,
                HasToilet = entity.HasToilet
            };

        protected override Expression<Func<VehicleDefinition, VehicleDefinitionSummary>> SummaryMapper =>
            entity => new VehicleDefinitionSummary()
            {
                Id = entity.Id,
                Year = entity.Year,
                SeatCount = entity.SeatCount,
                HasToilet = entity.HasToilet,
                HasWifi = entity.HasWifi,
                VehicleMakeName = entity.VehicleModel.VehicleMake.Name,
                VehicleModelName = entity.VehicleModel.Name
            };

        protected override VehicleDefinition MapToEntity(VehicleDefinitionDto dto)
        {
            return new VehicleDefinition()
            {
                Id = dto.Id,
                Year = dto.Year,
                SeatCount = dto.SeatCount,
                VehicleModelId = dto.VehicleModelId,
                HasWifi = dto.HasWifi,
                HasToilet = dto.HasToilet
            };
        }
    }
}
