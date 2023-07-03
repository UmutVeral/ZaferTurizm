using System.Diagnostics;
using System.Linq.Expressions;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class VehicleModelService : CrudService<VehicleModelDto, VehicleModelSummary, VehicleModel>, IVehicleModelService
    {
        public VehicleModelService(TourDbContext dbContext, GenericValidator<VehicleModel> validator)
            : base(dbContext, validator)
        { }

        protected override Expression<Func<VehicleModel, VehicleModelDto>> DtoMapper =>
            entity => new VehicleModelDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeId = entity.VehicleMakeId
            };

        protected override Expression<Func<VehicleModel, VehicleModelSummary>> SummaryMapper =>
            entity => new VehicleModelSummary()
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeName = entity.VehicleMake.Name
            };

        protected override VehicleModel MapToEntity(VehicleModelDto model)
        {
            return new VehicleModel()
            {
                Id = model.Id,
                Name = model.Name,
                VehicleMakeId = model.VehicleMakeId
            };
        }

        public IEnumerable<VehicleModelDto> GetByMakeId(int makeId)
        {
            try
            {
                return _dbContext.VehicleModels
                    .Where(entity => entity.VehicleMakeId == makeId)
                    .Select(DtoMapper)
                    .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>();
            }
        }
    }
}
