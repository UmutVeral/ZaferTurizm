using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class VehicleService : CrudService<VehicleDto, VehicleSummary, Vehicle>, IVehicleService
    {
        public VehicleService(TourDbContext dbContext, GenericValidator<Vehicle> validator)
            : base(dbContext, validator)
        { }

        protected override Expression<Func<Vehicle, VehicleDto>> DtoMapper =>
            entity => new VehicleDto()
            {
                Id = entity.Id,
                VehicleDefinitionId = entity.VehicleDefinitionId,
                PlateNumber = entity.PlateNumber
            };

        protected override Expression<Func<Vehicle, VehicleSummary>> SummaryMapper =>
            entity => new VehicleSummary()
            {
                Id = entity.Id,
                PlateNumber = entity.PlateNumber,
                VehicleMakeName = entity.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehicleModelName = entity.VehicleDefinition.VehicleModel.Name
                //Description = $"{entity.PlateNumber} - {entity.VehicleDefinition.VehicleModel.VehicleMake.Name} {entity.VehicleDefinition.VehicleModel.Name}"
            };

        protected override Vehicle MapToEntity(VehicleDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
