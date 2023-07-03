using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class __VehicleDefinitionService : __IVehicleDefinitionService
    {
        private readonly TourDbContext _dbContext;

        public __VehicleDefinitionService(TourDbContext tourDbContext)
        {
            _dbContext = tourDbContext;
        }

        public CommandResult Create(VehicleDefinitionDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(VehicleDefinitionDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleDefinitionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleDefinitionDto? GetById(int id)
        {
            try
            {
                return _dbContext.VehicleDefinitions
                    .Select(entity => new VehicleDefinitionDto()
                    {
                        Id = entity.Id,
                        VehicleMakeId = entity.VehicleModel.VehicleMakeId,
                        VehicleModelId = entity.VehicleModelId,
                        Year = entity.Year,
                        SeatCount = entity.SeatCount,
                        HasToilet = entity.HasToilet,
                        HasWifi = entity.HasWifi
                    }).SingleOrDefault(entity => entity.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<VehicleDefinitionSummary> GetSummaries()
        {
            try
            {
                return _dbContext.VehicleDefinitions
                    .Select(entity => new VehicleDefinitionSummary()
                    {
                        Id = entity.Id,
                        VehicleMakeName = entity.VehicleModel.VehicleMake.Name,
                        VehicleModelName = entity.VehicleModel.Name,
                        Year = entity.Year,
                        SeatCount = entity.SeatCount,
                        HasToilet = entity.HasToilet,
                        HasWifi = entity.HasWifi
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitionSummary>();
            }
        }

        public CommandResult Update(VehicleDefinitionDto model)
        {
            throw new NotImplementedException();
        }
    }
}
