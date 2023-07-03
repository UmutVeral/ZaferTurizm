using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class __VehicleModelService : __IVehicleModelService
    {
        private readonly TourDbContext _dbContext;

        public __VehicleModelService(TourDbContext tourDbContext)
        {
            _dbContext = tourDbContext;
        }

        public CommandResult Create(VehicleModelDto model)
        {


            throw new NotImplementedException();
        }

        public CommandResult Delete(VehicleModelDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleModelDto> GetAll()
        {
            try
            {
                return _dbContext.VehicleModels
                    .Select(model => new VehicleModelDto()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        VehicleMakeId = model.VehicleMakeId
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>();
                //return new VehicleModelDto[0];
                //return new List<VehicleModelDto>();
            }
        }

        public IEnumerable<VehicleModelSummary> GetSummaries()
        {
            try
            {
                return _dbContext.VehicleModels
                    .Select(model => new VehicleModelSummary()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        VehicleMakeName = model.VehicleMake.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelSummary>();
            }
        }

        public VehicleModelDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CommandResult Update(VehicleModelDto model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId)
        {
            try
            {
                return _dbContext.VehicleModels
                    .Where(entity => entity.VehicleMakeId == vehicleMakeId)
                    .Select(entity => new VehicleModelDto()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        VehicleMakeId = entity.VehicleMakeId
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleModelDto>();
                // Enumerable.Empty<VehicleModelDto>() yazmayı unutursan yukarıdaki yöntem de makbul
            }
        }
    }
}
